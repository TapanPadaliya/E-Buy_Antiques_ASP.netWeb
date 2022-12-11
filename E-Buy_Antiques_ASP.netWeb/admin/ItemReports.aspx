<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ItemReports.aspx.cs" Inherits="eBuyAntiquesStore2.admin.ItemReports" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Chart ID="Chart1" runat="server" Width="850px">
    <Series>
        <asp:Series Name="Series1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
</asp:Content>
