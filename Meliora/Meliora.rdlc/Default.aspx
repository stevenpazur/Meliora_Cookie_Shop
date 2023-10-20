<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Meliora.rdlc._Default" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding:15px">
        <div align="center" style="font-size:30px">User Info Report</div>
        <div align="center">
            <asp:Button ID="Button1" runat="server" Text="Load Report" OnClick="Button1_Click" Width="200px" />
            <br />
            <br />
            <br />
            <rsweb:ReportViewer runat="server"></rsweb:ReportViewer>
        </div>
    </div>

</asp:Content>
