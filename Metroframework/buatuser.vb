Imports Metroframework
Imports System.Data.OleDb
Public Class buatuser
    Sub clear()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox1.Focus()
    End Sub
    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        Login.Visible = True
        Me.Close()
    End Sub

    Private Sub buatuser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call buka()
        adaptor = New OleDb.OleDbDataAdapter("select * from tb_login", koneksi)
        data = New DataSet
        data.Clear()
        adaptor.Fill(data, "tb_login")
        adaptor.Dispose()
        data.Dispose()
        koneksi.Close()
    End Sub

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        Call buka()
        If MetroTextBox1.Text = "" Or MetroTextBox2.Text = "" Or MetroTextBox3.Text = "" Then
            MsgBox("Data belum lengkap mas!")
            MetroTextBox1.Focus()
            Exit Sub
        Else
            Call buka()
            str = "select * from tb_login where username = '" & MetroTextBox1.Text & "'"
            cmd = New OleDbCommand
            cmd.Connection = koneksi
            cmd.CommandText = str
            dr = cmd.ExecuteReader()
            dr.Read()
            If Not dr.HasRows Then
                str = "insert into tb_login values('" & MetroTextBox1.Text & "', '" & MetroTextBox2.Text & "', '" & MetroTextBox3.Text & "')"
                cmd = New OleDbCommand(str, koneksi)
                cmd.ExecuteReader()
                MsgBox("Registrasi Berhasil mas!")
                Login.Visible = True
                Me.Close()
            Else
                MetroTextBox1.Text = ""
                MsgBox("Username sudah digunakan !")
                MetroTextBox1.Focus()
            End If
        End If
    End Sub
End Class