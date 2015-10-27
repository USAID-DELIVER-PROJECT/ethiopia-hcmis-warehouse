using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Models;
using HCMIS.Concrete.Repository;
using HCMIS.Core.Finance.CostTier;
using HCMIS.Core.Finance.CostTier.DTO;
using HCMIS.Specification.Finance.CostTier;
using HCMIS.Specification.Finance.DTO;

namespace HCMIS.Core.Finance.CostTier.Services
{
    public class CostTierService
    {
        private RepositoryFactory repository;

        public CostTierService(RepositoryFactory Repository)
        {
           repository = Repository;
        }

        public CostTierService()
        {
            repository = new RepositoryFactory();
        }

        public IStock stock;

        public IStock BindCostFromLedger(IStock stock)
        {
            LedgerService ledgerService = new LedgerService(repository);
            Ledger ledger = ledgerService.GetLedger(stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                                        stock.MovingAverageId);

            stock.UnitCost = ledger.UnitCost;
            stock.Margin = ledger.Margin;
            stock.SellingPrice = ledger.SellingPrice;
            return stock;
        }

        public IStock BindCostFromLedgerLite(IStock stock)
        {
            LedgerService ledgerService = new LedgerService(repository);
            LedgerLite ledger = ledgerService.GetLedgerLite(stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                                        stock.MovingAverageId);
            stock.UnitCost = ledger.UnitCost;
            stock.Margin = ledger.Margin;
            stock.SellingPrice = ledger.SellingPrice;
            return stock;
        }

        public IStock CalculateNewReceive(IStock newStock,IStock currentStock,bool includeMargin)
        {
            stock = null;
            if (ValidationService.ValidateStockService(newStock, currentStock))
           {
               currentStock = BindCostFromLedger(currentStock);
               decimal totalCost,totalQuantity;
               // Add the TotalCost
               totalCost = Math.Round(newStock.Quantity*newStock.UnitCost,2,MidpointRounding.AwayFromZero) + Math.Round(currentStock.Quantity*currentStock.UnitCost,2,MidpointRounding.AwayFromZero);
               // Add the Quantities
               totalQuantity = currentStock.Quantity + newStock.Quantity;

               //Set the Quantity and UnitCost to the Averagecost
               currentStock.Quantity = totalQuantity;
               currentStock.UnitCost = Math.Round(totalCost/totalQuantity, 2, MidpointRounding.AwayFromZero);
               
               //Set Margin From New Stock and calculate SellingPrice if necessary
               currentStock.Margin = newStock.Margin;
               currentStock.SellingPrice = includeMargin?Math.Round(currentStock.Margin* currentStock.UnitCost,2, MidpointRounding.AwayFromZero):currentStock.UnitCost;
               currentStock.Identifier = newStock.Identifier;
               stock = currentStock;
               return stock;
           }
            return stock;
        }

        public IStock GetStock(int itemId, int unitId, int manufacturerId, int movingAverageId, int quantity,
                               decimal unitCost , decimal margin)
        {
            IStock stock = new Stock(itemId,unitId,manufacturerId,movingAverageId);
            stock.Quantity = quantity;
            stock.UnitCost = unitCost;
            stock.Margin = margin;
            return stock;
        }

        public IStock GetStock(int itemId, int unitId, int manufacturerId, int movingAverageId, int quantity)
        {
            IStock stock = new Stock(itemId, unitId, manufacturerId, movingAverageId);
            stock.Quantity = quantity;
            return stock;
        }

        public void RecordNewReceive(int userId)
        {
            
            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.RecordReceive(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId, stock.Quantity, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }

        public void RecordPriceOverride(int userId)
        {
            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.RecordPriceOverride(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }

        public void RecordVoidReceive(int userId)
        {
            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.RecordPriceOverride(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }

        public void ConfirmNewReceive(int userId)
        {

            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.ConfirmReceive(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId, stock.Quantity, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }

        public void ConfirmPriceOverride(int userId)
        {
            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.ConfirmPriceOverride(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }

        public void ConfirmVoidReceive(int userId)
        {
            IJournalService journalService = new JournalService(repository);
            journalService.StartRecordingSession();
            journalService.ConfirmVoidReceive(stock.Identifier, stock.ItemId, stock.UnitId, stock.ManufacturerId,
                                         stock.MovingAverageId,stock.Quantity, stock.UnitCost, stock.Margin,
                                         stock.SellingPrice, userId);
            journalService.CommitRecordingSession();
        }
    }   
}
