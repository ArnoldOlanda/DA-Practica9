<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exp2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            Total Peliculas<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Maximo RunTime<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Minimo RunTime<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Promedio Runtime<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
    </div>

</asp:Content>
