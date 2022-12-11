<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="ProductViewUser.aspx.cs" Inherits="eBuyAntiquesStore2.user.ProductViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="d1" runat="server">

<HeaderTemplate>
    <ul>
</HeaderTemplate>
<ItemTemplate>
    <li class="product"> <a href="product_desc.aspx?itemId=<%#Eval("itemId")%>"><img src="../<%#Eval("itemImage")%>" alt="" style="width: 300px; height: 337px; object-fit: fill;"/></a>
            <div class="product-info">
              <h3><%#Eval("itemName")%></h3>
              <div class="product-desc">
                <h4>Stocks:<%#Eval("quantity")%></h4>
                
                 <p></p>
                <strong class="price">Rs:<%#Eval("itemPrice")%></strong> </div>
            </div>
          </li>
</ItemTemplate>
<FooterTemplate>
     </ul>
</FooterTemplate>
        </asp:Repeater>
    </asp:Content>