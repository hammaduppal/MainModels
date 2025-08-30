namespace MainModels.DTOModels
{
    public class SystemSettingsDTO
    {
        public static SystemPreferencesVM GetSystemPreferences()
        {
            var systemPreferences = new SystemPreferencesVM
            {
                // General Settings
                CompanyName = "Tech Solutions Pvt Ltd",
                CompanyLogoUrl = "/images/logo.png",
                DefaultLanguage = "en",
                TimeZone = "Asia/Karachi",
                DateFormat = "dd/MM/yyyy",
                CurrencyCode = "PKR",
                CurrencySymbol = "₨",
                DecimalPlaces = 2,
                IsAffilatedInvoice = true,
                IsRestaurantApplication = true,
                 
                // Tax & Financial
                EnableTax = true,
                DefaultTaxRate = 17m, // 17% GST standard in Pakistan
                TaxRegistrationNumber = "1234567-8",
                PricesIncludeTax = false,

                // Inventory & Sales
                EnableInventoryTracking = true,
                DefaultWarehouse = "Main Warehouse - Islamabad",
                LowStockThreshold = 10,
                AllowNegativeStock = false,

                // Invoice & Document Settings
                InvoicePrefix = "INV",
                InvoiceStartNumber = 1001,
                QuotationPrefix = "QTN",
                ReceiptPrefix = "RCT",
                ShowLogoOnInvoices = true,
                ShowTaxBreakdown = true,

                // User & Security
                EnableTwoFactorAuth = false,
                SessionTimeoutMinutes = 30,
                AllowMultipleLogins = true,

                // Email & Communication
                SmtpServer = "smtp.gmail.com",
                SmtpPort = 587,
                SmtpUserName = "noreply@techsolutions.com",
                SmtpPassword = "password123", // dummy password
                EnableSsl = true,
                DefaultFromEmail = "noreply@techsolutions.com",

                // Other Options
                EnableAutoBackup = true,
                AutoBackupIntervalDays = 7,
                BackupLocation = "D:\\ERP_Backups"
            };
            return systemPreferences;


        }
        public static AccountingPreferencesVM GetAccountingPreferences()
        {
            return new AccountingPreferencesVM
            {
                FiscalYearStartMonth = "July",
                FiscalYearEndMonth = "June",
                FiscalYearStartDate = new DateTime(DateTime.Now.Year, 7, 1),
                FiscalYearEndDate = new DateTime(DateTime.Now.Year + 1, 6, 30),
                EnableMultiCurrency = true,
                BaseCurrencyCode = "PKR",
                DefaultExchangeRateSource = "State Bank of Pakistan",
                EnableAutomaticYearClosing = true,
                LockTransactionsAfterPeriodClose = true,
                DefaultSalesAccount = "Sales Revenue",
                DefaultPurchaseAccount = "Cost of Goods Sold",
                DefaultTaxAccount = "GST Payable",
                AllowBackDatedTransactions = false
            };
        }
    }
    public class SystemPreferencesVM
    {
        // General Settings
        public string CompanyName { get; set; }
        public Guid BranchId { get; set; }
        public bool IsRestaurantApplication { get; set; }
        public string CompanyLogoUrl { get; set; }
        public string DefaultLanguage { get; set; }
        public string TimeZone { get; set; }
        public string DateFormat { get; set; } // e.g., "dd/MM/yyyy"
        public string CurrencyCode { get; set; } // e.g., "USD"
        public string CurrencySymbol { get; set; } // e.g., "$"
        public int DecimalPlaces { get; set; } // e.g., 2
        public bool IsAffilatedInvoice { get; set; }
        // Tax & Financial
        public bool EnableTax { get; set; }
        public decimal? DefaultTaxRate { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public bool PricesIncludeTax { get; set; }

        // Inventory & Sales
        public bool EnableInventoryTracking { get; set; }
        public string DefaultWarehouse { get; set; }
        public int? LowStockThreshold { get; set; }
        public bool AllowNegativeStock { get; set; }

        // Invoice & Document Settings
        public string InvoicePrefix { get; set; } // e.g., "INV"
        public int? InvoiceStartNumber { get; set; }
        public string QuotationPrefix { get; set; }
        public string ReceiptPrefix { get; set; }
        public bool ShowLogoOnInvoices { get; set; }
        public bool ShowTaxBreakdown { get; set; }

        // User & Security
        public bool EnableTwoFactorAuth { get; set; }
        public int? SessionTimeoutMinutes { get; set; }
        public bool AllowMultipleLogins { get; set; }

        // Email & Communication
        public string SmtpServer { get; set; }
        public int? SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
        public string DefaultFromEmail { get; set; }

        // Other Options
        public bool EnableAutoBackup { get; set; }
        public int? AutoBackupIntervalDays { get; set; }
        public string BackupLocation { get; set; }
    }
    public class AccountingPreferencesVM
    {
        public string FiscalYearStartMonth { get; set; } // e.g., "July"
        public string FiscalYearEndMonth { get; set; }   // e.g., "June"
        public DateTime? FiscalYearStartDate { get; set; }
        public DateTime? FiscalYearEndDate { get; set; }
        public Guid BranchId { get; set; }
        public bool EnableMultiCurrency { get; set; }
        public string BaseCurrencyCode { get; set; } // e.g., "USD"
        public string DefaultExchangeRateSource { get; set; } // e.g., "ECB"

        public bool EnableAutomaticYearClosing { get; set; }
        public bool LockTransactionsAfterPeriodClose { get; set; }

        public string DefaultSalesAccount { get; set; }
        public string DefaultPurchaseAccount { get; set; }
        public string DefaultTaxAccount { get; set; }

        public bool AllowBackDatedTransactions { get; set; }
    }

}
