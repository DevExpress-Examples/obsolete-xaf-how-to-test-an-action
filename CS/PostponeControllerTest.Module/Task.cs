using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace PostponeControllerTest.Module {
    [DefaultClassOptions, ImageName("BO_Task")]
    public class Task : BaseObject {
        public Task(Session session) : base(session) { }

        public string Description {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue<string>("Description", value); }
        }

        public DateTime DueDate {
            get { return GetPropertyValue<DateTime>("DueDate"); }
            set { SetPropertyValue<DateTime>("DueDate", value); }
        }
    }   
}
