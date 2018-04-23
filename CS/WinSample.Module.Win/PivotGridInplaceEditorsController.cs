using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotChart.Win;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.Persistent.Base;

namespace WinSample.Module.Win {
    public class PivotGridInplaceEditorsController : ObjectViewController<DetailView, IAnalysisInfo> {
        AnalysisEditorWin analysisEditor;
        protected override void OnActivated() {
            base.OnActivated();
            analysisEditor = View.GetItems<AnalysisEditorWin>()[0];
            analysisEditor.ControlCreated += analysisEditor_ControlCreated;
            ((IAnalysisInfo)View.CurrentObject).InfoChanged += PivotGridInplaceEditorsController_InfoChanged;
        }
        void analysisEditor_ControlCreated(object sender, EventArgs e) {
            CustomizePivotGrid(analysisEditor.Control.PivotGrid);
            analysisEditor.Control.FieldBuilder = new MyPivotGridFieldBuilder(analysisEditor.Control);
            analysisEditor.Control.FieldBuilder.SetModel(Application.Model);
        }
        void PivotGridInplaceEditorsController_InfoChanged(object sender, AnalysisInfoChangedEventEventArgs e) {
            if (e.ChangeType == AnalysisInfoChangeType.ObjectTypeChanged) {
                CustomizePivotGrid(analysisEditor.Control.PivotGrid);
            }
        }
        private void CustomizePivotGrid(PivotGridControl pivotGrid) {
            if (((IAnalysisInfo)View.CurrentObject).DataType == typeof(AnalysedObject)) {
                pivotGrid.OptionsView.ShowRowGrandTotals = false;
                pivotGrid.OptionsView.ShowColumnGrandTotals = false;
                pivotGrid.EditValueChanged += pivotGridControl_EditValueChanged;
            } else {
                pivotGrid.OptionsView.ShowRowGrandTotals = true;
                pivotGrid.OptionsView.ShowColumnGrandTotals = true;
                pivotGrid.EditValueChanged -= pivotGridControl_EditValueChanged;
            }
        }
        private void pivotGridControl_EditValueChanged(object sender, EditValueChangedEventArgs e) {
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
            for (int j = 0; j < ds.RowCount; j++) {
                ds[j][e.DataField] = e.Editor.EditValue;
            }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            ((IAnalysisInfo)View.CurrentObject).InfoChanged -= PivotGridInplaceEditorsController_InfoChanged;
            if (analysisEditor != null) {
                analysisEditor.ControlCreated -= analysisEditor_ControlCreated;
                if (analysisEditor.Control != null) {
                    analysisEditor.Control.PivotGrid.EditValueChanged -= pivotGridControl_EditValueChanged;
                }
                analysisEditor = null;
            }
        }
    }
    public class MyPivotGridFieldBuilder : PivotGridFieldBuilder {
        public MyPivotGridFieldBuilder(IAnalysisControl owner) : base(owner) { }
        protected override void SetupPivotGridField(PivotGridFieldBase field, Type memberType, string displayFormat) {
            base.SetupPivotGridField(field, memberType, displayFormat);
            if (GetAnalysisInfo().DataType == typeof(AnalysedObject)) {
                switch (field.FieldName) {
                    case "BooleanProperty1":
                    case "BooleanProperty2":
                    case "BooleanProperty3":
                        ((PivotGridField)field).FieldEdit = new RepositoryItemCheckEdit();
                        field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Min;
                        field.Area = PivotArea.DataArea;
                        break;
                    case "Employee.FullName":
                        field.Area = PivotArea.RowArea;
                        break;
                    case "Year":
                        field.Area = PivotArea.ColumnArea;
                        break;
                    default:
                        field.Visible = false;
                        break;
                }
            }
        }
    }
}
