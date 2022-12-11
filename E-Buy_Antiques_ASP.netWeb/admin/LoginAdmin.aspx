<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="eBuyAntiquesStore2.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                </td>
            </tr>
                 <tr>
                <td>
                    <a href="RegisterAdmin.aspx">Already Registered</a>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
