Public Class PartidaGanada


    Sub ObtenerPunteo(Puntuacion As Integer)
        Label3.Text = Puntuacion
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.Show()
        Me.Close()
        Nivel3.Close()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Nivel3.Close()
    End Sub
End Class