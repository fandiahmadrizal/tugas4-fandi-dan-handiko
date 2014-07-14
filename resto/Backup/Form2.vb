Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data
Public Class Form2
    Dim serv As String = "Server=localhost" & ";"
    Dim dbase As String = "Database=resto" & ";"
    Dim uid As String = "uid=root" & ";"
    Dim pwd As String = "pwd=bintang123" & ";"
    Dim ConString = serv & dbase & uid & pwd & "default command timeout=3600; Allow User Variables=true"
    Public cnnOLEDB As New MySqlConnection(ConString)
    'Dim cmdOLEDB As New OdbcCommand 'eksekusi query
    Public cmdInsert As MySqlCommand 'eksekusi query
    Public cmdUpdate As MySqlCommand
    Public cmdDelete As New MySqlCommand
    Public ADP As MySqlDataAdapter 'untuk menampilkan pada grid view
    Public rd As MySqlDataReader
    Public DS As New DataSet
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnnOLEDB.Open()
        auto()

        BukaDB()
        cnnOLEDB.Open()
        Tampil()
        combo1()
    End Sub
    Sub BukaDB()
        If cnnOLEDB.State = ConnectionState.Open Then
            cnnOLEDB.Close()
        End If
    End Sub
    Sub auto()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        cmdInsert = New MySqlCommand("select no_trans from kasir order by no_trans desc", cnnOLEDB)
        rd = cmdInsert.ExecuteReader
        If rd.Read Then
            strSementara = Mid(rd.Item("no_trans"), 2, 2)
            strIsi = Val(strSementara) + 1
            Label5.Text = "K" + Mid("0", 1, 2 - strIsi.Length) & strIsi
        Else
            Label5.Text = "K01"
        End If
    End Sub
    Sub Tampil()
        ADP = New MySqlDataAdapter("Select * from tambah", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        DataGridView1.DataSource = DS.Tables("Tabel1")
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub
    Sub combo1()
        ADP = New MySqlDataAdapter("Select distinct no_order from tambah order by no_order desc", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim N As DataTable = DS.Tables("Tabel1")
        ComboBox1.DataSource = N
        ComboBox1.ValueMember = "no_order"
        ComboBox1.Text = "Pilih"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ADP = New MySqlDataAdapter("Select sum(total) from tambah where no_order = '" & ComboBox1.Text & "'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox3.Text = TextBox1.Text - TextBox2.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            cmdInsert.CommandText = "Insert Into kasir" & _
           "(no_trans, no_order,jumlah_uang,total_bayar,kembalian)" & _
           "Values (@no_trans, @no_order, @jumlah_uang, @total_bayar, @kembalian)"
            cmdInsert.Parameters.AddWithValue("@no_trans", Me.Label5.Text)
            cmdInsert.Parameters.AddWithValue("@no_order", Me.ComboBox1.Text)
            cmdInsert.Parameters.AddWithValue("@jumlah_uang", Me.TextBox1.Text)
            cmdInsert.Parameters.AddWithValue("@total_bayar", Me.TextBox2.Text)
            cmdInsert.Parameters.AddWithValue("@kembalian", Me.TextBox3.Text)
            cmdInsert.CommandType = CommandType.Text
            cmdInsert.Connection = cnnOLEDB
            cmdInsert.ExecuteNonQuery()
            cmdInsert.Parameters.Clear()
            MsgBox("Data Berhasil Disimpan")

        Catch ex As Exception
            MsgBox("Data Kurang Lengkap")
        End Try

        cmdInsert.Dispose()
    End Sub
End Class