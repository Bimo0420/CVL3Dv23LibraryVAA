using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class PipeNetworkExts
    {
        public static List<Pipe> GetPipesOfNetwork(this Network oNetwork)   //расширяем Network
        {
            if (oNetwork == null)
                return new List<Pipe>();


            List<Pipe> pipeList = new List<Pipe>();

            using (Transaction ts = DocumentData.CurrentDatabase.TransactionManager.StartTransaction())
            {
                if (oNetwork.GetPipeIds() == null)
                    return pipeList;

                foreach (ObjectId oPipeId in oNetwork.GetPipeIds())
                {
                    Pipe oPipe = ts.GetObject(oPipeId, OpenMode.ForRead, false, true) as Pipe;
                    pipeList.Add(oPipe);
                }
                ts.Commit();
            }
            return pipeList;
        }


    }


}
