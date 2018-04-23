using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp;

namespace WinSample.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Person john = CreateObject<Person>(new string[] { "FirstName" }, new object[] { "John" });
            Person sam = CreateObject<Person>(new string[] { "FirstName" }, new object[] { "Sam" });

            AnalysedObject analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { john, 2009 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty1 = true;
            }
            analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { john, 2010 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty2 = true;
            }
            analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { john, 2011 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty2 = true;
                analysedObject.BooleanProperty3 = true;
            }
            analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { sam, 2009 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty3 = true;
            }
            analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { sam, 2010 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty1 = true;
                analysedObject.BooleanProperty2 = true;
            }
            analysedObject = CreateObject<AnalysedObject>(new string[] { "Employee", "Year" }, new object[] { sam, 2011 });
            if (ObjectSpace.IsNewObject(analysedObject)) {
                analysedObject.BooleanProperty1 = true;
            }
        }
        private T CreateObject<T>(string[] propertyNames, object[] propertyValues) where T : XPBaseObject {
            if (propertyValues.Length != propertyNames.Length) {
                throw new ArgumentException();
            }
            GroupOperator criteria = new GroupOperator();
            for (int i = 0; i < propertyNames.Length; i++) {
                criteria.Operands.Add(new BinaryOperator(propertyNames[i], propertyValues[i]));
            }
            T obj = ObjectSpace.FindObject<T>(criteria);
            if (obj == null) {
                obj = ObjectSpace.CreateObject<T>();
                for (int i = 0; i < propertyNames.Length; i++) {
                    obj.ClassInfo.FindMember(propertyNames[i]).SetValue(obj, propertyValues[i]);
                }
            }
            return obj;
        }
    }
}
