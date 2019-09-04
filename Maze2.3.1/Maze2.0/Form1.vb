Public Class Game
    'Eric Yan
    'November 18, 2016 - January 24, 2017

    'To do
    'Audio

    'Bugged:
    'Monster transparency
    'Player lable colour change

    'Finished
    'TileCreate
    'Place Monsters
    'Maze Info/ Maze Switch
    'Maze Display
    'Maze Import
    'KeyDown
    'Maze Change
    'Collision Detection
    'LoadEvent
    'Player Attacks
    'Score
    'Enemy AI
    'Enemy Respawn


    'For Maze
    Dim strMaze(1, 1) As String
    Dim ptbMazeTiles(1, 1) As PictureBox
    Dim ptbMazeTile As New PictureBox
    Dim chrImage As Char
    Dim HMazeTilePosition As Integer = 0
    Dim VMazeTilePosition As Integer = 0
    Dim shtLevel As Short = 1
    Dim intXSize As Integer
    Dim intYSize As Integer
    Dim strLevelLocation As String


    'For Monster
    Dim imgFireMonsterAnimation(4) As Image
    Dim ptbFireMonster(3) As PictureBox
    Dim strFireMonsterDirection(3) As String
    Dim shtFireMonsterSpeed As Short = 4
    Dim shtFireMonsterAttack(3) As Short
    Dim shtFireMonsterDefence As Short = 1
    Dim shtFireMonsterHP(3) As Short
    Dim intX As Integer = Nothing
    Dim intY As Integer = Nothing
    Dim MonsterLocationX As Short
    Dim MonsterLocationY As Short
    Dim shtMonsterNum As Short = 4
    Dim shtReviveClock
    Dim shtHitMonster As Short


    'For Player
    Dim bolMovePossible As Boolean = True
    Dim bolMonsterMovePossible As Boolean = True
    Dim strPlayerState As String = "Stand"
    Dim strNextPlayerState As String
    Dim strPlayerDirection As String = "Right"
    Dim strPlayerAttack As String
    Dim imgPlayerAttack(4) As Image
    Dim ptbPlayerAttack As PictureBox
    Dim shtPlayerHp As Short = 50
    Dim shtPlayerAp As Short = 50
    Dim shtPlayerSpd As Short = 3
    Dim shtPlayerAtk As Short = 3
    Dim shtPlayerDef As Short = 0
    Dim shtPlayerDefOri As Short
    Dim shtStop As Short = 0

    'For Maze Components
    Dim imgTrapAnimation(4) As Image
    Dim intTrapIndexX As Integer
    Dim intTrapIndexY As Integer
    Dim imgPortalAnimation(2) As Image
    Dim intPortalIndexX As Integer
    Dim intPortalIndexY As Integer
    Dim WaitTime As Integer
    Dim intFrameCounter As Integer
    Dim shtScore As Short




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Preloads the map, images and player status


        Call MazeImport()
        Call Update()
        Dim ptbNew As New PictureBox

        For index = 0 To imgTrapAnimation.Length - 2
            imgTrapAnimation(index) = Image.FromFile("Trap" & index.ToString & ".jpg")
        Next index
        For index = 0 To 2
            imgPortalAnimation(index) = Image.FromFile("Portal" & index.ToString & ".jpg")
        Next
        For index = 0 To 3
            imgPlayerAttack(index) = Image.FromFile("Attack" & index.ToString & ".png")
        Next
        For index = 0 To 3
            imgFireMonsterAnimation(index) = Image.FromFile("Fire" & index.ToString & ".jpg")
        Next
        For index = 0 To 3
            shtFireMonsterAttack(index) = 5
        Next

        Call MonsterGenerate()



    End Sub
    Private Sub MazeGenerate()   'Also Maze Display
        'Generates the maze on the form by adding pic boxes
        'Uses 2dimensional array of pics to represent each tile
        Dim indexX = 0
        Dim indexY = 0
        Dim ptbNew As PictureBox
        ReDim ptbMazeTiles(strMaze.GetLength(0) - 1, strMaze.GetLength(1) - 1)
        For indexY = 0 To (strMaze.GetLength(0) - 2)
            For indexX = 0 To (strMaze.GetLength(1) - 2)
                ptbNew = New PictureBox
                chrImage = strMaze(indexY, indexX)
                Call TileCreate(chrImage)
                ptbNew.Size = New Drawing.Size(50, 50)
                ptbNew.Location = New Point(HMazeTilePosition, VMazeTilePosition)
                ptbNew.Image = ptbMazeTile.Image
                ptbNew.BackgroundImage = ptbMazeTile.BackgroundImage
                ptbNew.Tag = ptbMazeTile.Tag
                ptbNew.Name = "ptb" & indexY.ToString & indexX.ToString
                ptbMazeTiles(indexY, indexX) = ptbNew
                Me.Controls.Add(ptbNew)
                HMazeTilePosition += 50
            Next
            HMazeTilePosition = 0
            VMazeTilePosition += 50
        Next
        HMazeTilePosition = 0
        VMazeTilePosition = 0
        indexX = 0
        indexY = 0

    End Sub
    Private Sub MonsterGenerate()
        'Puts monsters on form
        'Assign monsters with stats
        Dim ptbNew As New PictureBox
        For index = 0 To shtMonsterNum - 1
            Me.Controls.Remove(ptbFireMonster(index))
            Call PlaceMonsters()
            shtFireMonsterHP(index) = 20
            strFireMonsterDirection(index) = "Right"
            ptbNew = New PictureBox
            ptbNew.Image = imgFireMonsterAnimation(0)
            ptbNew.BackgroundImage = Image.FromFile("Floor.jpg")
            ptbNew.Size = New Drawing.Size(50, 50)
            'ptbNew.Location = New Point(intX * 50, intY * 50)
            ptbNew.Left = intX * 50
            ptbNew.Top = intY * 50
            'MessageBox.Show(ptbNew.Left, ptbNew.Top)
            'ptbNew.Tag = "FireMonster" & index
            'ptbNew.Name = "FireMonster" & index
            ptbFireMonster(index) = ptbNew
            ptbFireMonster(index).BringToFront()
            'MessageBox.Show(intX, intY)
            Me.Controls.Add(ptbNew)
            ptbFireMonster(index).BringToFront()
            ptbFireMonster(index).Tag = "Alive"
            shtFireMonsterAttack(index) = 5
        Next

        tmrMonster.Enabled = True
    End Sub
    Private Sub TileCreate(ByVal chrImage As Char)
        'Uses characters from string array to decide the type of maze tile

        If chrImage = "W" Then
            ptbMazeTile.Tag = "Wall"
            ptbMazeTile.Image = Image.FromFile("Wall.jpg")
        ElseIf chrImage = "F" Then
            ptbMazeTile.Tag = "Floor"
            ptbMazeTile.Image = Image.FromFile("Floor.jpg")
        ElseIf chrImage = "P" Then
            ptbMazeTile.Tag = "Portal"
            ptbMazeTile.Image = Image.FromFile("Portal0.jpg")
        ElseIf chrImage = "T" Then
            ptbMazeTile.Tag = "Trap"
            ptbMazeTile.Image = Image.FromFile("Trap0.jpg")
        ElseIf chrImage = "C" Then
            ptbMazeTile.Tag = "Chest"
            ptbMazeTile.Image = Image.FromFile("Chest.png")
            ptbMazeTile.BackgroundImage = Image.FromFile("Floor.jpg")
        End If


    End Sub
    Private Sub MazeImport()
        'Imports the maze as a 2d string array using txt files
        Call MazeInfo()

        Dim fileReader = My.Computer.FileSystem.OpenTextFileReader(strLevelLocation)
            Dim stringReader As String
            ReDim strMaze(intYSize, intXSize)
            For indexY = 0 To (intYSize - 1)
                stringReader = fileReader.ReadLine
                For indexX = 0 To (intXSize - 1)
                    strMaze(indexY, indexX) = stringReader.Chars(indexX)
                Next
            Next
            Call MazeGenerate()


    End Sub
    Private Sub MazeInfo()
        'Information about the size, location, monster nums, name, of each map
        If shtLevel = 1 Then
            intXSize = 11
            intYSize = 11
            strLevelLocation = "D:\school work\grade 11\Programming 11\Maze2.3.1\Maze2.0\bin\Level1.txt"
            shtMonsterNum = 4
            Me.Text = "Birth"
        ElseIf shtLevel = 2 Then
            intXSize = 20
            intYSize = 12
            strLevelLocation = "D:\school work\grade 11\Programming 11\Maze2.3.1\Maze2.0\bin\Level2.txt"
            Me.Text = "Answers"
            shtMonsterNum = 6
        ElseIf shtLevel = 3 Then
            intXSize = 17
            intYSize = 10
            strLevelLocation = "D:\school work\grade 11\Programming 11\Maze2.3.1\Maze2.0\bin\Level3.txt"
            Me.Text = "Path"
            shtMonsterNum = 7
        ElseIf shtLevel = 4 Then
            intXSize = 28
            intYSize = 6
            strLevelLocation = "D:\school work\grade 11\Programming 11\Maze2.3.1\Maze2.0\bin\Level4.txt"
            Me.Text = "Near Hell"
            Me.lblPlayerHp.ForeColor = Color.Crimson
            Me.lblPlayerAp.ForeColor = Color.Crimson
            Me.lblPlayerAtk.ForeColor = Color.Crimson
            Me.lblPlayerDef.ForeColor = Color.Crimson
            Me.lblPlayerSpd.ForeColor = Color.Crimson
            Me.lblScore.ForeColor = Color.Crimson
            shtMonsterNum = 0
        ElseIf shtLevel = 5 Then
            Me.Hide()
            Final_Message.Show()
            If shtScore > 1000 Then
                MessageBox.Show("You have unlocked the true ending of this game")
            End If
            shtLevel = 1
            Call MazeImport()
        End If
    End Sub
    Private Sub LevelChanger()
        'Called after using the portal
        'Resets the player, monster, maze properties
        'Calls the mazeimport sub to generate new maze

        shtLevel += 1
        MessageBox.Show("Welcome to level " + shtLevel.ToString)
        shtScore += 100
            ptbPlayer.Left = 50
            ptbPlayer.Top = 50
            HMazeTilePosition = 0
            VMazeTilePosition = 0
            intTrapIndexY = Nothing
            intTrapIndexX = Nothing
            intPortalIndexX = Nothing
            intPortalIndexY = Nothing

        tmrTrap.Enabled = False
        tmrPortal.Enabled = False
        tmrMonster.Enabled = False
        For indexY = 0 To (strMaze.GetLength(0) - 2)
                For indexX = 0 To (strMaze.GetLength(1) - 2)
                    Me.Controls.Remove(ptbMazeTiles(indexY, indexX))
                Next
            Next
        For index = 0 To shtMonsterNum - 1
            Me.Controls.Remove(ptbFireMonster(index))
        Next

        If shtLevel < 5 Then
            Call MazeImport()
            ReDim ptbFireMonster(shtMonsterNum)
            ReDim shtFireMonsterHP(shtMonsterNum)
            ReDim shtFireMonsterAttack(shtMonsterNum)
            ReDim strFireMonsterDirection(shtMonsterNum)
            Call MonsterGenerate()
        ElseIf shtLevel = 5 Then
            Call MazeInfo()
            Exit Sub
        End If
    End Sub
    Private Sub PlaceMonsters()
        'Randomly select the location of monsters
        Dim shtBigX As Short = strMaze.GetLength(1) - 1
        Dim shtBigY As Short = strMaze.GetLength(0) - 1

        Do
            Randomize()
            intX = Int((shtBigX - 1) * Rnd())
            intY = Int((shtBigY - 1) * Rnd())
        Loop Until ptbMazeTiles(intY, intX).Tag = "Floor" And intX <> 1 And intY <> 1

    End Sub
    Private Sub CollisionDetection(ByVal Tester As PictureBox, ByVal NextDirection As String, ByVal speed As Short, ByVal identificator As String)
        'Check for collision with maze tiles
        'Used by both player and monster

        Dim TesterCopy = New PictureBox
        Dim XVal, YVal, Width, Height As Short
        XVal = Tester.Left
        YVal = Tester.Top
        Width = Tester.Width
        Height = Tester.Height
        TesterCopy.Left = XVal
        TesterCopy.Top = YVal
        TesterCopy.Width = Width
        TesterCopy.Height = Height


        If NextDirection = "Right" Then
            TesterCopy.Left += speed
        ElseIf NextDirection = "Left" Then
            TesterCopy.Left -= speed
        ElseIf NextDirection = "Up" Then
            TesterCopy.Top -= speed
        ElseIf NextDirection = "Down" Then
            TesterCopy.Top += speed
        End If




        bolMovePossible = True
        Dim indexY = 1
        Dim indexX = 1
        If identificator = "Player" Then
            Do
                Do

                    If TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Wall" Then

                        bolMovePossible = False

                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Floor" Then
                        bolMovePossible = True
                        tmrTrap.Enabled = False
                        tmrPortal.Enabled = False
                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Chest" Then
                        bolMovePossible = True
                        tmrTrap.Enabled = False
                        tmrPortal.Enabled = False
                        shtScore += 100
                        ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Floor"
                        Call OpenChest()
                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Trap" Then
                        bolMovePossible = True
                        tmrTrap.Enabled = True
                        tmrPortal.Enabled = False
                        intTrapIndexX = indexX - 1
                        intTrapIndexY = indexY - 1

                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Portal" Then
                        bolMovePossible = True
                        tmrTrap.Enabled = False
                        tmrPortal.Enabled = True
                        intPortalIndexX = indexX - 1
                        intPortalIndexY = indexY - 1

                    End If


                    indexX += 1
                Loop While indexX <= intXSize And bolMovePossible = True
                indexX = 1
                indexY += 1
            Loop While indexY <= intYSize And bolMovePossible = True
        End If




        If identificator = "Monster" Then
            Do
                Do

                    If TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Floor" Then

                        bolMonsterMovePossible = True

                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Wall" Then
                        bolMonsterMovePossible = False
                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Chest" Then
                        bolMonsterMovePossible = False
                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Trap" Then
                        bolMonsterMovePossible = False
                    ElseIf TesterCopy.Bounds.IntersectsWith(ptbMazeTiles(indexY - 1, indexX - 1).Bounds) And ptbMazeTiles(indexY - 1, indexX - 1).Tag = "Portal" Then
                        bolMonsterMovePossible = False

                    End If


                    indexX += 1
                Loop While indexX <= intXSize And bolMonsterMovePossible = True
                indexX = 1
                indexY += 1
            Loop While indexY <= intYSize And bolMonsterMovePossible = True
        End If
        If tmrTrap.Enabled = False And intTrapIndexX <> 0 And intTrapIndexY <> 0 Then
            ptbMazeTiles(intTrapIndexY, intTrapIndexX).Image = imgTrapAnimation(0)
        End If
    End Sub
    Private Sub OpenChest()
        'Event triggered when the player touches the chest
        'Randomly generates a event in the game
        Dim rndNum As Short
        Randomize()
        rndNum = Int(100 * Rnd()) + 1
        If rndNum < 3 Then
            MessageBox.Show("YOU ARE CURSED BY THE GREAT DEVELOPER")
            shtPlayerAp = 0
            shtPlayerAtk = 0
            shtPlayerDef = 0
            shtPlayerHp = 1
            shtPlayerSpd = 1
        ElseIf rndNum >= 3 And rndNum < 20 Then
            MessageBox.Show("MONSTERS ARE SUMMONED")
            Call MonsterGenerate()
        ElseIf rndNum >= 20 And rndNum < 50 Then
            MessageBox.Show("YOU FOUND A HP POTION")
            shtPlayerHp += 20
        ElseIf rndNum >= 50 And rndNum < 70 Then
            MessageBox.Show("YOU FOUND AN AP POTION")
            shtPlayerAp += 50
        ElseIf rndNum >= 70 And rndNum < 80 Then
            MessageBox.Show("YOU ARE GIVEN A SOUL OF BRAVERY")
            shtPlayerAtk += 2
        ElseIf rndNum >= 80 And rndNum < 90 Then
            MessageBox.Show("YOU ARE GIVEN A SOUL OF EDURANCE")
            shtPlayerDef += 2
        ElseIf rndNum >= 90 And rndNum < 97 Then
            MessageBox.Show("YOU ARE GIVEN A SOUL OF AGILITY")
            shtPlayerSpd += 1
        ElseIf rndNum >= 97 Then
            MessageBox.Show("YOU ARE ARE BLESSED BY THE GREAT DEVELOPER")
            shtPlayerAp += 100
            shtPlayerHp += 100
            shtPlayerAtk += 10
            shtPlayerDef += 10
            shtPlayerSpd += 5
        End If

        Me.lblPlayerHp.Text = "Hp: " + shtPlayerHp.ToString
        Me.lblPlayerAp.Text = "Ap: " + shtPlayerAp.ToString
        Me.lblPlayerAtk.Text = "Atk: " + shtPlayerAtk.ToString
        Me.lblPlayerDef.Text = "Def: " + shtPlayerDef.ToString
        Me.lblPlayerSpd.Text = "Spd: " + shtPlayerSpd.ToString
    End Sub
    Private Sub tmrTrap_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTrap.Tick
        'for trap animation and player HP subtraction
        shtPlayerHp -= 1
        ptbMazeTiles(intTrapIndexY, intTrapIndexX).Image = imgTrapAnimation(intFrameCounter Mod 3)
        intFrameCounter += 1
        Me.lblPlayerHp.Text = "Hp: " + shtPlayerHp.ToString
        Call checkHp()
    End Sub
    Private Sub tmrPortal_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPortal.Tick
        'For portal animation
        'Changes level after fixed time steping on the portal
        ptbMazeTiles(intPortalIndexY, intPortalIndexX).Image = imgPortalAnimation(intFrameCounter Mod 2)
        intFrameCounter += 1
        WaitTime += 1
        If WaitTime = 30 Then
            tmrPortal.Enabled = False
            WaitTime = 0
            Call LevelChanger()
        End If
    End Sub
    Private Sub checkHp()
        'Checks player hp
        'brings user to start page after dying
        If shtPlayerHp <= 0 Then
            tmrTrap.Enabled = False
            ptbPlayer.Left = 50
            ptbPlayer.Top = 50
            shtPlayerHp = 50
            shtPlayerAp = 50
            shtPlayerAtk = 3
            shtPlayerDef = 0
            shtPlayerSpd = 3
            shtScore = 0

            MessageBox.Show("You died ...")
            Me.Hide()
            StartPage.Show()


        End If
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        'player movement and attack controls
        If e.KeyValue = Keys.Up Then
            strPlayerState = "Run"
            strPlayerDirection = "Up"
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Down Then
            strPlayerState = "Run"
            strPlayerDirection = "Down"
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Right Then
            strPlayerState = "Run"
            strPlayerDirection = "Right"
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Left Then
            strPlayerState = "Run"
            strPlayerDirection = "Left"
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.A Then
            If tmrPlayerAttack.Enabled = False Then
                strPlayerAttack = "Attack"
                Call PlayerAttack()
            End If

        ElseIf e.KeyValue = Keys.S Then
            strPlayerAttack = "Defend"
            ptbPlayer.BackColor = Color.Crimson
            Me.Controls.Remove(ptbPlayerAttack)

            If shtPlayerDef - shtPlayerDefOri < 3 Then
                shtPlayerDefOri = shtPlayerDef
                shtPlayerDef += 3
            End If
        Else
            strPlayerState = "Stand"
            tmrPlayerMove.Enabled = False

        End If
        Me.lblPlayerDef.Text = "Def: " + shtPlayerDef.ToString

        Call Update()
        tmrPlayerMove.Enabled = True


    End Sub
    Private Sub PlayerMovement()
        'For moving player
        If strPlayerDirection = "Up" Then
            Me.ptbPlayer.Top -= shtPlayerSpd
        ElseIf strPlayerDirection = "Down" Then
            Me.ptbPlayer.Top += shtPlayerSpd
        ElseIf strPlayerDirection = "Left" Then
            Me.ptbPlayer.Left -= shtPlayerSpd
        ElseIf strPlayerDirection = "Right" Then
            Me.ptbPlayer.Left += shtPlayerSpd
        End If

    End Sub
    Private Sub PlayerAttack()
        'for generating player attacks
        'calls hitattack after
        If shtPlayerAp > 0 Then
            Dim ptbNew As New PictureBox
            ptbNew = New PictureBox
            If strPlayerDirection = "Up" Then
                ptbNew.Location = New Point(ptbPlayer.Left, ptbPlayer.Top - 40)
            ElseIf strPlayerDirection = "Down" Then
                ptbNew.Location = New Point(ptbPlayer.Left, ptbPlayer.Bottom + 20)
            ElseIf strPlayerDirection = "Left" Then
                ptbNew.Location = New Point(ptbPlayer.Left - 50, ptbPlayer.Top)
            ElseIf strPlayerDirection = "Right" Then
                ptbNew.Location = New Point(ptbPlayer.Right + 20, ptbPlayer.Top)
            End If
            ptbNew.Image = imgPlayerAttack(0)
            ptbNew.BackColor = Color.Transparent
            ptbNew.Size = New Drawing.Size(30, 30)
            ptbNew.Tag = "Atack"
            ptbNew.Name = "PlayerAttack"
            ptbPlayerAttack = ptbNew

            Me.Controls.Add(ptbPlayerAttack)
            ptbPlayerAttack.BringToFront()
            ptbPlayerAttack.Visible = True
            Me.tmrPlayerAttack.Enabled = True
            shtPlayerAp -= 5
            Call Update()
            Call hitAttack()
        End If
    End Sub
    Private Sub hitAttack()
        'runs every time attack is used
        'reudces monster hp for every succesful attacks
        For index = 0 To shtMonsterNum - 1
            Dim DistanceApart As Short = Math.Sqrt((Int(ptbPlayerAttack.Right + ptbPlayerAttack.Left) / 2 - Int(ptbFireMonster(index).Right + ptbFireMonster(index).Left) / 2) ^ 2 + (Int(ptbPlayerAttack.Bottom + ptbPlayerAttack.Top) / 2 - Int(ptbFireMonster(index).Bottom + ptbFireMonster(index).Top) / 2) ^ 2)
            If DistanceApart <= 50 Then
                shtFireMonsterHP(index) -= shtPlayerAtk
                If shtFireMonsterHP(index) <= 0 Then
                    Me.Controls.Remove(ptbFireMonster(index))
                    If shtFireMonsterAttack(index) > 0 Then
                        shtScore += 50
                    End If
                    shtFireMonsterAttack(index) = 0
                    ptbFireMonster(index).Tag = "Dead"
                End If
            End If
        Next
    End Sub
    Private Sub tmrPlayerAttack_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPlayerAttack.Tick
        'For attack animations and removing attack pis from form after finishing
        CollisionDetection(ptbPlayer, strPlayerDirection, shtPlayerSpd, ptbPlayer.Tag)
        ptbPlayerAttack.Image = imgPlayerAttack(intFrameCounter Mod 3)
        intFrameCounter += 1
        lblPlayerAp.ForeColor = Color.Aquamarine

        If intFrameCounter >= 3 Then
            Me.Controls.Remove(ptbPlayerAttack)
            tmrPlayerAttack.Enabled = False
            intFrameCounter = 0
            lblPlayerAp.ForeColor = SystemColors.AppWorkspace
        End If
    End Sub
    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        'Sets player state to stand 
        If e.KeyValue = Keys.Up Then
            strPlayerState = "Stand"
            tmrPlayerMove.Enabled = False
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Down Then
            strPlayerState = "Stand"
            tmrPlayerMove.Enabled = False
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Left Then
            strPlayerState = "Stand"
            tmrPlayerMove.Enabled = False
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.Right Then
            strPlayerState = "Stand"
            tmrPlayerMove.Enabled = False
            Me.Controls.Remove(ptbPlayerAttack)
        ElseIf e.KeyValue = Keys.A Then
            strPlayerAttack = "Stand"
            Me.Controls.Remove(ptbPlayerAttack)
            tmrPlayerAttack.Enabled = False
        ElseIf e.KeyValue = Keys.S Then
            strPlayerAttack = "Stand"
            ptbPlayer.BackColor = Color.Blue
            shtPlayerDef = shtPlayerDefOri
        End If
        Call Update()
    End Sub
    Private Sub tmrPlayerMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPlayerMove.Tick
        'For player movement
        'checks collision to see whether movement is possible
        Call CollisionDetection(ptbPlayer, strPlayerDirection, shtPlayerSpd, ptbPlayer.Tag)
        If bolMovePossible = False Then
            strPlayerState = "Stand"
        ElseIf bolMovePossible = True And strPlayerState = "Run" Then
            Call PlayerMovement()
        End If
    End Sub
    Private Sub tmrMonster_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMonster.Tick
        'for animation,  movement and respawn of monsters
        For index = 0 To shtMonsterNum - 1
            MonsterLocationX = ptbFireMonster(index).Left
            MonsterLocationY = ptbFireMonster(index).Top
            Call CollisionDetection(ptbFireMonster(index), strFireMonsterDirection(index), shtFireMonsterSpeed, "Monster")
            If bolMonsterMovePossible = False Then
                Call MonsterChooseDirection(index)
            End If
            ptbFireMonster(index).Image = imgFireMonsterAnimation(intFrameCounter Mod 3)

            If bolMonsterMovePossible = True Then

                If strFireMonsterDirection(index) = "Left" Then
                    ptbFireMonster(index).Left -= shtFireMonsterSpeed
                ElseIf strFireMonsterDirection(index) = "Right" Then
                    ptbFireMonster(index).Left += shtFireMonsterSpeed
                ElseIf strFireMonsterDirection(index) = "Up" Then
                    ptbFireMonster(index).Top -= shtFireMonsterSpeed
                ElseIf strFireMonsterDirection(index) = "Down" Then
                    ptbFireMonster(index).Top += shtFireMonsterSpeed
                End If
                Call CollisionDetection(ptbFireMonster(index), strFireMonsterDirection(index), shtFireMonsterSpeed, "Monster")
                If bolMonsterMovePossible = False Then
                    ptbFireMonster(index).Left = MonsterLocationX
                    ptbFireMonster(index).Top = MonsterLocationY
                End If
            End If
        Next

        If intFrameCounter Mod 6 = 0 Then
            Call hitMonster()
        End If
        If shtReviveClock = 200 Then
            Call MonsterGenerate()
            shtReviveClock = 0
        End If
        intFrameCounter += 1
        shtReviveClock += 1

    End Sub
    Private Sub MonsterChooseDirection(ByVal index As Short)
        'for choosing the direction of monsters according to the collision with the maze tiles

        Dim DirectionsAvailable(-1) As String
        Dim bolUpAdded As Boolean = False
        Dim bolDownAdded As Boolean = False
        Dim bolRightAdded As Boolean = False
        Dim bolLeftAdded As Boolean = False

        Do
            If bolDownAdded = False And strFireMonsterDirection(index) <> "Up" Then
                ReDim Preserve DirectionsAvailable(DirectionsAvailable.Length)
                DirectionsAvailable(DirectionsAvailable.Length - 1) = "Down"
                bolDownAdded = True
            ElseIf bolRightAdded = False And strFireMonsterDirection(index) <> "Left" Then
                ReDim Preserve DirectionsAvailable(DirectionsAvailable.Length)
                DirectionsAvailable(DirectionsAvailable.Length - 1) = "Right"
                bolRightAdded = True
            ElseIf bolLeftAdded = False And strFireMonsterDirection(index) <> "Right" Then
                ReDim Preserve DirectionsAvailable(DirectionsAvailable.Length)
                DirectionsAvailable(DirectionsAvailable.Length - 1) = "Left"
                bolLeftAdded = True
            ElseIf bolUpAdded = False And strFireMonsterDirection(index) <> "Down" Then
                ReDim Preserve DirectionsAvailable(DirectionsAvailable.Length)
                DirectionsAvailable(DirectionsAvailable.Length - 1) = "Up"
                bolUpAdded = True
            Else
                bolDownAdded = True
                bolUpAdded = True
                bolLeftAdded = True
                bolRightAdded = True
            End If
        Loop Until bolDownAdded = True And bolDownAdded = True And bolLeftAdded = True And bolRightAdded = True
        Randomize()
                strFireMonsterDirection(index) = DirectionsAvailable(Int(Rnd() * DirectionsAvailable.Length))


        bolMonsterMovePossible = True

    End Sub
    Private Sub hitMonster()
        'checks to see if player hits monsters
        'reduces hp when hit

        For index = 0 To shtMonsterNum - 1
            Dim DistanceApart As Short = Math.Sqrt((Int(ptbPlayer.Right + ptbPlayer.Left) / 2 - Int(ptbFireMonster(index).Right + ptbFireMonster(index).Left) / 2) ^ 2 + (Int(ptbPlayer.Bottom + ptbPlayer.Top) / 2 - Int(ptbFireMonster(index).Bottom + ptbFireMonster(index).Top) / 2) ^ 2)
            If DistanceApart <= 40 And ptbFireMonster(index).Tag = "Alive" Then
                shtPlayerHp = shtPlayerHp - (shtFireMonsterAttack(index) - shtPlayerDef)
                If (shtFireMonsterAttack(index) - shtPlayerDef) <= 0 Then
                    shtPlayerHp = (shtPlayerHp - 1)
                End If
                ptbPlayer.BackColor = Color.AliceBlue
                lblPlayerHp.ForeColor = Color.Red
                shtHitMonster = index
                'MessageBox.Show(index)
                Call checkHp()
            ElseIf DistanceApart > 40 And index <> shtHitMonster Then
                ptbPlayer.BackColor = Color.Blue
                lblPlayerHp.ForeColor = SystemColors.AppWorkspace
            End If

        Next

        Call Update()
    End Sub
    Private Sub Update()
        'Updates the stats of the player
        Me.lblPlayerHp.Text = "Hp: " + shtPlayerHp.ToString
        Me.lblPlayerAp.Text = "Ap: " + shtPlayerAp.ToString
        Me.lblPlayerAtk.Text = "Atk: " + shtPlayerAtk.ToString
        Me.lblPlayerDef.Text = "Def: " + shtPlayerDef.ToString
        Me.lblPlayerSpd.Text = "Spd: " + shtPlayerSpd.ToString
        Me.lblScore.Text = "Score: " + shtScore.ToString
    End Sub
    'Programming 11 Notes
    'Final Project
    'December 9, 2015 ~ January 17, 2016

    'Always check the location for the levels

    'A few words first:
    'This is indeed a very big project and took me way longer than I expected 
    'This version is not a perfect one since there are a few bugs that I haven't fixed. However, it won't interupt the gamplay
    'There's also a lot of other things I wanted to add but all canceled due to the lack of time
    'You might want to change the maze file location in the MazeInfo Sub (the txt file location)
    'Thanks for reading and I hope you enjoy the game

End Class

