using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace WinSample.Module {
    [DefaultClassOptions]
    public class AnalysedObject : BaseObject {
        public AnalysedObject(Session session) : base(session) { }
        private Person _Employee;
        public Person Employee {
            get { return _Employee; }
            set { SetPropertyValue("Employee", ref _Employee, value); }
        }
        private int _Year;
        public int Year {
            get { return _Year; }
            set { SetPropertyValue("Year", ref _Year, value); }
        }
        private bool _BooleanProperty1;
        public bool BooleanProperty1 {
            get { return _BooleanProperty1; }
            set { SetPropertyValue("BooleanProperty1", ref _BooleanProperty1, value); }
        }
        private bool _BooleanProperty2;
        public bool BooleanProperty2 {
            get { return _BooleanProperty2; }
            set { SetPropertyValue("BooleanProperty2", ref _BooleanProperty2, value); }
        }
        private bool _BooleanProperty3;
        public bool BooleanProperty3 {
            get { return _BooleanProperty3; }
            set { SetPropertyValue("BooleanProperty3", ref _BooleanProperty3, value); }
        }
    }

}
