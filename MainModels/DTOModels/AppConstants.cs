using System.ComponentModel;
using Microsoft.Identity.Client;

namespace MainModels.DTOModels
{
    public class AppConstants
    {
        public static class ProductType
        {
            public const int PhysicalInventory = 1;
            public const int ServiceInventory = 2;
        }

        public static class CoaAccounts
        {
            // ==== ASSETS ====
            public const int Assets = 1;
            public const int CashOnHand = 2;                 // 1010
            public const int BankAccounts = 3;               // 1020
            public const int CheckingAccount = 4;            // 1021
            public const int SavingsAccount = 5;             // 1022
            public const int AccountsReceivable = 6;         // 1030
            public const int Inventory = 7;                  // 1040
            public const int PrepaidExpenses = 8;            // 1050
            public const int FixedAssets = 9;                // 1060
            public const int Equipment = 10;                 // 1061
            public const int FurnitureFixtures = 11;         // 1062
            public const int InputTax = 39;                  // Input Tax (Purchase Tax)

            // ==== LIABILITIES ====
            public const int Liabilities = 12;
            public const int AccountsPayable = 13;           // 2010
            public const int AccruedExpenses = 14;           // 2020
            public const int TaxesPayable = 15;              // 2030
            public const int LoansPayable = 16;              // 2040
            public const int OutputTax = 40;                 // Output Tax (Sales Tax)

            // ==== EQUITY ====
            public const int Equity = 17;
            public const int OwnersCapital = 18;             // 3010
            public const int OwnersDrawings = 19;            // 3020
            public const int RetainedEarnings = 20;          // 3030
            public const int OpeningStock = 41;              // 3075


            // ==== REVENUE ====
            public const int Revenue = 21;
            public const int SalesIncome = 22;               // 4010
            public const int ServiceIncome = 23;             // 4020
            public const int OtherIncome = 24;               // 4030

            // ==== COST OF GOODS SOLD ====
            public const int COGS = 25;                      // 5000
            public const int Purchases = 26;                 // 5010
            public const int DirectMaterials = 27;           // 5020
            public const int DirectLabor = 28;               // 5030
            public const int FreightIn = 29;                 // 5040

            // ==== OPERATING EXPENSES ====
            public const int OperatingExpenses = 30;         // 6000
            public const int RentExpense = 31;               // 6010
            public const int UtilitiesExpense = 32;          // 6020
            public const int SalariesExpense = 33;           // 6030
            public const int MarketingExpense = 34;          // 6040
            public const int InsuranceExpense = 35;          // 6050
            public const int OfficeSupplies = 36;            // 6060
            public const int DepreciationExpense = 37;       // 6070
            public const int BankCharges = 38;               // 6080
        }


        public enum OrderStatusEnum
        {
            Pending = 1,
            Confirmed = 2,
            Processing = 3,
            Shipped = 4,
            Delivered = 5,
            Cancelled = 6
        }
        public enum EnumPriceFormat
        {
            RetailPrice = 0,
            SalesPrice = 1,
            PromotionPrice = 2
        }
        public enum PurchaseType
        {
            [Description("Requisition")]
            Requisition = 1,

            [Description("Purchase Order")]
            PurchaseOrder = 2,

            [Description("Receiving")]
            Receiving = 3
        }
        //public enum RequisitionTypes
        //{
        //    [Description("Requisition")]
        //    Requisition = 1,

        //    [Description("Purchase Order")]
        //    PurchaseOrder = 2,

        //}
        public enum PurchaseOrderTypes
        {
            [Description("Purchase Order")]
            PurchaseOrder = 2,

            [Description("Receiving")]
            Receiving = 3
        }
        public enum PurchaseStatus
        {
            Draft = 1,
            Approved = 2,
            Rejected = 3,
            Completed = 4
        }
        public enum InvoiceSource
        {
            POS = 1,
            Online = 2,
            WebOrder = 3,
            CallOrder = 4
        }
        public enum PaymentStatus
        {
            Paid = 1,
            Pending = 2,
            PartiallyPaid = 3,
            Refunded = 4,
            Cancelled = 5,
            Chargeback = 6,
            Failed = 7
        }
        public static class PurchaseTypes
        {
            public const int Purchase = 1;
            public const int OpeningStock = 2;
            public const int Transfer = 3;
            public const int Adjust = 4;

        }

    }
}
