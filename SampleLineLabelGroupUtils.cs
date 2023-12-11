//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.Civil.DatabaseServices;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CVL3Dv23LibraryVAA
////{
////    public class SampleLineLabelGroupUtils
////    {
////        //public static ObjectId CreateSampleLineLabelGroup(Database database, string labelGroupName)
////        //{
////        //    // Создаем новую группу меток линии профиля
////        //    SampleLineLabelGroup labelGroup = new SampleLineLabelGroup();
////        //    labelGroup.Name = labelGroupName;

////        //    // Настройка параметров меток группы (например, стиль меток)
////        //    // labelGroup.StyleId = YourLabelStyleId;

////        //    // Открываем таблицу групп меток для записи
////        //    using (Transaction transaction = database.TransactionManager.StartTransaction())
////        //    {
////        //        BlockTable blockTable = transaction.GetObject(database.BlockTableId, OpenMode.ForRead) as BlockTable;

////        //        if (blockTable != null)
////        //        {
////        //            BlockTableRecord modelSpace = transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

////        //            // Добавляем группу меток в модельное пространство
////        //            ObjectId labelGroupId = modelSpace.AppendEntity(labelGroup);
////        //            transaction.AddNewlyCreatedDBObject(labelGroup, true);

////        //            // Завершаем транзакцию
////        //            transaction.Commit();

////        //            // Возвращаем ObjectId созданной группы меток
////        //            return labelGroupId;
////        //        }
////        //        else
////        //        {
////        //            // В случае ошибки возвращаем ObjectId.Null
////        //            return ObjectId.Null;
////                }
////            }
////        }

////    }
////}
