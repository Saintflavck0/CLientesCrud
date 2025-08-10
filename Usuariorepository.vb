Public Class Usuariorepository
    Public Function ValidarCredenciales(usuario As String, password As String) As Boolean
        Return usuario = "admin" AndAlso password = "1234"
    End Function
End Class
