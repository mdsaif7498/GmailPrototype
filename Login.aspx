<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
        <center>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                &nbsp;
                    <asp:TextBox ID="txtUserName" runat="server" Width="142px" ValidationGroup="vgBtnSignIn"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtUserName" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="Enter your correct username" SetFocusOnError="True" ValidationGroup="vgBtnSignIn"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" Width="143px" ValidationGroup="vgBtnSignIn" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtPassword" runat="server" ControlToValidate="txtPassword" Display="None" ErrorMessage="Enter your correct password" SetFocusOnError="True" ValidationGroup="vgBtnSignIn"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" ValidationGroup="vgBtnSignIn" Width="117px" OnClick="btnSignIn_Click" style="text-align: center; margin-left: 0px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember me" ValidationGroup="vgBtnSignIn" />
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;<asp:HyperLink ID="hlNewUser" runat="server" NavigateUrl="~/Registration.aspx">New User? Create your own account</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="vsBtnSignIn" runat="server" ValidationGroup="vgBtnSignIn" />
                </td>
            </tr>
        </table>
            </center>
    </form>
</body>
</html>
