<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="product_desc.aspx.cs" Inherits="eBuyAntiquesStore2.user.product_desc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">


    <asp:Repeater ID="d1" runat="server">

<HeaderTemplate>
  
</HeaderTemplate>
<ItemTemplate>
       <div style="height:300px;width:600px;border-style:solid;border-width:1px;">
    <div style="height:300px;width:200px;float:left;border-style:solid;border-width:1px;">

       <img src="../<%#Eval("itemImage")%>" height="300" width="200" />
      
    </div>
           
    <div style="height:300px;width:395px;float:left;border-style:solid;border-width:1px;">

          Item Name:<%#Eval("itemName") %><br /><br />Item Description:<%#Eval("itemDescription") %><br /><br>
        Item Price:<%#Eval("itemPrice") %><br /><br>
        Item Quantity::<%#Eval("quantity") %><br /><br>

    </div>

   </div>       
</ItemTemplate>
        <FooterTemplate></FooterTemplate>
        </asp:Repeater>
 <br />

    <table>
        <tr>
            <td><asp:Label ID="l2" runat="server"  Text="Enter Quantity"></asp:Label></td>
            <td><asp:TextBox ID="t1"  runat="server"></asp:TextBox></td>
            <td> 
                <asp:Button ID='addToCartBtn' runat="server" Text="Add to Cart" onclick="add_to_cart" /></td>
            <td> <asp:Label ID="upd_qty" runat="server" ForeColor="Red" Text="Update Quantity" Visible="false" onclick=""></asp:Label></td>
            <asp:
        </tr>
 
    <tr>
        <td colspan="3">
            <asp:Label ID="l1" runat="server" ForeColor="Red" Text=""></asp:Label>

        </td>

    </tr>
    
       
    </table>    


    </asp:Content>