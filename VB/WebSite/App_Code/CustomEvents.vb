Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
#Region "#usingcustom"
Imports System.ComponentModel
Imports System.Collections
#End Region '#usingcustom

#Region "#customobject"
<Serializable> _
Public Class CustomEvent
    Private _id As Object
    Private _start As DateTime
    Private _end As DateTime
    Private _subject As String
    Private _status As Integer
    Private _description As String
    Private _label As Long
    Private _location As String
    Private _allday As Boolean
    Private _eventType As Integer
    Private _recurrenceInfo As String
    Private _reminderInfo As String
    Private _ownerId As Object
    Private _price As Double
    Private _contactInfo As String

    Public Sub New()
    End Sub

    Public Property StartTime() As DateTime
        Get
            Return _start
        End Get
        Set(ByVal value As DateTime)
            _start = value
        End Set
    End Property
    Public Property EndTime() As DateTime
        Get
            Return _end
        End Get
        Set(ByVal value As DateTime)
            _end = value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set(ByVal value As String)
            _subject = value
        End Set
    End Property
    Public Property Status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
    Public Property Label() As Long
        Get
            Return _label
        End Get
        Set(ByVal value As Long)
            _label = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property
    Public Property AllDay() As Boolean
        Get
            Return _allday
        End Get
        Set(ByVal value As Boolean)
            _allday = value
        End Set
    End Property
    Public Property EventType() As Integer
        Get
            Return _eventType
        End Get
        Set(ByVal value As Integer)
            _eventType = value
        End Set
    End Property
    Public Property RecurrenceInfo() As String
        Get
            Return _recurrenceInfo
        End Get
        Set(ByVal value As String)
            _recurrenceInfo = value
        End Set
    End Property
    Public Property ReminderInfo() As String
        Get
            Return _reminderInfo
        End Get
        Set(ByVal value As String)
            _reminderInfo = value
        End Set
    End Property
    Public Property OwnerId() As Object
        Get
            Return _ownerId
        End Get
        Set(ByVal value As Object)
            _ownerId = value
        End Set
    End Property
    Public Property Id() As Object
        Get
            Return _id
        End Get
        Set(ByVal value As Object)
            _id = value
        End Set
    End Property
    Public Property Price() As Double
        Get
            Return _price
        End Get
        Set(ByVal value As Double)
            _price = value
        End Set
    End Property
    Public Property ContactInfo() As String
        Get
            Return _contactInfo
        End Get
        Set(ByVal value As String)
            _contactInfo = value
        End Set
    End Property
End Class
<Serializable> _
Public Class CustomEventList
	Inherits BindingList(Of CustomEvent)
	Public Sub AddRange(ByVal events As CustomEventList)
		For Each customEvent As CustomEvent In events
			Me.Add(customEvent)
		Next customEvent
	End Sub
	Public Function GetEventIndex(ByVal eventId As Object) As Integer
		For i As Integer = 0 To Count - 1
			If Me(i).Id Is eventId Then
				Return i
			End If
		Next i
		Return -1
	End Function
End Class

Public Class CustomEventDataSource
	Private events_Renamed As CustomEventList
	Public Sub New(ByVal events As CustomEventList)
		If events Is Nothing Then
			DevExpress.XtraScheduler.Native.Exceptions.ThrowArgumentNullException("events")
		End If
		Me.events_Renamed = events
	End Sub
	Public Sub New()
		Me.New(New CustomEventList())
	End Sub
	Public Property Events() As CustomEventList
		Get
			Return events_Renamed
		End Get
		Set(ByVal value As CustomEventList)
			events_Renamed = value
		End Set
	End Property
	Public ReadOnly Property Count() As Integer
		Get
			Return Events.Count
		End Get
	End Property

	#Region "ObjectDataSource methods"
	Public Function InsertMethodHandler(ByVal customEvent As CustomEvent) As Object
		Dim id As Object = customEvent.GetHashCode()
		customEvent.Id = id
		Events.Add(customEvent)
		Return id
	End Function
	Public Sub DeleteMethodHandler(ByVal customEvent As CustomEvent)
		Dim eventIndex As Integer = Events.GetEventIndex(customEvent.Id)
		If eventIndex >= 0 Then
			Events.RemoveAt(eventIndex)
		End If
	End Sub
	Public Sub UpdateMethodHandler(ByVal customEvent As CustomEvent)
		Dim eventIndex As Integer = Events.GetEventIndex(customEvent.Id)
		If eventIndex >= 0 Then
			Events.RemoveAt(eventIndex)
			Events.Insert(eventIndex, customEvent)
		End If
	End Sub
	Public Function SelectMethodHandler() As IEnumerable
		Dim result As New CustomEventList()
		result.AddRange(Events)
		Return result
	End Function
	#End Region

	Public Function ObtainLastInsertedId() As Object
		If Count < 1 Then
			Return Nothing
		End If
		Return Events(Count - 1).Id
	End Function
End Class

#End Region ' #customobject
