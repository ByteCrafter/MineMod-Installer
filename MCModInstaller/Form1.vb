' Copyright (C) 2015 KByte (earlier ByteCrafter)
' This is free software, and you are welcome to redistribute it
' under certain conditions; read the Readme-Redistribution.txt file!
Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Dim mcpath_ As String = File.ReadAllText(Application.StartupPath & "\settings.txt").ToString 'Reads the settings file where the path is stored  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog 'Declaring the Mod file selector dialog (openfiledialog)
        With ofd
            .Title = "Add Minecraft Mods"
            .Filter = "Minecraft Mod File (*.jar)|*.jar" 'Currently only supports Jar file mods, support for zip comes soon!
        End With

        If ofd.ShowDialog = DialogResult.OK Then 'If the dialog closes with exit code 'Ok' then add the selected mod
            ListBox1.Items.Add(ofd.FileName.ToString)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MCPath.ShowDialog() 'Shows the settings dialog for choosing the installed Minecraft path
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            For Each i As String In ListBox1.Items 'For each Items (Added Mods) install them
                IO.File.Move(i, IO.Path.Combine(mcpath_.Trim, "mods", IO.Path.GetFileName(i)))
            Next
            MessageBox.Show("The added/selected Mods has been successfully installed!", "Successfully installed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Beep()
        Catch ex As Exception
            MessageBox.Show("An error occured while trying to install the selected/added Mods! Full message: " & ex.Message, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If mcpath_ = "" Then
            Label5.Text = "Not set!"
            Label5.ForeColor = Color.Red
            MCPath.TextBox1.Text = ""
        Else
            Label5.Text = mcpath_ 'Sets text from the settings file
            If Label5.Text.Length > 30 Then 'If path is too long, add at the 30th char an triple dot at the end
                Label5.Text = String.Concat(Label5.Text.Substring(0, 30), "...")
            End If
            MCPath.TextBox1.Text = mcpath_ 'Sets text from the settings file
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        ListBox1.Items.Remove(ListBox1.SelectedItem) 'If double clicked on an item, it will remove the selected item
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        MessageBox.Show("Full path: " & mcpath_, "Full path", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Full path if the path is too long to display
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        About.ShowDialog() 'Shows the About dialog
    End Sub
End Class
