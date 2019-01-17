//'********************************************************************
//'*                      OBJ_AdminUser() Class                       *
//'*                     -----------------------                      *
//'* This is a simple Class for storing information on a Website User *
//'* We use Public Properties to access the class variables           *
//'* And overload the Constructor to set the variables                *
//'********************************************************************
//Imports Microsoft.VisualBasic

//Public Class OBJ_AdminUser

//    Private _applicationid As Guid
//    Private _userid As Guid
//    Private _username As String
//    Private _loweredusername As String
//    Private _mobilealias As String
//    Private _isanonymous As Boolean
//    Private _lastactivitydate As DateTime

//    'Public Properties
//    Public Property ApplicationID() As Guid
//        Get
//            Return _applicationid
//        End Get
//        Set(ByVal value As Guid)
//            _applicationid = value
//        End Set
//    End Property

//    Public Property UserID() As Guid
//        Get
//            Return _userid
//        End Get
//        Set(ByVal value As Guid)
//            _userid = value
//        End Set
//    End Property

//    Public Property UserName() As String
//        Get
//            Return _username
//        End Get
//        Set(ByVal value As String)
//            _username = value
//        End Set
//    End Property

//    Public Property LoweredUserName() As String
//        Get
//            Return _loweredusername
//        End Get
//        Set(ByVal value As String)
//            _loweredusername = value
//        End Set
//    End Property

//    Public Property MobileAlias() As String
//        Get
//            Return _mobilealias
//        End Get
//        Set(ByVal value As String)
//            _mobilealias = value
//        End Set
//    End Property

//    Public Property IsAnonymous() As Boolean
//        Get
//            Return _isanonymous
//        End Get
//        Set(ByVal value As Boolean)
//            _isanonymous = value
//        End Set
//    End Property

//    Public Property LastActivityDate() As DateTime
//        Get
//            Return _lastactivitydate
//        End Get
//        Set(ByVal value As DateTime)
//            _lastactivitydate = value
//        End Set
//    End Property

//    'Default Constructor
//    Public Sub New()

//    End Sub

//    'Overloaded Constructor
//    Public Sub New(ByVal appID As Guid, ByVal userID As Guid, ByVal userName As String, ByVal loweredUserName As String, ByVal mobileAlias As String, ByVal isAnonymous As Boolean, ByVal lastActivityDate As DateTime)

//        Me.ApplicationID = appID
//        Me.UserID = userID
//        Me.UserName = userName
//        Me.LoweredUserName = loweredUserName
//        Me.MobileAlias = mobileAlias
//        Me.IsAnonymous = isAnonymous
//        Me.LastActivityDate = lastActivityDate

//    End Sub


//End Class