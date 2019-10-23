<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP_Inventory.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="left-box" style="background-color:#c9c4c4; width:30%; height:90vh; float:left; margin-top:2px;">
            <asp:Label CssClass="label"  runat="server">Add Raw Material</asp:Label>
            <br />
            <br />
            <asp:Label CssClass="label" runat="server">Raw Material Name</asp:Label>
            <asp:TextBox runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label CssClass="label" runat="server">Raw Material Code</asp:Label>
            <asp:TextBox runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label CssClass="label" runat="server">Raw Material Price</asp:Label>
            <asp:TextBox runat="server"></asp:TextBox>
            <br />
            <asp:Button CssClass="button" runat="server" Text="Save"/>
        </div>

        <div class="right-box" style="width:70%; height:90vh; float:left">
            <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit"   />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>    
        </div>
    </div>
</asp:Content>
