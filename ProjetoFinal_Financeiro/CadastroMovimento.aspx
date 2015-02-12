<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CadastroMovimento.aspx.cs" Inherits="ProjetoFinal_Financeiro.CadastroMovimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <fieldset>
        <legend>Cadastro de Movimento</legend>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:ScriptManager runat="server" />
        <asp:UpdateProgress runat="server">
            <ProgressTemplate>
                Carregando...
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:TextBox runat="server" name="user"
                    placeholder="Descrição" ID="txtDescricao" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="O nome é obrigatório"
                    ControlToValidate="txtDescricao" runat="server" Display="None" />
                <br />
                <br />
                Categoria:
        <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="true"
            OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" /><br />
                Sub Categoria:
                 <asp:DropDownList runat="server" ID="ddlSubCategoria" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button Text="Limpar" runat="server" ID="btnLimpar" />
        <asp:Button Text="Salvar" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" />
    </fieldset>
</asp:Content>
