using System;

class BankAccount
{
    // 1. Private fields (Data Hiding - cannot be accessed directly from outside)
    private readonly string _accountNumber;
    private string _holderName;
    private double _balance;
    private int _creditScore;

    // 2. Read-Only Property (only 'get' accessor)
    public string AccountNumber
    {
        get { return _accountNumber; }
    }

    // 3. Read-Write Property with validation in 'set' accessor
    public string HolderName
    {
        get { return _holderName; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
            {
                Console.WriteLine("[ERROR] Holder Name cannot be empty!");
            }
            else
            {
                _holderName = value.Trim();
                Console.WriteLine("[SUCCESS] Holder name updated to: " + _holderName);
            }
        }
    }

    // 4. Property with restricted 'set' logic (Encapsulating data integrity)
    public double Balance
    {
        get { return _balance; }
        private set { _balance = value; } // Only internal methods can modify balance directly
    }

    // 5. Property with boundary validation
    public int CreditScore
    {
        get { return _creditScore; }
        set
        {
            if (value < 300 || value > 900)
            {
                Console.WriteLine("[ERROR] Invalid Credit Score! Must be between 300 and 900. Value rejected: " + value);
            }
            else
            {
                _creditScore = value;
                Console.WriteLine("[SUCCESS] Credit score updated to: " + _creditScore);
            }
        }
    }

    // 6. Auto-implemented property
    public string AccountType { get; set; }

    // Constructor
    public BankAccount(string accNo, string holderName, double initialDeposit, string accType)
    {
        _accountNumber = accNo;
        _holderName = holderName;
        _balance = initialDeposit >= 0 ? initialDeposit : 0;
        _creditScore = 750;
        AccountType = accType;
    }

    // Methods encapsulating operations on private state
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine("[DEPOSIT] Deposited Rs. {0:N2}. New Balance: Rs. {1:N2}", amount, Balance);
        }
        else
        {
            Console.WriteLine("[ERROR] Deposit amount must be positive!");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("[ERROR] Withdrawal amount must be greater than zero!");
        }
        else if (amount > Balance)
        {
            Console.WriteLine("[ERROR] Insufficient funds! Available: Rs. {0:N2}, Attempted: Rs. {1:N2}", Balance, amount);
        }
        else
        {
            Balance -= amount;
            Console.WriteLine("[WITHDRAW] Withdrew Rs. {0:N2}. Remaining Balance: Rs. {1:N2}", amount, Balance);
        }
    }

    public void DisplayAccountSummary()
    {
        Console.WriteLine("\n----------------- Account Summary -----------------");
        Console.WriteLine("Account Number : " + AccountNumber);
        Console.WriteLine("Account Holder : " + HolderName);
        Console.WriteLine("Account Type   : " + AccountType);
        Console.WriteLine("Current Balance: Rs. {0:N2}", Balance);
        Console.WriteLine("Credit Score   : " + CreditScore);
        Console.WriteLine("---------------------------------------------------\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("     Demonstrating Encapsulation in C# using Get and Set Properties  ");
        Console.WriteLine("=====================================================================");

        // Create account
        BankAccount acc = new BankAccount("SB-IN-2026-994", "Sahil Rautela", 25000.00, "Savings");
        acc.DisplayAccountSummary();

        // 1. Reading values using 'get'
        Console.WriteLine("[1] Reading Properties via 'get':");
        Console.WriteLine("--> Account Number (Read-Only) : " + acc.AccountNumber);
        Console.WriteLine("--> Holder Name                : " + acc.HolderName);
        Console.WriteLine("--> Balance (Read-Only)        : Rs. {0:N2}", acc.Balance);

        // 2. Modifying values via 'set' (Valid input)
        Console.WriteLine("\n[2] Modifying Properties via 'set' (Valid values):");
        acc.HolderName = "Sahil R.";
        acc.CreditScore = 820;
        acc.AccountType = "Premium Savings";

        // 3. Testing Encapsulation Validation (Attempting Invalid input)
        Console.WriteLine("\n[3] Testing Encapsulation Protection (Invalid values):");
        Console.WriteLine("Attempting to set empty name...");
        acc.HolderName = ""; // Rejected by set property logic

        Console.WriteLine("Attempting to set invalid credit score (1200)...");
        acc.CreditScore = 1200; // Rejected by set property logic

        // 4. Controlled state transitions via methods
        Console.WriteLine("\n[4] Encapsulated Operations on Balance:");
        acc.Deposit(5000);
        acc.Withdraw(12000);
        acc.Withdraw(50000); // Exceeds balance, properly blocked

        acc.DisplayAccountSummary();

        Console.WriteLine("=====================================================================");
    }
}
