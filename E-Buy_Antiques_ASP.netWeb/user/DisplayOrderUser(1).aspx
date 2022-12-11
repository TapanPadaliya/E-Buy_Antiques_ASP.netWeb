<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="DisplayOrderUser.aspx.cs" Inherits="eBuyAntiquesStore2.user.DisplayOrderUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    
    <asp:Repeater id="r1" runat="server">
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
                <td><a href="ViewOrderUser.aspx?id=<%#Eval("id") %>">Full Order</a></td>
            </tr>

        </ItemTemplate>
        <FooterTemplate>
            </table>
             <asp:Label Visible='<%#bool.Parse((r1.Items.Count==0).ToString())%>' 
               runat="server" ID="lblNoRecord" Text="No Orders Found!"></asp:Label>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
