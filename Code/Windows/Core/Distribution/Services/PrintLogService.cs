using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFramework.Patterns;
using HCMIS.Concrete.Repository;
using System.IO;

namespace HCMIS.Core.Distribution.Services
{
    public class PrintLogService
    {
        // Save the stvReport in the database
        RepositoryFactory repo = new RepositoryFactory();
        private IUnitOfWork unitOfWork;

        public void StartPrintingSession()
        {
             unitOfWork = repo.UnitOfWork;
        }

        public void SaveLog(MemoryStream stream, string type ,bool isPrinted, int reference, int printedByUserID, DateTime dateTime)
        {
            HCMIS.Concrete.Models.PrintLog pLog = new HCMIS.Concrete.Models.PrintLog();

            pLog.IsPrinted = isPrinted;
            pLog.PrintedBy = printedByUserID;
            pLog.PrintedDate = dateTime;
            pLog.Value = stream.ToArray();
            pLog.Type = type;
            pLog.Reference = reference;
            repo.PrintLogs.Insert(pLog);
            
        }

       public void CommitPrintLog()
       {
           try
           {
               unitOfWork.Commit();
           }
           catch(Exception exp)
           {
               
           }
          
       }
        public static void SavePrintLogNoWait(MemoryStream stream, string type, bool isPrinted, int reference, int printedByUserID, DateTime dateTime)
        {
            //TODO: remove the try catch.
            try
            {
                // Save the stvReport in the database
                RepositoryFactory repo = new RepositoryFactory();

                var unitOfWork = repo.UnitOfWork;
                HCMIS.Concrete.Models.PrintLog pLog = new HCMIS.Concrete.Models.PrintLog();
                pLog.IsPrinted = isPrinted;
                pLog.PrintedBy = printedByUserID;
                pLog.PrintedDate = dateTime;
                pLog.Value = stream.ToArray();
                pLog.Type = type;
                pLog.Reference = reference;
                repo.PrintLogs.Insert(pLog);

                unitOfWork.Commit();
            }
            catch
            {
            }
        }


        public void ToFile(int id, string fileName)
        {
            HCMIS.Concrete.Models.PrintLog pl = repo.PrintLogs.First(p => p.ID == id);
            FileStream fs = new FileStream(fileName,FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(pl.Value);
            bw.Close(); 
            fs.Close();
            
            
        }

        public static IEnumerable<string> GetDocumentTypes()
        {
            RepositoryFactory repo = new RepositoryFactory();
            return repo.PrintLogs.AsQueryable().Select(l => l.Type).Distinct();
        }

        public static IEnumerable<PrintLogMeta> GetDocumentMeta(string type, DateTime fromDate, DateTime toDate)
        {
            RepositoryFactory repo = new RepositoryFactory();

            var results = repo.PrintLogs.AsQueryable()
                .Where(t => t.Type == type && t.PrintedDate >= fromDate && t.PrintedDate <= toDate)
                .Select(
                    p =>
                    new PrintLogMeta {ID = p.ID, PrintedDate = p.PrintedDate, Type = p.Type, Reference = p.Reference}).ToList();

            if (type == "STV")
            {

                foreach (var result in results)
                {
                    var log = repo.STVLogs.First(s => s.ID == result.Reference);
                    int? receivingUnitID = log.ReceivingUnitID;
                    if (receivingUnitID != null)
                    {
                        result.Description = repo.ReceivingUnits.First(f => f.ID == receivingUnitID).Name;
                        result.PrintedID = log.IDPrinted;
                    }
                    
                }

               
            }

            return results;

        }
        public static IEnumerable<PrintLogMeta> GetDocumentMeta(int Reference)
        {
            RepositoryFactory repo = new RepositoryFactory();

            var results = repo.PrintLogs.AsQueryable()
                .Where(t => t.Reference == Reference && (t.Type =="GRV/IGRV" || t.Type == "CostAnalysis"))
                .Select(
                    p =>
                    new PrintLogMeta { ID = p.ID, PrintedDate = p.PrintedDate, Type = p.Type, Reference = p.Reference }).ToList();

            return results;
        }
    }
}
