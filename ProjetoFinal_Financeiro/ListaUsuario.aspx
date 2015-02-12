<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ListaUsuario.aspx.cs" Inherits="ProjetoFinal_Financeiro.ListaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="false"
        DataKeyNames="ID"
        OnRowDeleting="gvUsuario_RowDeleting"
        OnRowCommand="gvUsuario_RowCommand"
        OnRowDataBound="gvUsuario_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Código" ItemStyle-Width="100" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Login" HeaderText="Login" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="DataCriacao" HeaderText="Data Cadastro" />
            <asp:BoundField DataField="Cpf" HeaderText="CPF" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton Text="Editar" ID="btnEditar"
                         runat="server" CommandName="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton Text="Excluir" runat="server" 
                        OnClientClick="return confirm('Deseja realmente excluir este usuário?');"
                        CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
