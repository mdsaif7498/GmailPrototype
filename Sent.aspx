<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sent.aspx.cs" Inherits="Sent" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMaster" Runat="Server">
      <p style="height: 191px; width: 1084px"> 

          <asp:GridView ID="gvSent" runat="server" AutoGenerateColumns="False" Height="169px" Width="1077px" AllowPaging="True" OnPageIndexChanging="gvSent_PageIndexChanging"  PageSize="3" ClientIDMode="AutoID"  OnRowCommand="gvSent_RowCommand" DataKeyNames="Id" >
              <Columns>
                  <asp:BoundField DataField="MailTo" HeaderText="MailTo" />
                  <asp:TemplateField HeaderText="Subject">
                      <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnSubject"  runat="server" Text='<%# Eval("Subject") %>' CommandName="Select"></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField HeaderText="Message" DataField="Message" />
                  <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                  </asp:BoundField>
                  
                  <asp:ButtonField HeaderText="Delete" Text="Delete"  CommandName="delMail"/>
              </Columns>
          </asp:GridView>

          
    <asp:Label ID="lblSentMail" runat="server"></asp:Label>
</asp:Content>

