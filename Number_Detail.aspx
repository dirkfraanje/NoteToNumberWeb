<%@ Page Title="Cijfer bewerken" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Number_Detail.aspx.cs" Inherits="NoteToNumberWeb.Number_Detail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Cijfer bewerken</h3>
        <asp:Table runat="server" ID="TableEdit" ></asp:Table>
        <asp:Button runat="server" ID="saveButton" CssClass="btn btn-success" Text="Opslaan"/>
    </main>
</asp:Content>
