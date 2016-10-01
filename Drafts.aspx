<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Drafts.aspx.cs" Inherits="Drafts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMaster" Runat="Server">
    <p> 
        <asp:GridView ID="gvDrafts" runat="server" AutoGenerateColumns="False" Height="208px" Width="1020px" OnPageIndexChanging="gvDrafts_PageIndexChanging" PageSize="3" AllowPaging="True" OnRowDeleting="gvDrafts_RowDeleting" OnRowCommand="gvDrafts_RowCommand"  DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="Message" HeaderText="Message" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                </asp:BoundField>
                <asp:ButtonField HeaderText="Delete" Text="Delete" CommandName="delMail" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

