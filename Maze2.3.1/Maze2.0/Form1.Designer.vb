<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrPlayerAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPlayerMove = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTrap = New System.Windows.Forms.Timer(Me.components)
        Me.lblPlayerHp = New System.Windows.Forms.Label()
        Me.ptbPlayer = New System.Windows.Forms.PictureBox()
        Me.tmrPortal = New System.Windows.Forms.Timer(Me.components)
        Me.lblPlayerAp = New System.Windows.Forms.Label()
        Me.lblPlayerAtk = New System.Windows.Forms.Label()
        Me.lblPlayerDef = New System.Windows.Forms.Label()
        Me.lblPlayerSpd = New System.Windows.Forms.Label()
        Me.tmrPlayerAttack = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMonster = New System.Windows.Forms.Timer(Me.components)
        Me.ptbMonster1 = New System.Windows.Forms.PictureBox()
        Me.ptbMonster2 = New System.Windows.Forms.PictureBox()
        Me.ptbMonster3 = New System.Windows.Forms.PictureBox()
        Me.ptbMonster4 = New System.Windows.Forms.PictureBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lblControls = New System.Windows.Forms.Label()
        CType(Me.ptbPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbMonster1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbMonster2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbMonster3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbMonster4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrPlayerMove
        '
        Me.tmrPlayerMove.Interval = 1
        '
        'tmrTrap
        '
        '
        'lblPlayerHp
        '
        Me.lblPlayerHp.AutoSize = True
        Me.lblPlayerHp.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerHp.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayerHp.Location = New System.Drawing.Point(1201, 29)
        Me.lblPlayerHp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlayerHp.Name = "lblPlayerHp"
        Me.lblPlayerHp.Size = New System.Drawing.Size(56, 31)
        Me.lblPlayerHp.TabIndex = 1
        Me.lblPlayerHp.Text = "Hp:"
        '
        'ptbPlayer
        '
        Me.ptbPlayer.BackColor = System.Drawing.Color.Blue
        Me.ptbPlayer.Location = New System.Drawing.Point(67, 58)
        Me.ptbPlayer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ptbPlayer.Name = "ptbPlayer"
        Me.ptbPlayer.Size = New System.Drawing.Size(27, 35)
        Me.ptbPlayer.TabIndex = 2
        Me.ptbPlayer.TabStop = False
        Me.ptbPlayer.Tag = "Player"
        '
        'tmrPortal
        '
        '
        'lblPlayerAp
        '
        Me.lblPlayerAp.AutoSize = True
        Me.lblPlayerAp.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerAp.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayerAp.Location = New System.Drawing.Point(1201, 62)
        Me.lblPlayerAp.Name = "lblPlayerAp"
        Me.lblPlayerAp.Size = New System.Drawing.Size(59, 31)
        Me.lblPlayerAp.TabIndex = 3
        Me.lblPlayerAp.Text = "Ap:"
        '
        'lblPlayerAtk
        '
        Me.lblPlayerAtk.AutoSize = True
        Me.lblPlayerAtk.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerAtk.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayerAtk.Location = New System.Drawing.Point(1201, 161)
        Me.lblPlayerAtk.Name = "lblPlayerAtk"
        Me.lblPlayerAtk.Size = New System.Drawing.Size(77, 31)
        Me.lblPlayerAtk.TabIndex = 4
        Me.lblPlayerAtk.Text = "Atk:"
        '
        'lblPlayerDef
        '
        Me.lblPlayerDef.AutoSize = True
        Me.lblPlayerDef.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerDef.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayerDef.Location = New System.Drawing.Point(1201, 192)
        Me.lblPlayerDef.Name = "lblPlayerDef"
        Me.lblPlayerDef.Size = New System.Drawing.Size(70, 31)
        Me.lblPlayerDef.TabIndex = 5
        Me.lblPlayerDef.Text = "Def:"
        '
        'lblPlayerSpd
        '
        Me.lblPlayerSpd.AutoSize = True
        Me.lblPlayerSpd.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerSpd.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayerSpd.Location = New System.Drawing.Point(1201, 223)
        Me.lblPlayerSpd.Name = "lblPlayerSpd"
        Me.lblPlayerSpd.Size = New System.Drawing.Size(71, 31)
        Me.lblPlayerSpd.TabIndex = 6
        Me.lblPlayerSpd.Text = "Spd:"
        '
        'tmrPlayerAttack
        '
        Me.tmrPlayerAttack.Interval = 200
        '
        'tmrMonster
        '
        '
        'ptbMonster1
        '
        Me.ptbMonster1.Location = New System.Drawing.Point(1432, 638)
        Me.ptbMonster1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ptbMonster1.Name = "ptbMonster1"
        Me.ptbMonster1.Size = New System.Drawing.Size(67, 58)
        Me.ptbMonster1.TabIndex = 9
        Me.ptbMonster1.TabStop = False
        '
        'ptbMonster2
        '
        Me.ptbMonster2.Location = New System.Drawing.Point(1581, 638)
        Me.ptbMonster2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ptbMonster2.Name = "ptbMonster2"
        Me.ptbMonster2.Size = New System.Drawing.Size(67, 58)
        Me.ptbMonster2.TabIndex = 10
        Me.ptbMonster2.TabStop = False
        '
        'ptbMonster3
        '
        Me.ptbMonster3.Location = New System.Drawing.Point(1507, 638)
        Me.ptbMonster3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ptbMonster3.Name = "ptbMonster3"
        Me.ptbMonster3.Size = New System.Drawing.Size(67, 58)
        Me.ptbMonster3.TabIndex = 11
        Me.ptbMonster3.TabStop = False
        '
        'ptbMonster4
        '
        Me.ptbMonster4.Location = New System.Drawing.Point(1656, 638)
        Me.ptbMonster4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ptbMonster4.Name = "ptbMonster4"
        Me.ptbMonster4.Size = New System.Drawing.Size(67, 58)
        Me.ptbMonster4.TabIndex = 12
        Me.ptbMonster4.TabStop = False
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Algerian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblScore.Location = New System.Drawing.Point(1201, 330)
        Me.lblScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(105, 31)
        Me.lblScore.TabIndex = 13
        Me.lblScore.Text = "Score:"
        '
        'lblControls
        '
        Me.lblControls.AutoSize = True
        Me.lblControls.Font = New System.Drawing.Font("Algerian", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControls.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblControls.Location = New System.Drawing.Point(988, 549)
        Me.lblControls.Name = "lblControls"
        Me.lblControls.Size = New System.Drawing.Size(382, 136)
        Me.lblControls.TabIndex = 14
        Me.lblControls.Text = "Conrols:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Movement - Arrow Keys" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attack - A" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Defence -S"
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1382, 703)
        Me.Controls.Add(Me.lblControls)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.ptbMonster4)
        Me.Controls.Add(Me.ptbMonster3)
        Me.Controls.Add(Me.ptbMonster2)
        Me.Controls.Add(Me.ptbMonster1)
        Me.Controls.Add(Me.lblPlayerSpd)
        Me.Controls.Add(Me.lblPlayerDef)
        Me.Controls.Add(Me.lblPlayerAtk)
        Me.Controls.Add(Me.lblPlayerAp)
        Me.Controls.Add(Me.ptbPlayer)
        Me.Controls.Add(Me.lblPlayerHp)
        Me.Font = New System.Drawing.Font("Algerian", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Game"
        Me.Text = "Birth"
        CType(Me.ptbPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbMonster1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbMonster2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbMonster3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbMonster4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrPlayerAnimation As System.Windows.Forms.Timer
    Friend WithEvents tmrPlayerMove As System.Windows.Forms.Timer
    Friend WithEvents tmrTrap As System.Windows.Forms.Timer
    Friend WithEvents lblPlayerHp As System.Windows.Forms.Label
    Friend WithEvents ptbPlayer As System.Windows.Forms.PictureBox
    Friend WithEvents tmrPortal As System.Windows.Forms.Timer
    Friend WithEvents lblPlayerAp As Label
    Friend WithEvents lblPlayerAtk As Label
    Friend WithEvents lblPlayerDef As Label
    Friend WithEvents lblPlayerSpd As Label
    Friend WithEvents tmrPlayerAttack As System.Windows.Forms.Timer
    Friend WithEvents tmrMonster As System.Windows.Forms.Timer
    Friend WithEvents ptbMonster1 As System.Windows.Forms.PictureBox
    Friend WithEvents ptbMonster2 As System.Windows.Forms.PictureBox
    Friend WithEvents ptbMonster3 As System.Windows.Forms.PictureBox
    Friend WithEvents ptbMonster4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents lblControls As System.Windows.Forms.Label
End Class
