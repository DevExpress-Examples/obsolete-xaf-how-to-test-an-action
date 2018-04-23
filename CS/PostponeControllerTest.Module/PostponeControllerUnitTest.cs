#if DEBUG
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using System.Collections;

namespace PostponeControllerTest.Module {
    [TestFixture]
    public class PostponeControllerUnitTest {
        IObjectSpace objectSpace;
        PostponeController controller;
        TestApplication application;
        [SetUp]
        public void SetUp() {
            XPObjectSpaceProvider objectSpaceProvider =
                new XPObjectSpaceProvider(new MemoryDataStoreProvider());
            application = new TestApplication();
            ModuleBase testModule = new ModuleBase();
            testModule.AdditionalExportedTypes.Add(typeof(Task));
            application.Modules.Add(testModule);
            application.Modules[0].AdditionalExportedTypes.Add(typeof(Task));
            application.Setup("TestApplication", objectSpaceProvider);
            objectSpace = objectSpaceProvider.CreateObjectSpace();
            controller = new PostponeController();
        }
        [Test]
        public void TestPostponeActionDueDateUnspecified() {
            Task task = objectSpace.CreateObject<Task>();
            controller.SetView(application.CreateDetailView(objectSpace, task));
            controller.Postpone.DoExecute();
            Assert.AreEqual(task.DueDate, DateTime.Today.AddDays(1));
        }
        [Test]
        public void TestPostponeActionDueDateSpecified() {
            Task task = objectSpace.CreateObject<Task>();
            task.DueDate = new DateTime(2011, 6, 6);
            controller.SetView(application.CreateDetailView(objectSpace, task));
            controller.Postpone.DoExecute();
            Assert.AreEqual(task.DueDate, new DateTime(2011, 6, 7));
        }
    }
    class TestApplication : XafApplication {
        protected override LayoutManager CreateLayoutManagerCore(bool simple) {
            return null;
        }
    }
}
#endif