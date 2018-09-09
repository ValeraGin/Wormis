using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wormis;

public partial class autoupload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files.Count == 1)
        {
            System.IO.File.Delete(Server.MapPath("~/wormisbase.new.bin"));
            Request.Files[0].SaveAs(Server.MapPath("~/wormisbase.new.bin"));

            bool isBase = false;
            try
            {
                var f = utils.ReadFromBinaryFile<Tournaments>(Server.MapPath("~/wormisbase.new.bin"));
                if (f != null) { isBase = true; };
            }
            catch { }

            if (isBase)
            {
                System.IO.File.Delete(Server.MapPath("~/wormisbase.bin"));
                System.IO.File.Move(Server.MapPath("~/wormisbase.new.bin"), Server.MapPath("~/wormisbase.bin"));
                Response.Write("Вы успешно загрузили базу данных на сервер. Спасибо.");
            }
            else
            {
                System.IO.File.Delete(Server.MapPath("~/wormisbase.new.bin"));
                Response.Write("Это не база данных турниров.");
            }

        }
    }

}