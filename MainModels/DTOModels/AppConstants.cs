using System.ComponentModel;

namespace MainModels.DTOModels
{
    public class AppConstants
    {
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
        public enum PurchaseStatus
        {
            Draft = 1,
            Submitted = 2,
            Approved = 3,
            Rejected = 4,
            Completed = 5
        }
      

    }
}
