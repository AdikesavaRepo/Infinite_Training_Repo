<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsForm.aspx.cs" Inherits="DropDown_Assignment.ProductsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <h2>Select a Product from dropdown for more details</h2>

            <asp:DropDownList ID="ProductsDropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ProductsDropDownList1_SelectedIndexChanged">
                <asp:ListItem>Apples</asp:ListItem>
                <asp:ListItem>Desks</asp:ListItem>
                <asp:ListItem>Milk</asp:ListItem>
                <asp:ListItem>Mobiles</asp:ListItem>
                <asp:ListItem>RiceBags</asp:ListItem>
                <asp:ListItem>Televisions</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />

            <asp:Image ID="productsimg" runat="server" Width="200px" Height="200px" ImageUrl="~/Products/Apples.jpg" />

            <br />
            <br />

            <asp:Button ID="btnprice" runat="server" Text="Get Price" OnClick="btnprice_Click" />

            <br />
            <br />

            <asp:Label ID="lblprice" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>

        </div>

    </form>
</body>
</html>
