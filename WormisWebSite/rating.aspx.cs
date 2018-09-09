using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wormis;

public partial class Rating : System.Web.UI.Page
{
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



    protected void Page_Load(object sender, EventArgs e)
    {
        var uDict = new Dictionary<string, List<ResultByOne>>();

        var trs = utils.ReadFromBinaryFile<Tournaments>(HttpContext.Current.Server.MapPath("~/wormisbase.bin"));

        DateLabel.Text = trs.time.ToString("dd/MM/yy H:mm:ss zzz");
        UserLabel.Text = trs.user;
        CountLabel.Text = trs.Count.ToString();

        
        foreach (var tr in trs)
        {
            foreach (var r in tr)
            {
                if (uDict.ContainsKey(r.name))
                { uDict[r.name].Add(r); }
                else
                {
                    var l = new List<ResultByOne>();
                    l.Add(r);
                    uDict.Add(r.name, l);
                }
            }
        }

        foreach (var l in uDict.Values)
        {
            if (l.Count < 4) continue;
            int money = 0;
            int coupon = 0;
            int allmaxmass = 0;
            int allfinalmass = 0;
            int allpts = 0;
            foreach (var item in l)
            {
                money += item.GetMoney();
                if (item.GetCoupon()) { coupon += 1; };
                allmaxmass += item.maxMass;
                allfinalmass += item.finalMass;
                allpts += item.GetPTS();
            };

            RatingTable.Rows.Add( 
                makeRow(
                    l[0].name,
                    l.Count.ToString(),
                    money.ToString(),
                    coupon.ToString(),
                    (allpts / l.Count).ToString(),
                    (allfinalmass / l.Count).ToString(),
                    (allmaxmass / l.Count).ToString()
                )
                );
        }
    }
}