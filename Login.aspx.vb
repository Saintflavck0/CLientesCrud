Imports System
Imports System.Web.UI

Partial Class Login
    Inherits System.Web.UI.Page

    Private repo As New Usuariorepository() ' Asume que tienes una clase para validar usuarios

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim usuario = txtUsuario.Text.Trim()
        Dim password = txtPassword.Text.Trim()

        If repo.ValidarCredenciales(usuario, password) Then
            Session("Usuario") = usuario
            Response.Redirect("Clientes.aspx")
        Else
            lblMensaje.Text = "Usuario o contraseña incorrectos."
        End If
    End Sub
End Class