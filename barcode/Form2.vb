﻿Imports Microsoft.VisualBasic
#Region "#Usings"
Imports System
Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting.BarCode
Imports DevExpress.XtraReports.UI
' ...
#End Region ' #Usings

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getData()

        'DocumentViewer1.DocumentSource = XtraReport1
    
    End Sub

    Private Sub getData()
        '    Dim dtSPK As DataTable = TryCast(frmBarcodeProd.dgResult.DataSource, DataTable).Copy
    End Sub

    Public Function CreateCode128BarCode1(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 128.
        barCode.Symbology = New Code128Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code128Generator).CharacterSet = Code128Charset.CharsetB

        Return barCode
    End Function

    Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        Dim barCode As XRBarCode = CreateEAN13BarCode("13245649842")

        'Me.Detail.Controls.Add(CreateEAN13BarCode(frmBarcodeProd.dgResult(0, 3).Value))

        'Me.Detail.Controls.Add(CreateCode128BarCode("012345678"))
        'XtraReport1.XrLabel1.Text = "test"
        'XtraReport1.XrBarCode1 = CreateEAN13BarCode("1234567890123")

        CType(sender, XtraReport).Bands.Add(New DetailBand())
        CType(sender, XtraReport).Bands(BandKind.Detail).Controls.Add(barCode)
    End Sub

    Public Enum BarCodeTypes
        Codabar
        Code11
        Code39
        Code39Extended
        Code93
        Code93Extended
        Code128
        EAN8
        EAN13
        GS1128
        GS1DataBar
        DataMatrix
        DataMatrixGS1
        Industrial2of5
        IntelligentMail
        Interleaved2of5
        Matrix2of5
        CodeMSI
        PDF417
        PostNet
        QRCode
        UPCA
        UPCE0
        UPCE1
        UPCSupplemental2
        UPCSupplemental5
        UPCShippingContainer
    End Enum

#Region "#DataSource"
    Private Class BarCode
        Public privateType As BarCodeTypes
        Public Property Type() As BarCodeTypes
            Get
                Return privateType
            End Get
            Set(ByVal value As BarCodeTypes)
                privateType = value
            End Set
        End Property

        Private privateDisplayName As String

        Public Property DisplayName() As String
            Get
                Return privateDisplayName
            End Get
            Set(ByVal value As String)
                privateDisplayName = value
            End Set
        End Property

        Public Sub New(ByVal BarCodeType As BarCodeTypes, ByVal BarCodeName As String)
            Type = BarCodeType
            DisplayName = BarCodeName
        End Sub
    End Class

    Private Function MakeBarCodesList() As List(Of BarCode)
        Dim list As New List(Of BarCode)()

        'list.Add(New BarCode(BarCodeTypes.Codabar, "Codabar"))
        'list.Add(New BarCode(BarCodeTypes.Code11, "Code 11 (USD-8)"))
        'list.Add(New BarCode(BarCodeTypes.Code39, "Code 39 (USD-3)"))
        'list.Add(New BarCode(BarCodeTypes.Code39Extended, "Code 39 Extended"))
        'list.Add(New BarCode(BarCodeTypes.Code93, "Code 93"))
        'list.Add(New BarCode(BarCodeTypes.Code93Extended, "Code 93 Extended"))
        'list.Add(New BarCode(BarCodeTypes.Code128, "Code 128"))
        'list.Add(New BarCode(BarCodeTypes.EAN8, "EAN 8"))
        list.Add(New BarCode(BarCodeTypes.EAN13, "EAN 13"))
        'list.Add(New BarCode(BarCodeTypes.GS1128, "GS1-128 - EAN-128 (UCC)"))
        'list.Add(New BarCode(BarCodeTypes.GS1DataBar, "GS1 DataBar"))
        'list.Add(New BarCode(BarCodeTypes.DataMatrix, "Data Matrix (ECC200)"))
        'list.Add(New BarCode(BarCodeTypes.DataMatrixGS1, "Data Matrix (GS1)"))
        'list.Add(New BarCode(BarCodeTypes.Industrial2of5, "Industrial 2 of 5"))
        'list.Add(New BarCode(BarCodeTypes.IntelligentMail, "Intelligent Mail"))
        'list.Add(New BarCode(BarCodeTypes.Interleaved2of5, "Interleaved 2 of 5"))
        'list.Add(New BarCode(BarCodeTypes.Matrix2of5, "Matrix 2 of 5"))
        'list.Add(New BarCode(BarCodeTypes.CodeMSI, "MSI/Plessey"))
        'list.Add(New BarCode(BarCodeTypes.PDF417, "PDF417"))
        'list.Add(New BarCode(BarCodeTypes.PostNet, "PostNet"))
        'list.Add(New BarCode(BarCodeTypes.QRCode, "QR Code"))
        'list.Add(New BarCode(BarCodeTypes.UPCA, "UPC-A"))
        'list.Add(New BarCode(BarCodeTypes.UPCE0, "UPC-E0"))
        'list.Add(New BarCode(BarCodeTypes.UPCE1, "UPC-E1"))
        'list.Add(New BarCode(BarCodeTypes.UPCSupplemental2, "UPC Supplemental 2"))
        'list.Add(New BarCode(BarCodeTypes.UPCShippingContainer, "UPC Shipping Container Symbol (ITF-14)"))


        Return list
    End Function
