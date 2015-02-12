<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaUsuario.aspx.cs" Inherits="ProjetoFinal_Financeiro.ListaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Código" ItemStyle-Width="100" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Login" HeaderText="Login" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="DataCriacao" HeaderText="Data Cadastro" />
            <asp:BoundField DataField="Cpf" HeaderText="CPF" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Editar" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Excluir" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
