Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace HowToFilterListViewInLinkDialog.Module

   <DefaultClassOptions> _
   Public Class Contact
	   Inherits Person
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Private position_Renamed As Position
	  Public Property Position() As Position
		 Get
			Return position_Renamed
		 End Get
		 Set(ByVal value As Position)
			SetPropertyValue("Position", position_Renamed, value)
			' Refresh the Tasks property data source
			RefreshAvailableTasks()
		 End Set
	  End Property
	  ' Set the AvailableTasks collection as data source for the Tasks property
	  <Association("Contact-DemoTask", GetType(DemoTask)), DataSourceProperty("AvailableTasks")> _
	  Public ReadOnly Property Tasks() As XPCollection
		 Get
			Return GetCollection("Tasks")
		 End Get
	  End Property
	  Private availableTasks_Renamed As XPCollection(Of DemoTask)
	  <Browsable(False)> _
	  Public ReadOnly Property AvailableTasks() As XPCollection(Of DemoTask)
		 Get
			If availableTasks_Renamed Is Nothing Then
			   ' Retrieve all Task objects
			   availableTasks_Renamed = New XPCollection(Of DemoTask)(Session)
			End If
			' Filter the retieved collection according to the current conditions
			RefreshAvailableTasks()
			' Return the filtered collection of Task objects
			Return availableTasks_Renamed
		 End Get
	  End Property
	  Private Sub RefreshAvailableTasks()
		 If availableTasks_Renamed Is Nothing Then
			Return
		 End If
		 If (Position IsNot Nothing) AndAlso (Position.Title = "Manager") Then
			'Filter the collection
			availableTasks_Renamed.Criteria = CriteriaOperator.Parse("[Priority] = 'High'")
		 Else
			'Remove the applied filter
			availableTasks_Renamed.Criteria = Nothing
		 End If
	  End Sub
   End Class
   <DefaultClassOptions, System.ComponentModel.DefaultProperty("Title")> _
   Public Class Position
	   Inherits BaseObject
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Private title_Renamed As String
	  Public Property Title() As String
		 Get
			Return title_Renamed
		 End Get
		 Set(ByVal value As String)
			SetPropertyValue("Title", title_Renamed, value)
		 End Set
	  End Property
   End Class
   <DefaultClassOptions> _
   Public Class DemoTask
	   Inherits Task
	  Private priority_Renamed As Priority
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Public Property Priority() As Priority
		 Get
			Return priority_Renamed
		 End Get
		 Set(ByVal value As Priority)
			SetPropertyValue("Priority", priority_Renamed, value)
		 End Set
	  End Property
	  <Association("Contact-DemoTask", GetType(Contact))> _
	  Public ReadOnly Property Contacts() As XPCollection
		 Get
			Return GetCollection("Contacts")
		 End Get
	  End Property
	  '...
   End Class
   Public Enum Priority
	  Low = 0
	  Normal = 1
	  High = 2
   End Enum
End Namespace