#End Region ' #DataSource

#Region "#Codabar"
    Public Function CreateCodabarBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Codabar
        barCode.Symbology = New CodabarGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 300
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, CodabarGenerator).StartStopPair = CodabarStartStopPair.BN
        CType(barCode.Symbology, CodabarGenerator).WideNarrowRatio = 2.5F

        Return barCode
    End Function
#End Region ' #Codabar
#Region "#Code11"
    Public Function CreateCode11BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 11.
        barCode.Symbology = New Code11Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        Return barCode
    End Function
#End Region ' #Code11
#Region "#Code39"
    Public Function CreateCode39BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 39.
        barCode.Symbology = New Code39Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code39Generator).CalcCheckSum = False
        CType(barCode.Symbology, Code39Generator).WideNarrowRatio = 2.5F

        Return barCode
    End Function
#End Region ' #Code39
#Region "#Code39Extended"
    Public Function CreateCode39ExBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 39 Extended.
        barCode.Symbology = New Code39ExtendedGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code39ExtendedGenerator).CalcCheckSum = False
        CType(barCode.Symbology, Code39ExtendedGenerator).WideNarrowRatio = 2.5F

        Return barCode
    End Function
#End Region ' #Code39Extended
#Region "#Code93"
    Public Function CreateCode93BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 93.
        barCode.Symbology = New Code93Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code93Generator).CalcCheckSum = False

        Return barCode
    End Function
#End Region ' #Code93
#Region "#Code93Extended"
    Public Function CreateCode93ExBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 93 Extended.
        barCode.Symbology = New Code93ExtendedGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code93ExtendedGenerator).CalcCheckSum = False

        Return barCode
    End Function
#End Region ' #Code93Extended
#Region "#Code128"
    Public Function CreateCode128BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Code 128.
        barCode.Symbology = New Code128Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Code128Generator).CharacterSet = Code128Charset.CharsetB

        Return barCode
    End Function
#End Region ' #Code128
#Region "#EAN8"
    Public Function CreateEAN8BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to EAN 8.
        barCode.Symbology = New EAN8Generator()

        ' Adjust the barcode's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        Return barCode
    End Function
#End Region ' #EAN8
#Region "#EAN13"
    Public Function CreateEAN13BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to EAN 13.
        barCode.Symbology = New EAN13Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 275
        barCode.Height = 200

        Return barCode
    End Function
#End Region ' #EAN13
#Region "#GS1-128-EAN128"
    Public Function CreateGS1128BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to EAN 128.
        barCode.Symbology = New EAN128Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, EAN128Generator).CharacterSet = Code128Charset.CharsetB

        Return barCode
    End Function
#End Region ' #GS1-128-EAN128
#Region "#GS1-DataBar"
    Public Function CreateDataBarGS1BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to GS1 DataBar.
        barCode.Symbology = New DataBarGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 250
        barCode.Height = 160

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, DataBarGenerator).FNC1Substitute = "#"
        CType(barCode.Symbology, DataBarGenerator).SegmentsInRow = 4
        CType(barCode.Symbology, DataBarGenerator).Type = DataBarType.ExpandedStacked

        Return barCode
    End Function
#End Region ' #GS1-DataBar
#Region "#DataMatrixECC200"
    Public Function CreateDataMatrixBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to DataMatrix.
        barCode.Symbology = New DataMatrixGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 150

        ' If the AutoModule property is set to false, uncomment the next line.
        barCode.AutoModule = True
        'barcode.Module = 3;

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, DataMatrixGenerator).CompactionMode = DataMatrixCompactionMode.Text
        CType(barCode.Symbology, DataMatrixGenerator).MatrixSize = DataMatrixSize.MatrixAuto

        Return barCode
    End Function
