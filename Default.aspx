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
                    <asp:FileUpload runat="server" accept=".musicxml" CssClass="form-control" class="w-50" />
                </p>
                <p>
                    <asp:Button ID="translate" runat="server" Text="Vertalen" CssClass="btn btn-success" />
                </p>

            </section>
            <%--<section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>--%>
        </div>
    </main>

</asp:Content>
