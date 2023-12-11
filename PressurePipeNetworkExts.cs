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
using System.Windows.Forms;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CVL3Dv23LibraryVAA
{
    public static class PressurePipeNetworkExt
    {
        public static List<PressurePipe> GetPipesOfPressurePipeNetwork(this PressurePipeNetwork pressurePipeNetwork)   //расширяем Network
        {
            if (pressurePipeNetwork == null)
                return new List<PressurePipe>();


            List<PressurePipe> pressurePipeList = new List<PressurePipe>();

            using (Transaction ts = DocumentData.CurrentDatabase.TransactionManager.StartTransaction())
            {
                if (pressurePipeNetwork.GetPipeIds() == null)
                    return pressurePipeList;

                foreach (ObjectId oPressurePipeId in pressurePipeNetwork.GetPipeIds())
                {
                    PressurePipe oPressurePipe = ts.GetObject(oPressurePipeId, OpenMode.ForRead, false, true) as PressurePipe;
                    pressurePipeList.Add(oPressurePipe);
                }
                ts.Commit();
            }
            return pressurePipeList;
        }
    }
}
