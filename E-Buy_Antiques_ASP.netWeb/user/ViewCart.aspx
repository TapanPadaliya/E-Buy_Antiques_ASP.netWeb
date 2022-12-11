<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="eBuyAntiquesStore2.user.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div>

        <asp:DataList ID="d2"  runat="server">
           
            <HeaderTemplate>
                <table border="2">
                    <tr style="background-color:silver;color:white;font-weight:bold">
                        <td>Item Name</td>
                        <td>Item Price</td>
                        <td>Item Image</td>
                        <td>Item Quantity</td>
                        <td>Delete</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td>
                        <%#Eval("itemName")%>
                    </td>
                   
                   
                    <td>
                        <%#Eval("itemPrice")%>
                    </td>
                    <td>
                        <img src="../<%#Eval("itemImage")%>" height="100" width="100" />
                    </td>

                     <td>
                        <%#Eval("quantity")%>
                    </td>

                     <td>
                        <a href="DeleteItem.aspx?pos=<%#Eval("pos") %>">delete</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
                <asp:Label Visible='<%#bool.Parse((d2.Items.Count==0).ToString())%>' 
               runat="server" ID="lblNoRecord" Text="No Record Found!"></asp:Label>
            </FooterTemplate>
            
        </asp:DataList>
        <br />
        <p align="center">
            <asp:Label ID="carttotprice" runat="server"></asp:Label>
            <asp:Button ID="cout" runat="server" Text="Place Order" OnClick="cout_Click"/>
         </p>
    </div>
</asp:Content>
