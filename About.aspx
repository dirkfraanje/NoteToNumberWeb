<%@ Page Title="Achtergrond" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NoteToNumberWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Wat is cijfermuziek?</h3>
        <p>Cijfermuziek is net zoals noten een manier om muziek op schrift vast te leggen.</p>
        <p>Meer informatie over cijfermuziek is te vinden op <a href="http://www.cijfermuziek.nl" target="_blank">www.cijfermuziek.nl</a></p>
        <h3>Waarom deze site?</h3>
        <p>Op een verjaardag vroeg mijn oom: "Kun jij geen programma maken dat automatisch noten omzet naar cijfers? Even een fotootje en klaar..." </p>
        <p>Dat leek me een leuke uitdaging, al gauw ontdekte ik dat muziek op noten, digitaal kan worden vastgelegd in .musicxml bestanden, meer informatie daarover is te vinden op <a href="https://www.musicxml.com/" target="_blank">www.musicxml.com</a>.</p>
        <p>Dat werd dus mijn vertrekpunt, en ik ontdekte, na wat leuke programmeer-uitdagingen, dat het mogelijk is om noten te vertalen naar cijfers. Helaas was "Even een fotootje en klaar..." minder makkelijk. Er bleken al verschillende tools te zijn die een pdf-bestand of foto kunnen omzetten naar een digitaal bestand, maar het blijkt dat dit meestal toch net niet helemaal goed gaat.</p>
        <p>Op verschillende forums lees je dan ook dat dit omzetten het beste handmatig kan gebeuren (Nee helaas, ook AI bied geen uitkomst...)</p>
        <p>Er is een goed en gratis programma met de naam MuseScore, zie voor meer informatie <a href="https://musescore.org/nl" target="_blank">musescore.org/nl</a>. Als hierin de noten netjes zijn ingevuld kan er een .musicxml bestand worden ge-exporteerd, zie <a href="Contact">Hoe kom ik aan een .musicxml bestand?</a> op deze site voor meer informatie.</p>
        <p>Met veel plezier heb ik deze tool voor ome Jan gemaakt, ik hoop dat u er veel plezier aan beleeft!</p>
    </main>
</asp:Content>
