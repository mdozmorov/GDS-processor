Imports System.Collections.ObjectModel
Imports System.IO

Public Class GDSprocessor

    Private Sub btnFolderSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolderSelect.Click
        FolderBrowserDialog1.ShowDialog()           'Select folder
        txtFolder.Text = FolderBrowserDialog1.SelectedPath
        lblNumOfFiles.Text = My.Computer.FileSystem.GetFiles(FolderBrowserDialog1.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly, "GDS*.soft").Count & " GDS*.soft files found"
    End Sub

    Private Sub btnAnnotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnotation.Click
        OpenFileDialog1.InitialDirectory = txtFolder.Text
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.SafeFileName = "Homo_sapiens.gene_info" Then
            txtAnnotation.Text = OpenFileDialog1.FileName
        Else
            MsgBox("Locate Homo_sapiens.gene_info file on disk") : Exit Sub
        End If

    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim files As ReadOnlyCollection(Of String), fdir As String, fnum As Short
        Dim f As Object, Line1 As String, ch As String, sp() As String, exptsp() As String, counter As Integer
        Dim org() As String, et() As String, MaxFields() As Short, MaxLines() As Short, desc() As String, ValType() As String, plat() As String, probe() As String, exptdesc() As String
        Dim ProcessFlag As Boolean, UB As Short, UBexpt As Short
        Dim MicroArray(,) As Single, LLIDnames(,) As String, Sample_ID() As String, t As Integer, recs As Integer, MaxLLID As Integer, MaxGDS As Integer, CurrentGDS As Integer
        Dim LLIDpresent() As Integer, NumOfFiles As Integer

        'Check if user entered path to files
        If txtFolder.Text = vbNullString Then
            MsgBox("Select folder containing GSM files") : Exit Sub
        Else
            fdir = txtFolder.Text
        End If

        If txtGDSmetaData.Text = vbNullString Then
            MsgBox("Enter file name for storing GDS meta data") : Exit Sub
        Else
            FileOpen(10, fdir & "\GDSinfo.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Shared)               'File for outputting the resulting matrixFileOpen(2, "E:\WorkOMRF\Gene Ontology\HS.NCBI\Homo_sapiens.gene_info.txt", OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
            PrintLine(10, "GDS" & vbTab & "Organism" & vbTab & "Channels" & vbTab & "Samples" & vbTab & "Genes" & vbTab & "Description" & vbTab & "Value type" & vbTab & "Platform" & vbTab & "Type")
        End If

        files = My.Computer.FileSystem.GetFiles(fdir, FileIO.SearchOption.SearchTopLevelOnly, "GDS*.soft")  'Get a list of GDS files
        fnum = files.Count                                                                                  'And count of them

        'Prepare arrays for storing meta-data for them
        ReDim org(fnum) : ReDim et(fnum) : ReDim MaxFields(fnum) : ReDim MaxLines(fnum) : ReDim desc(fnum) : ReDim ValType(fnum) : ReDim plat(fnum) : ReDim probe(fnum) : ReDim exptdesc(fnum)

        counter = 0
        For Each f In files
            counter += 1
            FileClose(1)                                                            'Close previous file
            FileOpen(1, f, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)    'Open new
            While Not EOF(1)
                Line1 = LineInput(1)                                                'Read a line
                ch = Mid(Line1, 1, 1)                                               'First symbol of a string
                If (ch$ = "!" Or ch$ = "^" Or ch$ = "#") Then                       'Is it header?
                    If Mid(Line1, 1, 27) = "!dataset_sample_organism = " Then org(counter) = Mid(Line1, 27, Line1.Length) 'Organism
                    If Mid(Line1, 1, 25) = "!dataset_channel_count = " Then et(counter) = Mid(Line1, 25, Line1.Length) 'Number of channels
                    If Mid(Line1, 1, 24) = "!dataset_sample_count = " Then MaxFields(counter) = Val(Mid(Line1, 24, Line1.Length)) 'Number of samples
                    If Mid(Line1, 1, 25) = "!dataset_feature_count = " Then MaxLines(counter) = Val(Mid(Line1, 25, Line1.Length)) 'Number of genes
                    If Mid(Line1, 1, 23) = "!dataset_description = " Then desc(counter) = Mid(Line1, 23, Line1.Length) 'Description
                    If Mid(Line1, 1, 22) = "!dataset_value_type = " Then ValType(counter) = Mid(Line1, 22, Line1.Length) 'Type of value, count OR transformed count
                    If ValType(counter) = "transformed count" Then ValType(counter) = "TC" 'Mark transformed count experiments
                    If Mid(Line1, 1, 20) = "!dataset_platform = " Then plat(counter) = Mid(Line1, 20, Line1.Length) 'Platform
                    If Mid(Line1, 1, 16) = "!dataset_type = " Then probe(counter) = Mid(Line1, 16, Line1.Length) 'Probe type
                    'If Mid(Line1, 1, 4) = "#GSM" Then exptdesc(counter) = exptdesc(counter) & Line1 & "||" 'Put descriptions in one string separated by ||
                End If
                If ch = "!" And Line1 = "!dataset_table_begin" Then Exit While 'Mark for beginning of a dataset
            End While
            'Save meta data
            PrintLine(10, f & vbTab & org(counter) & vbTab & et(counter) & vbTab & MaxFields(counter) & vbTab & MaxLines(counter) & vbTab & desc(counter) & vbTab & ValType(counter) & vbTab & plat(counter) & vbTab & probe(counter))

        Next
        FileClose(1)
        FileClose(10)
        MsgBox("Meta data saved in " & txtGDSmetaData.Text)

        'Run through annotation file and count number of LLIDs, equal number of rows
        FileOpen(2, txtAnnotation.Text, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
        MaxLLID = 0
        While Not EOF(2)            'Read until end of file
            LineInput(2)            'Go through each line
            MaxLLID += 1            'And incrementally increase LLID counter
            'Debug.Print(MaxLLID)
        End While
        FileClose(2)                'Close the file to reset row counter

        'MaxLLID = 46663
        'Run through each GDS file, check its meta data, and count number of GSMs 
        MaxGDS = 0
        For t = 1 To fnum
            'Check if the file satisfies the conditions
            If InStr(org(t), "Homo sapiens") <> 0 And (InStr(probe(t), "nucleotide") <> 0 Or InStr(probe(t), "gene expression") <> 0) And (InStr(et(t), "single") <> 0 Or InStr(et(t), "1") <> 0) Then
                MaxGDS += MaxFields(t)
            End If
        Next

        'Attempt to allocate memory
        Try
            ReDim MicroArray(MaxLLID, MaxGDS)   'Container for numerical data
            ReDim LLIDnames(MaxLLID, 1)         'Cross-mapping array, holding LLID (0) and corresponding Gene identifier (1)
            ReDim Sample_ID(MaxGDS)             'Array for GSM names
        Catch ex As Exception
            MsgBox("OUT OF MEMORY :(" & vbCrLf & "Choose less files or upgrade your computer memory")
        End Try

        'Open annotation file once more and populate cross-mapping array
        FileOpen(2, txtAnnotation.Text, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
        counter = 0
        While Not EOF(2)
            counter += 1
            Line1 = LineInput(2)
            sp = Line1.Split(vbTab)
            LLIDnames(counter, 0) = sp(1)   'LLID
            LLIDnames(counter, 1) = sp(2)   'Gene name
        End While
        FileClose(2)

        'File for outputting the resulting matrix
        FileOpen(10, fdir & "\" & txtFolder.Text, OpenMode.Output, OpenAccess.Default, OpenShare.Shared)

        'Run through each file again and extract raw data
        counter = 0
        CurrentGDS = 0
        For Each f In files
            counter += 1    'Counter for datasets
            Debug.Print(counter)
            FileClose(1)
            FileOpen(1, f, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
            'Proceed only if several parameters match
            If InStr(org(counter), "Homo sapiens") <> 0 And (InStr(probe(counter), "nucleotide") <> 0 Or InStr(probe(counter), "gene expression") <> 0) And (InStr(et(counter), "single") <> 0 Or InStr(et(counter), "1") <> 0) Then
                While Not EOF(1)
                    Line1 = LineInput(1)                                    'Read a line
                    ch = Mid(Line1, 1, 1)                                   'First symbol of a string
                    If ch = "!" And Line1 = "!dataset_table_begin" Then     'If beginning of the dataset encountered
                        Line1 = LineInput(1)                                'Dataset header
                        sp = Line1.Split(vbTab)                             'Split, sp(0)=ID sp(1)=Name sp(2)... - GSM names
                        For t = 1 To MaxFields(counter)                     'Go through each GSM in a dataset
                            Sample_ID(CurrentGDS + t) = sp(t + 1)           'Store GSM names
                        Next
                        For recs = 1 To MaxLines(counter)                   'Go through each line in a dataset
                            Line1 = LineInput(1)                            'Read in
                            sp = Line1.Split(vbTab)                         'and split
                            For t = 1 To MaxLLID                            'Run through each LLID
                                If sp(1) = LLIDnames(t, 1) Then Exit For 't stores LLID number, when matching LLID found
                            Next
                            If t <= MaxLLID Then                            'check if LLID found, otherwice skip
                                For tt = 1 To MaxFields(counter)            'Go through each field
                                    If sp(tt + 1) = "null" Then sp(tt + 1) = vbNullString
                                    MicroArray(t, CurrentGDS + tt) = sp(tt + 1) 'Populate columns in the matrix
                                Next
                            End If
                        Next
                    End If

                End While
                CurrentGDS += MaxFields(counter)                            'MaxGDS stores last row position in the matrix
            End If
        Next

        'Go through each LLID and count number of times it's more than 0
        ReDim LLIDpresent(MaxLLID)
        For t = 1 To MaxGDS
            For tt = 1 To MaxLLID
                If MicroArray(tt, t) > 0 Then LLIDpresent(tt) += 1
            Next
        Next

        'Output header containing LLIDs expressed at least in one experiment
        Print(10, "-" & vbTab)
        For t = 1 To MaxLLID
            If LLIDpresent(t) > 0 Then Print(10, LLIDnames(t, 0) & vbTab)
        Next
        Print(10, vbCrLf)

        'Process data matrix and output the data when LLID expressed at least in one experiment
        counter = 0
        CurrentGDS = 0
        For Each f In files
            counter += 1
            If InStr(org(counter), "Homo sapiens") <> 0 And (InStr(probe(counter), "nucleotide") <> 0 Or InStr(probe(counter), "gene expression") <> 0) And (InStr(et(counter), "single") <> 0 Or InStr(et(counter), "1") <> 0) Then
                For t = 1 To MaxFields(counter)
                    Print(10, Sample_ID(CurrentGDS + t) & vbTab)
                    For tt = 1 To MaxLLID
                        If LLIDpresent(tt) > 0 Then Print(10, MicroArray(tt, CurrentGDS + t) & vbTab)
                    Next
                    Print(10, vbCrLf)
                Next
                CurrentGDS += MaxFields(counter)                    'MaxGDS stores last row position in the matrix
            End If
        Next
        MsgBox("Raw data extracted successfully and stored in " & txtRawDataFile.Text)

        '    'For recs = 1 To MaxLines
        '    '    Print(10, MAnames(recs) & vbTab)
        '    '    For t = 2 To UB
        '    '        Print(10, MicroArray(t, recs) & vbTab)
        '    '    Next
        '    '    Print(10, vbCrLf)
        '    'Next
        'Else
        '    Exit While      'Proceed next file, if current didn't match the criteria
        'End If
        'MsgBox("sss")



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        'If My.Computer.Network.Ping("ftp://ftp.ncbi.nih.gov/gene/DATA/", 1000) Then
        '    MsgBox("Ping successful")
        '    My.Computer.Network.DownloadFile("ftp://ftp.ncbi.nih.gov/gene/DATA/README", "E:\readme.txt")
        '    MsgBox("Downloaded")
        'Else
        '    MsgBox("No luck")
        'End If
    End Sub

    Private Sub btnQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQC.Click
        Dim FileName1 As String, FileName2 As String, FileName3 As String
        Dim Line1 As String, sp() As String
        Dim MaxLLID As Integer, GSMzeros() As Single, GSMzerosTrimmed() As Single
        Dim Min As Single, Max As Single, Mean As Single, Median As Single, NumZeros As Integer, Excluded As String

        'Open raw data file
        FileName1 = txtFolder.Text & "\" & txtRawDataFile.Text
        FileOpen(1, FileName1, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
        Line1 = LineInput(1)                    'Read first line
        MaxLLID = UBound(Line1.Split(vbTab))    'Get number of LLIDs
        ReDim GSMzeros(MaxLLID)                 'Prepare array to store number of times LLID equal to 0

        FileName2 = "D:\GEOEXP\GDSmatrixQC.txt"
        FileOpen(2, FileName2, OpenMode.Output)
        PrintLine(2, Line1)

        FileName1 = txtFolder.Text & "\" & txtQCFileName.Text
        FileName3 = "D:\GEOEXP\GDSQCdata.txt"
        FileOpen(3, FileName3, OpenMode.Output)
        PrintLine(3, "GSM" & vbTab & "Min" & vbTab & "Max" & vbTab & "Average" & vbTab & "Median" & vbTab & "% of zeros" & vbTab & "Excluded")

        Do Until EOF(1)
            Line1 = LineInput(1)
            sp = Line1.Split(vbTab)
            For t = 1 To MaxLLID
                If sp(t) <> vbNullString Then GSMzeros(t) = sp(t)
            Next
            Array.Sort(GSMzeros)
            NumZeros = 0
            For t = 1 To MaxLLID
                If GSMzeros(t) = 0 Then NumZeros += 1
            Next
            ReDim GSMzerosTrimmed(MaxLLID - NumZeros)
            For t = 0 To MaxLLID - NumZeros
                GSMzerosTrimmed(t) = GSMzeros(t + NumZeros)
            Next
            Min = GSMzerosTrimmed.Min
            Max = GSMzerosTrimmed.Max
            Mean = GSMzerosTrimmed.Average
            Median = GSMzerosTrimmed((MaxLLID - NumZeros) / 2)
            IIf(Mean / Median < 1.2, Excluded = "Yes", Excluded = "No")
            PrintLine(3, sp(0) & vbTab & Min & vbTab & Max & vbTab & Mean & vbTab & Median & vbTab & (System.Math.Round((NumZeros / MaxLLID) * 100)) & vbTab & Excluded)
            If Excluded = "No" Then PrintLine(2, Line1)
        Loop

        MsgBox("sss")
    End Sub

    Private Sub btnNormalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNormalize.Click
        Dim FileName1 As String, FileName2 As String, FileName3 As String
        Dim Line1 As String, sp() As String
        Dim MaxGSM As Integer, MaxLLID As Integer, Microarray(,) As Single, Sample_ID() As String
        Dim b() As Single, c() As Single, Keys() As Short, GSMnulls() As Boolean, Min As Single, Max As Single, coeff As Single, tGSM As Integer, tLLID As Integer

        FileName1 = "D:\GEOEXP\GDSmatrix.txt"
        FileOpen(1, FileName1, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
        Line1 = LineInput(1)
        MaxLLID = UBound(Line1.Split(vbTab))

        FileName2 = "D:\GEOEXP\GDSmatrix1-10000.txt"
        FileOpen(2, FileName2, OpenMode.Output)
        PrintLine(2, Line1)

        While Not EOF(1)
            Line1 = LineInput(1)
            MaxGSM += 1
        End While
        FileClose(1)

        ReDim Microarray(MaxLLID, MaxGSM) : ReDim Sample_ID(MaxGSM)

        FileOpen(1, FileName1, OpenMode.Input, OpenAccess.Default, OpenShare.Shared)
        Line1 = LineInput(1)

        For tGSM = 1 To MaxGSM
            Line1 = LineInput(1)
            sp = Line1.Split(vbTab)
            Sample_ID(tGSM) = sp(0)
            Erase b : ReDim b(MaxLLID)
            For tLLID = 1 To MaxLLID
                If sp(tLLID) = vbNullString Then
                    b(tLLID) = vbNull
                Else
                    b(tLLID) = sp(tLLID)
                End If
            Next
            Min = b.Min : coeff = 10000 / (b.Max - b.Min)

            For tLLID = 1 To MaxLLID
                Microarray(tLLID, tGSM) = ((b(tLLID) - Min) * coeff)
            Next
        Next

        'ReDim c(MaxLLID) : ReDim Keys(MaxLLID)

        'For tGSM = 1 To MaxGSM
        '    Erase b : ReDim b(MaxLLID)
        '    For tLLID = 1 To MaxLLID
        '        b(tLLID) = Microarray(tLLID, tGSM)
        '    Next
        '    Array.Sort(b)
        '    For tLLID = 1 To MaxLLID
        '        c(tLLID) += b(tLLID)
        '    Next
        'Next

        'For tLLID = 1 To MaxLLID
        '    Keys(tLLID) = tLLID
        '    c(tLLID) = c(tLLID) / MaxGSM
        '    'For tGSM = 1 To MaxGSM
        '    '    c(tLLID) += Microarray(tLLID, tGSM)
        '    'Next
        '    'c(tLLID) = c(tLLID) / MaxGSM
        'Next
        ''Array.Sort(c)


        'For tGSM = 1 To MaxGSM
        '    Erase GSMnulls : ReDim GSMnulls(MaxLLID)
        '    Erase b : ReDim b(MaxLLID)
        '    For tLLID = 1 To MaxLLID
        '        If Microarray(tLLID, tGSM) = 0 Then
        '            GSMnulls(tLLID) = True
        '        Else
        '            GSMnulls(tLLID) = False
        '        End If
        '        b(tLLID) = Microarray(tLLID, tGSM)
        '    Next
        '    Array.Sort(b, Keys)
        '    For tLLID = 1 To MaxLLID
        '        b(tLLID) = c(tLLID)
        '    Next
        '    Array.Sort(Keys, b)

        '    For tLLID = 1 To MaxLLID
        '        If GSMnulls(tLLID) = True Then
        '            Microarray(tLLID, tGSM) = vbNull
        '        Else
        '            Microarray(tLLID, tGSM) = b(tLLID)
        '        End If
        '        'Microarray(tLLID, tGSM) = b(tLLID)
        '    Next
        'Next

        For tGSM = 1 To MaxGSM
            Print(2, Sample_ID(tGSM) & vbTab)
            For tLLID = 1 To MaxLLID
                Print(2, Microarray(tLLID, tGSM) & vbTab)
            Next
            Print(2, vbCrLf)
        Next
        FileClose(1)
        FileClose(2)
        MsgBox("ddd")
    End Sub


End Class
