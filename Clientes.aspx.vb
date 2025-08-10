Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Class Clientes
    Inherits System.Web.UI.Page

    Private repo As New ClienteRepository()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            CargarClientes()
        End If
    End Sub

    Private Sub CargarClientes()
        gvClientes.DataSource = repo.GetAll()
        gvClientes.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim cliente As New Cliente With {
            .Nombre = txtNombre.Text.Trim(),
            .Apellidos = txtApellidos.Text.Trim(),
            .Telefono = txtTelefono.Text.Trim(),
            .Correo = txtEmail.Text.Trim()
        }

        If String.IsNullOrEmpty(hfClienteId.Value) Then
            repo.Insert(cliente)
        Else
            cliente.ClienteId = Convert.ToInt32(hfClienteId.Value)
            repo.Update(cliente)
        End If

        LimpiarFormulario()
        CargarClientes()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        hfClienteId.Value = ""
        txtNombre.Text = ""
        txtApellidos.Text = ""
        txtTelefono.Text = ""
        txtEmail.Text = ""
    End Sub

    Protected Sub gvClientes_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvClientes.EditIndex = e.NewEditIndex
        CargarClientes()
    End Sub

    Protected Sub gvClientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvClientes.EditIndex = -1
        CargarClientes()
    End Sub

    Protected Sub gvClientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim clienteId As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)
        Dim row As GridViewRow = gvClientes.Rows(e.RowIndex)

        Dim nombre As String = CType(row.Cells(1).Controls(0), TextBox).Text.Trim()
        Dim apellidos As String = CType(row.Cells(2).Controls(0), TextBox).Text.Trim()
        Dim telefono As String = CType(row.Cells(3).Controls(0), TextBox).Text.Trim()
        Dim correo As String = CType(row.Cells(4).Controls(0), TextBox).Text.Trim()

        Dim cliente As New Cliente With {
            .ClienteId = clienteId,
            .Nombre = nombre,
            .Apellidos = apellidos,
            .Telefono = telefono,
            .Correo = correo
        }

        repo.Update(cliente)
        gvClientes.EditIndex = -1
        CargarClientes()
    End Sub

    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)
        repo.Delete(id)
        CargarClientes()
    End Sub
End Class