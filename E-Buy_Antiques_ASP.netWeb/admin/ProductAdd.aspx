<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="eBuyAntiquesStore2.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<table border="2" class="nav-justified" style="width: 54%; height: 370px; background-color: #3399FF">
    <tr>
        <td style="height: 30px; width: 121px">Product ID:</td>
        <td style="height: 30px; width: 297px">
            <asp:Label ID="product_id" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Product Name:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:TextBox ID="TextBox1" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 29px; width: 121px">Upload Image:</td>
        <td style="height: 29px; width: 297px">
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Price:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:TextBox ID="TextBox2" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Quantity:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:TextBox ID="TextBox3" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Description:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:TextBox ID="TextBox4" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 30px; width: 121px">Weight:</td>
        <td style="height: 30px; width: 297px">
            <asp:TextBox ID="TextBox5" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Category:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:DropDownList ID="pdropdown" runat="server" DataTextField="categoryId" DataValueField="categoryId">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ebuyAntiquesStoreConnectionString %>" SelectCommand="SELECT * FROM [CategoryMaster]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">Crafted On:</td>
        <td class="modal-sm" style="width: 297px">
            <asp:TextBox ID="TextBox6" runat="server" Width="227px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 121px">&nbsp;</td>
        <td class="modal-sm" style="width: 297px">
            <asp:Button ID="Button1" runat="server" BackColor="#339933" OnClick="Button1_Click" Text="Add Product" Width="56px" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
