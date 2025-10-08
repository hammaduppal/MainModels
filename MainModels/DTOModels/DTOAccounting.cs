
namespace MainModels.DTOModels
{
    public partial class AccountBalanceVM
    {
        public Guid BalanceId { get; set; }

        public int CoaId { get; set; }

        public int BranchId { get; set; }

        public int FiscalYear { get; set; }

        public int FiscalPeriod { get; set; }

        public decimal? OpeningBalance { get; set; }

        public decimal? DebitTotal { get; set; }

        public decimal? CreditTotal { get; set; }

        public decimal? ClosingBalance { get; set; }

        public DateTime LastUpdated { get; set; }

        public virtual ChartOfAccountVM ChartOfAccounts { get; set; }
    }
    public partial class AccountPayableVM
    {
        public Guid Apid { get; set; }

        public int SupplierId { get; set; }

        public int? PurchaseId { get; set; }

        public Guid? JournalEntryId { get; set; }

        public decimal Amount { get; set; }

        public decimal? PaidAmount { get; set; }

        public decimal? Balance { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }

        public int BranchId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual JournalEntryVM JournalEntry { get; set; }
    }

    public partial class AccountReceivableVM
    {
        public Guid Arid { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public Guid CustomerId { get; set; }

        public Guid? InvoiceId { get; set; }

        public Guid? JournalEntryId { get; set; }

        public decimal Amount { get; set; }

        public decimal? ReceivedAmount { get; set; }

        public decimal? Balance { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }

        public Guid BranchId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual JournalEntryVM JournalEntry { get; set; }
    }
    public class ChartOfAccountVM
    {
        public int CoaId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public int? ParentCoaId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ChartOfAccountVM> Children { get; set; } = new List<ChartOfAccountVM>();
    }

    public partial class FiscalPeriodVM
    {
        public Guid FiscalPeriodId { get; set; }

        public int FiscalYear { get; set; }

        public int PeriodNumber { get; set; }

        public string PeriodName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool? IsClosed { get; set; }

        public int BranchId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual LoginUserVM CreatedByNavigation { get; set; }
    }
    public partial class JournalEntryVM
    {
        public Guid JournalEntryId { get; set; }

        public string EntryNumber { get; set; }

        public DateTime EntryDate { get; set; }

        public string ReferenceNumber { get; set; }

        public string Description { get; set; }

        public string SourceModule { get; set; }

        public int BranchId { get; set; }

        public decimal? TotalDebit { get; set; }

        public decimal? TotalCredit { get; set; }

        public string Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AccountPayableVM> AccountPayables { get; set; } = new List<AccountPayableVM>();

        public virtual ICollection<AccountReceivableVM> AccountReceivables { get; set; } = new List<AccountReceivableVM>();

        public virtual LoginUserVM CreatedByNavigation { get; set; }

        public virtual ICollection<JournalLineVM> JournalLines { get; set; } = new List<JournalLineVM>();

        public virtual ICollection<PaymentVM> Payments { get; set; } = new List<PaymentVM>();

        public virtual ICollection<TaxTransactionVM> TaxTransactions { get; set; } = new List<TaxTransactionVM>();

        public virtual LoginUserVM UpdatedByNavigation { get; set; }
    }
    public partial class JournalLineVM
    {
        public Guid JournalLineId { get; set; }

        public Guid JournalEntryId { get; set; }

        public int CoaId { get; set; }

        public string Description { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }

        public Guid? ReferenceId { get; set; }

        public string ReferenceType { get; set; }

        public int? LineOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ChartOfAccountVM Coa { get; set; }

        public virtual JournalEntryVM JournalEntry { get; set; }
    }
    public partial class PaymentVM
    {
        public Guid PaymentId { get; set; }

        public string PaymentType { get; set; }

        public string SourceType { get; set; }

        public int? SourceId { get; set; }

        public int? ReferenceId { get; set; }

        public Guid? JournalEntryId { get; set; }

        public string PaymentMode { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int BranchId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual JournalEntryVM JournalEntry { get; set; }
    }
    public partial class ReconciliationLogVM
    {
        public Guid ReconciliationId { get; set; }

        public string SourceType { get; set; }

        public Guid? SourceId { get; set; }

        public string Description { get; set; }

        public decimal? AdjustmentAmount { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int BranchId { get; set; }
    }
    public partial class TaxTransactionVM
    {
        public Guid TaxTransactionId { get; set; }

        public string SourceType { get; set; }

        public int SourceId { get; set; }

        public Guid? JournalEntryId { get; set; }

        public int TaxAccountId { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal BaseAmount { get; set; }

        public string TaxType { get; set; }

        public int BranchId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual JournalEntryVM JournalEntry { get; set; }

        public virtual ChartOfAccountVM TaxAccount { get; set; }
    }

}
