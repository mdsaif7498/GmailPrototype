<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trash.aspx.cs" Inherits="Trash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMaster" Runat="Server">
     <asp:GridView ID="gvTrash" runat="server" AutoGenerateColumns="False" Height="153px" Width="1077px" AllowPaging="True" OnPageIndexChanging="gvTrash_PageIndexChanging" ClientIDMode="AutoID"  OnRowCommand="gvTrash_RowCommand"  DataKeyNames="Id" >
              <Columns>
                  <asp:BoundField DataField="Subject" HeaderText="Subject" />
                  <asp:BoundField HeaderText="Message" DataField="Message" />
                  <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                  </asp:BoundField>
                  <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="delMail" />
              </Columns>
          </asp:GridView>

                 </asp:Content>

