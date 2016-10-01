<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style11 {
            width: 100%;
        }
        .auto-style12 {
            width: 94px;
        }
        .auto-style13 {
            width: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMaster" Runat="Server">
     
    
    <asp:GridView ID="gvInbox" runat="server" AutoGenerateColumns="False" Height="203px" Width="1077px" AllowPaging="True" OnPageIndexChanging="gvInbox_PageIndexChanging"  PageSize="3" ClientIDMode="AutoID"  style="margin-top: 14px" OnRowDataBound="gvInbox_RowDataBound" OnRowCommand="gvInbox_RowCommand" DataKeyNames="Id" OnSelectedIndexChanged="gvInbox_SelectedIndexChanged">
              <Columns>
                 
               
                  <asp:BoundField DataField="MailFrom" HeaderText="MailFrom" />
                  <asp:TemplateField HeaderText="Subject">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnkBtnSubject" runat="server"  Text='<%# Eval("Subject") %>' CommandName="Select" CommandArgument="Select" ></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="Message" HeaderText="Message" />
                  <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                  </asp:BoundField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:HiddenField ID="hfSeenFlag" runat="server" Value='<%# Eval("IsSeenFlag") %>' />
                </ItemTemplate>
            </asp:TemplateField>                  
                  <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="delMail" />
                
                  
              </Columns>
          </asp:GridView>

  
   
    
    <asp:MultiView ID="mvInbox" runat="server">

        <asp:View ID="MailView" runat="server">
        <asp:Label ID="lblInboxMail" runat="server"></asp:Label>
        <asp:Button ID="btnForward" runat="server" Text="Forward" OnClick="btnForward_Click" Visible="False"  />
        <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" Visible="False" />

            &nbsp;
        </asp:View>
         <asp:View ID="ForwardView" runat="server">

               
             <table class="auto-style11">
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="txtSenderTo" runat="server" Width="217px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblSenderFrom" runat="server" ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblSenderSubject" runat="server" ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblSenderMessage" runat="server" ></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblSenderDate" runat="server"></asp:Label>
                     </td>
                 </tr>
             </table>

             <asp:Button ID="btnSendForward" runat="server" Text="Send" OnClick="btnSendForward_Click" />
                 <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

             <asp:Label ID="lblResult" runat="server" ></asp:Label>

               
         

               
        </asp:View>
        <asp:View ID="ReplyView" runat="server">
            <table class="auto-style11">
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblReplyFrom" runat="server" Text="From"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblReplySenderFrom" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblReplyTo" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblReplySenderTo" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblReplySubject" runat="server" Text="Subject"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReplySenderSubject" runat="server" Width="233px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:Label ID="lblReplyMessage" runat="server" Text="Message"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtReplySenderMessage" runat="server" Height="65px" Width="230px"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
              <asp:Button ID="btBacktoMailView" runat="server" Text="Back" OnClick="btBacktoMailView_Click" />
            <asp:Label ID="lblResultShow" runat="server"></asp:Label>
          
        </asp:View>
    </asp:MultiView>
    
</asp:Content>

