using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class CivilDocumentExts
    {
        public static List<Network> GetNetworks(this CivilDocument oCivilDocument)   //расширяем CivilDocument
        {
            //if (oCivilDocument == null)
            //    return new List<Network>();


            List<Network> networkList = new List<Network>();
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection networkIds = oCivilDocument.GetPipeNetworkIds();

            using (Transaction ts = DocumentData.CurrentDatabase.TransactionManager.StartTransaction())
            {
                //if (oCivilDocument.GetPipeNetworkIds() == null)
                //    return oNetworkList;

                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId networkId in networkIds)
                {
                    Network oNetwork = ts.GetObject(networkId, OpenMode.ForRead, false, true) as Network;
                    networkList.Add(oNetwork);
                }
            }
            return networkList;
        }

        public static List<PressurePipeNetwork> GetPressurePipeNetworks(this CivilDocument oCivilDocument)   //расширяем CivilDocument
        {
            //if (oCivilDocument == null)
            //    return new List<Network>();


            List<PressurePipeNetwork> pressurePipeNetworkList = new List<PressurePipeNetwork>();
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection pressurePipeNetworkIds = oCivilDocument.GetPressurePipeNetworkIds();

            using (Transaction ts = DocumentData.CurrentDatabase.TransactionManager.StartTransaction())
            {
                //if (oCivilDocument.GetPipeNetworkIds() == null)
                //    return oNetworkList;

                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId pressurePipeNetworkId in pressurePipeNetworkIds)
                {
                    PressurePipeNetwork oPressurePipeNetwork = ts.GetObject(pressurePipeNetworkId, OpenMode.ForRead, false, true) as PressurePipeNetwork;
                    pressurePipeNetworkList.Add(oPressurePipeNetwork);
                }
            }
            return pressurePipeNetworkList;



        }
    }
}
