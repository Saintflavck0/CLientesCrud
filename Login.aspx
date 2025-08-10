<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="CLientesCrud.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5" style="max-width: 400px;">
        <h2 class="mb-4">Iniciar Sesión</h2>

        <div class="mb-3">
            <label for="txtUsuario" class="form-label">Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label for="txtPassword" class="form-label">Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>

        <div class="mb-3">
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" />
    </div>
</asp:Content>
