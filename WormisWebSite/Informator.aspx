<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeFile="informator.aspx.cs" Inherits="Informator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Сайт гильдии "Russia Wormis" - Информатор</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <!-- Blog Entries Column -->
    <div class="col-md-8">

        <h1 class="page-header">Информатор Tournaments</h1>

        <!-- First Blog Post -->
        <p><span class="glyphicon glyphicon-time" style="margin-right: 5px"></span>Загружены результаты по <asp:Label ID="DateLabel" runat="server" Text="Label"></asp:Label></p>
        <p><span class="glyphicon glyphicon-asterisk" style="margin-right: 5px"></span><asp:Label ID="CountLabel" runat="server" Text="Label"></asp:Label> результатов турнира было обработано</p>
        <p style="visibility: hidden"><span class="glyphicon glyphicon-asterisk" style="margin-right: 5px"></span><asp:Label ID="UserLabel" runat="server" Text="Label"></asp:Label> с этого компьютера была загружена база данных</p>
        <hr>

        <form runat="server" id="aspnetForm">

            <div class="input-group">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Введите ник..."></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="TextBtn" runat="server" CssClass="form-control" Text="Обработать" OnClick="TextBtn_Click" />
                </span>
            </div>

            <br />
            <br />
            <br />
            <div class="input-group">
                <span class="input-group-addon">Russia Worm.is</span>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" placeholder="Выберите ник...">
                    <asp:ListItem>Ivanesss</asp:ListItem>
                    <asp:ListItem>RussiaMoscow</asp:ListItem>
                    <asp:ListItem>DadCity</asp:ListItem>
                    <asp:ListItem>Eldar3216</asp:ListItem>
                    <asp:ListItem>OfMyDr1ams</asp:ListItem>
                    <asp:ListItem>Taktika</asp:ListItem>
                    <asp:ListItem>haste95</asp:ListItem>
                    <asp:ListItem>LeiaXP</asp:ListItem>
                    <asp:ListItem>BeHepa</asp:ListItem>
                    <asp:ListItem>gewal131</asp:ListItem>
                    <asp:ListItem>CatyFoxi</asp:ListItem>
                </asp:DropDownList>
                <span class="input-group-btn">
                    <asp:Button ID="ListBtn" runat="server" CssClass="form-control" Text="Обработать" OnClick="ListBtn_Click"  />
                </span>
            </div>
        </form>
    </div>
    <br />
    <!-- Blog Sidebar Widgets Column -->
    <div class="col-md-4">

        <!-- Side Widget Well -->
        <div class="well">
            <h4>Внимание</h4>
            <p aria-sort="none">При вводе ника - обратите внимание на регистр букв.</p>
        </div>

        <!-- Side Widget Well -->
        <div class="well">
            <h4>Для нетерпеливых</h4>
            <p>Если не хотите ждать, когда автор обработает новые результаты с сайта, то можете ему в этом помочь - скачав Updater базы данных сайта, он работает в автоматическом режиме (5-15 мин).</p>
            <p><span class="glyphicon glyphicon-save"></span><a href="/download/Updater.zip"> Updater.zip (56kb)</a></p>
        </div>

    </div>

    <div class="col-md-12" >
        <center><h2><asp:Label ID="Nickname" runat="server" Text=""></asp:Label></h2></center>
        <asp:Table ID="Table1" runat="server" CssClass="table" Visible="False">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableHeaderCell runat="server">Место</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Финальная масса</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Максимальная масса</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">PTS</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Приз</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Ссылка</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>

        <br />

        <asp:Table ID="Table2" runat="server" CssClass="table" Visible="False">
            <asp:TableRow runat="server" TableSection="TableHeader">
                <asp:TableHeaderCell runat="server">Монет</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Купонов</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средний PTS</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средняя  финальная масса</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Средняя  максимальная масса</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>


</asp:Content>
