using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using System.Collections;

namespace PostponeControllerTest.Module {
    public class PostponeController : ViewController {
        private SimpleAction postpone;
        public PostponeController() {
            TargetObjectType = typeof(Task);
            postpone = new SimpleAction(this, "Postpone", "Edit");
            postpone.Execute += new SimpleActionExecuteEventHandler(Postpone_Execute);
        }
        void Postpone_Execute(object sender, SimpleActionExecuteEventArgs e) {
            IList selectedObjects = View.SelectedObjects;
            foreach (object selectedObject in selectedObjects)
            {                              
                Task selectedTask = (Task)selectedObject;                    
                    if (selectedTask.DueDate == DateTime.MinValue) {
                        selectedTask.DueDate = DateTime.Today;
                    }
                    selectedTask.DueDate = selectedTask.DueDate.AddDays(1);               
            }
        }
        public SimpleAction Postpone {
            get { return postpone; }
        }
    }
}
