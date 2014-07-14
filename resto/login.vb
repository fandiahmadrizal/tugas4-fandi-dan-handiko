Imports MySql.Data.MySqlClient
Public Class login
    Dim serv As String = "Server=localhost" & ";"
    Dim dbase As String = "Database=resto" & ";"
    Dim uid As String = "uid=root" & ";"
    Dim pwd As String = "pwd=" & ";"
    Dim ConString = serv & dbase & uid & pwd & "default command timeout=3600; Allow User Variables=true"
    Public cnnOLEDB As New MySqlConnection(ConString)
    'Dim cmdOLEDB As New OdbcCommand 'eksekusi query
    Public cmdInsert As MySqlCommand 'eksekusi query
    Public cmdUpdate As MySqlCommand
    Public cmdDelete As New MySqlCommand
    Public ADP As MySqlDataAdapter 'untuk menampilkan pada grid view
    Public rd As MySqlDataReader
    Public DS As New DataSet

    Sub login()
        cnnOLEDB.Open()
        cmdInsert = New MySqlCommand("select status from user WHERE nama_user ='" & T_nama_user.Text & "' AND password = '" & T_password.Text & "' ", cnnOLEDB)
        Dim reader As MySqlDataReader = cmdInsert.ExecuteReader()
        While reader.Read()
            T_Status.Text = (reader("status"))
        End While
        cnnOLEDB.Close()
    End Sub


    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        T_password.PasswordChar = "*"
    End Sub

    Private Sub ButtonLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogin.Click
        login()
        If T_Status.Text = "pelanggan" Then
            pelanggan.Show()
            Me.Hide()
        ElseIf T_Status.Text = "kasir" Then
            kasir.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub T_nama_user_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_nama_user.TextChanged

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        about.Show()
        Me.Visible = False
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        contact.Show()
        Me.Visible = False
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        how.Show()
        Me.Visible = False
    End Sub
End Class