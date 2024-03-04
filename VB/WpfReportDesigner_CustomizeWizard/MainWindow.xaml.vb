Imports System.Windows

Namespace WpfReportDesigner_CustomizeWizard

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Me.reportDesigner.Loaded, AddressOf Me.ReportDesigner_Loaded
        End Sub

        Private Sub ReportDesigner_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            RemoveHandler Me.reportDesigner.Loaded, AddressOf Me.ReportDesigner_Loaded
            Me.reportDesigner.ActualCommands.NewDocumentCommand.Execute(Nothing)
        End Sub
    End Class
End Namespace
