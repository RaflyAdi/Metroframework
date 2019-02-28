Imports System.Data.OleDb
Public Class halamanawalmula
    Sub panggildata()
        adaptor = New OleDb.OleDbDataAdapter("SELECT * FROM tb_login", koneksi)
        data = New DataSet
        data.Clear()
        adaptor.Fill(data, "tb_login")
        MetroGrid1.DataSource = (data.Tables("tb_login"))
        MetroGrid1.ReadOnly = True
    End Sub
    Private Sub halamanawalmula_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub

    Private Sub MetroTextBox1_TextChanged(sender As Object, e As System.EventArgs) Handles MetroTextBox1.TextChanged
        adaptor = New OleDbDataAdapter("select * from tb_login where username like '%" & MetroTextBox1.Text & "%' order by username asc", koneksi)
        data = New DataSet
        data.Clear()
        adaptor.Fill(data, "tb_login")
        MetroGrid1.DataSource = (data.Tables("tb_login"))
        MetroGrid1.ReadOnly = True
    End Sub

    Private Sub MetroButton1_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton1.Click
        If MessageBox.Show("Apakah anda yakin ingin menghapus Username " + MetroTextBox1.Text, "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cmd = New OleDbCommand("delete from tb_login where username = '" & MetroTextBox1.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            Call panggildata()
            MetroTextBox1.Focus()
            MetroTextBox1.Text = ""
        Else
            Call panggildata()
            MetroTextBox1.Focus()
        End If
    End Sub

    Private Sub MetroLabel1_Click(sender As System.Object, e As System.EventArgs) Handles MetroLabel1.Click
        If MessageBox.Show("Apakah Anda Yakin ingin Log out ", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub MetroTextBox1_Click(sender As System.Object, e As System.EventArgs) Handles MetroTextBox1.Click

    End Sub

    Private Sub MetroGrid1_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MetroGrid1.RowHeaderMouseClick
        Dim i As Integer
        i = MetroGrid1.CurrentRow.Index
        MetroTextBox4.Text = MetroGrid1.Item(0, i).Value
        MetroTextBox2.Text = MetroGrid1.Item(1, i).Value
        MetroTextBox3.Text = MetroGrid1.Item(2, i).Value
    End Sub

    Private Sub MetroButton2_Click(sender As System.Object, e As System.EventArgs) Handles MetroButton2.Click
        Dim sql As String
        sql = "update tb_login set password='" & MetroTextBox2.Text & "', email='" & MetroTextBox3.Text & "' where username='" & MetroTextBox4.Text & "'"
        MsgBox("data behasil diubah")
        Call panggildata()
    End Sub
End Class