Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

<DefaultClassOptions()> _
Public Class Contact
    Inherits Person
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private fPosition As Position
    Public Property Position() As Position
        Get
            Return fPosition
        End Get
        Set(ByVal value As Position)
            SetPropertyValue("Position", fPosition, value)
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
    Private fAvailableTasks As XPCollection(Of DemoTask)
    <Browsable(False)> _
    Public ReadOnly Property AvailableTasks() As XPCollection(Of DemoTask)
        Get
            If fAvailableTasks Is Nothing Then
                ' Retrieve all Task objects
                fAvailableTasks = New XPCollection(Of DemoTask)(Session)
            End If
            ' Filter the retieved collection according to the current conditions
            RefreshAvailableTasks()
            ' Return the filtered collection of Task objects
            Return fAvailableTasks
        End Get
    End Property
    Private Sub RefreshAvailableTasks()
        If fAvailableTasks Is Nothing Then
            Return
        End If
        If (Not Position Is Nothing) AndAlso (Position.Title = "Manager") Then
            'Filter the collection
            fAvailableTasks.Criteria = CriteriaOperator.Parse("[Priority] = 'High'")
        Else
            'Remove the applied filter
            fAvailableTasks.Criteria = Nothing
        End If
    End Sub
End Class
<DefaultClassOptions(), System.ComponentModel.DefaultProperty("Title")> _
Public Class Position
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private fTitle As String
    Public Property Title() As String
        Get
            Return fTitle
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Title", fTitle, Value)
        End Set
    End Property
End Class
<DefaultClassOptions()> _
Public Class DemoTask
    Inherits Task
    Private fPriority As Priority
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Property Priority() As Priority
        Get
            Return fPriority
        End Get
        Set(ByVal value As Priority)
            SetPropertyValue("Priority", fPriority, Value)
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

