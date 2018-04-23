Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports System.Collections

Namespace PostponeControllerTest.Module
    Public Class PostponeController
        Inherits ViewController


        Private postpone_Renamed As SimpleAction
        Public Sub New()
            TargetObjectType = GetType(Task)
            postpone_Renamed = New SimpleAction(Me, "Postpone", "Edit")
            AddHandler postpone_Renamed.Execute, AddressOf Postpone_Execute
        End Sub
        Private Sub Postpone_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
            Dim selectedObjects As IList = View.SelectedObjects
            For Each selectedObject As Object In selectedObjects
                Dim selectedTask As Task = DirectCast(selectedObject, Task)
                    If selectedTask.DueDate = Date.MinValue Then
                        selectedTask.DueDate = Date.Today
                    End If
                    selectedTask.DueDate = selectedTask.DueDate.AddDays(1)
            Next selectedObject
        End Sub
        Public ReadOnly Property Postpone() As SimpleAction
            Get
                Return postpone_Renamed
            End Get
        End Property
    End Class
End Namespace
