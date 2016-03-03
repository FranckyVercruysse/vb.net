Public Class Form1
    Dim eenWerknemer As Werknemer
    Dim fotoPad As String

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        MaakWerknemer("Jonas", "Vercruysse", "Administratie", "Dit is een ervaren programmeur", 0)
    End Sub

    Private Sub MaakWerknemer(Voornaam As String, Familienaam As String, Afdeling As String, Aantekeningen As String, Status As Integer)
        If MsgBox("Wilt u een foto toevoegen ?", MsgBoxStyle.YesNo, "Foto toevoegen") = MsgBoxResult.Yes Then
            OFDFoto.ShowDialog()
        End If

        If fotoPad = "" Then
            eenWerknemer = New Werknemer(Me.CreateGraphics, Voornaam, Familienaam, Afdeling, Aantekeningen, Status)
        Else
            Dim oImg As Image = Image.FromFile(fotoPad)
            eenWerknemer = New Werknemer(Me.CreateGraphics, Voornaam, Familienaam, Afdeling, Aantekeningen, Status, oImg)
        End If

        If eenWerknemer IsNot Nothing Then
            eenWerknemer.Draw()
        End If
    End Sub

    Private Sub OFDFoto_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OFDFoto.FileOk
        fotoPad = OFDFoto.FileName
    End Sub
End Class
