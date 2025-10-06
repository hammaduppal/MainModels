using System.ComponentModel;

namespace MainModels.DTOModels
{
    public class AppConstants
    {
        public static class CoaAccounts
        {
            public const int Cash = 1;                  // replace with your actual COA ID
            public const int AccountsReceivable = 6;
            public const int SalesRevenue = 15;
            public const int OutputTaxPayable = 20;
            public const int COGS = 25;
            public const int Inventory = 30;
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
        public enum RequisitionTypes
        {
            [Description("Requisition")]
            Requisition = 1,

            [Description("Purchase Order")]
            PurchaseOrder = 2,

        }
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


    }
}
