<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoFinal_Financeiro.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Finança Pessoal - Log-in</title>
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    <link rel="stylesheet" href="css/style.css" media="screen" type="text/css" />
</head>
<body>
    <div class="login-card">
        <h1>Log-in</h1>
        <br>
        <form id="form1" runat="server">
            <asp:TextBox runat="server" name="user"
                placeholder="Usuário" ID="txtUsuario" />
            <asp:RequiredFieldValidator ErrorMessage="Informe o usuário"
                ControlToValidate="txtUsuario"
                runat="server" />
            <asp:TextBox runat="server" name="pass"
                placeholder="Senha" ID="txtSenha" TextMode="Password" />
            <asp:RequiredFieldValidator ErrorMessage="Informe a senha"
                ControlToValidate="txtSenha" runat="server" />
            <asp:Button ID="btnEntrar" Text="Entrar" OnClick="btnEntrar_Click"
                CssClass="login login-submit" runat="server" />
        </form>

        <div class="login-help">
            <a href="">Novo Usuário</a> • <a href="#">Esqueci minha senha</a>
        </div>
    </div>
    <!-- <div id="error"><img src="https://dl.dropboxusercontent.com/u/23299152/Delete-icon.png" /> Your caps-lock is on.</div> -->
    <script src='http://codepen.io/assets/libs/fullpage/jquery_and_jqueryui.js'></script>
</body>
</html>
