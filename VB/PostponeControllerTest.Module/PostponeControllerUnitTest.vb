#If DEBUG Then
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports NUnit.Framework
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.SystemModule
Imports System.Collections

Namespace PostponeControllerTest.Module
    <TestFixture> _
    Public Class PostponeControllerUnitTest
        Private objectSpace As IObjectSpace
        Private controller As PostponeController
        Private application As TestApplication
        <SetUp> _
        Public Sub SetUp()
            Dim objectSpaceProvider As New XPObjectSpaceProvider(New MemoryDataStoreProvider())
            application = New TestApplication()
            Dim testModule As New ModuleBase()
            testModule.AdditionalExportedTypes.Add(GetType(Task))
            application.Modules.Add(testModule)
            application.Modules(0).AdditionalExportedTypes.Add(GetType(Task))
            application.Setup("TestApplication", objectSpaceProvider)
            objectSpace = objectSpaceProvider.CreateObjectSpace()
            controller = New PostponeController()
        End Sub
        <Test> _
        Public Sub TestPostponeActionDueDateUnspecified()
            Dim task As Task = objectSpace.CreateObject(Of Task)()
            controller.SetView(application.CreateDetailView(objectSpace, task))
            controller.Postpone.DoExecute()
            Assert.AreEqual(task.DueDate, Date.Today.AddDays(1))
        End Sub
        <Test> _
        Public Sub TestPostponeActionDueDateSpecified()
            Dim task As Task = objectSpace.CreateObject(Of Task)()
            task.DueDate = New Date(2011, 6, 6)
            controller.SetView(application.CreateDetailView(objectSpace, task))
            controller.Postpone.DoExecute()
            Assert.AreEqual(task.DueDate, New Date(2011, 6, 7))
        End Sub
    End Class
    Friend Class TestApplication
        Inherits XafApplication

        Protected Overrides Function CreateLayoutManagerCore(ByVal simple As Boolean) As LayoutManager
            Return Nothing
        End Function
    End Class
End Namespace
#End If