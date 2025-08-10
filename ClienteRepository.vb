Imports System.Data.SqlClient
Imports System.Configuration

Public Class ClienteRepository
    Private ReadOnly connStr As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString

    Public Function GetAll() As List(Of Cliente)
        Dim lista As New List(Of Cliente)
        Try
            Using conn As New SqlConnection(connStr)
                Dim cmd As New SqlCommand("SELECT * FROM Clientes", conn)
                conn.Open()
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        lista.Add(New Cliente With {
                            .ClienteId = Convert.ToInt32(reader("ClienteId")),
                            .Nombre = reader("Nombre").ToString(),
                            .Apellidos = reader("Apellidos").ToString(),
                            .Telefono = reader("Telefono").ToString(),
                            .Correo = reader("Correo").ToString()
                        })
                    End While
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener clientes: " & ex.Message)
        End Try
        Return lista
    End Function

    Public Sub Insert(cliente As Cliente)
        Try
            Using conn As New SqlConnection(connStr)
                Dim cmd As New SqlCommand("INSERT INTO Clientes (Nombre, Apellidos, Telefono, Correo) VALUES (@Nombre, @Apellidos, @Telefono, @Correo)", conn)
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre)
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al insertar cliente: " & ex.Message)
        End Try
    End Sub

    Public Sub Update(cliente As Cliente)
        Try
            Using conn As New SqlConnection(connStr)
                Dim cmd As New SqlCommand("UPDATE Clientes SET Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, Correo=@Correo WHERE ClienteId=@Id", conn)
                cmd.Parameters.AddWithValue("@Id", cliente.ClienteId)
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre)
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar cliente: " & ex.Message)
        End Try
    End Sub

    Public Sub Delete(id As Integer)
        Try
            Using conn As New SqlConnection(connStr)
                Dim cmd As New SqlCommand("DELETE FROM Clientes WHERE ClienteId=@Id", conn)
                cmd.Parameters.AddWithValue("@Id", id)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al eliminar cliente: " & ex.Message)
        End Try
    End Sub
End Class
