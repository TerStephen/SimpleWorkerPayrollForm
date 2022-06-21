Class MainWindow
    ''---------------------
    'Terrel Stephen
    '2017-09-12
    'WorkerPayrollForm
    ''---------------------

    ''Pay scheme
    'Messages   Price 
    '1-249      $11
    '250-499    $17
    '500-749    $21
    '>=750      $25


    Private Const lowestMessageRate As Double = 0.11
    Private Const middleMessageRate As Double = 0.17
    Private Const upperMessageRate As Double = 0.21
    Private Const highestMessageRate As Double = 0.25

    Dim finalWorkerCount As Integer
    Dim finalPayrollTotal As Double
    Dim convertResult As Boolean
    Dim convert As Integer

    ''' <summary>
    ''' Event Handler for Calculate button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Calculate_Click(sender As Object, e As RoutedEventArgs) Handles btn_Calculate.Click
        'txtWorkerName
        'Dim workerPayTotal

        If (txtWorkerName.Text IsNot String.Empty) Then 'Is there a name entered?
            If (txtMessages.Text IsNot String.Empty) Then 'Is there a message amount given?
                convertResult = Int32.TryParse(txtMessages.Text, convert) 'Is messenge amount a whole number?
                If (convertResult) Then
                    If (Me.txtMessages.Text > 0) Then 'More than 0 messages?
                        'Do calculations now that its all been confirmed

                        If (txtMessages.Text < 250) Then
                            lblPayAmount.Content = FormatCurrency(txtMessages.Text * lowestMessageRate, 2)
                        ElseIf (txtMessages.Text >= 250 And txtMessages.Text <= 499) Then
                            lblPayAmount.Content = FormatCurrency(txtMessages.Text * middleMessageRate, 2)
                        ElseIf (txtMessages.Text >= 500 And txtMessages.Text <= 749) Then
                            lblPayAmount.Content = FormatCurrency(txtMessages.Text * upperMessageRate, 2)
                        ElseIf (txtMessages.Text >= 750) Then
                            lblPayAmount.Content = FormatCurrency(txtMessages.Text * highestMessageRate, 2)
                        End If


                        lblTotalPaymentNum.Content = lblTotalPaymentNum.Content + lblPayAmount.Content

                    Else
                            MsgBox("You cannot enter Negative or 0 messages")
                        txtMessages.Focus()
                    End If
                Else
                    MsgBox("You cannot enter Letters or Non-Whole Numbers")
                    txtMessages.Focus()
                End If
            Else
                MsgBox("A message count needs to be entered")
                txtMessages.Focus()
            End If
        Else
            MsgBox("A name needs to be entered")
            txtWorkerName.Focus()
        End If

    End Sub
    ''' <summary>
    ''' Event handler if Clear button gets clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        txtMessages.Text = ""
        txtWorkerName.Text = ""
    End Sub

    Private Sub txtWorkerName_TextChanged(sender As Object, e As TextChangedEventArgs)

    End Sub
End Class
