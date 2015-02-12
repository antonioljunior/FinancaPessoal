<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="ProjetoFinal_Financeiro.CadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox runat="server" name="user"
        placeholder="Nome" ID="txtNome" />
    <asp:TextBox runat="server" name="user"
        placeholder="Login" ID="txtLogin" />
    <asp:TextBox runat="server" name="user" TextMode="Password"
        placeholder="Senha" ID="txtSenha" />
    <asp:TextBox runat="server" name="user"
        placeholder="Email" ID="txtEmail" />
    <asp:TextBox runat="server" name="user" data-inputmask="'mask': '999.999.999-99'"
        placeholder="CPF" ID="txtCPF" />
    <asp:Button Text="Limpar" runat="server" ID="btnLimpar" />
    <asp:Button Text="Salvar" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" />
</asp:Content>
