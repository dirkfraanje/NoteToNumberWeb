<%@ Page Title="Noten naar cijfers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoteToNumberWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Noten naar cijfers</h1>
        </section>

        <div class="row">
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Bestand uploaden (.musicxml)</h2>
                <p>
                    <asp:FileUpload ID="upload" runat="server" accept=".musicxml" CssClass="form-control" class="w-50" />
                </p>
                <asp:Panel runat="server" ID="warningLabelPanel">
                    <asp:Label runat="server" ID="warningLabel"></asp:Label>
                </asp:Panel>
                <asp:Panel runat="server">

                    <p>
                        <asp:Button ID="translate" runat="server" Text="Vertalen" CssClass="btn btn-success" />
                        <asp:TextBox ID="deleteList" hidden runat="server" />
                    </p>
                </asp:Panel>
                <h1>
                    <asp:Label ID="resultHead" runat="server"></asp:Label></h1>
                <asp:Table ID="result" runat="server" Width="100%"></asp:Table>
            </section>
        </div>
    </main>

</asp:Content>
