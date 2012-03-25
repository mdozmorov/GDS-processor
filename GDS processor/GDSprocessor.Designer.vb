<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GDSprocessor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnQC = New System.Windows.Forms.Button()
        Me.btnNormalize = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.btnFolderSelect = New System.Windows.Forms.Button()
        Me.lblNumOfFiles = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGDSmetaData = New System.Windows.Forms.TextBox()
        Me.txtAnnotation = New System.Windows.Forms.TextBox()
        Me.btnAnnotation = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRawDataFile = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQCFileName = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(12, 278)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(121, 25)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "Process all GDS files"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(456, 513)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnQC
        '
        Me.btnQC.Location = New System.Drawing.Point(15, 419)
        Me.btnQC.Name = "btnQC"
        Me.btnQC.Size = New System.Drawing.Size(121, 23)
        Me.btnQC.TabIndex = 2
        Me.btnQC.Text = "Quality Control"
        Me.btnQC.UseVisualStyleBackColor = True
        '
        'btnNormalize
        '
        Me.btnNormalize.Location = New System.Drawing.Point(12, 524)
        Me.btnNormalize.Name = "btnNormalize"
        Me.btnNormalize.Size = New System.Drawing.Size(121, 25)
        Me.btnNormalize.TabIndex = 3
        Me.btnNormalize.Text = "Normalization"
        Me.btnNormalize.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Initializing - select folder containing GSM files"
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(15, 27)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(217, 20)
        Me.txtFolder.TabIndex = 5
        '
        'btnFolderSelect
        '
        Me.btnFolderSelect.Location = New System.Drawing.Point(238, 27)
        Me.btnFolderSelect.Name = "btnFolderSelect"
        Me.btnFolderSelect.Size = New System.Drawing.Size(30, 23)
        Me.btnFolderSelect.TabIndex = 6
        Me.btnFolderSelect.Text = "..."
        Me.btnFolderSelect.UseVisualStyleBackColor = True
        '
        'lblNumOfFiles
        '
        Me.lblNumOfFiles.AutoSize = True
        Me.lblNumOfFiles.Location = New System.Drawing.Point(12, 50)
        Me.lblNumOfFiles.Name = "lblNumOfFiles"
        Me.lblNumOfFiles.Size = New System.Drawing.Size(19, 13)
        Me.lblNumOfFiles.TabIndex = 7
        Me.lblNumOfFiles.Text = "***"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "File for storind GDS meta data"
        '
        'txtGDSmetaData
        '
        Me.txtGDSmetaData.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtGDSmetaData.Location = New System.Drawing.Point(15, 181)
        Me.txtGDSmetaData.Name = "txtGDSmetaData"
        Me.txtGDSmetaData.Size = New System.Drawing.Size(217, 20)
        Me.txtGDSmetaData.TabIndex = 9
        Me.txtGDSmetaData.Text = "GDSinfo.txt"
        '
        'txtAnnotation
        '
        Me.txtAnnotation.Location = New System.Drawing.Point(15, 133)
        Me.txtAnnotation.Name = "txtAnnotation"
        Me.txtAnnotation.Size = New System.Drawing.Size(217, 20)
        Me.txtAnnotation.TabIndex = 11
        '
        'btnAnnotation
        '
        Me.btnAnnotation.Location = New System.Drawing.Point(238, 130)
        Me.btnAnnotation.Name = "btnAnnotation"
        Me.btnAnnotation.Size = New System.Drawing.Size(30, 23)
        Me.btnAnnotation.TabIndex = 12
        Me.btnAnnotation.Text = "..."
        Me.btnAnnotation.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 94)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(291, 13)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ftp://ftp.ncbi.nih.gov/gene/DATA/GENE_INFO/Mammalia/"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(284, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Download annotation file Homo_sapiens.gene_info.gz from"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "extractit and locate on disk"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "File for storing extracted raw data"
        '
        'txtRawDataFile
        '
        Me.txtRawDataFile.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtRawDataFile.Location = New System.Drawing.Point(15, 230)
        Me.txtRawDataFile.Name = "txtRawDataFile"
        Me.txtRawDataFile.Size = New System.Drawing.Size(215, 20)
        Me.txtRawDataFile.TabIndex = 17
        Me.txtRawDataFile.Text = "GDSmatrix.txt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(260, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Step 1 - Extract raw data from 1-color human datasets"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 315)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Step 2 - quality control of raw data"
        '
        'txtQCFileName
        '
        Me.txtQCFileName.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtQCFileName.Location = New System.Drawing.Point(15, 352)
        Me.txtQCFileName.Name = "txtQCFileName"
        Me.txtQCFileName.Size = New System.Drawing.Size(215, 20)
        Me.txtQCFileName.TabIndex = 20
        Me.txtQCFileName.Text = "GDSQCdata.txt"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox1.Location = New System.Drawing.Point(12, 393)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(218, 20)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.Text = "GDSmatrixQC.txt"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 336)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "File to store GSM statistics"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 377)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(194, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "File to store data that passed QC check"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 460)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(259, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Step 3 - scale and quantile normalize QC passed data"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 481)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "File to store normalized data"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox2.Location = New System.Drawing.Point(15, 498)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(215, 20)
        Me.TextBox2.TabIndex = 26
        Me.TextBox2.Text = "GDSmatrixQCnorm.txt"
        '
        'GDSprocessor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 561)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtQCFileName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRawDataFile)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnAnnotation)
        Me.Controls.Add(Me.txtAnnotation)
        Me.Controls.Add(Me.txtGDSmetaData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNumOfFiles)
        Me.Controls.Add(Me.btnFolderSelect)
        Me.Controls.Add(Me.txtFolder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNormalize)
        Me.Controls.Add(Me.btnQC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnProcess)
        Me.Name = "GDSprocessor"
        Me.Text = "GDS file processor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnQC As System.Windows.Forms.Button
    Friend WithEvents btnNormalize As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents btnFolderSelect As System.Windows.Forms.Button
    Friend WithEvents lblNumOfFiles As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGDSmetaData As System.Windows.Forms.TextBox
    Friend WithEvents txtAnnotation As System.Windows.Forms.TextBox
    Friend WithEvents btnAnnotation As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRawDataFile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQCFileName As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox

End Class
