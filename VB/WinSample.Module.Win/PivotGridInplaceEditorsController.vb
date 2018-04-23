Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.PivotChart
Imports DevExpress.ExpressApp.PivotChart.Win
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Persistent.Base

Namespace WinSample.Module.Win
	Public Class PivotGridInplaceEditorsController
		Inherits ObjectViewController(Of DetailView, IAnalysisInfo)
		Private analysisEditor As AnalysisEditorWin
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			analysisEditor = View.GetItems(Of AnalysisEditorWin)()(0)
			AddHandler analysisEditor.ControlCreated, AddressOf analysisEditor_ControlCreated
			AddHandler (CType(View.CurrentObject, IAnalysisInfo)).InfoChanged, AddressOf PivotGridInplaceEditorsController_InfoChanged
		End Sub
		Private Sub analysisEditor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
			CustomizePivotGrid(analysisEditor.Control.PivotGrid)
			analysisEditor.Control.FieldBuilder = New MyPivotGridFieldBuilder(analysisEditor.Control)
			analysisEditor.Control.FieldBuilder.SetModel(Application.Model)
		End Sub
		Private Sub PivotGridInplaceEditorsController_InfoChanged(ByVal sender As Object, ByVal e As AnalysisInfoChangedEventEventArgs)
			If e.ChangeType = AnalysisInfoChangeType.ObjectTypeChanged Then
				CustomizePivotGrid(analysisEditor.Control.PivotGrid)
			End If
		End Sub
		Private Sub CustomizePivotGrid(ByVal pivotGrid As PivotGridControl)
			If (CType(View.CurrentObject, IAnalysisInfo)).DataType Is GetType(AnalysedObject) Then
				pivotGrid.OptionsView.ShowRowGrandTotals = False
				pivotGrid.OptionsView.ShowColumnGrandTotals = False
				AddHandler pivotGrid.EditValueChanged, AddressOf pivotGridControl_EditValueChanged
			Else
				pivotGrid.OptionsView.ShowRowGrandTotals = True
				pivotGrid.OptionsView.ShowColumnGrandTotals = True
				RemoveHandler pivotGrid.EditValueChanged, AddressOf pivotGridControl_EditValueChanged
			End If
		End Sub
		Private Sub pivotGridControl_EditValueChanged(ByVal sender As Object, ByVal e As EditValueChangedEventArgs)
			Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
			For j As Integer = 0 To ds.RowCount - 1
				ds(j)(e.DataField) = e.Editor.EditValue
			Next j
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler (CType(View.CurrentObject, IAnalysisInfo)).InfoChanged, AddressOf PivotGridInplaceEditorsController_InfoChanged
			If analysisEditor IsNot Nothing Then
				RemoveHandler analysisEditor.ControlCreated, AddressOf analysisEditor_ControlCreated
				If analysisEditor.Control IsNot Nothing Then
					RemoveHandler analysisEditor.Control.PivotGrid.EditValueChanged, AddressOf pivotGridControl_EditValueChanged
				End If
				analysisEditor = Nothing
			End If
		End Sub
	End Class
	Public Class MyPivotGridFieldBuilder
		Inherits PivotGridFieldBuilder
		Public Sub New(ByVal owner As IAnalysisControl)
			MyBase.New(owner)
		End Sub
		Protected Overrides Sub SetupPivotGridField(ByVal field As PivotGridFieldBase, ByVal memberType As Type, ByVal displayFormat As String)
			MyBase.SetupPivotGridField(field, memberType, displayFormat)
			If GetAnalysisInfo().DataType Is GetType(AnalysedObject) Then
				Select Case field.FieldName
					Case "BooleanProperty1", "BooleanProperty2", "BooleanProperty3"
						CType(field, PivotGridField).FieldEdit = New RepositoryItemCheckEdit()
						field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min
						field.Area = PivotArea.DataArea
					Case "Employee.FullName"
						field.Area = PivotArea.RowArea
					Case "Year"
						field.Area = PivotArea.ColumnArea
					Case Else
						field.Visible = False
				End Select
			End If
		End Sub
	End Class
End Namespace
