Imports System.Collections.Generic
Imports DevExpress.DataAccess.Wizard.Model
Imports DevExpress.DataAccess.Wizard.Presenters
Imports DevExpress.Utils.IoC
Imports DevExpress.Xpf.DataAccess.DataSourceWizard
Imports DevExpress.Xpf.Reports.UserDesigner.ReportWizard
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Wizards
Imports DevExpress.DataAccess.UI.Wizard
Imports DevExpress.XtraReports.Wizards.Presenters
Imports System.Runtime.InteropServices

Namespace WpfReportDesigner_CustomizeWizard

    Public Class MyWizardCustomizationService
        Implements IWizardCustomizationService

        Private Sub CustomizeDataSourceWizard(ByVal customization As DataSourceWizardCustomizationModel, ByVal container As ViewModelSourceIntegrityContainer) Implements IDataSourceWizardCustomizationService.CustomizeDataSourceWizard
            If customization.StartPage Is GetType(ChooseDataSourceTypePage(Of IDataSourceModel)) Then
                customization.Model.DataSourceType = DataSourceType.Xpo
                customization.StartPage = GetType(ConnectionPropertiesPage(Of IDataSourceModel))
            End If

            CustomizeProviders(container)
        End Sub

        Private Sub CustomizeReportWizard(ByVal customization As ReportWizardCustomizationModel, ByVal container As ViewModelSourceIntegrityContainer) Implements IWizardCustomizationService.CustomizeReportWizard
            If customization.StartPage Is GetType(ChooseReportTypePage(Of XtraReportModel)) Then
                customization.Model.ReportType = ReportType.Standard
                customization.Model.DataSourceType = DataSourceType.Xpo
                customization.StartPage = GetType(ConnectionPropertiesPage(Of XtraReportModel))
            End If

            CustomizeProviders(container)
        End Sub

        Private Function TryCreateDataSource(ByVal model As IDataSourceModel, <Out> ByRef dataSource As Object, <Out> ByRef dataMember As String) As Boolean Implements IDataSourceWizardCustomizationService.TryCreateDataSource
            dataSource = Nothing
            dataMember = Nothing
            Return False
        End Function

        Private Function TryCreateReport(ByVal model As XtraReportModel, <Out> ByRef report As XtraReport) As Boolean Implements IWizardCustomizationService.TryCreateReport
            report = Nothing
            Return False
        End Function

        Private Shared Sub CustomizeProviders(ByVal container As IntegrityContainer)
            Dim providers = container.Resolve(Of List(Of ProviderLookupItem))()
            providers.RemoveAll(Function(ByVal x) Not Equals(x.ProviderKey, "MSSqlServer"))
        End Sub
    End Class
End Namespace
