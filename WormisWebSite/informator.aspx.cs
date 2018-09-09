using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wormis;


public partial class Informator : System.Web.UI.Page
{
    Tournaments trs = utils.ReadFromBinaryFile<Tournaments>(HttpContext.Current.Server.MapPath("~/wormisbase.bin"));

    protected void Page_Load(object sender, EventArgs e)
    {
        DateLabel.Text = trs.time.ToString("dd/MM/yy H:mm:ss zzz");
        UserLabel.Text = trs.user;
        CountLabel.Text = trs.Count.ToString();
    }

    TableRow makeRow(params string[] list)
    {
        var trow = new TableRow();
        for (int i = 0; i < list.Length; i++)
        {
            var tc = new TableCell();
            tc.Text = list[i];
            trow.Cells.Add(tc);
        }
        return trow;
    }


    void NameLoad(string Name)
    {
        int money = 0;
        int coupon = 0;
        int allmaxmass = 0;
        int allfinalmass = 0;
        int allpts = 0;
        int count = 0;

        foreach (var tr in trs)
        {
            var g = tr.Find(
                delegate (ResultByOne r)
                {
                    return r.name == Name;
                }
            );

            if (g != null)
            {

                string prize = "-";
                if (g.GetMoney() != 0) { money += g.GetMoney(); prize = g.GetMoney().ToString() + " coins"; };
                if (g.GetCoupon()) { coupon += 1; prize = "Купон на игру"; };
                allmaxmass += g.maxMass;
                allfinalmass += g.finalMass;
                allpts += g.GetPTS();
                count += 1;


                Table1.Visible = true;
                Table1.Rows.Add(
                    makeRow(g.position.ToString(),
                    g.finalMass.ToString(),
                    g.maxMass.ToString(),
                    g.GetPTS().ToString(),
                    prize,
                    "<a href=" + "http://mitos.is/assistance.php?tournament=" + tr.number.ToString() + ">" + "http://mitos.is/assistance.php?tournament=" + tr.number.ToString() + "</a>")
                );

                Table2.Visible = true;
                
            };
        };

        if (count > 0)
        {
            Table1.Visible = true;
            Table2.Visible = true;
            Nickname.Text = Name;
            Table2.Rows.Add(makeRow(money.ToString(), coupon.ToString(), (allpts / count).ToString(), (allfinalmass / count).ToString(), (allmaxmass / count).ToString()));
        } else
        {
            Nickname.Text = "<p class='bg-danger'>" + Name + " не играл в турнир, либо ошибка в написании</p>";
            Table1.Visible = false;
            Table2.Visible = false;
        }
    }

    protected void TextBtn_Click(object sender, EventArgs e)
    {
        NameLoad(TextBox1.Text);
    }

    protected void ListBtn_Click(object sender, EventArgs e)
    {
        NameLoad(DropDownList1.Text);
    }
}