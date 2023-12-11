using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public class DocumentData
    {
        public static Document CurrentAutoCADDocument  
        {
            get
            {
                return Application.DocumentManager.MdiActiveDocument;
            }
        }

        public static Database CurrentDatabase  
        {
            get
            {
                return CurrentAutoCADDocument.Database;
            }
        }

        public static CivilDocument CurrentCivilDocument  
        {
            get
            {
                return CivilDocument.GetCivilDocument(CurrentDatabase);
            }
        }
    }
}

