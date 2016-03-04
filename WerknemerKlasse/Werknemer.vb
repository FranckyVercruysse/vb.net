Imports System.Drawing

Public Class Werknemer
    'om drawing surface te beheren
    Private G As Graphics
    Private FotoBox As New Rectangle(5, 5, 150, 200)
    Private InfoBox As New Rectangle(160, 5, 250, 200)

    'Werknemer PROPERTIES
    Public Voornaam As String
    Public Naam As String
    Public Afdeling As String
    Public Aantekeningen As String
    Public Status As WerknemerStatus
    'Foto van de werknemer
    Public Foto As Image


    Public Enum WerknemerStatus
        Actief
        Beëindigd
    End Enum

    'wanneer een nieuwe instance van de klasse Werknemer gemaakt wordt... (constructor)
    Public Sub New(GFX As Graphics, VNaam As String, FamilieNaam As String, Afd As String, Aantek As String, Status As Integer, Optional WerknemerFoto As Image = Nothing)
        G = GFX

        Voornaam = VNaam
        Naam = FamilieNaam
        Afdeling = Afd
        Aantekeningen = Aantek

        Select Case Status
            Case 0
                Status = WerknemerStatus.Actief
            Case 1
                Status = WerknemerStatus.Beëindigd
            Case Else
                Status = WerknemerStatus.Actief

        End Select

        Foto = WerknemerFoto
    End Sub

    Public Sub Draw()
        'Wis Drawing Surface
        G.Clear(Color.FromName("Control"))      'kleur van form Form1

        'Werknemer foto box
        G.FillRectangle(Brushes.AliceBlue, FotoBox)
        G.DrawRectangle(Pens.Black, FotoBox)

        If Foto IsNot Nothing Then
            G.DrawImage(Foto, New Rectangle(FotoBox.X + 1, FotoBox.Y + 1, FotoBox.Width - 1, FotoBox.Height - 1))

        End If

        'Info Werknemer
        G.FillRectangle(Brushes.Lavender, InfoBox)
        G.DrawRectangle(Pens.Black, InfoBox)

        G.DrawString("" &
            "Naam Werknemer : " & Voornaam & " " & Naam & vbCrLf &
            "Status Werknemer : " & Status.ToString & vbCrLf &
            "Afdeling : " & Afdeling & vbCrLf &
            "Aantekening : " & Aantekeningen, New Font("Tahoma", 9), Brushes.Black, New Point(InfoBox.X + 5, InfoBox.Y + 5))
    End Sub
End Class
