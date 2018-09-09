using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using Wormis;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        void DoWork()
        {
            Invoke(new Action(() => { listBox1.Items.Add("Выполняющиеся потоки:"); }));

            var fname = "wormisbase.bin";
            Tournaments trs;

            int min;
            if (File.Exists(fname))
              { trs = utils.ReadFromBinaryFile<Tournaments>(fname); }
            else
            {
                trs = new Tournaments();
                trs.user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                trs.minIndex = 0;
            };

            WebClient client = new WebClient();
            while (true)
            {
                min = trs.maxIndex;
                trs.maxIndex += 50;
                int SuccessCount = 0;
                Parallel.For(min, trs.maxIndex, (a) =>
                // for (int a = min; a < trs.maxIndex; a++)
                {
                    //Invoke(new Action(() => { progressBar1.Maximum = trs.maxIndex - min; }));
                    Invoke(new Action(() => { listBox1.Items.Add("загрузка http://mitos.is/assistance.php?tournament=" + a.ToString()); label1.Text = "Потоков чтения с сайта: " + (listBox1.Items.Count - 1).ToString(); }));
                    string htmlCode;
                    lock (client)
                    {
                        htmlCode = client.DownloadString("http://mitos.is/assistance.php?tournament=" + a.ToString());
                    };

                    Invoke(new Action(() => {
                        var i = listBox1.Items.IndexOf("загрузка http://mitos.is/assistance.php?tournament=" + a.ToString());
                        listBox1.Items.RemoveAt(i);
                        listBox1.Items.Insert(i, "обработка http://mitos.is/assistance.php?tournament=" + a.ToString());
                    }));

                    var tr = new Tournament(a);
                    HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
                    hap.LoadHtml(htmlCode);
                    HtmlNodeCollection nodes = hap.DocumentNode.SelectNodes("//*[contains(@class, 'trow')]");
                    if (nodes != null)
                    {
                        for (int i = 1; i < nodes.Count; i++)
                        {
                            var name = nodes[i].ChildNodes[1].ChildNodes[0].InnerHtml;
                            var finalmass = Convert.ToInt32(nodes[i].ChildNodes[2].ChildNodes[0].InnerHtml);
                            var maxmass = Convert.ToInt32(nodes[i].ChildNodes[3].ChildNodes[0].InnerHtml);
                            tr.Add(new ResultByOne(i, name, finalmass, maxmass));
                        }
                        trs.Add(tr);
                        SuccessCount += 1;
                    }
                    Invoke(new Action(() => { listBox1.Items.Remove("обработка http://mitos.is/assistance.php?tournament=" + a.ToString()); }));
                });
                if (SuccessCount == 0)
                {
                    trs.Sort(delegate (Tournament x, Tournament y)
                    {
                        return x.number.CompareTo(y.number);
                    });
                    trs.maxIndex = trs[trs.Count - 1].number;
                    break;
                }
            }
            trs.time = DateTime.Now;
            utils.WriteToBinaryFile(fname, trs);
            Invoke(new Action(() => { listBox1.Items.Clear(); listBox1.Items.Add("Файл сохранен как " + fname); }));

            Invoke(new Action(() => { listBox1.Items.Clear(); listBox1.Items.Add("Отправка файла на сайт " + fname); }));

            WebClient myWebClient = new WebClient();
            byte[] responseArray = myWebClient.UploadFile("http://russiawormis.azurewebsites.net/autoupload.aspx", fname);
            Invoke(new Action(() => { listBox1.Items.Clear(); listBox1.Items.Add("Ответ от сервера(russiawormis.azurewebsites.net): "); listBox1.Items.Add(System.Text.Encoding.UTF8.GetString(responseArray)); }));

            //System.Diagnostics.Process.Start("http://russiawormis.azurewebsites.net/upload.aspx");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() => { DoWork(); }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
