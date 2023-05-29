Imports System.Data.SqlClient

Public Class Form1
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Controls.Clear()
        InitializeComponent()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connectionString As String = "Data Source=Z4P5-062; Initial Catalog = login;Trusted_Connection = True;"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()

        Dim query As String = "SELECT * FROM login WHERE username = @username AND password = @password"
        Dim command As New SqlCommand(query, connection)

        command.Parameters.AddWithValue("@username", tbUsername.Text)
        command.Parameters.AddWithValue("@password", tbPassword.Text)

        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                Dim username As String = reader("username").ToString
                Dim password As String = reader("password").ToString
            End While
            MsgBox("Welcome!")
        Else
            MsgBox("Unidentified User!")
        End If
    End Sub
End Class
