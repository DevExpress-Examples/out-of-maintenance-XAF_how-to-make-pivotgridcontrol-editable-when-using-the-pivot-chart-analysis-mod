' Developer Express Code Central Example:
' How to access the PivotGridControl and make it editable
' 
' This example demonstrates how to allow inplace editing in PivotGridControl,
' which is accessible in XAF applications via the Pivot Chart module. IOW, it
' shows how to change reported XP objects directly from the Analysis
' DetailView.
' 
' See Also:
' Pivot Chart Module
' (ms-help://DevExpress.Xaf/CustomDocument3024.htm)
' PivotGridControl Class
' (ms-help://DevExpress.WindowsForms/clsDevExpressXtraPivotGridPivotGridControltopic.htm)
' http://www.devexpress.com/scid=DS5903
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E1232


Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.
<Assembly: AssemblyTitle("WinSample.Module")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyConfiguration("")>
<Assembly: AssemblyCompany("-")>
<Assembly: AssemblyProduct("WinSample.Module")>
<Assembly: AssemblyCopyright("Copyright © - 2007")>
<Assembly: AssemblyTrademark("")>
<Assembly: AssemblyCulture("")>

' Setting ComVisible to false makes the types in this assembly not visible 
' to COM components.  If you need to access a type in this assembly from 
' COM, set the ComVisible attribute to true on that type.
<Assembly: ComVisible(False)>

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Revision and Build Numbers 
' by using the '*' as shown below:
<Assembly: AssemblyVersion("1.0.*")>
