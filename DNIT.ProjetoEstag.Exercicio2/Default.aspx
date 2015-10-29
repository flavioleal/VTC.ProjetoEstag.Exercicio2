<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DNIT.ProjetoEstag.Exercicio2._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>

        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    Nome:<br />
    
    <asp:TextBox ID="txtNome" runat="server" Text="" /> &nbsp;<asp:Label ID="lblNome" runat="server" Style="color:red"></asp:Label>
    <br />
    Sexo:<br />
    <div>
        <asp:DropDownList ID="ddlSexo" runat="server"  AutoPostBack="true"> 
        </asp:DropDownList> &nbsp;<asp:Label ID="lblSexo" runat="server" Style="color:red"></asp:Label>
    </div>


    <asp:Label ID="Teste" runat="server" Style="color:red"></asp:Label>

    Estado Civil:<br />

      <div>
            <asp:RadioButtonList ID="rbtEstado" runat="server"> 
              
            </asp:RadioButtonList> &nbsp;<asp:Label ID="lblEstado" runat="server" Style="color:red"></asp:Label>           
            </div>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    &nbsp;<asp:Button ID="btnLimpar" runat="server" Text="limpar" OnClick="btnLimpar_Click" />
    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    <asp:Button ID="btnDeletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />
    <br />
    <asp:Label ID="Label2" runat="server" Style="color:red"></asp:Label>

    <asp:GridView ID="gdvResultado" runat="server" Width="426px" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Usuario" />
            <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
            <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" />

        </Columns>
    </asp:GridView>

</asp:Content>
