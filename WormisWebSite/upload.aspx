<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cайт гильдии "Russia Wormis"</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form id="form1" runat="server">
    <div class="col-md-12">
        <h1 class="page-header">Ваша база данных сформирована - загрузите её на сайт</h1>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Загрузить базу данных на сервер" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:Label ID="SuccessLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <div class="well">
            <h4>Информация</h4>
            <p>База данных имеет название "wormisbase.bin" и лежит вместе с программой updater</p>
        </div>
        <br />
    </div>

    </form>

</asp:Content>
