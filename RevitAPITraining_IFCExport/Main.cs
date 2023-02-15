using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using Transaction = Autodesk.Revit.DB.Transaction;

namespace RevitAPITraining_IFCExport
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            using (var ts = new Transaction(doc, "Export ifc"))
            {
                ts.Start();

                var ifcOption = new IFCExportOptions();
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                doc.Export(path, "export.ifc", ifcOption);

                ts.Commit();
            }

            return Result.Succeeded;
        }
    }
}
