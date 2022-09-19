
Public Class Form2

    Dim xPacman As Integer = 713 'el valor inicial de la posicion x del picturBox que contiene el pacman
    Dim yPacman As Integer = 452 'el valor inicial de la posicion y del picturBox que contiene el pacman
    Dim xPinky As Integer = 361
    Dim yPinky As Integer = 260
    Dim xRojo As Integer = 403
    Dim yRojo As Integer = 260
    Dim yNaranja As Integer = 260
    Dim xNaranja As Integer = 443
    Dim xAzul As Integer = 485
    Dim yAzul As Integer = 260
    Dim Puntaje As Integer = 0
    Dim tiempoFantasma As Byte = 10
    Dim tiempoJuego As Byte = 0
    Dim bolitasComidas As Byte = 0
    Dim vidas As Byte = 4





    '***************************************************************************Timers para el movimiento del Pacman***************************************************************

    '---------------------Para mover a la Izquierda---------------------------------

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles PacmanIzquierda.Tick

        xPacman -= 5 'a la variable de la posicion en X el resta 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto 
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover a la Derecha---------------------------------

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles PacmanDerecha.Tick

        xPacman += 5 'a la variable de la posicion en X el suma 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover hacia Arriba---------------------------------
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles PacmanArriba.Tick

        yPacman -= 5 'a la variable de la posicion en Y el resta 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles PacmanAbajo.Tick

        yPacman += 5 'a la variable de la posicion en Y el suma 5
        Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'le asigno la nueva localizacion al pictureBox
        VerificarLimite(sender) 'este metodo es para ver que no haya topado en alguna parte del laberinto
        'tiene como parametro el objeto sender para que pueda ver que Timer es, en el metodo de VerificarLimite
        VerificarBolitas()

    End Sub

    '*********************************************************************Evento de pulsar las teclas************************************************************************
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode = Keys.A) Then
            Nivel2.ObtenerVidasPuntaje(vidas, Puntaje)
            Nivel2.Show()
            Me.Close()

        End If
        '---------------si la tecla que pulso es la flecha de Izquierda--------------
        If (e.KeyCode = Keys.Left) Then

            Pacman.Image = My.Resources.Pacman4 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia  la Izquierda
            PacmanIzquierda.Enabled = True 'activo el timer que mueve al pictureBox hacia la Izquierda 
            PacmanDerecha.Enabled = False 'desactivo todos los demas timer 
            PacmanArriba.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 

        End If

        '---------------si la tecla que pulso es la flecha de Derecha--------------
        If (e.KeyCode = Keys.Right) Then

            Pacman.Image = My.Resources.Pacman1 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia la derecha
            PacmanDerecha.Enabled = True 'activo el timer que mueve al pictureBox hacia la derecha 
            PacmanIzquierda.Enabled = False 'desactivo todos los demas timer 
            PacmanArriba.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 

        End If

        '---------------si la tecla que pulso es la flecha de Arriba--------------
        If (e.KeyCode = Keys.Up) Then
            Pacman.Image = My.Resources.Pacman2 'al PictureBox del pacman le asigno el gif de el pacman viendo hacia la arriba
            PacmanArriba.Enabled = True 'activo el timer que mueve al pictureBox hacia la Arriba 
            PacmanIzquierda.Enabled = False 'desactivo todos los demas timer 
            PacmanDerecha.Enabled = False 'desactivo todos los demas timer 
            PacmanAbajo.Enabled = False 'desactivo todos los demas timer 

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

        For i = 1 To 46 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("LB" & i, True) 'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Pacman Topa con algun Label---------------------

            If (Pacman.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (Timer.Equals(PacmanIzquierda)) Then

                    xPacman += 5 'la valor de la X del pacman de sumo 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Derecha antes de topar---------------------

                If (Timer.Equals(PacmanDerecha)) Then

                    xPacman -= 5 'al valor de la X del pacman le resto 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------

                If (Timer.Equals(PacmanArriba)) Then

                    yPacman += 5 'al valor de la Y del pacman le sumo 5
                    Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto
                    PacmanIzquierda.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanDerecha.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanArriba.Enabled = False 'desactivo todos los timers para que ya no se mueva
                    PacmanAbajo.Enabled = False 'desactivo todos los timers para que ya no se mueva

                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------

                If (Timer.Equals(PacmanAbajo)) Then

                    yPacman -= 5 'al valor de la Y del pacman le resto 5
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

            xPacman = 880 'le asigno el valor de 880 a la X
            Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto

        End If

        '------------------------------Si el Pacman esta en el lugar 2 para teletransportarse---------------------

        If (Pacman.Location.X > 908) Then 'si el pictureBox esta en la posicion 908

            xPacman = -30 'le asigno el valor de -30 a la X
            Pacman.Location = New System.Drawing.Point(xPacman, yPacman) 'al pictureBox le asigno el nuevo punto

        End If

    End Sub

    '*********************************************************************Metodo verificarBolitas************************************************************************
    Private Sub VerificarBolitas()

        For i = 1 To 229 Step 1
            Dim PictureBolita = Me.Controls.Find("PictureBox" & i, True)

            If (Pacman.Bounds.IntersectsWith(PictureBolita(0).Bounds) And PictureBolita(0).Visible = True) Then

                If (PictureBolita(0).Equals(PictureBox1)) Then
                    My.Computer.Audio.Play(My.Resources.Fruta, AudioPlayMode.WaitToComplete)
                    Puntaje += 90
                End If
                PictureBolita(0).Visible = False
                Puntaje += 10
                bolitasComidas += 1
                Label1.Text = Puntaje



                If (PictureBolita(0).Equals(PictureBox21) Or PictureBolita(0).Equals(PictureBox3) Or PictureBolita(0).Equals(PictureBox83) Or
                    PictureBolita(0).Equals(PictureBox135) Or PictureBolita(0).Equals(PictureBox183) Or PictureBolita(0).Equals(PictureBox173) Or
                    PictureBolita(0).Equals(PictureBox160)) Then

                    PictureBox230.Image = My.Resources.fantasma1
                    PictureBox231.Image = My.Resources.fantasma1
                    PictureBox232.Image = My.Resources.fantasma1
                    PictureBox233.Image = My.Resources.fantasma1
                    tiempoFantasma = 10
                    Timer1.Enabled = True


                End If

                Exit For

            End If

        Next

        If (bolitasComidas = 229) Then

            xPacman = 46
            yPacman = 454
            Pacman.Location = New Point(xPacman, yPacman)
            bolitasComidas = 0
            MsgBox("¡¡NIVEL 1 SUPERADO!!")
            Nivel2.ObtenerVidasPuntaje(vidas, Puntaje)
            Nivel2.Show()
            Me.Close()

        End If

    End Sub



    '*****************************************************************************Fantasma Rosado***************************************************************************************

    '---------------------Para mover a la Izquierda---------------------------------

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles RosadoIzquierda.Tick

        xPinky -= 5
        PictureBox230.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles RosadoAbajo.Tick

        yPinky += 5
        PictureBox230.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)

    End Sub

    '---------------------Para mover a la Derecha---------------------------------

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles RosadoDerecha.Tick
        xPinky += 5
        PictureBox230.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)
    End Sub

    '---------------------Para mover a la Arriba---------------------------------
    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles RosadoArriba.Tick
        yPinky -= 5
        PictureBox230.Location = New Point(xPinky, yPinky)
        VerificarPinky(sender)
    End Sub

    '---------------------------------------------Metodo VerificarFanstama------------------------------------
    Private Sub VerificarPinky(Timer As Object)

        For i = 1 To 50 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto


            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------
            If (PictureBox230.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i


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

                        xPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        RosadoDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        xPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False
                        RosadoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        xPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = False
                        RosadoArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (Timer.Equals(RosadoAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        yPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoArriba.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        yPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        yPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoDerecha.Enabled = True
                        RosadoAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (Timer.Equals(RosadoDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        xPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoAbajo.Enabled = True
                        RosadoDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        xPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoIzquierda.Enabled = True
                        RosadoDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        xPinky -= 5
                        PictureBox230.Location = New Point(xPinky, yPinky)

                        RosadoArriba.Enabled = True
                        RosadoDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (Timer.Equals(RosadoArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio = 1) Then

                        yPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)
                        RosadoArriba.Enabled = False
                        RosadoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio = 2) Then

                        yPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)
                        RosadoIzquierda.Enabled = True
                        RosadoArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio = 3) Then

                        yPinky += 5
                        PictureBox230.Location = New Point(xPinky, yPinky)
                        RosadoDerecha.Enabled = True
                        RosadoArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureBox230.Location.X > 905) Then

            xPinky = -30
            PictureBox230.Location = New Point(xPinky, yPinky)

        End If

        If (PictureBox230.Location.X < -30) Then
            xPinky = 905
            PictureBox230.Location = New Point(xPinky, yPinky)
        End If

        '------------------------------Si el Pacman Topa con algun fantasma--------------------
        If (PictureBox230.Bounds.IntersectsWith(Pacman.Bounds) Or PictureBox231.Bounds.IntersectsWith(Pacman.Bounds) Or
            PictureBox233.Bounds.IntersectsWith(Pacman.Bounds) Or PictureBox232.Bounds.IntersectsWith(Pacman.Bounds)) Then


            If (Timer1.Enabled = True) Then

                Puntaje += 100
                Label1.Text = Puntaje

                If (PictureBox230.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xPinky = 311
                    yPinky = 260

                    RosadoArriba.Enabled = False
                    RosadoAbajo.Enabled = True
                    RosadoIzquierda.Enabled = False
                    RosadoDerecha.Enabled = False

                    PictureBox230.Location = New Point(xPinky, yPinky)

                End If

                If (PictureBox231.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xRojo = 404
                    yRojo = 260

                    RojoAbajo.Enabled = False
                    RojoDerecha.Enabled = False
                    RojoIzquierda.Enabled = False
                    RojoArriba.Enabled = True

                    PictureBox231.Location = New Point(xRojo, yRojo)

                End If

                If (PictureBox232.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xAzul = 443
                    yAzul = 260

                    AzulAbajo.Enabled = False
                    AzulDerecha.Enabled = False
                    AzulArriba.Enabled = False
                    Azulizquierda.Enabled = True

                    PictureBox232.Location = New Point(xAzul, yAzul)

                End If


                If (PictureBox233.Bounds.IntersectsWith(Pacman.Bounds)) Then

                    xNaranja = 485
                    yNaranja = 260

                    NaranjaArriba.Enabled = False
                    NaranjaDerecha.Enabled = False
                    NaranjaIzquierda.Enabled = False
                    NaranjaAbajo.Enabled = True

                    PictureBox233.Location = New Point(xNaranja, yNaranja)

                End If



            Else

                My.Computer.Audio.Play(My.Resources.Muerte, AudioPlayMode.WaitToComplete)


                xPacman = 710
                yPacman = 449
                xPinky = 361
                yPinky = 260
                xRojo = 404
                yRojo = 260
                xNaranja = 443
                yNaranja = 260
                xAzul = 485
                yAzul = 260

                PictureBox230.Location = New Point(xPinky, yPinky)
                Pacman.Location = New Point(xPacman, yPacman)
                PictureBox231.Location = New Point(xRojo, yRojo)
                PictureBox233.Location = New Point(xNaranja, yNaranja)
                PictureBox232.Location = New Point(xAzul, yAzul)

                If (vidas = 4) Then
                    PictureBox236.Visible = False
                End If
                If (vidas = 3) Then
                    PictureBox235.Visible = False
                End If
                If (vidas = 2) Then
                    PictureBox234.Visible = False
                End If
                If (vidas = 1) Then
                    GameOver.Show()
                    Me.Close()
                    Exit Sub
                End If

                vidas -= 1

            End If


        End If

    End Sub



    '****************************************************************************Fantasma Rojo**************************************************************************

    '---------------------Para mover a la Izquierda---------------------------------
    Private Sub RojoIzquierda_Tick(sender As Object, e As EventArgs) Handles RojoIzquierda.Tick

        xRojo -= 5
        PictureBox231.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover a la Derecha---------------------------------
    Private Sub RojoDerecha_Tick(sender As Object, e As EventArgs) Handles RojoDerecha.Tick

        xRojo += 5
        PictureBox231.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover hacia Abajo---------------------------------
    Private Sub RojoAbajo_Tick(sender As Object, e As EventArgs) Handles RojoAbajo.Tick

        yRojo += 5
        PictureBox231.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------Para mover hacia Arriba---------------------------------
    Private Sub RojoArriba_Tick(sender As Object, e As EventArgs) Handles RojoArriba.Tick

        yRojo -= 5
        PictureBox231.Location = New Point(xRojo, yRojo)
        VerificarRojo(sender)

    End Sub

    '---------------------------------------------Metodo VerificarFanstama------------------------------------
    Private Sub VerificarRojo(Timer As Object)

        For i = 1 To 50 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureBox231.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

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

                        xRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        RojoDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        xRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False
                        RojoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        xRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = False
                        RojoArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (Timer.Equals(RojoAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        yRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoArriba.Enabled = True
                        RojoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        yRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = True
                        RojoAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        yRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoDerecha.Enabled = True
                        RojoAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (Timer.Equals(RojoDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        xRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoAbajo.Enabled = True
                        RojoDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        xRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoIzquierda.Enabled = True
                        RojoDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        xRojo -= 5
                        PictureBox231.Location = New Point(xRojo, yRojo)

                        RojoArriba.Enabled = True
                        RojoDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (Timer.Equals(RojoArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio2 = 1) Then

                        yRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)
                        RojoArriba.Enabled = False
                        RojoAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio2 = 2) Then

                        yRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)
                        RojoIzquierda.Enabled = True
                        RojoArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio2 = 3) Then

                        yRojo += 5
                        PictureBox231.Location = New Point(xRojo, yRojo)
                        RojoDerecha.Enabled = True
                        RojoArriba.Enabled = False

                    End If


                End If

            End If


        Next


        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureBox231.Location.X > 905) Then

            xRojo = -30
            PictureBox231.Location = New Point(xRojo, yRojo)

        End If

        If (PictureBox231.Location.X < -30) Then
            xRojo = 905
            PictureBox231.Location = New Point(xRojo, yRojo)
        End If

    End Sub



    '************************************************************************Fantasma Anaranjado****************************************************************
    Private Sub NaranjaIzquierda_Tick(sender As Object, e As EventArgs) Handles NaranjaIzquierda.Tick

        xNaranja -= 5
        PictureBox233.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NranjaAbajo_Tick(sender As Object, e As EventArgs) Handles NaranjaAbajo.Tick

        yNaranja += 5
        PictureBox233.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NaranjaDerecha_Tick(sender As Object, e As EventArgs) Handles NaranjaDerecha.Tick

        xNaranja += 5
        PictureBox233.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub NaranjaArriba_Tick(sender As Object, e As EventArgs) Handles NaranjaArriba.Tick

        yNaranja -= 5
        PictureBox233.Location = New Point(xNaranja, yNaranja)
        verificarNaranja(sender)

    End Sub

    Private Sub verificarNaranja(timer As Object)

        For i = 1 To 50 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureBox233.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb46) And NaranjaArriba.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio3 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(NaranjaIzquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        xNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        NaranjaDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        xNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False
                        NaranjaAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        xNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = False
                        NaranjaArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(NaranjaAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        yNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaArriba.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        yNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        yNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaDerecha.Enabled = True
                        NaranjaAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(NaranjaDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        xNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaAbajo.Enabled = True
                        NaranjaDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        xNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaIzquierda.Enabled = True
                        NaranjaDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        xNaranja -= 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)

                        NaranjaArriba.Enabled = True
                        NaranjaDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(NaranjaArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio3 = 1) Then

                        yNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)
                        NaranjaArriba.Enabled = False
                        NaranjaAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio3 = 2) Then

                        yNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)
                        NaranjaIzquierda.Enabled = True
                        NaranjaArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio3 = 3) Then

                        yNaranja += 5
                        PictureBox233.Location = New Point(xNaranja, yNaranja)
                        NaranjaDerecha.Enabled = True
                        NaranjaArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureBox233.Location.X > 905) Then

            xNaranja = -30
            PictureBox233.Location = New Point(xNaranja, yNaranja)

        End If

        If (PictureBox233.Location.X < -30) Then
            xNaranja = 905
            PictureBox233.Location = New Point(xNaranja, yNaranja)
        End If

    End Sub

    '**********************************************************************************Fantasma Azul****************************************************************************
    Private Sub Azulizquierda_Tick(sender As Object, e As EventArgs) Handles Azulizquierda.Tick
        xAzul -= 5
        PictureBox232.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)
    End Sub

    Private Sub AzulDerecha_Tick(sender As Object, e As EventArgs) Handles AzulDerecha.Tick

        xAzul += 5
        PictureBox232.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)

    End Sub

    Private Sub AzulAbajo_Tick(sender As Object, e As EventArgs) Handles AzulAbajo.Tick

        yAzul += 5
        PictureBox232.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)

    End Sub

    Private Sub AzulArriba_Tick(sender As Object, e As EventArgs) Handles AzulArriba.Tick

        yAzul -= 5
        PictureBox232.Location = New Point(xAzul, yAzul)
        verificarAzul(sender)
    End Sub


    Private Sub verificarAzul(timer As Object)

        For i = 1 To 50 Step 1 'este for es porque tiene que verificar los 43 Labels del laberinto

            Dim Labels = Me.Controls.Find("Lb" & i, True)  'creo una variable llamada labels y le asigno el label con el nombre "LB + i" que es el contador para verificar los 43 labels
            'la funcion Find, busca el label con ese nombre y lo guarda en una matriz con todos los que coinciden 

            '------------------------------Si el Fantasma Topa con algun Label---------------------

            If (PictureBox232.Bounds.IntersectsWith(Labels(0).Bounds)) Then 'esto es para saber si el pictureBox del pacman "Topo" con el label(0) que va a variar segun el valor de i

                If (Labels(0).Equals(Lb44) And AzulDerecha.Enabled = True) Then
                    Exit For
                End If

                Dim Numero As New Random 'creamos una varible de tipo ramdom
                Dim Aleatorio4 As Byte = Numero.Next(1, 4) 'generamos un numero aleatorio entre 1 y 3

                '---------------Si se estaba moviendo hacia Izquierda antes de topar---------------------
                If (timer.Equals(Azulizquierda)) Then

                    'generamos un numero aleatorio para que el movimiento del fantasma sea al azar

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        xAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False 'desactivo el timer de mover hacia la izquierda
                        AzulDerecha.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        xAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False
                        AzulAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        xAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = False
                        AzulArriba.Enabled = True


                    End If



                End If

                '---------------Si se estaba moviendo hacia Abajo antes de topar---------------------
                If (timer.Equals(AzulAbajo)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        yAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        AzulArriba.Enabled = True
                        AzulAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        yAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = True
                        AzulAbajo.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        yAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        AzulDerecha.Enabled = True
                        AzulAbajo.Enabled = False

                    End If


                End If

                '---------------Si se estaba moviendo hacia la Derecha antes de topar---------------------
                If (timer.Equals(AzulDerecha)) Then

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        xAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        AzulAbajo.Enabled = True
                        AzulDerecha.Enabled = False


                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        xAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        Azulizquierda.Enabled = True
                        AzulDerecha.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        xAzul -= 5
                        PictureBox232.Location = New Point(xAzul, yAzul)

                        AzulArriba.Enabled = True
                        AzulDerecha.Enabled = False


                    End If

                End If

                '---------------Si se estaba moviendo hacia Arriba antes de topar---------------------
                If (timer.Equals(AzulArriba)) Then

                    '--------------si el numero aleatorio es 1----------------
                    If (Aleatorio4 = 1) Then

                        yAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)
                        AzulArriba.Enabled = False
                        AzulAbajo.Enabled = True

                    End If

                    '--------------si el numero aleatorio es 2----------------
                    If (Aleatorio4 = 2) Then

                        yAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)
                        Azulizquierda.Enabled = True
                        AzulArriba.Enabled = False

                    End If

                    '--------------si el numero aleatorio es 3----------------
                    If (Aleatorio4 = 3) Then

                        yAzul += 5
                        PictureBox232.Location = New Point(xAzul, yAzul)
                        AzulDerecha.Enabled = True
                        AzulArriba.Enabled = False

                    End If


                End If

            End If


        Next

        '---------Para que el fantasma se pueda teletransportar--------------
        If (PictureBox232.Location.X > 905) Then

            xAzul = -30
            PictureBox232.Location = New Point(xAzul, yAzul)

        End If

        If (PictureBox232.Location.X < -30) Then
            xAzul = 905
            PictureBox232.Location = New Point(xAzul, yAzul)
        End If

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick

        tiempoFantasma -= 1

        If (tiempoFantasma = 3) Then

            PictureBox230.Image = My.Resources.fantasma
            PictureBox232.Image = My.Resources.fantasma
            PictureBox231.Image = My.Resources.fantasma
            PictureBox233.Image = My.Resources.fantasma

        End If

        If (tiempoFantasma = 0) Then

            PictureBox230.Image = My.Resources.Fa1
            PictureBox232.Image = My.Resources.Fa2
            PictureBox231.Image = My.Resources.Fa3
            PictureBox233.Image = My.Resources.Fa4
            Timer1.Enabled = False

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

    Private Sub PictureBox239_Click(sender As Object, e As EventArgs) Handles PictureBox239.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox240_Click(sender As Object, e As EventArgs) Handles PictureBox240.Click
        Me.Close()
        Form1.Close()
    End Sub
End Class