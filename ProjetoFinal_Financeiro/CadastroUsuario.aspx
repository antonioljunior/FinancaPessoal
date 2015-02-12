<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="ProjetoFinal_Financeiro.CadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <fieldset>
        <legend>Cadastro de Usuários</legend>
        <asp:ValidationSummary runat="server" />
        <asp:TextBox runat="server" name="user"
            placeholder="Nome" ID="txtNome" />
        <asp:RequiredFieldValidator ErrorMessage="O nome é obrigatório" 
            ControlToValidate="txtNome" runat="server" Display="None" />
        <br /><br />
        <asp:TextBox runat="server" name="user"
            placeholder="Login" ID="txtLogin" /><br /><br />
        <asp:RequiredFieldValidator ErrorMessage="O login é obrigatório" 
            ControlToValidate="txtLogin" runat="server" Display="None" />
        <asp:TextBox runat="server" name="user" 
            placeholder="Senha" ID="txtSenha" /><br /><br />
        <asp:RequiredFieldValidator ErrorMessage="A senha é obrigatória" 
            ControlToValidate="txtSenha" runat="server" Display="None" />
        <asp:TextBox runat="server" name="user"
            placeholder="Email" ID="txtEmail" /><br /><br />
        <asp:TextBox runat="server" name="user" data-inputmask="'mask': '999.999.999-99'"
            placeholder="CPF" ID="txtCPF" /><br /><br />
        <asp:Button Text="Limpar" runat="server" ID="btnLimpar" />
        <asp:Button Text="Salvar" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" />
    </fieldset>
</asp:Content>
