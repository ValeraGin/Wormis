<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeFile="rating.aspx.cs" Inherits="Rating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cайт гильдии "Russia Wormis" - Рейтинг Tournaments</title>

    <link href="js/blue/style.css" rel="stylesheet">

    <script src="js/jquery.tablesorter.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#main_RatingTable").tablesorter();
            $("#main_RatingTable").bind("sortStart", function () {
                $("#preloader").show();
            }).bind("sortEnd", function () {
                $("#preloader").hide();
            });
        }
        );
    </script>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">



    <div class="col-md-8">
        <h1 class="page-header">Рейтинг Tournaments</h1>
        <p>
            <span class="glyphicon glyphicon-time" style="margin-right: 5px"></span>Загружены результаты по
            <asp:Label ID="DateLabel" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <span class="glyphicon glyphicon-asterisk" style="margin-right: 5px"></span>
            <asp:Label ID="CountLabel" runat="server" Text="Label"></asp:Label>
            результатов турнира было обработано
        </p>
        <p><span class="glyphicon glyphicon-asterisk" style="margin-right: 5px"></span>В рейтинге отображаються только игроки, которые отыграли 4 турнира и больше</p>
        <p style="visibility: hidden">
            <span class="glyphicon glyphicon-asterisk" style="margin-right: 5px"></span>
            <asp:Label ID="UserLabel" runat="server" Text="Label"></asp:Label>
            с этого компьютера была загружена база данных
        </p>
    </div>


    <div class="col-md-4">
        <div class="well">
            <h4>Для нетерпеливых</h4>
            <p>Если не хотите ждать, когда автор обработает новые результаты с сайта, то можете ему в этом помочь - скачав Updater базы данных сайта, он работает в автоматическом режиме (5-15 мин).</p>
            <p><span class="glyphicon glyphicon-save"></span><a href="/download/Updater.zip">Updater.zip (56kb)</a></p>
        </div>
    </div>


    <!-- Blog Entries Column -->
    <div class="col-md-12">

   

        <hr>
        <asp:Table ID="RatingTable" runat="server" CssClass="tablesorter">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableHeaderCell runat="server">Имя</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Количество игр</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Монет</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Купонов</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средний PTS</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средняя  финальная масса</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средняя  максимальная масса</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    </span>

</asp:Content>
