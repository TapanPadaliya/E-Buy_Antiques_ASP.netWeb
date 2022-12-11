<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewFullOrder.aspx.cs" Inherits="eBuyAntiquesStore2.admin.ViewFullOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater id="r2" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray;color:white">
                    <td width="100">
                        Customer ID:
                    </td>
                    <td width="125">
                        Customer Name:
                    </td>
                    <td width="125">
                        Customer Email:
                    </td>
                    <td width="175">
                        Customer Address:
                    </td>
                    <td width="125">
                        Customer City:
                    </td>
                    <td width="125">
                        Customer State:
                    </td>
                     <td width="125">
                        Order Time:
                    </td>

                     <td width="125">
                        Order Details:
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
               <td>
                    <%#Eval("id") %>

                </td>
                <td>
                    <%#Eval("custName") %>

                </td>
                <td>
                    <%#Eval("custEmail") %>

                </td>
                 <td>
                    <%#Eval("custAddr") %>

                </td>
                 <td>
                    <%#Eval("custCity") %>

                </td>
                 <td>
                    <%#Eval("custState") %>

                </td>
                 <td>
                    <%#Eval("orderDateTime") %>

                </td>
                <td><a href="ViewFullOrder.aspx?id=<%#Eval("id") %>">Show Order</a></td>
            </tr>

        </ItemTemplate>
        <FooterTemplate>
            </table>

        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:gray;color:white">
                    <td>Item ID</td>
                    <td>Item Name:</td>
                    <td>Item Price:</td>
                    <td>Item Image:</td>
                    <td>Item Quantity</td>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
             <tr>
                 <td>
                     <%#Eval("orderID") %>
                 </td>
                 <td>
                     <%#Eval("itemName") %>
                 </td>
                 <td>
                     <%#Eval("itemPrice") %>
                 </td>
                 <td>
                   <img src="../<%#Eval("itemImage")%>" height="100" width="100" /
                 </td>
                 <td>
                     <%#Eval("quantity") %>
                 </td>
                
             </tr>

        </ItemTemplate>
        <FooterTemplate>
        </table>
            </FooterTemplate>
    </asp:Repeater>
    <asp:Label id="l1" runat="server"></asp:Label>
       <br />
   <td><a href="DisplayOrder.aspx">Back</a></td>
</asp:Content>
