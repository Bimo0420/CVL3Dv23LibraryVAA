using Autodesk.Aec.PropertyData.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class PropertySetUtils
    {
        //static public void GetPropSetIdByName(Database db, Transaction trnsctn, ref ObjectId propSetDefId, string propertySetName, Editor editor) //проверяет, был ли найден идентификатор для набора характеристик
        //{
        //    //ObjectId propSetDefId = ObjectId.Null;

        //    DictionaryPropertySetDefinitions dbPropSetDefs = new DictionaryPropertySetDefinitions(db);
        //    //using (trnscn)

        //    //{
        //    //    if (dbPropSetDefs.Has(propertySetName, trnsctn))
        //    //    {
        //    //        propSetDefId = dbPropSetDefs.GetAt(propertySetName);
        //    //        trnsctn.Commit();    //не помогло
        //    //    }
        //    //    else
        //    //    {
        //    //         editor.WriteMessage("\n Набор характеристик отсутствует");
        //    //         return;
        //    //    }

        //    //}

        //    if (dbPropSetDefs.Has(propertySetName, trnsctn))
        //        {
        //            propSetDefId = dbPropSetDefs.GetAt(propertySetName);
        //        trnsctn.Commit();    //не помогло
        //        }
        //        else
        //        {
        //            editor.WriteMessage("\n Набор характеристик отсутствует");
        //            return;
        //        }

        //}

        static public SampleLineData CreateSampleLineData(SampleLine sampleLine, ObjectId propSetDefId)
        {
            ObjectId objPropSetId = ObjectId.Null;
            try
            {
                objPropSetId = PropertyDataServices.GetPropertySet(sampleLine, propSetDefId);
            }
            catch
            {
                sampleLine.UpgradeOpen();
                PropertyDataServices.AddPropertySet(sampleLine, propSetDefId);
                objPropSetId = PropertyDataServices.GetPropertySet(sampleLine, propSetDefId);
                sampleLine.DowngradeOpen();
            }

            PropertySet propSet;
            using (OpenCloseTransaction t = new OpenCloseTransaction())
            {
                propSet = (PropertySet)t.GetObject(objPropSetId, OpenMode.ForRead);
            }

            string urban = propSet.GetAt(propSet.PropertyNameToId("Урбан")).ToString();
            string nomer = propSet.GetAt(propSet.PropertyNameToId("Номер")).ToString();

            return new SampleLineData(urban, nomer);
        }

    }
}
