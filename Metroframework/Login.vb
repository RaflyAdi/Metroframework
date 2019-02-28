Imports Metroframework
Imports System.Data.OleDb
Public Class Login
    Sub clear()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox1.Focus()
    End Sub
    Private Sub Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MetroTextBox1.Focus()
        Call buka()
        adaptor = New OleDb.OleDbDataAdapter("select * from tb_login", koneksi)
        data = New DataSet
        data.Clear()
        adaptor.Fill(data, "tb_login")
        adaptor.Dispose()
    End Sub

    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        Call buka()
        cmd = New OleDbCommand
        cmd.CommandType = CommandType.Text
        cmd.Connection = koneksi

        str = "select * from tb_login where username = '" & MetroTextBox1.Text & "' and password = '" & MetroTextBox2.Text & "'"
        cmd.CommandText = str
            dr = cmd.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                MsgBox("Login Sukses Mas!", vbInformation)
                Me.Visible = False
                clear()
                halamanawalmula.Show()
        Else
            If MetroTextBox1.Text = "" And MetroTextBox2.Text = "" Then
                MessageBox.Show("Masukkan Username dan password terlebih dahulu mas!")
            Else
                MsgBox("Username / Password salah mas!")
                clear()
                MetroTextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub MetroPanel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MetroPanel1.Paint

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        buatuser.Show()
        Me.Hide()
    End Sub
End Class
