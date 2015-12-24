' Copyright (C) 2015 KByte (earlier ByteCrafter)
' This Is free software, And you are welcome to redistribute it
' under certain conditions; read the Readme-Redistribution.txt file!
Imports System.IO
Public Class MCPath
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists(Application.StartupPath & "settings.txt") = True Then
            Using fw As New IO.StreamWriter(Application.StartupPath & "\settings.txt")
                fw.WriteLineAsync(TextBox1.Text)
                fw.Close()
            End Using
            Me.Hide()
        Else
            MessageBox.Show("Fatal error while trying to save the settings: Settings file not found (settings.txt)! Restart MineMod Installer and then try again!", "An fatal error occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub TextBox1_DoubleClick(sender As Object, e As EventArgs) Handles TextBox1.DoubleClick
        Dim fbd As New FolderBrowserDialog
        With fbd
            .Description = "Select the folder where Minecraft is installed. Don't select the Mods path, only the installed Minecraft path!"
        End With

        If fbd.ShowDialog = DialogResult.OK Then
            TextBox1.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub MCPath_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class