Public Class Form1
    Dim geekenabled As Boolean = False
    Dim transnum As Integer = 1

    Dim orgwidth As Integer = 501
    Dim orggkpnl As Integer = 215

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowserForm.Close()

        WebBrowserForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebBrowserForm.CaptureForm()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim txtbx_enabled = False

        Select Case ComboBox1.SelectedIndex
            Case 1
                TextBox2.Text = "Mozilla/5.0 (Linux; Android 9.0; Z832 Build/MMB29M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Mobile Safari/537.36"
            Case 2
                TextBox2.Text = "Mozilla/5.0 (Linux; Android 9.0; SAMSUNG-SM-T377A Build/NMF26X) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Mobile Safari/537.36"
            Case 3
                txtbx_enabled = True
        End Select

        TextBox2.Enabled = txtbx_enabled
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Nothing Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        orgwidth = Width
        orggkpnl = GeekPanel.Width
        ComboBox1.SelectedIndex = 0

        Width = orgwidth - orggkpnl

        CenterToScreen()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://blog.pbj.kr")
    End Sub

    Private Sub anitime_Tick(sender As Object, e As EventArgs) Handles anitime.Tick
        If geekenabled = False Then
            If (Width + transnum <= orgwidth) Then
                transnum += dpicalc(Me, 2)
                Me.Width += transnum
            Else
                Width = orgwidth
                anitime.Stop()
                transnum = 1
                geekenabled = True
            End If
        Else
            If (Width - transnum >= orgwidth - orggkpnl) Then
                transnum += dpicalc(Me, 2)
                Me.Width -= transnum
            Else
                Width = orgwidth - orggkpnl
                anitime.Stop()
                transnum = 1
                geekenabled = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        anitime.Start()
    End Sub
End Class
