namespace Examples.Banking
{
    public class BankAccount
    {
        private readonly string _accountNumber;
        private readonly decimal _balance;
        private const decimal MinimumBalance = 0.0m;
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if(string.IsNullOrEmpty(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty", nameof(accountNumber));
            if (initialBalance < MinimumBalance)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be less than minimum balance");

            _accountNumber = accountNumber;
            _balance = initialBalance;
        }

        public decimal Balance() => _balance;

        public static BankAccount NewSavingsAccount(string accountNumber, decimal initialBalance = 0.0m) =>
            new BankAccount(accountNumber, initialBalance);

        public static BankAccount NewCurrentAccount(string accountNumber) =>
            new BankAccount(accountNumber, 10000.0m);

        public BankAccount Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
            return new BankAccount(_accountNumber, Balance() + amount);
        }

        public BankAccount Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
            if (Balance() - amount < MinimumBalance)
                throw new InvalidOperationException("Insufficient funds for this withdrawal");
            return new BankAccount(_accountNumber, Balance() - amount);
        }

        public bool IsBetterThan(BankAccount other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other), "Comparison account cannot be null");
            return Balance() > other.Balance();
        }

    }
}
