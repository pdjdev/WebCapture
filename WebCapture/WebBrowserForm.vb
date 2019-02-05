Public Class WebBrowserForm
    Dim tmpimg As Bitmap

    'Private Enum Exec
    '    OLECMDID_OPTICAL_ZOOM = 63
    'End Enum
    'Private Enum ExecOpt
    '    OLECMDEXECOPT_DODEFAULT = 0
    '    OLECMDEXECOPT_PROMPTUSER = 1
    '    OLECMDEXECOPT_DONTPROMPTUSER = 2
    '    OLECMDEXECOPT_SHOWHELP = 3
    'End Enum

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        'Dim zoomint As System.Int32 = Convert.ToInt32(Form1.numupdown_zoom.Value)

        'Try
        ' Dim Res As Object = Nothing
        ' Dim MyWeb As Object
        ' MyWeb = Me.WebBrowser1.ActiveXInstance
        ' MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM,
        ' ExecOpt.OLECMDEXECOPT_DONTPROMPTUSER, zoomint, IntPtr.Zero)
        ' Catch ex As Exception
        ' MsgBox("Error:" & ex.Message)
        ' End Try

        Form1.Button2.Enabled = True
        'Timer1.Start()
        Beep()
    End Sub

    Function ScanImg()
        Dim tmpImg As New Bitmap(Width, Height)

        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Width, Height))
        End Using

        Return tmpImg
    End Function

    Private Sub WebBrowserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Width = Form1.numupdown_x.Value
        Height = Form1.numupdown_y.Value

        WebBrowser1.ScriptErrorsSuppressed = Form1.CheckBox1.Checked

        If Form1.ComboBox1.SelectedIndex = 0 Then
            WebBrowser1.Navigate(Form1.TextBox1.Text)
        Else
            WebBrowser1.Navigate(Form1.TextBox1.Text, "_self", Nothing, "User-Agent: " + Form1.TextBox2.Text)
        End If

        '"Connection: Keep-Alive" + Chr(10) + Chr(13) + "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8" + Chr(10) + Chr(13)
        CenterToScreen()
        Form1.Activate()
    End Sub

    Public Sub CaptureForm()
        TopMost = True

        tmpimg = ScanImg()

        TopMost = False

        SaveFileDialog1.FileName = WebBrowser1.DocumentTitle
        Dim filedialog = SaveFileDialog1.ShowDialog()

        If filedialog = DialogResult.OK Then
            tmpimg.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub WebBrowserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.TopMost = False
        Form1.Button2.Enabled = False
    End Sub

    Private Sub WebBrowserForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Form1.TopMost = True
    End Sub
End Class