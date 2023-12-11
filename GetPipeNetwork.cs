using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CVL3Dv23LibraryVAA
{
    public class GetPipeNetwork
    {
        public static void PipeNetwork()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
                return;
            CivilDocument cDoc = CivilDocument.GetCivilDocument(doc.Database);
            Editor ed = doc.Editor; //извлекает id из object (ObjectId)

            var pipeNetworkIds = cDoc.GetPipeNetworkIds();
            
            MessageBox.Show($"Количество трубопроводных сетей!: {pipeNetworkIds.Count}");
        }
    }

}
