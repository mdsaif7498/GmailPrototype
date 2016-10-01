<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
</head>
<body>
    <form id="form1" runat="server">
      <center>
        &nbsp;<asp:Label  ID="lbl" runat="server" Text="Create your own email account" Font-Names="Calibri" Font-Size="XX-Large" BorderStyle="Solid"></asp:Label>
        <table >
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style4" colspan="2">
                    &nbsp;<asp:TextBox ID="txtFirstName" runat="server" Width="137px" Height="16px" ValidationGroup="vgBtnRegister"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revTxtFirstName" runat="server" ControlToValidate="txtFirstName" Display="None" ErrorMessage="Invalid info..!!Please enter correct info." SetFocusOnError="True" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="vgBtnRegister"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvTxtFirstName" runat="server" ErrorMessage="Enter your first name" ControlToValidate="txtFirstName" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtLastName" runat="server" Width="152px" ValidationGroup="vgBtnRegister"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revTxtLastName" runat="server" ControlToValidate="txtLastName" Display="None" ErrorMessage="Invalid info...!!Please enter correct  info" SetFocusOnError="True" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="vgBtnRegister"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvTxtLastName" runat="server" ErrorMessage="Enter your last name" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                    <table class="auto-style3">
                        <tr>
                            <td>
                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:DropDownList ID="ddlGender" runat="server" Width="307px" Height="17px" ValidationGroup="vgBtnRegister" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="I am....">I am....</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvDdlGender" runat="server" ErrorMessage="Select your gender" ControlToValidate="ddlGender" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="auto-style3">
                                    <tr>
                                        <td>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile phone"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                    <asp:TextBox ID="txtMobile" runat="server" Width="299px" ValidationGroup="vgBtnRegister"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revTxtMobile" runat="server" ControlToValidate="txtMobile" Display="None" ErrorMessage="Invalid Mobile Number..!! Please enter correct mobile number" SetFocusOnError="True" ValidationExpression="[0-9]{10}" ValidationGroup="vgBtnRegister"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                    <asp:RequiredFieldValidator ID="rfvTxtMobile" runat="server" ErrorMessage="Enter your mobile number" ControlToValidate="txtMobile" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                    <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                     </asp:ScriptManager>
                    <asp:TextBox ID="txtCalender" runat="server" ></asp:TextBox>
                    <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCalender">
                    </cc:CalendarExtender>


                                        </td>
                                    </tr>
                                 
                            </td>
                        </tr>
                   
                </td>
            </tr>
        
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblUserName" runat="server" Text="Choose your username"></asp:Label>
                </td>
        
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:TextBox ID="txtUserName" runat="server" Width="299px" ValidationGroup="vgBtnRegister"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtUserName" runat="server" ErrorMessage="Enter your username" ControlToValidate="txtUserName" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revTxtUserName" runat="server" ControlToValidate="txtUserName" Display="None" ErrorMessage="Enter your correct username" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vgBtnRegister"></asp:RegularExpressionValidator>
                </td>
        
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblPassword" runat="server" Text="Create a password"></asp:Label>
                </td>
        
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:TextBox ID="txtPassword" runat="server" Width="298px" ValidationGroup="vgBtnRegister" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtPassword" runat="server" ErrorMessage="Enter your password" ControlToValidate="txtPassword" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                </td>
        
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm your password"></asp:Label>
                </td>
        
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" Width="297px" ValidationGroup="vgBtnRegister" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTxtConfirmPassword" runat="server" ErrorMessage="Enter your password again" ControlToValidate="txtConfirmPassword" Display="None" SetFocusOnError="True" ValidationGroup="vgBtnRegister"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="None" ErrorMessage="Entered password is incorrect. Please enter the correct password" SetFocusOnError="True" ValidationGroup="vgBtnRegister" ValueToCompare="0"></asp:CompareValidator>
                </td>
        
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
        
                <td class="auto-style1"></td>
            </tr>
           
            <tr>
                <td class="auto-style6">
                    &nbsp;</td>
        
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style4">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="vgBtnRegister"  />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"  />
                    <br />
                    <br />
                </td>
            </tr>
        
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:ValidationSummary ID="vsBtnRegister" runat="server" ValidationGroup="vgBtnRegister" ShowMessageBox="True" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
          
        </table>
              </%--center>
      </form>



</body>
</html>
