Public NotInheritable Class StartUp

    Dim opacityRate As Double = 0.0
    Dim maximizeRate As Boolean = True
    Dim minimizeRate As Boolean = False


    Private Sub StartUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        Me.Opacity = 0.0

        timerSplash.Interval = 1
        timerSplash.Enabled = True
        timerSplash.Start()

    End Sub

   
    Private Sub timerSplash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerSplash.Tick

        If opacityRate >= 1.0 Then
            opacityRate = opacityRate + 1.0
            If opacityRate >= 20.0 Then

                opacityRate = 0.99
                Me.Opacity = opacityRate
            End If
        ElseIf maximizeRate Then
            opacityRate = opacityRate + 0.025
            Me.Opacity = opacityRate
            If opacityRate >= 1.0 Then
                maximizeRate = False
                minimizeRate = True
            End If
        ElseIf minimizeRate Then
            opacityRate = opacityRate - 0.025
            If opacityRate < 0 Then
                opacityRate = 0
            End If
            Me.Opacity = opacityRate
            If Opacity <= 0.0 Then
                minimizeRate = False
                maximizeRate = False
            End If
        Else
            timerSplash.Stop()
            timerSplash.Enabled = False
            timerSplash.Dispose()

            Me.Visible = False
            Dim Login As New F_Login
            Login.Show()

        End If
    End Sub

End Class