#End Region ' #DataMatrixECC200
#Region "#DataMatrixGS1"
    Public Function CreateDataMatrixGS1BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Data Matrix GS1.
        barCode.Symbology = New DataMatrixGS1Generator()

        ' Adjust the bar code's main properties.
        barCode.AutoModule = True
        barCode.Text = BarCodeText
        barCode.ShowText = True
        barCode.Width = 200
        barCode.Height = 200

        ' Adjust the properties specific to the bar code type.
        ' (Assigned below are the default values.)
        CType(barCode.Symbology, DataMatrixGS1Generator).FNC1Substitute = "#"
        CType(barCode.Symbology, DataMatrixGS1Generator).HumanReadableText = True
        CType(barCode.Symbology, DataMatrixGS1Generator).MatrixSize = DataMatrixSize.MatrixAuto

        Return barCode
    End Function
#End Region ' #DataMatrixGS1
#Region "#Industrial2of5"
    Public Function CreateIndustrial2of5BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Industrial 2 of 5.
        barCode.Symbology = New Industrial2of5Generator()

        ' Adjust the main properties of the bar code.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Industrial2of5Generator).CalcCheckSum = False
        CType(barCode.Symbology, Industrial2of5Generator).WideNarrowRatio = 3

        Return barCode
    End Function
#End Region ' #Industrial2of5
#Region "#IntelligentMail"
    Public Function CreateIntelligentMailBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Intelligent Mail.
        barCode.Symbology = New IntelligentMailGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.ShowText = True
        barCode.WidthF = 300.0F
        barCode.HeightF = 50.0F

        ' If the AutoModule property is set to false, uncomment the next line.
        barCode.AutoModule = True
        'barcode.Module = 3;

        Return barCode
    End Function
#End Region ' #IntelligentMail
#Region "#Interleaved2of5"
    Public Function CreateInterleaved2of5BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code controle.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Interleaved 2 of 5.
        barCode.Symbology = New Interleaved2of5Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Interleaved2of5Generator).CalcCheckSum = False
        CType(barCode.Symbology, Interleaved2of5Generator).WideNarrowRatio = 3

        Return barCode
    End Function
#End Region ' #Interleaved2of5
#Region "#Matrix2of5"
    Public Function CreateMatrix2of5BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to Matrix 2 of 5.
        barCode.Symbology = New Matrix2of5Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, Matrix2of5Generator).CalcCheckSum = False
        CType(barCode.Symbology, Matrix2of5Generator).WideNarrowRatio = 3

        Return barCode
    End Function
#End Region ' #Matrix2of5
#Region "#MSI-Plessey"
    Public Function CreateCodeMSIBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to MSI.
        barCode.Symbology = New CodeMSIGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, CodeMSIGenerator).MSICheckSum = MSICheckSum.DoubleModulo10

        Return barCode
    End Function
#End Region ' #MSI-Plessey
#Region "#PDF417"
    Public Function CreatePDF417BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to PDF417.
        barCode.Symbology = New PDF417Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 150

        ' If the AutoModule property is set to false, uncomment the next line.
        barCode.AutoModule = True
        'barcode.Module = 3;

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, PDF417Generator).Columns = 1
        CType(barCode.Symbology, PDF417Generator).CompactionMode = PDF417CompactionMode.Text
        CType(barCode.Symbology, PDF417Generator).ErrorCorrectionLevel = ErrorCorrectionLevel.Level2
        CType(barCode.Symbology, PDF417Generator).Rows = 9
        CType(barCode.Symbology, PDF417Generator).TruncateSymbol = False
        CType(barCode.Symbology, PDF417Generator).YToXRatio = 3

        Return barCode
    End Function
#End Region ' #PDF417
#Region "#PostNet"
    Public Function CreatePostNetBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to PostNet.
        barCode.Symbology = New PostNetGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        Return barCode
    End Function
#End Region ' #PostNet
#Region "#QRCode"
    Public Function CreateQRCodeBarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to QRCode.
        barCode.Symbology = New QRCodeGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 150

        ' If the AutoModule property is set to false, uncomment the next line.
        barCode.AutoModule = True
        ' barcode.Module = 3;

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, QRCodeGenerator).CompactionMode = QRCodeCompactionMode.AlphaNumeric
        CType(barCode.Symbology, QRCodeGenerator).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H
        CType(barCode.Symbology, QRCodeGenerator).Version = QRCodeVersion.AutoVersion

        Return barCode
    End Function
#End Region ' #QRCode
#Region "#UPC-A"
    Public Function CreateUPCABarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to UPC-A.
        barCode.Symbology = New UPCAGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 275
        barCode.Height = 200

        Return barCode
    End Function
#End Region ' #UPC-A
#Region "#UPC-E0"
    Public Function CreateUPCE0BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to UPC-E0.
        barCode.Symbology = New UPCE0Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        Return barCode
    End Function
