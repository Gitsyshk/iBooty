﻿Imports System.Management

Public Class Form1
    Public cmdline As String
    Public iDevice As String
    Public DFUConnected As Boolean = False
    Public RecoveryConnected As Boolean = False
    Public ResetDFU As Boolean = False
    Public killit As Boolean = False
    Public iWant2Exit As Boolean = False
    Public icountMatch As Integer
    Private WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Private WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Private WithEvents doit As System.ComponentModel.BackgroundWorker
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedItem = "Select your iDevice:"
        If File_Exists(Application.StartupPath & "\files\llb.3gs.dfu") = True Then
            ComboBox1.Items.Add("iPhone 3GS")
        End If
        If File_Exists(Application.StartupPath & "\files\llb.4.dfu") = True Then
            ComboBox1.Items.Add("iPhone 4")
        End If
        If File_Exists(Application.StartupPath & "\files\llb.ipt2g.dfu") = True Then
            ComboBox1.Items.Add("iPod Touch 2G")
        End If
        If File_Exists(Application.StartupPath & "\files\llb.ipt3.dfu") = True Then
            ComboBox1.Items.Add("iPod Touch 3G")
        End If
        If File_Exists(Application.StartupPath & "\files\llb.ipt4.dfu") = True Then
            ComboBox1.Items.Add("iPod Touch 4")
        End If
        If File_Exists(Application.StartupPath & "\files\llb.ipad.dfu") = True Then
            ComboBox1.Items.Add("iPad")
        End If
        If File_Exists(Application.StartupPath & "\files\notice.read") = False Then
            Init.Show()
            Init.BringToFront()
            Init.InitCount.Text = "10"
            Delay(1)
            Init.InitCount.Text = "9"
            Delay(1)
            Init.InitCount.Text = "8"
            Delay(1)
            Init.InitCount.Text = "7"
            Delay(1)
            Init.InitCount.Text = "6"
            Delay(1)
            Init.InitCount.Text = "5"
            Delay(1)
            Init.InitCount.Text = "4"
            Delay(1)
            Init.InitCount.Text = "3"
            Delay(1)
            Init.InitCount.Text = "2"
            Delay(1)
            Init.InitCount.Text = "1"
            Delay(1)
            Init.Hide()
            Try
                SaveToDisk("bla.nk", "files\notice.read")
            Catch Ex As Exception
            End Try
        End If
        Me.Hide()
        Label2.Left = (Me.Width / 2) - (Label2.Width / 2)
        Me.Show()
        Me.BringToFront()
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Process.Start("http://ih8sn0w.com")
    End Sub
    Public Sub CleanupDFU()
        dfuinstructions.Visible = False
        Prepare.Visible = False
        Button3.Visible = True
        Button3.Text = "Cancel"
        iWant2Exit = True
        Label2.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Blocks
        'Do what we gotta do =)
        Status.Text = "Exploiting with limera1n..."
        cmdline = Quote.Text & "files\s-irecovery.exe" & Quote.Text & " -e"
        ExecCmd(cmdline, True)
        ProgressBar1.Value = 50
        'Search for the return of the device...
        Status.Text = "Waiting for device..."
        Delay(3.5)
        BackgroundWorker3 = New System.ComponentModel.BackgroundWorker
        BackgroundWorker3.RunWorkerAsync()
    End Sub
    Public Sub UploadiBSS()
        Status.Text = "Uploading LLB..."
        cmdline = Quote.Text & "files\s-irecovery.exe" & Quote.Text & " -f " & Quote.Text & "files\llb." & iDevice & ".dfu" & Quote.Text
        ExecCmd(cmdline, True)
        Status.Text = "Booting..."
        Call UploadiBoot()
    End Sub
    Public Sub UploadiBoot()
        ProgressBar1.Value = 100
        iWant2Exit = False
        Button3.Visible = False
        Button3.Text = "Reset DFU Instructions"
        Button3.Enabled = True
        Delay(1)
        Status.Text = "Done! :) [3]"
        Delay(1)
        Status.Text = "Done! :) [2]"
        Delay(1)
        Status.Text = "Done! :) [1]"
        Delay(1)
        Call GoGoGadgetCleanUp()
    End Sub
    Public Sub DFUIntructions()
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Label2.Visible = False
        dfuinstructions.Visible = False
        Prepare.Visible = True
        Prepare.Text = "Prepare to press Power + Home (5)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to press Power + Home (4)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to press Power + Home (3)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to press Power + Home (2)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to press Power + Home (1)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Visible = False
        dfuinstructions.Visible = True
        dfuinstructions.Text = "Press the Power + Home Button! (10)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Press the Power + Home Button! (9)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Press the Power + Home Button! (8)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Press the Power + Home Button! (7)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Press the Power + Home Button! (6)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Visible = True
        Prepare.Text = "Prepare to release the Power but keep holding Home. (5)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        dfuinstructions.Text = "Press the Power + Home Button! (5)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to release the Power but keep holding Home. (4)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        dfuinstructions.Text = "Press the Power + Home Button! (4)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to release the Power but keep holding Home. (3)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        dfuinstructions.Text = "Press the Power + Home Button! (3)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Text = "Prepare to release the Power but keep holding Home. (2)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        dfuinstructions.Text = "Press the Power + Home Button! (2)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Press the Power + Home Button! (1)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Prepare.Text = "Prepare to release the Power but keep holding Home. (1)"
        Prepare.Left = (Me.Width / 2) - (Prepare.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Prepare.Visible = False
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (30)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (29)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (28)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (27)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (26)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (25)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (24)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (23)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (22)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (21)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (20)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (19)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (18)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (17)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (16)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (15)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (14)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (13)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (12)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (11)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (10)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (9)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (8)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (7)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (6)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (5)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (4)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (3)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (2)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If DFUConnected = True Then
            Call CleanupDFU()
            Exit Sub
        End If
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        dfuinstructions.Text = "Release the Power Button, but keep holding home! (1)"
        dfuinstructions.Left = (Me.Width / 2) - (dfuinstructions.Width / 2)
        Delay(1)
        If ResetDFU = True Then
            ResetDFU = False
            Call DFUIntructions()
            Exit Sub
        End If
        Call GoGoGadgetCleanUp()
        dfuinstructions.Visible = False
        MsgBox("You failed to Enter DFU. Please Try again.", MsgBoxStyle.Critical)
    End Sub
    Public Sub GoGoGadgetCleanUp()
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Value = 0
        Button1.Visible = True
        Label2.Visible = True
        Try
            BackgroundWorker1.CancelAsync()
            BackgroundWorker2.CancelAsync()
            BackgroundWorker3.CancelAsync()
        Catch ex As Exception
        End Try
        Button3.Visible = False
        Button3.Enabled = True
        Button3.Text = "Reset DFU Instructions"
        ComboBox1.Enabled = True
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("http://github.com/iH8sn0w/iBooty")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComboBox1.Enabled = False
        Status.Text = "Searching for DFU..."
        Button1.Visible = False
        Button3.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
        Call DFUIntructions()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If iWant2Exit = True Then
            iWant2Exit = False
            Button3.Enabled = False
            Status.Text = "Cancelling..."
            cmdline = "cmd /c taskkill /f /t /im files\s-irecovery.exe"
            ExecCmd(cmdline, True)
            killit = True
            Call GoGoGadgetCleanUp()
        Else
            ResetDFU = True
        End If
    End Sub
    Public Sub Search_DFU2(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        DFUConnected = False
        RecoveryConnected = False
        Do Until DFUConnected = True
            If killit = True Then
                killit = False
                Exit Sub
            End If
            'Searching for DFU...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("DFU") Then
                If killit = True Then
                    killit = False
                    Exit Sub
                End If
                Call UploadiBSS()
            End If
        Loop
    End Sub
    Public Sub Search_DFU(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        DFUConnected = False
        RecoveryConnected = False
        Do Until DFUConnected = True
            If killit = True Then
                killit = False
                Exit Sub
            End If
            'Searching for DFU...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("DFU") Then
                If killit = True Then
                    killit = False
                    Exit Sub
                End If
                'MsgBox("In DFU!", MsgBoxStyle.Information)
                DFUConnected = True
            End If
        Loop
    End Sub
    Public Sub Search_Recovery(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        DFUConnected = False
        RecoveryConnected = False
        Do Until RecoveryConnected = True
            If killit = True Then
                killit = False
                Exit Sub
            End If
            'Searching for Recovery...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (iBoot) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("iBoot") Then
                'MsgBox("In Recovery!", MsgBoxStyle.Information)
                RecoveryConnected = True
                If killit = True Then
                    killit = False
                    Exit Sub
                End If
                Call UploadiBoot()
            End If
        Loop
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Select your iDevice:" Then
            Button1.Enabled = False
            Button1.Text = "Select your iDevice!"
            iDevice = ""
            Me.Text = "iBooty 2.2 -- By: iH8sn0w"
            line.Visible = True
        ElseIf ComboBox1.SelectedItem = "iPhone 3GS" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "3gs"
            line.Visible = False
        ElseIf ComboBox1.SelectedItem = "iPhone 4" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "4"
            line.Visible = False
        ElseIf ComboBox1.SelectedItem = "iPod Touch 2G" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "ipt2g"
            line.Visible = False
        ElseIf ComboBox1.SelectedItem = "iPod Touch 3G" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "ipt3"
            line.Visible = False
        ElseIf ComboBox1.SelectedItem = "iPod Touch 4" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "ipt4"
            line.Visible = False
        ElseIf ComboBox1.SelectedItem = "iPad" Then
            Button1.Enabled = True
            Button1.Text = "Start"
            Me.Text = "iBooty 2.2 -- By: iH8sn0w" & " - [" & ComboBox1.SelectedItem & "]"
            iDevice = "ipad"
            line.Visible = False
        End If
    End Sub
End Class
