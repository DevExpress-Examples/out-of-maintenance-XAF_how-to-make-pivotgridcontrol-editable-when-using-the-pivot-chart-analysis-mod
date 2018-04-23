Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WinSample.Module
	<DefaultClassOptions> _
	Public Class AnalysedObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _Employee As Person
		Public Property Employee() As Person
			Get
				Return _Employee
			End Get
			Set(ByVal value As Person)
				SetPropertyValue("Employee", _Employee, value)
			End Set
		End Property
		Private _Year As Integer
		Public Property Year() As Integer
			Get
				Return _Year
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Year", _Year, value)
			End Set
		End Property
		Private _BooleanProperty1 As Boolean
		Public Property BooleanProperty1() As Boolean
			Get
				Return _BooleanProperty1
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue("BooleanProperty1", _BooleanProperty1, value)
			End Set
		End Property
		Private _BooleanProperty2 As Boolean
		Public Property BooleanProperty2() As Boolean
			Get
				Return _BooleanProperty2
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue("BooleanProperty2", _BooleanProperty2, value)
			End Set
		End Property
		Private _BooleanProperty3 As Boolean
		Public Property BooleanProperty3() As Boolean
			Get
				Return _BooleanProperty3
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue("BooleanProperty3", _BooleanProperty3, value)
			End Set
		End Property
	End Class

End Namespace
