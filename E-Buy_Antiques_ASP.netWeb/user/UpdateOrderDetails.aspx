<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="UpdateOrderDetails.aspx.cs" Inherits="eBuyAntiquesStore2.user.UpdateOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div>
    <p>Update Shipping Details</p>
</div>
<table>

    <tr>
        <td>
            User Name:
        </td>

        <td>
            <asp:TextBox ID="uname" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            User Address:
        </td>

        <td>
            <asp:TextBox ID="uaddr" runat="server" TextMode="MultiLine" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            City:
        </td>

        <td>
            
            <asp:TextBox ID="ucity" runat="server" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            State:
        </td>

        <td>
            
            <asp:TextBox ID="ustate" runat="server" ></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td colspan="2">
            <asp:BUtton ID="cout" runat="server" Text="CheckOut" OnClick="cout_Click"></asp:BUtton>
        </td>
    </tr>

</table>
</asp:Content>
