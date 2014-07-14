Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data
Public Class pelanggan
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
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnnOLEDB.Open()
        auto()

        BukaDB()
        cnnOLEDB.Open()

    End Sub
    Sub BukaDB()
        If cnnOLEDB.State = ConnectionState.Open Then
            cnnOLEDB.Close()
        End If
    End Sub
    Sub lagi()
        auto()
        BukaDB()
        cnnOLEDB.Open()
    End Sub
    Sub auto()
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        cmdInsert = New MySqlCommand("select no_order from tambah order by no_order desc", cnnOLEDB)
        rd = cmdInsert.ExecuteReader
        If rd.Read Then
            strSementara = Mid(rd.Item("no_order"), 2, 2)
            strIsi = Val(strSementara) + 1
            Label3.Text = "P" + Mid("0", 1, 2 - strIsi.Length) & strIsi
        Else
            Label3.Text = "P01"
        End If
    End Sub
    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = "0"
        TextBox3.Text = "0"
        ComboBox1.Text = ""
        TextBox4.Text = ""
        PictureBox1.Image = Nothing
        DataGridView1.DataMember = Nothing
    End Sub

    'Sub TampilData()
    'Tambahkan huruf T pada perintah select
    '    ADP = New MySqlDataAdapter("Select no_order,nama,harga,jumlah,meja From transaksi Where no_order =  '" & Label3.Text & "'", cnnOLEDB)
    '   DS = New DataSet
    '  ADP.Fill(DS, "Tabel1")
    ' DataGridView1.DataSource = DS.Tables("Tabel1")
    'End Sub



    Private Sub PictureBox2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='1'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '1'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try


    End Sub

    Private Sub PictureBox3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='2'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '2'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PictureBox5_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='3'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '3'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PictureBox4_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='4'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '4'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox7_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='5'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '5'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox6_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='6'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '6'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox9_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='7'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '7'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox8_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='8'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '8'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox11_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox11.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='9'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '9'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox10_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='10'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '10'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PictureBox12_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='11'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '11'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox13_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox13.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='12'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '12'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox14_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox14.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='13'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '13'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox15_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox15.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='14'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '14'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox16_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox16.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='15'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '15'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub


    Private Sub PictureBox17_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox17.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='16'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '16'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox18_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox18.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='17'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '17'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox19_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox19.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='18'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '18'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox20_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox20.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='19'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '19'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PictureBox21_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox21.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='20'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '20'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox22_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox22.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='21'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '21'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox23_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox23.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='22'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '22'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox24_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox24.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='23'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '23'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox25_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox25.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='24'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '24'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox26_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox26.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='25'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '25'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox27_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox27.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='26'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '26'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox28_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox28.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='27'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '27'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PictureBox29_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox29.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='28'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '28'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox30_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox30.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='29'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '29'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub PictureBox31_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox31.MouseClick
        ADP = New MySqlDataAdapter("Select Nama,Harga,Gambar from makanan where Nomor ='30'", cnnOLEDB)
        DS = New DataSet
        ADP.Fill(DS, "Tabel1")
        Dim B As DataTable = DS.Tables("Tabel1")
        TextBox1.Text = DS.Tables("Tabel1").Rows(0).Item(0).ToString()
        TextBox2.Text = DS.Tables("Tabel1").Rows(0).Item(1).ToString()
        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nomor = '30'", cnnOLEDB)
            'command.Parameters.AddWithValue("@NIM", CType(NIM, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)


            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            PictureBox17.Visible = False
            PictureBox18.Visible = False
            PictureBox19.Visible = False
            PictureBox20.Visible = False
            PictureBox21.Visible = False
            PictureBox22.Visible = False
            PictureBox23.Visible = False
            PictureBox24.Visible = False
            PictureBox25.Visible = False
            PictureBox26.Visible = False
            PictureBox27.Visible = False
            PictureBox28.Visible = False
            PictureBox29.Visible = False
            PictureBox30.Visible = False
            PictureBox31.Visible = False
            Label1.Text = "Menu Makanan"
            PictureBox1.Image = Nothing
            TextBox1.Text = ""
            TextBox2.Text = "0"

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            PictureBox17.Visible = True
            PictureBox18.Visible = True
            PictureBox19.Visible = True
            PictureBox20.Visible = True
            PictureBox21.Visible = True
            PictureBox22.Visible = True
            PictureBox23.Visible = True
            PictureBox24.Visible = True
            PictureBox25.Visible = True
            PictureBox26.Visible = True
            PictureBox27.Visible = True
            PictureBox28.Visible = True
            PictureBox29.Visible = True
            PictureBox30.Visible = True
            PictureBox31.Visible = True
            Label1.Text = "Menu Minuman"
            PictureBox1.Image = Nothing
            TextBox1.Text = ""
            TextBox2.Text = "0"
        End If
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim i As Integer = DataGridView1.Rows.Add()
        Dim x, z As Integer
        DataGridView1.Rows.Item(i).Cells("Nama").Value = TextBox1.Text
        DataGridView1.Rows.Item(i).Cells("Harga").Value = TextBox2.Text
        DataGridView1.Rows.Item(i).Cells("Jumlah").Value = TextBox3.Text
        DataGridView1.Rows.Item(i).Cells("Meja").Value = ComboBox1.Text
        DataGridView1.Rows.Item(i).Cells("Total").Value = TextBox4.Text
        For x = 0 To DataGridView1.RowCount - 2
            z = z + DataGridView1.Rows(x).Cells("Total").Value
            Label8.Text = z.ToString
        Next

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim nama As Object = DataGridView1.Rows(e.RowIndex).Cells("Nama").Value
        Dim harga As Object = DataGridView1.Rows(e.RowIndex).Cells("Harga").Value
        Dim jumlah As Object = DataGridView1.Rows(e.RowIndex).Cells("Jumlah").Value
        Dim meja As Object = DataGridView1.Rows(e.RowIndex).Cells("Meja").Value
        Dim total As Object = DataGridView1.Rows(e.RowIndex).Cells("Total").Value


        TextBox1.Text = CType(nama, String)
        TextBox2.Text = CType(harga, String)
        TextBox3.Text = CType(jumlah, String)
        ComboBox1.Text = CType(meja, String)
        TextBox4.Text = CType(total, String)

        Try
            Dim command As New MySqlCommand("select Gambar from makanan where Nama = '" & TextBox1.Text & "'", cnnOLEDB)
            command.Parameters.AddWithValue("@nama", CType(nama, String))
            Dim picturedata1 As Byte() = DirectCast(command.ExecuteScalar(), Byte())
            command.Dispose()
            Dim stream As New IO.MemoryStream(picturedata1)
            Me.PictureBox1.Image = Image.FromStream(stream)
            stream.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = (TextBox2.Text * TextBox3.Text)
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox4.Text = (TextBox2.Text * TextBox3.Text)
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" _
       And ComboBox1.Text <> "" Then

            Try
                For i = 0 To DataGridView1.RowCount - 2
                    cmdInsert.CommandText = "Insert Into tambah" & _
                   "(no_order, nama, harga, jumlah, meja, total)" & _
                   "Values (@no_order, @nama, @harga, @jumlah, @meja, @total)"
                    cmdInsert.Parameters.AddWithValue("@no_order", Me.Label3.Text)
                    cmdInsert.Parameters.AddWithValue("@nama", Me.DataGridView1.Rows(i).Cells("Nama").Value)
                    cmdInsert.Parameters.AddWithValue("@harga", Me.DataGridView1.Rows(i).Cells("Harga").Value)
                    cmdInsert.Parameters.AddWithValue("@jumlah", Me.DataGridView1.Rows(i).Cells("Jumlah").Value)
                    cmdInsert.Parameters.AddWithValue("@meja", Me.DataGridView1.Rows(i).Cells("Meja").Value)
                    cmdInsert.Parameters.AddWithValue("@total", Me.DataGridView1.Rows(i).Cells("Total").Value)
                    cmdInsert.CommandType = CommandType.Text
                    cmdInsert.Connection = cnnOLEDB
                    cmdInsert.ExecuteNonQuery()
                    cmdInsert.Parameters.Clear()
                    MsgBox("Data Berhasil Disimpan")
                Next

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Data Kurang Lengkap")
        End If
        cmdInsert.Dispose()
        bersih()
        lagi()

    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        Dim z As Integer
        For i = 0 To DataGridView1.RowCount - 2
            z = z + DataGridView1.Rows(i).Cells("Total").Value
            Label8.Text = z.ToString
        Next i
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        login.Show()
        Me.Visible = False
    End Sub
End Class
