using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public class GetPipeNetworkGPT4
    {
        public void GetPipeNetwork()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor editor = doc.Editor;

            using (Transaction transaction = db.TransactionManager.StartTransaction())
            {
                // Открытие текущего пространства модели
                BlockTableRecord modelSpace = transaction.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead) as BlockTableRecord;

                // Получение всех объектов трубопроводной сети
                ObjectIdCollection pipeNetworkIds = new ObjectIdCollection();
                foreach (ObjectId objectId in modelSpace)
                {
                    Entity entity = transaction.GetObject(objectId, OpenMode.ForRead) as Entity;
                    if (entity is PipeNetwork)
                    {
                        pipeNetworkIds.Add(objectId);
                    }
                }

                // Вывод списка объектов трубопроводной сети
                foreach (ObjectId networkId in pipeNetworkIds)
                {
                    PipeNetwork pipeNetwork = transaction.GetObject(networkId, OpenMode.ForRead) as PipeNetwork;
                    editor.WriteMessage("Pipe Network: " + pipeNetwork.Name);
                }

                transaction.Commit();
            }
        }
    }
}
