Public Class Nivel2

    Dim vida As Byte
    Dim xPacman As Integer = 225 'el valor inicial de la posicion x del picturBox que contiene el pacman
    Dim yPacman As Integer = 330 'el valor inicial de la posicion y del picturBox que contiene el pacman
    Dim xPinky As Integer = 353
    Dim yPinky As Integer = 260
    Dim xRojo As Integer = 386
    Dim yRojo As Integer = 260
    Dim xNaranja As Integer = 417
    Dim yNaranja As Integer = 260
    Dim xAzul As Integer = 446
    Dim yAzul As Integer = 260
    Dim xMorado As Integer = 489
    Dim yMorado As Integer = 260
    Dim xVerde As Integer = 532
    Dim yVerde As Integer = 260
    Dim Puntaje As Integer
    Dim BolitasComidas As Integer
    Dim tiempoFantasma As Byte
    Dim tiempoJuego As Byte
    Dim Labels = Me.Controls.Find("LB", True)
    Dim PictureBolita = Me.Controls.Find("PictureBox", True)


    Sub ObtenerVidasPuntaje(vidas As Byte, Puntos As Integer)
        vida = vidas
        Puntaje = Puntos

    End Sub

    Private Sub Nivel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If (vida = 1) Then

            H5.Visible = False
            H6.Visible = False
            H7.Visible = False

        ElseIf (vida = 2) Then
            H5.Visible = False
            H7.Visible = False

        ElseIf (vida = 3) Then
            H5.Visible = False
        End If
        Label12.Text = Puntaje

    End Sub

    '***************************************************************************Timers para el movimiento del Pacman***************************************************************

    '---------------------Para mover a la Izquierda---------------------------------
    Private Sub PacmanIzquierda_Tick(sender As Object, e As EventArgs) Handles PacmanIzquierda.Tick

        xPacman -= 7 'a la variable de la posicion en X el resta 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto 
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover a la Derecha---------------------------------

    Private Sub PacmanDerecha_Tick(sender As Object, e As EventArgs) Handles PacmanDerecha.Tick

        xPacman += 7 'a la variable de la posicion en X el suma 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover hacia Arriba---------------------------------

    Private Sub PacmanArriba_Tick(sender As Object, e As EventArgs) Handles PacmanArriba.Tick

        yPacman -= 7 'a la variable de la posicion en Y el resta 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------

    Private Sub PacmanAbajo_Tick(sender As Object, e As EventArgs) Handles PacmanAbajo.Tick

        yPacman += 7 'a la variable de la posicion en Y el suma 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub


    '*********************************************************************Evento de pulsar las teclas************************************************************************

    Private Sub Nivel2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        '---------------si la tecla que pulso es la flecha de Izquierda--------------
        If (e.KeyCode = Keys.Left) Then

            Pacman.Image = My.Resources.Pacman4 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia  la Izquierda
            PacmanIzquierda.Enabled = True 'activo el timer que mueve al pictureBox hacia la Izquierda 
            PacmanDerecha.Enabled = False 'desactivo todos los demas timer 
            PacmanArriba.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 
            exit sub

        End If

        '---------------si la tecla que pulso es la flecha de Derecha--------------
        If (e.KeyCode = Keys.Right) Then

            Pacman.Image = My.Resources.Pacman1 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia la derecha
            PacmanDerecha.Enabled = True 'activo el timer que mueve al pictureBox hacia la derecha 
            PacmanIzquierda.Enabled = False 'desactivo todos los demas timer 
            PacmanArriba.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 
            Exit Sub
        End If

        '---------------si la tecla que pulso es la flecha de Arriba--------------
        If (e.KeyCode = Keys.Up) Then
            Pacman.Image = My.Resources.Pacman2 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia la arriba
            PacmanArriba.Enabled = True 'activo el timer que mueve al pictureBox hacia la Arriba 
            PacmanIzquierda.Enabled = False 'desactivo todos los demas timer 
            PacmanDerecha.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 
            Exit Sub
        End If

        '---------------si la tecla que pulso es la flecha de Abajo--------------
        If (e.KeyCode = Keys.Down) Then
            Pacman.Image = My.Resources.Pacman3 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia la abajo
            PacmanAbajo.Enabled = True 'activo el timer que mueve al pictureBox hacia la Abajo 
            PacmanArriba.Enabled = False 'desactivo todos los demas timer 
            PacmanIzquierda.Enabled = False 'desactivo todos los demas timer 
            PacmanDerecha.Enabled = False 'desactivo todos los demas timer 
        End If


    End Sub


    '*********************************************************************Metodo verificarLimite************************************************************************
    Private Sub VerificarLimite(Timer As Object)

        For i = 1 To 54 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Labels = Me.Controls.Find("LB" & i, True) 'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Pacman Topa con algun Label---------------------

            If (Pacman.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (Timer.Equals(PacmanIzquierda)) Then

                    xPacman += 7 'la valor de la X del pacman de sumo 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Derecha antes de topar---------------------

                If (Timer.Equals(PacmanDerecha)) Then

                    xPacman -= 7 'al valor de la X del pacman le resto 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------

                If (Timer.Equals(PacmanArriba)) Then

                    yPacman += 7 'al valor de la Y del pacman le sumo 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------

                If (Timer.Equals(PacmanAbajo)) Then

                    yPacman -= 7 'al valor de la Y del pacman le resto 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                Exit For 'si entro a este if es porque ya detecto con que objeto topo entonces  me salgon del for y me evito las siguiente comparaciones innecesarias

            End If

        Next

        '------------------------------Si el Pacman esta en el lugar 1 para teletransportarse---------------------

        If (Pacman.Location.X < -30) Then 'si el pictureBox esta en la posicion -30 

            xPacman = 1063 'le asigno el valor de 880 a la X
            Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto

        End If

        '------------------------------Si el Pacman esta en el lugar 2 para teletransportarse---------------------

        If (Pacman.Location.X > 1063) Then 'si el pictureBox esta en la posicion 908

            xPacman = -30 'le asigno el valor de -30 a la X
            Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto

        End If

    End Sub

    '*********************************************************************Metodo verificarBolitas************************************************************************
    Private Sub VerificarBolitas()

        For i = 1 To 279 Step 1
            PictureBolita = Me.Controls.Find("PictureBox" & i, True)

            If (Pacman.Bounds.IntersectsWith(PictureBolita(0).Bounds) And PictureBolita(0).Visible = True) Then

                If (PictureBolita(0).Equals(PictureBox1)) Then
                    My.Computer.Audio.Play(My.Resources.Fruta, AudioPlayMode.WaitToComplete)
                    Puntaje += 290
                End If
                PictureBolita(0).Visible = False
                Puntaje += 10
                BolitasComidas += 1
                Label12.Text = Puntaje



                If (PictureBolita(0).Equals(PictureBox135) Or PictureBolita(0).Equals(PictureBox160) Or PictureBolita(0).Equals(PictureBox173) Or
                    PictureBolita(0).Equals(PictureBox183) Or PictureBolita(0).Equals(PictureBox239) Or PictureBolita(0).Equals(PictureBox83) Or
                    PictureBolita(0).Equals(PictureBox59) Or PictureBolita(0).Equals(PictureBox3) Or PictureBolita(0).Equals(PictureBox21)) Then

                    PictureRosado.Image = My.Resources.fantasma1
                    PictureRojo.Image = My.Resources.fantasma1
                    PictureNaranja.Image = My.Resources.fantasma1
                    PictureAzul.Image = My.Resources.fantasma1
                    PictureMorado.Image = My.Resources.fantasma1
                    PictureVerde.Image = My.Resources.fantasma1

                    tiempoFantasma = 8
                    Fantasmas.Enabled = True


                End If

                Exit For

            End If

        Next

        If (BolitasComidas = 279) Then

            xPacman = 46
            yPacman = 454
            Pacman.Location = New Point(xPacman, yPacman)
            BolitasComidas = 0
            MsgBox("¡¡NIVEL 2 SUPERADO!!")
            Nivel3.ObtenerVidasPuntaje(vida, Puntaje)
            Nivel3.Show()
            Me.Close()

        End If

    End Sub

    '*****************************************************************************Fantasma Rosado***************************************************************************************

    '---------------------Para mover a la Izquierda---------------------------------

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles RosadoIzquierda.Tick

        xPinky -= 7
        PictureRosado.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles RosadoAbajo.Tick

        yPinky += 7
        PictureRosado.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)

    End Sub

    '---------------------Para mover a la Derecha---------------------------------

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles RosadoDerecha.Tick
        xPinky += 7
        PictureRosado.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)
    End Sub

    '---------------------Para mover a la Arriba---------------------------------
    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles RosadoArriba.Tick
        yPinky -= 7
        PictureRosado.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)
    End Sub

    '---------------------------------------------Metodo VerificarFanstama------------------------------------
    Private Sub VerificarPinky(Timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto


            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------
            If (PictureRosado.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i


                If (Labels(0).Equals(Lb46) And RosadoArriba.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (Timer.Equals(RosadoIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        xPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        RosadoDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        xPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False
                        RosadoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        xPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False
                        RosadoArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (Timer.Equals(RosadoAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        yPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoArriba.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        yPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        yPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoDerecha.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (Timer.Equals(RosadoDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        xPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoAbajo.Enabled = True
                        RosadoDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        xPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = True
                        RosadoDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        xPinky -= 7
                        PictureRosado.Location = New Point(xPinky, yPinky)

                        RosadoArriba.Enabled = True
                        RosadoDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (Timer.Equals(RosadoArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        yPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)
                        RosadoArriba.Enabled = False
                        RosadoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        yPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)
                        RosadoIzquierda.Enabled = True
                        RosadoArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        yPinky += 7
                        PictureRosado.Location = New Point(xPinky, yPinky)
                        RosadoDerecha.Enabled = True
                        RosadoArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureRosado.Location.X > 1063) Then

            xPinky = -30
            PictureRosado.Location = New Point(xPinky, yPinky)

        End If

        If (PictureRosado.Location.X < -30) Then
            xPinky = 1063
            PictureRosado.Location = New Point(xPinky, yPinky)
        End If

        '------------------------------Si el Pacman Topa con algun fantasma--------------------
        If (PictureRosado.Bounds.IntersectsWith(Pacman.Bounds) Or PictureRojo.Bounds.IntersectsWith(Pacman.Bounds) Or
            PictureNaranja.Bounds.IntersectsWith(Pacman.Bounds) Or PictureAzul.Bounds.IntersectsWith(Pacman.Bounds) Or
            PictureMorado.Bounds.IntersectsWith(Pacman.Bounds) Or PictureVerde.Bounds.IntersectsWith(Pacman.Bounds)) Then


            If (Fantasmas.Enabled = True) Then

                Puntaje += 100
                Label12.Text = Puntaje

                If (PictureRosado.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xPinky = 353
                    yPinky = 260

                    RosadoArriba.Enabled = False
                    RosadoAbajo.Enabled = True
                    RosadoIzquierda.Enabled = False
                    RosadoDerecha.Enabled = False

                    PictureRosado.Location = New Point(xPinky, yPinky)

                End If

                If (PictureRojo.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xRojo = 386
                    yRojo = 260

                    RojoAbajo.Enabled = False
                    RojoDerecha.Enabled = False
                    RojoIzquierda.Enabled = True
                    RojoArriba.Enabled = False

                    PictureRojo.Location = New Point(xRojo, yRojo)

                End If

                If (PictureAzul.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xAzul = 446
                    yAzul = 260

                    AzulAbajo.Enabled = False
                    AzulDerecha.Enabled = False
                    AzulArriba.Enabled = False
                    Azulizquierda.Enabled = True

                    PictureAzul.Location = New Point(xAzul, yAzul)

                End If


                If (PictureNaranja.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xNaranja = 417
                    yNaranja = 260

                    NaranjaArriba.Enabled = False
                    NaranjaDerecha.Enabled = True
                    NaranjaIzquierda.Enabled = False
                    NaranjaAbajo.Enabled = False

                    PictureNaranja.Location = New Point(xNaranja, yNaranja)

                End If

                If (PictureMorado.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xMorado = 489
                    yMorado = 260

                    MoradoArriba.Enabled = False
                    MoradoDerecha.Enabled = False
                    MoradoIzquierda.Enabled = False
                    MoradoAbajo.Enabled = True

                    PictureMorado.Location = New Point(xMorado, yMorado)

                End If

                If (PictureVerde.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xVerde = 532
                    yVerde = 260

                    VerdeArriba.Enabled = False
                    VerdeDerecha.Enabled = False
                    VerdeIzquierda.Enabled = False
                    VerdeAbajo.Enabled = True

                    PictureVerde.Location = New Point(xVerde, yVerde)

                End If



            Else

                My.Computer.Audio.Play(My.Resources.Muerte, AudioPlayMode.WaitToComplete)


                xPacman = 225
                yPacman = 328
                xPinky = 353
                yPinky = 260
                xRojo = 386
                yRojo = 260
                xNaranja = 417
                yNaranja = 260
                xAzul = 446
                yAzul = 260
                xMorado = 489
                yMorado = 260
                xVerde = 532
                yVerde = 260

                PictureRosado.Location = New Point(xPinky, yPinky)
                Pacman.Location = New Point(xPacman, yPacman)
                PictureRojo.Location = New Point(xRojo, yRojo)
                PictureNaranja.Location = New Point(xNaranja, yNaranja)
                PictureAzul.Location = New Point(xAzul, yAzul)
                PictureVerde.Location = New Point(xVerde, yVerde)
                PictureMorado.Location = New Point(xMorado, yMorado)

                If (vida = 4) Then
                    H5.Visible = False
                End If
                If (vida = 3) Then
                    H6.Visible = False
                End If
                If (vida = 2) Then
                    H7.Visible = False
                End If
                If (vida = 1) Then
                    GameOver.Show()
                    Me.Close()
                    Exit Sub
                End If

                vida -= 1

            End If


        End If

    End Sub

    '****************************************************************************Fantasma Rojo**************************************************************************

    '---------------------Para mover a la Izquierda---------------------------------
    Private Sub RojoIzquierda_Tick(sender As Object, e As EventArgs) Handles RojoIzquierda.Tick

        xRojo -= 7
        PictureRojo.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover a la Derecha---------------------------------
    Private Sub RojoDerecha_Tick(sender As Object, e As EventArgs) Handles RojoDerecha.Tick

        xRojo += 7
        PictureRojo.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------
    Private Sub RojoAbajo_Tick(sender As Object, e As EventArgs) Handles RojoAbajo.Tick

        yRojo += 7
        PictureRojo.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover hacia Arriba---------------------------------
    Private Sub RojoArriba_Tick(sender As Object, e As EventArgs) Handles RojoArriba.Tick

        yRojo -= 7
        PictureRojo.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------------------------------Metodo VerificarFanstama------------------------------------
    Private Sub VerificarRojo(Timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureRojo.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb35) And RojoAbajo.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio2 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (Timer.Equals(RojoIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        xRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        RojoDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        xRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False
                        RojoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        xRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False
                        RojoArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (Timer.Equals(RojoAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        yRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoArriba.Enabled = True
                        RojoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        yRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = True
                        RojoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        yRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoDerecha.Enabled = True
                        RojoAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (Timer.Equals(RojoDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        xRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoAbajo.Enabled = True
                        RojoDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        xRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = True
                        RojoDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        xRojo -= 7
                        PictureRojo.Location = New Point(xRojo, yRojo)

                        RojoArriba.Enabled = True
                        RojoDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (Timer.Equals(RojoArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        yRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)
                        RojoArriba.Enabled = False
                        RojoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        yRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)
                        RojoIzquierda.Enabled = True
                        RojoArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        yRojo += 7
                        PictureRojo.Location = New Point(xRojo, yRojo)
                        RojoDerecha.Enabled = True
                        RojoArriba.Enabled = False

                    End If


                End If

            End If


        Next


        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureRojo.Location.X > 1063) Then

            xRojo = -30
            PictureRojo.Location = New Point(xRojo, yRojo)

        End If

        If (PictureRojo.Location.X < -30) Then
            xRojo = 1063
            PictureRojo.Location = New Point(xRojo, yRojo)
        End If

    End Sub

    '***********************************************************************************Fantasma Anaranjado****************************************************************
    Private Sub NaranjaIzquierda_Tick(sender As Object, e As EventArgs) Handles NaranjaIzquierda.Tick

        xNaranja -= 7
        PictureNaranja.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NranjaAbajo_Tick(sender As Object, e As EventArgs) Handles NaranjaAbajo.Tick

        yNaranja += 7
        PictureNaranja.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NaranjaDerecha_Tick(sender As Object, e As EventArgs) Handles NaranjaDerecha.Tick

        xNaranja += 7
        PictureNaranja.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NaranjaArriba_Tick(sender As Object, e As EventArgs) Handles NaranjaArriba.Tick

        yNaranja -= 7
        PictureNaranja.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub verificarNaranja(timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureNaranja.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb35) And NaranjaAbajo.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio3 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(NaranjaIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        xNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        NaranjaDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        xNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False
                        NaranjaAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        xNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False
                        NaranjaArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(NaranjaAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        yNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaArriba.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        yNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        yNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaDerecha.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(NaranjaDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        xNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaAbajo.Enabled = True
                        NaranjaDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        xNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = True
                        NaranjaDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        xNaranja -= 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)

                        NaranjaArriba.Enabled = True
                        NaranjaDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(NaranjaArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        yNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)
                        NaranjaArriba.Enabled = False
                        NaranjaAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        yNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)
                        NaranjaIzquierda.Enabled = True
                        NaranjaArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        yNaranja += 7
                        PictureNaranja.Location = New Point(xNaranja, yNaranja)
                        NaranjaDerecha.Enabled = True
                        NaranjaArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureNaranja.Location.X > 1063) Then

            xNaranja = -30
            PictureNaranja.Location = New Point(xNaranja, yNaranja)

        End If

        If (PictureNaranja.Location.X < -30) Then
            xNaranja = 1063
            PictureNaranja.Location = New Point(xNaranja, yNaranja)
        End If

    End Sub

    '****************************************************************************************Fantasma Azul****************************************************************************

    Private Sub Azulizquierda_Tick(sender As Object, e As EventArgs) Handles Azulizquierda.Tick
        xAzul -= 7
        PictureAzul.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)
    End Sub

    Private Sub AzulDerecha_Tick(sender As Object, e As EventArgs) Handles AzulDerecha.Tick

        xAzul += 7
        PictureAzul.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)

    End Sub

    Private Sub AzulAbajo_Tick(sender As Object, e As EventArgs) Handles AzulAbajo.Tick

        yAzul += 7
        PictureAzul.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)

    End Sub

    Private Sub AzulArriba_Tick(sender As Object, e As EventArgs) Handles AzulArriba.Tick

        yAzul -= 7
        PictureAzul.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)
    End Sub


    Private Sub verificarAzul(timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureAzul.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb46) And AzulArriba.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio4 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(Azulizquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        xAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        AzulDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        xAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False
                        AzulAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        xAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False
                        AzulArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(AzulAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        yAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        AzulArriba.Enabled = True
                        AzulAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        yAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = True
                        AzulAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        yAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        AzulDerecha.Enabled = True
                        AzulAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(AzulDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        xAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        AzulAbajo.Enabled = True
                        AzulDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        xAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = True
                        AzulDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        xAzul -= 7
                        PictureAzul.Location = New Point(xAzul, yAzul)

                        AzulArriba.Enabled = True
                        AzulDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(AzulArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        yAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)
                        AzulArriba.Enabled = False
                        AzulAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        yAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)
                        Azulizquierda.Enabled = True
                        AzulArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        yAzul += 7
                        PictureAzul.Location = New Point(xAzul, yAzul)
                        AzulDerecha.Enabled = True
                        AzulArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureAzul.Location.X > 1063) Then

            xAzul = -30
            PictureAzul.Location = New Point(xAzul, yAzul)

        End If

        If (PictureAzul.Location.X < -30) Then
            xAzul = 1063
            PictureAzul.Location = New Point(xAzul, yAzul)
        End If

    End Sub



    '*************************************************************************************Fantasma MOrado**************************************************************************

    Private Sub Moradoizquierda_Tick(sender As Object, e As EventArgs) Handles MoradoIzquierda.Tick
        xMorado -= 7
        PictureMorado.Location = New Point(xMorado, yMorado)
        verificarMorado(sender)
    End Sub

    Private Sub MoradoDerecha_Tick(sender As Object, e As EventArgs) Handles MoradoDerecha.Tick

        xMorado += 7
        PictureMorado.Location = New Point(xMorado, yMorado)
        verificarMorado(sender)

    End Sub

    Private Sub MoradoAbajo_Tick(sender As Object, e As EventArgs) Handles MoradoAbajo.Tick

        yMorado += 7
        PictureMorado.Location = New Point(xMorado, yMorado)
        verificarMorado(sender)

    End Sub

    Private Sub MoradoArriba_Tick(sender As Object, e As EventArgs) Handles MoradoArriba.Tick

        yMorado -= 7
        PictureMorado.Location = New Point(xMorado, yMorado)
        verificarMorado(sender)
    End Sub


    Private Sub verificarMorado(timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureMorado.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb45) And MoradoIzquierda.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio5 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(MoradoIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio5 = 3) Then

                        xMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        MoradoDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio5 = 2) Then

                        xMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoIzquierda.Enabled = False
                        MoradoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio5 = 1) Then

                        xMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoIzquierda.Enabled = False
                        MoradoArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(MoradoAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio5 = 1) Then

                        yMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoArriba.Enabled = True
                        MoradoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio5 = 2) Then

                        yMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoIzquierda.Enabled = True
                        MoradoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio5 = 3) Then

                        yMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoDerecha.Enabled = True
                        MoradoAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(MoradoDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio5 = 3) Then

                        xMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoAbajo.Enabled = True
                        MoradoDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio5 = 2) Then

                        xMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoIzquierda.Enabled = True
                        MoradoDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio5 = 1) Then

                        xMorado -= 7
                        PictureMorado.Location = New Point(xMorado, yMorado)

                        MoradoArriba.Enabled = True
                        MoradoDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(MoradoArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio5 = 1) Then

                        yMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)
                        MoradoArriba.Enabled = False
                        MoradoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio5 = 2) Then

                        yMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)
                        MoradoIzquierda.Enabled = True
                        MoradoArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio5 = 3) Then

                        yMorado += 7
                        PictureMorado.Location = New Point(xMorado, yMorado)
                        MoradoDerecha.Enabled = True
                        MoradoArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureMorado.Location.X > 1063) Then

            xMorado = -30
            PictureMorado.Location = New Point(xMorado, yMorado)

        End If

        If (PictureMorado.Location.X < -30) Then
            xMorado = 1063
            PictureMorado.Location = New Point(xMorado, yMorado)
        End If

    End Sub




    '*************************************************************************************Fantasma Verde**************************************************************************

    Private Sub Verdeizquierda_Tick(sender As Object, e As EventArgs) Handles VerdeIzquierda.Tick
        xVerde -= 7
        PictureVerde.Location = New Point(xVerde, yVerde)
        verificarVerde(sender)
    End Sub

    Private Sub VerdeDerecha_Tick(sender As Object, e As EventArgs) Handles VerdeDerecha.Tick

        xVerde += 7
        PictureVerde.Location = New Point(xVerde, yVerde)
        verificarVerde(sender)

    End Sub

    Private Sub VerdeAbajo_Tick(sender As Object, e As EventArgs) Handles VerdeAbajo.Tick

        yVerde += 7
        PictureVerde.Location = New Point(xVerde, yVerde)
        verificarVerde(sender)

    End Sub

    Private Sub VerdeArriba_Tick(sender As Object, e As EventArgs) Handles VerdeArriba.Tick

        yVerde -= 7
        PictureVerde.Location = New Point(xVerde, yVerde)
        verificarVerde(sender)
    End Sub


    Private Sub verificarVerde(timer As Object)

        For i = 1 To 58 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureVerde.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb44) And VerdeDerecha.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio6 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(VerdeIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio6 = 3) Then

                        xVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        VerdeDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio6 = 2) Then

                        xVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeIzquierda.Enabled = False
                        VerdeAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio6 = 1) Then

                        xVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeIzquierda.Enabled = False
                        VerdeArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(VerdeAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio6 = 1) Then

                        yVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeArriba.Enabled = True
                        VerdeAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio6 = 2) Then

                        yVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeIzquierda.Enabled = True
                        VerdeAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio6 = 3) Then

                        yVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeDerecha.Enabled = True
                        VerdeAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(VerdeDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio6 = 3) Then

                        xVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeAbajo.Enabled = True
                        VerdeDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio6 = 2) Then

                        xVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeIzquierda.Enabled = True
                        VerdeDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio6 = 1) Then

                        xVerde -= 7
                        PictureVerde.Location = New Point(xVerde, yVerde)

                        VerdeArriba.Enabled = True
                        VerdeDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(VerdeArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio6 = 1) Then

                        yVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)
                        VerdeArriba.Enabled = False
                        VerdeAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio6 = 2) Then

                        yVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)
                        VerdeIzquierda.Enabled = True
                        VerdeArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio6 = 3) Then

                        yVerde += 7
                        PictureVerde.Location = New Point(xVerde, yVerde)
                        VerdeDerecha.Enabled = True
                        VerdeArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureVerde.Location.X > 1063) Then

            xVerde = -30
            PictureVerde.Location = New Point(xVerde, yVerde)

        End If

        If (PictureVerde.Location.X < -30) Then
            xVerde = 1063
            PictureVerde.Location = New Point(xVerde, yVerde)
        End If

    End Sub

    Private Sub Fantasmas_Tick(sender As Object, e As EventArgs) Handles Fantasmas.Tick
        tiempoFantasma -= 1

        If (tiempoFantasma = 3) Then

            PictureRosado.Image = My.Resources.fantasma
            PictureRojo.Image = My.Resources.fantasma
            PictureNaranja.Image = My.Resources.fantasma
            PictureAzul.Image = My.Resources.fantasma
            PictureMorado.Image = My.Resources.fantasma
            PictureVerde.Image = My.Resources.fantasma

        End If

        If (tiempoFantasma = 0) Then

            PictureRosado.Image = My.Resources.Fa1
            PictureRojo.Image = My.Resources.Fa3
            PictureNaranja.Image = My.Resources.Fa4
            PictureAzul.Image = My.Resources.Fa2
            PictureMorado.Image = My.Resources.Fa5
            PictureVerde.Image = My.Resources.Fa6

            Fantasmas.Enabled = False

        End If
    End Sub

    Private Sub Juego_Tick(sender As Object, e As EventArgs) Handles Juego.Tick

        If (tiempoJuego = 20) Then
            PictureBox1.Visible = True
        End If
        If (tiempoJuego = 35) Then
            PictureBox1.Visible = False
            tiempoJuego = 0
        End If

        tiempoJuego += 1

    End Sub

    Private Sub PictureBox282_Click(sender As Object, e As EventArgs) Handles PictureBox282.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox281_Click(sender As Object, e As EventArgs) Handles PictureBox281.Click

        Me.Close()
        Form2.Close()

    End Sub
End Class