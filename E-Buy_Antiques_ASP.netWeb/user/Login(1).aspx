<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eBuyAntiquesStore2.user.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div>
    
        <table align="center" style="height: 500px; width: 655px; background-color: #5f98f3;">
            <tr>
                <td colspan="2" align="center">
                    <h2>Login Page</h2>
                </td>
            </tr>
            <tr>
                <td align="center" style="width:50%">
                    <b>Email Id:</b>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="216px" BackColor="#5F98F3" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width:50%">
                    <b>Password:</b>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="216px" BackColor="#5F98F3" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Login" BackColor="#5F98F3" Font-Size="Large" Height="54px" OnClick="Button1_Click" Width="116px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
