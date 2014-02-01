Imports System.IO

Module paint_module

    Dim prefix As String = "frame"
    Dim pen As New Pen(Color.Red)
    Dim frame_name As String = "frame1"

    Dim __image As Bitmap

    Dim fs As FileStream


    Sub creation_frame(ByVal longueur As Integer, ByVal hauteur As Integer, ByVal id As Integer)
        Console.WriteLine("- appel de paint_module")
        Dim _image As New Bitmap(longueur, hauteur)
        frame_name = prefix + id.ToString
        MsgBox(frame_name)
        _image.Save("temp\" & frame_name & ".png", System.Drawing.Imaging.ImageFormat.Png)
        _image.Dispose()

    End Sub
    Sub dessin_frame(ByVal x As Integer, y As Integer)

        'method from file (fail)
        '__image = Image.FromFile("temp\" & frame_name & ".png")
        '------------

        'methode from stream (in test)
        fs = New FileStream("temp\" & frame_name & ".png", FileMode.Open)
        __image = Image.FromStream(fs)
        '------------
        Console.WriteLine("- écriture de " & x & ", " & y)
        __image.SetPixel(x, y, Color.Black)
        'Try
        '    __image.Save(frame_name & ".png", System.Drawing.Imaging.ImageFormat.Png)
        'Catch ex As Exception
        '    Console.WriteLine(ex)
        'End Try
        fs.Close()
        save_frame2()
    End Sub

    Sub save_frame()
        __image.Save(frame_name & ".png", System.Drawing.Imaging.ImageFormat.Png)
        Console.WriteLine(">> " & frame_name & " sauvée")
    End Sub

    Sub save_frame2()
        Try
            __image.Save("temp\" & frame_name & ".png", System.Drawing.Imaging.ImageFormat.Png)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        Console.WriteLine(">> " & frame_name & " sauvée")


    End Sub
End Module
