using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class SampleLineUtils
    {
        public static Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection GetSampleLinesFromGroup( this SampleLineGroup sampleLineGroup)
        {
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection sampleLineIds = new Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection();

            if (sampleLineGroup != null)
                {
                    sampleLineIds = sampleLineGroup.GetSampleLineIds();
                }



            //catch (Autodesk.AutoCAD.Runtime.Exception ex)
            //{

            //    Console.WriteLine("Ошибка при получении списка Sample Line из группы: " + ex.Message);
            //}

            return sampleLineIds;
        }
    }

    public static class SampleLineExtensions
    {
        public static void ChangeName(this SampleLine sampleLine, string newName)
        {
            if (sampleLine == null)
                return;

            using (Transaction transaction = sampleLine.Database.TransactionManager.StartTransaction())
            {
                try
                {
                    sampleLine.UpgradeOpen();
                    sampleLine.Name = newName;
                    transaction.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    transaction.Abort();
                    Console.WriteLine("Ошибка при изменении имени Sample Line: " + ex.Message);
                }
            }
        }
    }
}
