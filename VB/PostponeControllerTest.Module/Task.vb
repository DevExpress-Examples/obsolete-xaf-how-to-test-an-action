Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace PostponeControllerTest.Module
    <DefaultClassOptions, ImageName("BO_Task")> _
    Public Class Task
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Property Description() As String
            Get
                Return GetPropertyValue(Of String)("Description")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", value)
            End Set
        End Property

        Public Property DueDate() As Date
            Get
                Return GetPropertyValue(Of Date)("DueDate")
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DueDate", value)
            End Set
        End Property
    End Class
End Namespace
