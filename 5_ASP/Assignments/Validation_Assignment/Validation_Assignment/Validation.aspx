<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validation.aspx.cs" Inherits="Validation_Assignment.Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        &nbsp;&nbsp;&nbsp; Insert Your Details :<br />
            <br />
&nbsp; Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1forname" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Name Cannot be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp; Family Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtfamname" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1forfamilyname" runat="server" ControlToValidate="txtfamname" Display="Dynamic" ErrorMessage="Familyname cannot be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtname" ControlToValidate="txtfamname" Display="Dynamic" ErrorMessage="Differs from name" ForeColor="Red" Operator="NotEqual" ValidationGroup="Validation sum"></asp:CompareValidator>
            <br />
            <br />
&nbsp; Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1foraddress" runat="server" ControlToValidate="txtaddress" Display="Dynamic" ErrorMessage="Address cant be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtaddress" Display="Dynamic" ErrorMessage="at least 2 Characters" ForeColor="Red" ValidationExpression="^[a-zA-Z]{2,}"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp; City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcity" Display="Dynamic" ErrorMessage="City cant be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtcity" Display="Dynamic" ErrorMessage="at least 2 Characters" ForeColor="Red" ValidationExpression="^[a-zA-Z]{2,}$"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp; Zip Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtzipcode" Display="Dynamic" ErrorMessage="Zip Code cant be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtzipcode" Display="Dynamic" ErrorMessage="(xxxxx)" ForeColor="Red" ValidationExpression="\d{5}" ValidationGroup="Validation sum"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp; Phone&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtpone" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpone" Display="Dynamic" ErrorMessage="phone cant be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpone" Display="Dynamic" ErrorMessage="(xx-xxxxxxxx / xxx-xxxxxxx)" ForeColor="Red" ValidationExpression="\d{10}" ValidationGroup="Validation sum"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp; E-Mail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="E-Mail cant be null" ForeColor="Red" ValidationGroup="Validation sum">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="example@example.com" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Validation sum"></asp:RegularExpressionValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="chkbtn" runat="server" Text="Check" ValidationGroup="Validation sum" OnClick="chkbtn_Click" />
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Validation Sum" ValidationGroup="Validation sum" />

            <br />
            Validation Sum :<br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" BackColor="#33CCFF" BorderColor="#66FF33" BorderStyle="Double" ForeColor="Black"></asp:Label>

        </div>
    </form>
</body>
</html>
