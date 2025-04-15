namespace UnitTests;
using Examples.Banking;

public class BankingTests
{
    private readonly BankAccount _bankAccount = BankAccount.NewSavingsAccount("123456", 100);

    [Fact]
    public void NotAcceptableValues()
    {
        Assert.Throws<ArgumentException>(() => BankAccount.NewSavingsAccount("", 100));
        Assert.Throws<ArgumentOutOfRangeException>(() => BankAccount.NewSavingsAccount("123456789", -100));
        Assert.Throws<ArgumentOutOfRangeException>(() => BankAccount.NewCurrentAccount("1234",9000));
    }

    [Fact]
    public void InitialBalance()
    {
        Assert.Equal(100.0m, _bankAccount.Balance());
        Assert.Equal(0.0m, BankAccount.NewSavingsAccount("789012").Balance());
        Assert.Equal(10000.0m, BankAccount.NewCurrentAccount("345678").Balance());
    }

    [Fact]
    public void DepositBalanceUpdated()
    {
        Assert.Equal(1000, _bankAccount.Deposit(900).Balance());
    }

    [Fact]
    public void WithdrawBalanceUpdated()
    {
        Assert.Equal(100, _bankAccount.Balance());
        Assert.Equal(50, _bankAccount.Withdraw(50).Balance());
    }

    [Fact]
    public void CompareAccounts()
    {
        Assert.True(_bankAccount.IsBetterThan(BankAccount.NewSavingsAccount("123456789", 50)));
    }

}

