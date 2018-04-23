Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp

Namespace WinSample.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim john As Person = CreateObject(Of Person)(New String() { "FirstName" }, New Object() { "John" })
			Dim sam As Person = CreateObject(Of Person)(New String() { "FirstName" }, New Object() { "Sam" })

			Dim analysedObject As AnalysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { john, 2009 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty1 = True
			End If
			analysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { john, 2010 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty2 = True
			End If
			analysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { john, 2011 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty2 = True
				analysedObject.BooleanProperty3 = True
			End If
			analysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { sam, 2009 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty3 = True
			End If
			analysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { sam, 2010 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty1 = True
				analysedObject.BooleanProperty2 = True
			End If
			analysedObject = CreateObject(Of AnalysedObject)(New String() { "Employee", "Year" }, New Object() { sam, 2011 })
			If ObjectSpace.IsNewObject(analysedObject) Then
				analysedObject.BooleanProperty1 = True
			End If
		End Sub
		Private Function CreateObject(Of T As XPBaseObject)(ByVal propertyNames() As String, ByVal propertyValues() As Object) As T
			If propertyValues.Length <> propertyNames.Length Then
				Throw New ArgumentException()
			End If
			Dim criteria As New GroupOperator()
			For i As Integer = 0 To propertyNames.Length - 1
				criteria.Operands.Add(New BinaryOperator(propertyNames(i), propertyValues(i)))
			Next i
			Dim obj As T = ObjectSpace.FindObject(Of T)(criteria)
			If obj Is Nothing Then
				obj = ObjectSpace.CreateObject(Of T)()
				For i As Integer = 0 To propertyNames.Length - 1
					obj.ClassInfo.FindMember(propertyNames(i)).SetValue(obj, propertyValues(i))
				Next i
			End If
			Return obj
		End Function
	End Class
End Namespace
