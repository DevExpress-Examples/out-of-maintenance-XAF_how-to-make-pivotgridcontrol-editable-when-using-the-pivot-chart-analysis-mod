<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592083/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1232)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[PivotGridInplaceEditorsController.cs](./CS/WinSample.Module.Win/PivotGridInplaceEditorsController.cs) (VB: [PivotGridInplaceEditorsController.vb](./VB/WinSample.Module.Win/PivotGridInplaceEditorsController.vb))**
<!-- default file list end -->
# How to make PivotGridControl editable when using the Pivot Chart (Analysis) module


<p><strong>Note: </strong>PivotGrid controls can be displayed in XAF via two modules - <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3025"><u>Pivot Chart</u></a> and <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3303"><u>Pivot Grid</u></a>. This example is related to the <strong>Pivot Chart module</strong>. To learn how to access the PivotGridControl in the Pivot Grid module, refer to the <a href="https://www.devexpress.com/Support/Center/p/K18539">How to access and customize controls used to represent data in list views (PivotGridControl, SchedulerControl, ChartControl, etc.)</a> article.</p><p><strong>Scenario:</strong></p><p>PivotGridControl displays data in the data area using a certain summary - Sum or Count by default. Thus, when a value of type String or Boolean is displayed, the user does not see real values. This example demonstrates how to show these values and provide the capability to change them. A solution is based on the following XtraPivotGrid example: <a href="https://www.devexpress.com/Support/Center/p/E280">String editing in the XtraPivotGrid control</a>.</p><p><strong>Steps to implement:</strong></p><p>1. A ViewController for the Analysis DetailView (<strong>PivotGridInplaceEditorsController</strong>) is created in the WinForms-specific module.</p><p>2. This controller accesses and customizes the Analysis editor (<strong>AnalysisEditorWin</strong>) in two ways:</p><p>   2.1. Settings that do not depend on the data source and are not stored in the Analysis object are defined when the View controls are created and when the Analysis object's Data Type is changed. The PivotGridControl is accessed via the <strong>AnalysisEditorWin.Control.PivotGrid</strong> property.</p><p>   2.2. Settings related to the PivotGrid fields depend on the data source and are loaded only at certain moments (e.g. when the Bind Analysis Data action is executed). To change them, it is convenient to use a custom field builder, or handle events of the default field builder. The field builder is used by the analysis editor to create PivotGrid fields based on the data source, or restore them based on settings stored in the Analysis object. To access the FieldBuilder, use the <strong>AnalysisEditorBase.Control.FieldBuilder</strong> property. In this example, a custom FieldBuilder is used to customize field settings.</p><p>There are also two other ways to customize the PivotGridControl when its settings are loaded:</p><p>1. By handling the AnalysisEditorBase.PivotGridSettingsLoaded event.<br />
2. By handling the AnalysisDataBindController.BindDataAction.Execute event.</p><p>These events are appropriate for customizing the existing Analysis reports. However, the PivotGridSettingsLoaded event will not be raised when the Analysis object is just created, and both events are not raised when the DataType of the existing Analysis object is changed.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E1395">How to make PivotGrid fields invisible when the Analysis view is initialized</a></p>

<br/>


