Public Class frmPOS
    Public SQL As New SQLControl
    Dim ProductCat As Integer
    Dim UnitItem As Integer
    Dim LastBillItemNo As Integer


    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MdiParent = frmMain
        FetchOrderType()
        FetchCatList()
        FetchIDType()
        FetchBillQ()
        lblDateTime.Text = Now()
        lblLogged.Text = frmLogin.txtUser.Text
        DefaultSetting()
        cmdSave.Enabled = False
        cmdCheckout.Enabled = False
        cmdDelete.Enabled = False


    End Sub
    Private Sub DefaultSetting()
        lblBillNo.Visible = True
        FetchIDType()
        FetchOrderType()
        txtTableNo.Clear()
        txtCustomer.Clear()
        txtIDNo.Clear()
        txtBillTotal.Text = Format(0, "0.00")
        txtPromo.Text = Format(0, "0.00")
        txtSubTotal.Text = Format(0, "0.00")
        txtCash.Text = Format(0, "0.00")
        txtChange.Text = Format(0, "0.00")
        cmdAddToList.Enabled = False
        cmdDelete.Enabled = False
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False


        SQL.ExecQuery("SELECT TOP 1 TaxPercent FROM CafeBillTax WHERE IsActive = 1 ")
        If SQL.HasException = True Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            txtVAT.Text = r("TaxPercent")
        Next

    End Sub

    Private Sub ClearAll()
        lblBillNo.Text = "00"
        lblBillNo.Visible = False
        txtTableNo.Clear()
        txtCustomer.Clear()
        txtIDNo.Clear()
        txtBillTotal.Text = Format(0, "0.00")
        txtPromo.Text = Format(0, "0.00")
        txtSubTotal.Text = Format(0, "0.00")
        txtCash.Text = Format(0, "0.00")
        txtChange.Text = Format(0, "0.00")
        FetchIDType()
        FetchOrderType()
        cmdAddToList.Enabled = False
        cmdSave.Enabled = False

    End Sub

    Private Sub CreateBillNo()
        Dim Bill As Integer
        Dim BillNo As String
        Dim NewBill As String
        '  Dim mo As String
        SQL.ExecQuery("Select BillNo from BillNoTracker;")

        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            Bill = r("BillNo") + 1
        Next

        BillNo = Format(Bill, "D4").ToString()
        '   mo = Now.Month.ToString()

        NewBill = Now.Year.ToString() + "-" + BillNo
        lblBillNo.Visible = True
        lblBillNo.Text = NewBill
        SQL.AddParam("@Bill", Bill)
        SQL.ExecQuery("Update BillNoTracker set BillNo = @Bill; ")
        If SQL.HasException(True) Then Exit Sub

        SQL.AddParam("@BillNo", NewBill)
        SQL.AddParam("@BillDate", lblDateTime.Text)
        SQL.AddParam("@Logged", lblLogged.Text)
        SQL.AddParam("@OrderType", cmbOrderType.Text)
        SQL.AddParam("@TableNo", txtTableNo.Text)
        SQL.AddParam("@CustomerName", txtCustomer.Text)
        SQL.AddParam("@IDType", txtIDType.Text)
        SQL.AddParam("@IDNumber", txtIDNo.Text)
        SQL.AddParam("@BillTotal", txtBillTotal.Text)
        SQL.AddParam("@BillSub", txtSubTotal.Text)
        SQL.AddParam("@Promo", txtPromo.Text)
        SQL.AddParam("@Cash", txtCash.Text)
        SQL.AddParam("@Change", txtChange.Text)

        SQL.ExecQuery("EXEC sp_NewBill @BillNo, @BillDate, @Logged,@TableNo,@CustomerName,@IDType,@IDNumber,@Promo,@BillTotal,@BillSub,@Cash,@Change,@OrderType; ")
        If SQL.HasException(True) Then Exit Sub

    End Sub


    Private Sub FetchCatList()
        ' REFRESH LISTBOX
        lbxCategory.Items.Clear()
        ' RUN QUERY
        SQL.ExecQuery("SELECT ProductCategory from Dim_ProductCategory where IsActive= 1 ORDER BY ProductCategory;")
        If SQL.HasException(True) Then Exit Sub
        ' LOOP ROW & ADD TO LISTBOX
        For Each r As DataRow In SQL.DBDT.Rows
            lbxCategory.Items.Add(r("ProductCategory").ToString)
        Next

    End Sub

    Private Sub FetchIDType()
        ' REFRESH LISTBOX
        txtIDType.Items.Clear()
        ' RUN QUERY
        SQL.ExecQuery("select IDType from Dim_IDType;")
        If SQL.HasException(True) Then Exit Sub
        ' LOOP ROW & ADD TO LISTBOX
        For Each r As DataRow In SQL.DBDT.Rows
            txtIDType.Items.Add(r("IDType").ToString)
        Next

    End Sub

    Private Sub FetchBillQ()
        ' REFRESH LISTBOX
        lbxBillQ.Items.Clear()
        ' RUN QUERY
        SQL.ExecQuery("select BillNo from CafeBillTemp;")
        If SQL.HasException(True) Then Exit Sub
        ' LOOP ROW & ADD TO LISTBOX
        For Each r As DataRow In SQL.DBDT.Rows
            lbxBillQ.Items.Add(r("BillNo").ToString)
        Next

    End Sub


    Private Sub FetchItemList(Category As Integer)
        ' REFRESH LISTBOX
        lbxItem.Items.Clear()
        SQL.AddParam("@Item", Category)
        ' RUN QUERY

        SQL.ExecQuery("SELECT ItemID, Item, Price from Dim_Items where IsActive= 1  and ProductCategoryID = @Item ORDER BY Item;")
        If SQL.HasException(True) Then Exit Sub
        ' LOOP ROW & ADD TO LISTBOX
        For Each r As DataRow In SQL.DBDT.Rows
            lbxItem.Items.Add(r("Item").ToString)
        Next



    End Sub

    Private Sub FetchOrderType()
        ' REFRESH COMBOBOX
        cmbOrderType.Items.Clear()
        ' RUN QUERY
        SQL.ExecQuery("SELECT OrderType from Dim_OrderType ORDER BY OrderTypeID;")
        If SQL.HasException(True) Then Exit Sub
        ' LOOP ROW & ADD TO COMBOBOX
        For Each r As DataRow In SQL.DBDT.Rows
            cmbOrderType.Items.Add(r("OrderType").ToString)
        Next
        cmbOrderType.Text = "Dine-in"

    End Sub

    Private Sub lbxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCategory.SelectedIndexChanged
        Dim CategoryID As Integer
        lbxItem.Items.Clear()
        SQL.AddParam("@CatID", lbxCategory.Text)
        SQL.ExecQuery("Select ProductCategoryID from Dim_ProductCategory where IsActive= 1 and ProductCategory = @CatID")
        For Each r As DataRow In SQL.DBDT.Rows
            CategoryID = r("ProductCategoryID")
        Next
        FetchItemList(CategoryID)
    End Sub

    Private Sub lbxItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxItem.SelectedIndexChanged
        txtItem.Text = lbxItem.Text
        SQL.AddParam("@Item", lbxItem.Text)
        SQL.ExecQuery("select Price from Dim_Items where Item = @Item ")
        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            txtPrice.Text = r("Price")
        Next

        txtQty.Text = 1
        txtDisc.Text = 0
        CalculateItemTotal()
        cmdAddToList.Enabled = True


    End Sub

    Private Sub LoadDgv()

        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("Select BillItemNo, Item, Quantity, Price, Discount, ItemTotal from CafeSalesTemp where BillNo = @BillNo order by BillItemNo ; ")

        If SQL.HasException(True) Then Exit Sub

        dgvPOS.DataSource = SQL.DBDT


    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub




    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        CalculateItemTotal()
    End Sub

    Private Sub CalculateItemTotal()
        Dim number As Decimal
        Dim ItemTotal As Decimal

        If Not String.IsNullOrEmpty(txtQty.Text) AndAlso Not String.IsNullOrEmpty(txtPrice.Text) AndAlso Not String.IsNullOrEmpty(txtDisc.Text) Then

            If Decimal.TryParse(txtQty.Text, number) Then
                txtQty.Text = Format(number, "0.00")
            End If
            If Decimal.TryParse(txtPrice.Text, number) Then
                txtPrice.Text = Format(number, "0.00")
            End If
            If Decimal.TryParse(txtDisc.Text, number) Then
                txtDisc.Text = Format(number, "0.00")
            End If

            ItemTotal = (txtQty.Text * txtPrice.Text)

            If txtDisc.Text > 0 Then
                ItemTotal = ItemTotal - (ItemTotal * (txtDisc.Text / 100))
            End If

            txtTotal.Text = ItemTotal


        End If

    End Sub

    Private Sub txtDisc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDisc.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs) Handles txtDisc.TextChanged
        CalculateItemTotal()
    End Sub

    Private Sub GetIDs()
        SQL.AddParam("@ProductCategory", lbxCategory.Text)
        SQL.AddParam("@Item", lbxItem.Text)

        SQL.ExecQuery("select ProductCategoryID, ItemID from vwProductItems where ProductCategory = @ProductCategory and Item = @Item; ")
        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            ProductCat = r("ProductCategoryID")
            UnitItem = r("ItemID")
        Next



    End Sub

    Private Sub GetLastBillItemNo()
        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("select isnull(max(BillItemNo),0) maxitemno from CafeSalesTemp where BillNo = @BillNo;")

        For Each r As DataRow In SQL.DBDT.Rows
            LastBillItemNo = r("maxitemno") + 1
        Next

    End Sub



    Private Sub cmdAddToList_Click(sender As Object, e As EventArgs) Handles cmdAddToList.Click
        If lblBillNo.Text = "00" Then
            MsgBox("Please NEW BILL for new record.")
            Exit Sub
        End If

        GetIDs()
        GetLastBillItemNo()

        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.AddParam("@ProductCategoryID", ProductCat)
        SQL.AddParam("@ProductCategory", lbxCategory.Text)
        SQL.AddParam("@ItemID", UnitItem)
        SQL.AddParam("@Item", lbxItem.Text)
        SQL.AddParam("@Discount", txtDisc.Text)
        SQL.AddParam("@Quantity", txtQty.Text)
        SQL.AddParam("@Price", txtPrice.Text)
        SQL.AddParam("@ItemTotal", txtTotal.Text)
        SQL.AddParam("@LastBillItemNo", LastBillItemNo)

        SQL.ExecQuery("INSERT INTO CafeSalesTemp (BillNo, ProductCategoryID, ProductCategory, ItemID, Item, Discount, Quantity, Price, ItemTotal,BillItemNo) " & _
                      "VALUES (@BillNo, @ProductCategoryID, @ProductCategory, @ItemID, @Item, @Discount, @Quantity, @Price, @ItemTotal, @LastBillItemNo); ", True)

        If SQL.HasException(True) Then Exit Sub

        LoadDgv()
        cmdAddToList.Enabled = False
        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        '  cmdReprint.Enabled = False
        ' cmdQ.Enabled = False


        txtItem.Clear()
        txtQty.Clear()
        txtPrice.Clear()
        txtDisc.Clear()
        txtTotal.Clear()

        CalculateBillTotal()

    End Sub
    Private Sub CalculateBillTotal()
        Dim BillTotal As Decimal
        Dim SubTotal As Decimal
        Dim number As Decimal
        '  Dim promodisc As Decimal


        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("select isnull(sum(ItemTotal),0) BillTotal from CafeSalesTemp where BillNo = @BillNo; ")

        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            BillTotal = r("BillTotal")
        Next
        txtBillTotal.Text = BillTotal

        If Decimal.TryParse(txtBillTotal.Text, number) Then
            txtBillTotal.Text = Format(number, "0.00")
        End If

        If Not String.IsNullOrEmpty(txtPromo.Text) Then

            If Decimal.TryParse(txtPromo.Text, number) Then
                txtPromo.Text = Format(number, "0.00")
            End If



            If txtPromo.Text > 0 Then

                SubTotal = BillTotal - (BillTotal * (txtPromo.Text / 100))
            Else
                SubTotal = BillTotal

            End If
        End If

        txtSubTotal.Text = SubTotal

    End Sub



    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        Dim c As Integer
        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("SELECT COUNT(*) c FROM CafeSalesTemp WHERE BillNo = @BillNo; ")

        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            c = r("c")
        Next

        If c > 0 Then

            Dim index As Integer = dgvPOS.CurrentRow.Index

            SQL.AddParam("@BillItemNo", index + 1)

            SQL.AddParam("@BillNo", lblBillNo.Text)

            SQL.ExecQuery("DELETE FROM CafeSalesTemp WHERE BillItemNo = @BillItemNo and BillNo = @BillNo; ")
            If SQL.HasException(True) Then Exit Sub
            SQL.ExecQuery("UPDATE x SET x.BillItemNo = x.New_BillItemNo FROM ( " & _
                    "SELECT BillItemNo, ROW_NUMBER() OVER (ORDER BY [BillItemNo]) AS New_BillItemNo FROM CafeSalesTemp) x; ", True)
            If SQL.HasException(True) Then Exit Sub
            LoadDgv()

            cmdSave.Enabled = True
            cmdCheckout.Enabled = False
            ' cmdReprint.Enabled = False
            ' cmdQ.Enabled = False
        End If

    End Sub

    Private Sub txtPromo_TextChanged(sender As Object, e As EventArgs) Handles txtPromo.TextChanged
        cmdSave.Enabled = True
        CalculateBillTotal()
    End Sub

    Private Sub txtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem.TextChanged
        If txtItem.Text = "" Then
            cmdAddToList.Enabled = False
        Else
            cmdAddToList.Enabled = True
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If lblBillNo.Text <> "00" Then

            SQL.AddParam("@BillNo", lblBillNo.Text)
            SQL.AddParam("@OrderType", cmbOrderType.Text)
            SQL.AddParam("@TableNo", txtTableNo.Text)
            SQL.AddParam("@CustomerName", txtCustomer.Text)
            SQL.AddParam("@IDType", txtIDType.Text)
            SQL.AddParam("@IDNumber", txtIDNo.Text)
            SQL.AddParam("@BillTotal", txtBillTotal.Text)
            SQL.AddParam("@BillSub", txtSubTotal.Text)
            SQL.AddParam("@Promo", txtPromo.Text)
            SQL.AddParam("@Cash", txtCash.Text)
            SQL.AddParam("@Change", txtChange.Text)

            SQL.ExecQuery("Update CafeBillTemp " & _
                          "set OrderTYpe = @OrderType, TableNo = @TableNo, CustomerName = @CustomerName, IDType = @IDType, IDNumber = @IDNumber, PromoDiscount = @Promo, BillTotal = @BillTotal, BillSubTotal = @BillSub, Cash = @Cash, Change = @Change " & _
                          "where BillNo = @BillNo; ", True)

            If SQL.HasException(True) Then Exit Sub

            MsgBox("Record saved!")
            cmdSave.Enabled = False
            cmdCheckout.Enabled = True
            '  cmdReprint.Enabled = True
            ' cmdQ.Enabled = True
            FetchBillQ()

        Else : Exit Sub
        End If

    End Sub

    Private Sub cmdCheckout_Click(sender As Object, e As EventArgs) Handles cmdCheckout.Click
        If cmdSave.Enabled = True Then
            MsgBox("Save this record first.")
            cmdCheckout.Enabled = False
            Exit Sub

        Else
            If MsgBox("Are you sure you want to check-out?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                SQL.CurrentBillNo = lblBillNo.Text

                SQL.AddParam("@BillNo", SQL.CurrentBillNo)
                SQL.ExecQuery("EXEC sp_Checkout @BillNo ")
                If SQL.HasException(True) Then Exit Sub

                frmReceipt.Show()
                MsgBox("Bill check-out successful.")

                ClearAll()
                cmdCheckout.Enabled = False
                ' cmdReprint.Enabled = True
                'cmdQ.Enabled = True
                FetchBillQ()
                LoadDgv()
            End If

        End If


    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        If cmdSave.Enabled = True Then
            MsgBox("Save or cancel this record first.")
            Exit Sub

        End If

        CreateBillNo()
        DefaultSetting()
        LoadDgv()
        txtItem.Clear()
        txtQty.Clear()
        txtPrice.Clear()
        txtDisc.Clear()
        txtTotal.Clear()
        cmdSave.Enabled = False
        '  cmdReprint.Enabled = False
        '  cmdQ.Enabled = False


    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        Dim Change As Decimal
        Dim number As Decimal

        cmdSave.Enabled = True
        ' cmdReprint.Enabled = False
        ' cmdQ.Enabled = False

        If Not String.IsNullOrEmpty(txtCash.Text) Then

            If Decimal.TryParse(txtCash.Text, number) Then
                txtCash.Text = Format(number, "0.00")
            End If

            If Decimal.TryParse(txtSubTotal.Text, number) Then
                txtSubTotal.Text = Format(number, "0.00")
            End If

            Change = txtCash.Text - txtSubTotal.Text
            txtChange.Text = Change

            If Decimal.TryParse(txtChange.Text, number) Then
                txtChange.Text = Format(number, "0.00")
            End If
            'txtChange.Text = Format(Change, "0.00")
        End If

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("EXEC sp_CancelBill @BillNo; ")
        ClearAll()
        LoadDgv()
        FetchBillQ()
        'Me.Close()
    End Sub

    Private Sub txtTableNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTableNo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

  

    Private Sub txtCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtCustomer.TextChanged
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        '  cmdReprint.Enabled = False
        '   cmdQ.Enabled = False
    End Sub

    Private Sub txtIDType_TextChanged(sender As Object, e As EventArgs)
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        ' cmdReprint.Enabled = False
        '  cmdQ.Enabled = False
    End Sub

    Private Sub txtIDNo_TextChanged(sender As Object, e As EventArgs) Handles txtIDNo.TextChanged
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        '  cmdReprint.Enabled = False
        ' cmdQ.Enabled = False
    End Sub

    Private Sub txtTableNo_TextChanged(sender As Object, e As EventArgs) Handles txtTableNo.TextChanged
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        ' cmdReprint.Enabled = False
        'cmdQ.Enabled = False
    End Sub


    Private Sub cmbOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrderType.SelectedIndexChanged
        If cmbOrderType.Text = "Delivery" Or cmbOrderType.Text = "Take-out" Then
            txtTableNo.Text = "0"
        End If
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        ' cmdReprint.Enabled = False
        '  cmdQ.Enabled = False
    End Sub

    Private Sub txtIDType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtIDType.SelectedIndexChanged
        SQL.AddParam("@ID", txtIDType.Text)
        SQL.ExecQuery("SELECT IDDisc FROM Dim_IDType WHERE IDType = @ID; ")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            txtPromo.Text = r("IDDisc")
        Next
        cmdSave.Enabled = True
        cmdCheckout.Enabled = False
        '  cmdReprint.Enabled = False
        '  cmdQ.Enabled = False
    End Sub

    Private Sub cmdReprint_Click(sender As Object, e As EventArgs)
        If cmdSave.Enabled = True Then
            MsgBox("Save or cancel current record first.")
            ' cmdReprint.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub cmdQ_Click(sender As Object, e As EventArgs)
        If cmdSave.Enabled = True Then
            MsgBox("Save or cancel current record first.")
            '  cmdQ.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub lbxBillQ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxBillQ.SelectedIndexChanged
        If cmdSave.Enabled = True Then
            MsgBox("Save or cancel current record first.")
            Exit Sub
        Else
            LoadBillQ()
            cmdSave.Enabled = True
        End If

    End Sub

    Private Sub LoadBillQ()

        lblBillNo.Text = lbxBillQ.Text
        LoadDgv()
        SQL.AddParam("@BillNo", lblBillNo.Text)
        SQL.ExecQuery("SELECT BillNo,TableNo,CustomerName,IDType,IDNumber,PromoDiscount,BillTotal,BillSubTotal,Cash,Change,OrderType FROM CafeBillTemp WHERE BillNo = @BillNo; ")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            cmbOrderType.Text = r("OrderType")
            txtTableNo.Text = r("TableNo")
            txtCustomer.Text = r("CustomerName")
            txtIDType.Text = r("IDType")
            txtIDNo.Text = r("IDNumber")
            txtBillTotal.Text = r("BillTotal")
            txtSubTotal.Text = r("BillSubTotal")
            txtPromo.Text = r("PromoDiscount")
            txtCash.Text = r("Cash")
            txtChange.Text = r("Change")
        Next

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        If cmdSave.Enabled = True Then
            MsgBox("Save or cancel current record first.")
            Exit Sub
        Else
            Me.Close()
        End If

    End Sub
End Class