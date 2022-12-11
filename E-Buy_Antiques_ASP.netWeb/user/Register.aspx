<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eBuyAntiquesStore2.user.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div>
    
  
    <table align="center" style="width: 700px; height: 781px; background-color: #5f98f3">
        <tr>
            <td colspan="2" align="center">
                <h2>Registration Page</h2>
            </td>
        </tr>
        <tr>
            <td style="width:50%"><b>Name:</b></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="374px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="First Name is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Only characters are required" ForeColor="Red" ValidationExpression="^[A-Za-z ]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%"><b>Password:</b></td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Height="22px" Width="374px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox6" ErrorMessage="Password is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%"><b>Confirm Password:</b></td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Height="22px" Width="374px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox7" ErrorMessage="Confirm Password is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox6" ControlToValidate="TextBox7" ErrorMessage="Password Doesn't match" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Email_ID:</b>
            </td>
            <td>
                <asp:TextBox ID="email" runat="server" Height="22px" Width="374px" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Email_ID is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
        
                </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td style="width:50%"><b>Address:</b></td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="22px" Width="374px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="Address is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%"><b>City:</b></td>
            <td>
                <asp:TextBox ID="city" runat="server" Height="22px" Width="374px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Address is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%"><b>State:</b></td>
            <td>
                <asp:TextBox ID="state" runat="server" Height="22px" Width="374px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Address is empty." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%" align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Register" Font-Bold="True" Font-Size="Large" Height="39px" Width="118px" OnClick="Button1_Click"/>
            </td>
            <td>
                &nbsp;
                <asp:HyperLink ID="HP1" runat="server" Text="Already a member?" NavigateUrl="~/Login.aspx"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td style="width:50%" colspan="2">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
    </table>
      </div>
</asp:Content>
