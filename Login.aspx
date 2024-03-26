<%@ Page Title="Cijfer bewerken" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoteToNumberWeb.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Inloggen</h3>
        <div class="form-group">
            <label for="UserName">Gebruikersnaam</label>
            <asp:TextBox runat="server" class="form-control" ID="UserName" placeholder="Gebruikersnaam" />
        </div>
        <div>
            <asp:Label runat="server" ID="UserWarning" Visible="false" CssClass="text-danger">Gebruikersnaam onjuist</asp:Label>
        </div>
        <div class="form-group">
            <label for="Password">Wachtwoord</label>
            <asp:TextBox runat="server" TextMode="Password" type="password" class="form-control" ID="Password" placeholder="Wachtwoord" />
        </div>
        <div>
            <asp:Label runat="server" ID="PasswordWarning" Visible="false" CssClass="text-danger">Wachtwoord onjuist</asp:Label>
        </div>

        <asp:Button runat="server" ID="LoginButton" type="submit" class="btn btn-primary mt-2" Text="Inloggen" />
    </main>
</asp:Content>
