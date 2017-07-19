Public Class Form1
    Private decRetail As Decimal
    Private decPercentage As Decimal

    Private Function ValidateInputFields() As Boolean
        'try to convert each of the input fields
        'return false if any field is invalid
        'display a suitable error message

        If Not Decimal.TryParse(txtRetailPrice.Text, decRetail) Then
            lblMessage.Text = "Retail price must be numeric"
            Return False
        End If

        If Not Decimal.TryParse(txtDiscountPercent.Text, decPercentage) Then
            lblMessage.Text = "Discount percentage must be numeric"
            Return False
        End If

        Return True
    End Function

    Function CalculateSalePrice(ByVal decRetail As Decimal,
                                ByVal decPercentage As Decimal) As Decimal
        'calculate and return the sale price
        Dim decSalePrice As Decimal
        decSalePrice = decRetail - (decRetail * decPercentage)
        Return decSalePrice
    End Function

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim decSalePrice As Decimal
        'clear any previous message
        lblMessage.Text = String.Empty
        'if the input is valid, display the sale price
        If ValidateInputFields() Then
            decSalePrice = CalculateSalePrice(decRetail, decPercentage)
            lblSalePrice.Text = decSalePrice.ToString("c")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDiscountPercent.Clear()
        txtRetailPrice.Clear()
        lblMessage.Text = String.Empty
        lblSalePrice.Text = String.Empty
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
