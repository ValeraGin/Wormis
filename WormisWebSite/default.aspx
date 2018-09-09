<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cайт гильдии "Russia Wormis"</title>
    <!-- Put this script tag to the <head> of your page -->
    <script type="text/javascript" src="//vk.com/js/api/openapi.js?129"></script>
    <script type="text/javascript">
        VK.init({ apiId: 5634224, onlyWidgets: true });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="col-md-12">

        <div class="jumbotron">
            <h1>Привет мир</h1>
            <p class="lead">
                На этом сайте вы можете быстро проверить себя в рейтинге Worm.is
            <br />
            <center>
            <img alt="" src="img/cat1.png" style="margin: 20px" />
            <img alt="" src="img/cat2.png" style="margin: 20px" />
            <img alt="" src="img/cat3.png" style="margin: 20px" />
            </center>
            </p>
            <p><a class="btn btn-lg btn-success" href="informator.aspx" role="button">Найти себя</a></p>
            <center>
            <img alt="" src="img/cat4.png" style="margin: 20px" />
            <img alt="" src="img/cat5.png" style="margin: 20px" />
            <img alt="" src="img/cat6.png" style="margin: 20px" />
            </center>
        </div>


        <!-- Put this div tag to the place, where the Comments block will be -->
        <div class="center-block" id="vk_comments"></div>
        <script type="text/javascript">
            VK.Widgets.Comments("vk_comments", { limit: 20, attach: "*" });
        </script>
    </div>
</asp:Content>
