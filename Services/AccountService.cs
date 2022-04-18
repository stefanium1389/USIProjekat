using RazorPagesAccount.Models;

namespace RazorPagesAccount.Services;

public static class AccountService {

    static List<Account> Accounts { get; }

    static AccountService()
    {
        Accounts = new List<Account> //TODO: read from a database (or file), for now i hardcoded some accounts to have something to work with
                {
                    new Account { Id = 1, Email = "manager@email.com", Password = "manager", Type=AccountType.Manager},
                    new Account { Id = 2, Email = "doctor@email.com", Password = "doctor", Type=AccountType.Doctor},
                    new Account { Id = 3, Email = "patient@email.com", Password = "patient", Type=AccountType.Patient},
                    new Account { Id = 4, Email = "secretary@email.com", Password = "secretary", Type=AccountType.Secretary},
                };
    }

    public static List<Account> GetAll() => Accounts;

    public static Account? Get(int id) => Accounts.FirstOrDefault(p => p.Id == id);

    public static void AddAccount(Account acc)
    {
        acc.Id = Accounts.Count() + 1; //should be readjusted in final version, like this you can have id duplicates
        Accounts.Add(acc);
    }
    public static void Delete(int id)
    {
        var acc = Get(id);
        if (acc is null)
            return;

        Accounts.Remove(acc);
    }
    public static bool LogIn(string user, string pass)
    {
        foreach (Account acc in Accounts) {
            if (acc.Email == user){
                if (acc.Password == pass)
                return true;
            }
        }
        return false;
    }
}