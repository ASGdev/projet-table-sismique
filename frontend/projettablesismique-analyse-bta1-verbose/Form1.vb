Imports System.IO
Imports System.Drawing
Imports System.Console
Imports System.IO.Compression
Imports System.Threading


Public Class Form1

    Dim chemin As String
    Dim verification As String
    Dim reader As StreamReader
    Dim writer As StreamWriter
    Dim compteur_nom_fichier As Integer

    Dim i As Integer = 0
    Dim linecount As Integer
    Dim largeur As Integer
    Dim longueur As Integer
    Dim array() As String
    Dim k As Integer
    Public x, y As Integer
    Public nombre_frames_vis As Integer

    Dim compteur_frames As Integer

    Dim valeur_trackbar_actuelle As Integer

    Dim thread_amplitude As System.Threading.Thread = New System.Threading.Thread(AddressOf get_amplitude)
    Dim thread_analyse As System.Threading.Thread = New System.Threading.Thread(AddressOf lecture_analyse_fichier)

    Dim amplitude As Integer

    Declare Function AttachConsole Lib "kernel32.dll" (dwProcessId As Int32) As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        _start_analyse()
    End Sub

    Sub _start_analyse()
        Console.WriteLine("... lancment de vérification du fichier")
        verification_fichier(False, "")
    End Sub
    Sub verification_fichier(ByVal opened As Boolean, ByVal chemin As String)
        '=========== reedit
        OpenFileDialog1.Title = "Ouvrir un fichier .vis"
        OpenFileDialog1.Filter = "Fichier données (*.vis)|*.vis"
        OpenFileDialog1.FileName = "data.vis"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            chemin = OpenFileDialog1.FileName

            'lis l'entête du fichier pour reconnaitre un fichier créer par le backend
            'MsgBox(opened)
            'MsgBox(chemin)
            'MsgBox("lala")
            Dim lignes As String() = IO.File.ReadAllLines(chemin)
            verification = lignes(0)
            Console.WriteLine("Le chemin du fichier est : " & chemin)
            Console.WriteLine("> le fichier s'est ouvert correctement")
            'implemté a cause de thread // annulé!
            'chemin = 
            '--
            'MsgBox(verification)
            _analyse_fichier(chemin)
            If verification <> "#rapportvision#" Then
                MsgBox("Le fichier ne peut être ouvert (code #02)")
                Console.WriteLine("! Le fichier ne peut être ouvert")
            End If
        End If

        '=========== fin reedit


        'If opened = False Then
        '    OpenFileDialog1.Title = "Ouvrir un fichier .vis"
        '    OpenFileDialog1.Filter = "Fichier données (*.vis)|*.vis"
        '    OpenFileDialog1.FileName = ""
        '    OpenFileDialog1.ShowDialog()
        'End If

        'If opened = True Then
        '    'lis l'entête du fichier pour reconnaitre un fichier créer par le backend
        '    'MsgBox(opened)
        '    'MsgBox(chemin)
        '    'MsgBox("lala")
        '    Dim lignes As String() = IO.File.ReadAllLines(chemin)
        '    verification = lignes(0)
        '    Console.WriteLine("Le chemin du fichier est : " & chemin)
        '    Console.WriteLine("> le fichier s'est ouvert correctement")

        '    'MsgBox(verification)
        '    If verification <> "#rapportvision#" Then
        '        MsgBox("Le fichier ne peut être ouvert (code #02)")
        '        Console.WriteLine("! Le fichier ne peut être ouvert")
        '    End If
        'End If

        'lecture_analyse_fichier(chemin) > avant implementation thread


    End Sub

    'Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    '    Try
    '        chemin = OpenFileDialog1.FileName
    '        'MsgBox(chemin)
    '        'verification_fichier(True, chemin)

    '        verification_fichier(True, chemin)

    '    Catch ex As Exception
    '        'MsgBox("Désolé, une erreur s'est produite (code #01)")
    '        MsgBox(ex.ToString)
    '        Console.WriteLine("! Une erreur s'est produite lors de l'ouverture du fichier !")
    '    End Try

    'End Sub

    Sub end_handler()
        'create new frame
        'save image
        'clear imagebox
        'move trackbar
        Console.WriteLine("... execution end_handler")
        Dim prefixe_nom_fichier As String = "frame"

        Dim nom_fichier As String
        nom_fichier = prefixe_nom_fichier + compteur_nom_fichier.ToString
        MsgBox(nom_fichier)

        'PictureBox2.Image.Save(nom_fichier, System.Drawing.Imaging.ImageFormat.Png)

        compteur_nom_fichier = compteur_nom_fichier + 1


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        end_handler()
    End Sub

    Sub lecture_analyse_fichier(ByVal chemina As Object) 'essayer avec string!
        '--- pour le thread (A REGLER)...ou pas!
        chemin = Convert.ToString(chemina)
        'MsgBox("chemin " & chemin)
        Dim lignes As String() = IO.File.ReadAllLines(chemin)
        linecount = lignes.Length
        'MsgBox(linecount)
        'MsgBox("Ici")
        Console.WriteLine("...Parsing en cours...")
        Do Until i = linecount '-2 because of linecount overflow (reedit: ?)
            'MsgBox("i " & i)
            Dim ligne As String = lignes(i)
            'MsgBox("ligne:  " & ligne)

            Select Case i
                Case 0
                    'MsgBox("Ok")
                Case 1
                    largeur = Convert.ToInt32(ligne)
                    'MsgBox(largeur)
                Case 2
                    longueur = Convert.ToInt32(ligne)
                    'MsgBox(longueur)
                Case 3
                    nombre_frames_vis = Convert.ToInt32(ligne)
                    'MsgBox("ici " & nombre_frames_vis)

                Case Else
                    If ligne.Contains("#frame") Then
                        comptage_nombre_frame2()
                    ElseIf ligne.Contains("#end") Then
                        fin_analyse()

                    Else
                        array = Split(ligne, ",")
                        x = array(0)
                        'MsgBox(x)
                        y = array(1)
                        'MsgBox(y)
                        'init_dessin(fin, x, y)
                        paint_module.dessin_frame(x, y)
                    End If

            End Select


            i = i + 1
        Loop

        If compteur_frames <> nombre_frames_vis Then
            Console.WriteLine(compteur_frames & " vs " & nombre_frames_vis)
            MsgBox("Erreur lors de l'ouverture (code #03)")
            Console.WriteLine("! Erreur lors de l'ouverture du fichier (#003) !")
            error_handler(3)
        Else
            Console.WriteLine("> tests passés avec succès")
            'MsgBox("Ici2")
            passage_analyse(nombre_frames_vis)
        End If


    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    chemin = "C:\Users\Samsung\Desktop\data.vis"
    '    lecture_analyse_fichier(chemin)
    'End Sub


    'Sub comptage_nombre_frame(ByVal chemin As String)
    '    Dim lignes As String() = IO.File.ReadAllLines(chemin)
    '    Do Until i = linecount '-2 because of linecount overflow
    '        Dim ligne As String = lignes(i)
    '        If ligne.Contains("#end") Then
    '            compteur_frames = compteur_frames + 1
    '        End If
    '        i = i + 1
    '    Loop

    '    MsgBox("number of frames: " & compteur_frames)
    'End Sub


    Sub comptage_nombre_frame2()
        compteur_frames = compteur_frames + 1
        MsgBox(compteur_frames)
        Console.WriteLine("actual frame number: " & compteur_frames)
        paint_module.creation_frame(longueur, largeur, compteur_frames)
    End Sub

    Sub error_handler(ByVal error_id As Integer)
        Select Case error_id
            Case 3
                MsgBox("Le fichier semble corrompu." & vbCrLf & "Vous pouvez le réparer manuellement en cliquant sur le lien.", MsgBoxStyle.Critical, "Fichier corrompu")
        End Select
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim _image As String = "frame"
        Dim compteur As Integer = "0"
        MsgBox(nombre_frames_vis)
        TrackBar1.Value = 0
        For i As Integer = 0 To nombre_frames_vis - 1
            Dim file As String = _image + compteur.ToString
            'frame_actuelle.Image = Image.FromFile(file)
            compteur = compteur + 1
            TrackBar1.Value = TrackBar1.Value + 1
        Next



    End Sub



    Sub passage_analyse(ByVal nbr_frame As Integer)
        TabControl1.SelectTab(1)
        Label1.Text = nbr_frame.ToString

        '----
        TrackBar1.Maximum = nbr_frame
        TrackBar1.TickFrequency = 1
        '----

        valeur_trackbar_actuelle = 0


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TrackBar1.Value < nombre_frames_vis Then
            TrackBar1.Value = TrackBar1.Value + 1
        End If
    End Sub



    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        Label2.Text = TrackBar1.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TrackBar1.Value > 0 Then
            TrackBar1.Value = TrackBar1.Value - 1
        End If
    End Sub
    Sub _get_amplitude(ByVal done As Boolean)

        worker()

        Try
            thread_amplitude.Start()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try


    End Sub

    Sub fin_get_amplitude()
        thread_amplitude.Join(1000)
        Console.WriteLine("Thread exécuté correctement...")
        Console.WriteLine("Thread arrêté.")
        dispose_worker()
        MsgBox("L'amplitude est de " & amplitude)
    End Sub


    Sub get_amplitude()

        Console.WriteLine("... execution : analyse de l'amplitude")
        'MsgBox(largeur)
        'MsgBox(longueur)
        '---
        largeur = 50
        longueur = 50
        '---
        Dim x, y As Integer
        Dim xmin As Integer = 0
        Dim xmax As Integer = 0
        Dim __image As Bitmap
        Dim __color As Color
        __image = Image.FromFile("minmax.png")


        For x = 0 To largeur - 1
            For y = 0 To longueur - 1
                __color = __image.GetPixel(x, y)
                Console.WriteLine(x & "" & y)
                Console.WriteLine("color: " & __color.ToString)
                If __color = Color.FromArgb(255, 0, 0, 0) Then
                    Console.WriteLine("Couleur trouvee")
                    If xmin = 0 Then
                        xmin = x
                    Else
                        xmax = x
                    End If


                End If

            Next
        Next

        Console.WriteLine("xmin " & xmin)
        Console.WriteLine("xmax " & xmax)

        amplitude = xmax - xmin
        Console.WriteLine("amplitude = " & amplitude)
        Console.WriteLine("thread id: " & System.Threading.Thread.CurrentThread.ThreadState)

        fin_get_amplitude()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        _get_amplitude(False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Console.WriteLine("Application de supervision de la table sismique")
        Console.WriteLine("Version beta 0.4 - Copyright 2014 ASGdev")
        Console.WriteLine("==== Lancement du programme ====")
        Label2.Text = "0"
        Panel1.Hide()
        Panel2.Hide()
        Me.TabPage3.Update()
        Button12.Enabled = False
        Dim dossier_temp_frames As DirectoryInfo = Directory.CreateDirectory("temp")

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim nom_dossier As String
        Dim path, _path As String

        nom_dossier = InputBox("Saisir le nom du dossier pour l'export", "Avant tout")
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            path = FolderBrowserDialog1.SelectedPath
        End If
        _path = path + "\" + nom_dossier
        Console.WriteLine("path: " & _path)
        Dim dossier_enregistrement As DirectoryInfo = Directory.CreateDirectory(_path)

        Console.WriteLine("Dossier d'enregistrement: " & FolderBrowserDialog1.SelectedPath.ToString)

    End Sub



    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        Console.WriteLine("* Entrée dans le module d'export")
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        Console.WriteLine("* Entrée dans le module d'acceuil")
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Console.WriteLine("* Entrée dans le module de traitement")
    End Sub
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        Console.WriteLine("* Entrée dans le module d'analyse")
    End Sub

    'Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    '    Dim nom_dossier As String
    '    Dim path, _path As String

    '    nom_dossier = InputBox("Saisir le nom du dossier pour l'export", "Avant tout")
    '    If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
    '        path = FolderBrowserDialog1.SelectedPath
    '    End If
    '    _path = path + "\" + nom_dossier
    '    Console.WriteLine("path: " & _path)
    '    Dim dossier_enregistrement As DirectoryInfo = Directory.CreateDirectory(_path)

    '    Console.WriteLine("Dossier d'enregistrement: " & FolderBrowserDialog1.SelectedPath.ToString)

    '    'faire enregistrer le dossier

    '    ZipFile.CreateFromDirectory(_path, path)
    '    Console.WriteLine("Fichier zip, crée sous: " & path)


    'End Sub

    Private Delegate Sub workerDelegate()

    Sub worker()

        Me.Panel1.Show()
        Console.WriteLine("Thread 1 exécuté...")

        pb_worker.Style = ProgressBarStyle.Marquee
        pb_worker.MarqueeAnimationSpeed = 35

        Me.Panel2.Show()
        Console.WriteLine("Thread 2 exécuté...")

        ProgressBar3.Style = ProgressBarStyle.Marquee
        ProgressBar3.MarqueeAnimationSpeed = 35

    End Sub

    Sub dispose_worker()
        Me.Panel1.Hide()
        Me.Panel2.Hide()
        Console.WriteLine("-- worker disposed")
        Label5.Text = "Fichier validé"
        Button12.Enabled = "True"

    End Sub


    Private Sub frame_actuelle_Click(sender As Object, e As EventArgs) Handles frame_actuelle.Click

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        paint_module.save_frame()
    End Sub

    Sub _analyse_fichier(ByVal chemin As String)

        MsgBox(chemin)

        worker()

        Try
            thread_analyse.Start(chemin)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub

    Sub fin_analyse()
        Console.WriteLine("-- fin d'analyse --")


        Console.WriteLine("Thread exécuté correctement...")


        Try
            thread_analyse.Abort(500)
        Catch ex As ThreadAbortException
            Console.WriteLine(ex)
        Finally
            dispose_worker()
        End Try
        Console.WriteLine("Thread arrêté.")
        dispose_worker()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item("TabPage2")
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Unchecked Then
            Try
                Process.Start("analyse-table-sismique.exe")
                Me.Close()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Try
                dyslexic.confirmation()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

        End If
    End Sub
End Class

