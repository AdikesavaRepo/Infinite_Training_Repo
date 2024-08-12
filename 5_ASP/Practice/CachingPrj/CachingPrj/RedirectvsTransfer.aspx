<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedirectvsTransfer.aspx.cs" Inherits="CachingPrj.RedirectvsTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name :&nbsp;&nbsp; <asp:TextBox ID ="txtname" runat="server"></asp:TextBox>
            <br />
            Email :&nbsp;&nbsp; <asp:TextBox ID ="txtemail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="GetBtnData" runat="server" OnClick="Button1_Click" Text="GetPage" />
            <br />

        </div>
    </form>
</body>
</html>
