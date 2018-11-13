Public Class Form1
    'Declare And Assign Public Variables

    'Create New Random
    Dim r As Random = New Random

    'Integer for Timer1's ticks
    Dim T1 As Integer = 0

    'String for converting random integer
    Dim intToString As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Roll Die on Startup
        RollDie()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Start the timer
        Timer1.Start()
        ListBox1.Items.Clear()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Increase Integer as the timer ticks (this integer will reflect which tick the timer is currently on)
        T1 += 1

        'Roll the die
        RollDie()

        'label displays message when die is rolling
        Label1.Text = "Rolling.."

        'If the timer's tick has reached 6, (reflected by the T1 integer) the timer will stop and T1 will be reset to 0 so this entire function can work again
        If T1 = 6 Then
            'stop the timer
            Timer1.Stop()

            'reset T1 to 0
            T1 = 0

            'label displays message of what was rolled
            Label1.Text = "You've rolled " & intToString & "!"
        End If

    End Sub

    Private Sub RollDie()

        'Get random numbers between 1 and 6.
        Dim dieSide As Integer = r.Next(1, 7)
        ListBox1.Items.Add(dieSide)
        'Convert Random Integer to string
        intToString = dieSide.ToString

        'Use that converted string to call specific image by name from My.Resources (they are named 1 - 6) and then set the picturebox to that image
        PictureBox1.BackgroundImage = My.Resources.ResourceManager.GetObject(intToString)
    End Sub

End Class