#End Region ' #UPC-E0
#Region "#UPC-E1"
    Public Function CreateUPCE1BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to UPC-E1.
        barCode.Symbology = New UPCE1Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 100

        Return barCode
    End Function
#End Region ' #UPC-E1
#Region "#UPCSupplemental2"
    Public Function CreateUPCSupplemental2BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to UPC Supplemental 2.
        barCode.Symbology = New UPCSupplemental2Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 100
        barCode.Height = 55

        Return barCode
    End Function
#End Region ' #UPCSupplemental2
#Region "#UPCSupplemental5"
    Public Function CreateUPCSupplemental5BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to UPC Supplemental 5.
        barCode.Symbology = New UPCSupplemental5Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 150
        barCode.Height = 55

        Return barCode
    End Function
#End Region ' #UPCSupplemental5
#Region "#UPCShippingContainer"
    Public Function CreateITF14BarCode(ByVal BarCodeText As String) As XRBarCode
        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the barcode's type to ITF-14.  
        barCode.Symbology = New ITF14Generator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 350
        barCode.Height = 100

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, ITF14Generator).CalcCheckSum = False
        CType(barCode.Symbology, ITF14Generator).WideNarrowRatio = 2.5F

        Return barCode
    End Function
#End Region ' #UPCShippingContainer

#Region "#CreateBarCode"
    Public Function CreateBarCode(ByVal Type As BarCodeTypes) As XRBarCode
        Dim barCode As XRBarCode = Nothing

        Select Case Type
            Case BarCodeTypes.Codabar
                barCode = CreateCodabarBarCode("0123-456789")
            Case BarCodeTypes.Code11
                barCode = CreateCode11BarCode("0123-456789")
            Case BarCodeTypes.Code39
                barCode = CreateCode39BarCode("01234-ABCD")
            Case BarCodeTypes.Code39Extended
                barCode = CreateCode39ExBarCode("012-Abc")
            Case BarCodeTypes.Code93
                barCode = CreateCode93BarCode("01234-ABCD")
            Case BarCodeTypes.Code93Extended
                barCode = CreateCode93ExBarCode("012-Abc")
            Case BarCodeTypes.Code128
                barCode = CreateCode128BarCode("01234-ABcd")
            Case BarCodeTypes.EAN8
                barCode = CreateEAN8BarCode("01234567")
            Case BarCodeTypes.EAN13
                barCode = CreateEAN13BarCode(frmBarcodeProd.dgResult(0, 3).Value)
            Case BarCodeTypes.GS1128
                barCode = CreateGS1128BarCode("01234-Abcd")
            Case BarCodeTypes.GS1DataBar
                barCode = CreateDataBarGS1BarCode("01906141410000153202000150")
            Case BarCodeTypes.DataMatrix
                barCode = CreateDataMatrixBarCode("01234-ABCD")
            Case BarCodeTypes.DataMatrixGS1
                barCode = CreateDataMatrixGS1BarCode("01234-ABCD")
            Case BarCodeTypes.Industrial2of5
                barCode = CreateIndustrial2of5BarCode("0123456789")
            Case BarCodeTypes.IntelligentMail
                barCode = CreateIntelligentMailBarCode("4408200000012345678991203")
            Case BarCodeTypes.Interleaved2of5
                barCode = CreateInterleaved2of5BarCode("0123456789")
            Case BarCodeTypes.Matrix2of5
                barCode = CreateMatrix2of5BarCode("0123456789")
            Case BarCodeTypes.CodeMSI
                barCode = CreateCodeMSIBarCode("0123456789")
            Case BarCodeTypes.PDF417
                barCode = CreatePDF417BarCode("01234-ABCD")
            Case BarCodeTypes.PostNet
                barCode = CreatePostNetBarCode("0123456789")
            Case BarCodeTypes.QRCode
                barCode = CreateQRCodeBarCode("01234-ABCD")
            Case BarCodeTypes.UPCA
                barCode = CreateUPCABarCode("00123456789")
            Case BarCodeTypes.UPCE0
                barCode = CreateUPCE0BarCode("123")
            Case BarCodeTypes.UPCE1
                barCode = CreateUPCE1BarCode("123")
            Case BarCodeTypes.UPCSupplemental2
                barCode = CreateUPCSupplemental2BarCode("01")
            Case BarCodeTypes.UPCSupplemental5
                barCode = CreateUPCSupplemental5BarCode("01234")
            Case BarCodeTypes.UPCShippingContainer
                barCode = CreateITF14BarCode("1234567890123")
        End Select

        Return barCode
    End Function
#End Region ' #CreateBarCode
End Class