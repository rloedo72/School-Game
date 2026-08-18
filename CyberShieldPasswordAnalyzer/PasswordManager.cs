using System.Collections.Generic;
using System.Linq;

namespace CyberShieldPasswordAnalyzer;

public class PasswordManager
{
    public List<Password> Passwords { get; } = new List<Password>();
    //System.IO.File.WriteAllText("password_count.txt", Passwords.Count.ToString()); // used this to check count while testing

    public void AddPassword(Password p)
    {
        // only add if its not null, was crashing before i added this check
        if (p != null) Passwords.Add(p);
    }

    public int TotalPasswords => Passwords.Count;

    // had to check count == 0 first or this throws an error on an empty list
    public double AverageScore => Passwords.Count == 0 ? 0 : Passwords.Average(p => p.Score);

    public int HighestScore => Passwords.Count == 0 ? 0 : Passwords.Max(p => p.Score);

    public int LowestScore => Passwords.Count == 0 ? 0 : Passwords.Min(p => p.Score);

    public int CountWeak => Passwords.Count(p => p.Score < 50);
    public int CountModerate => Passwords.Count(p => p.Score >= 50 && p.Score < 80);
    public int CountStrong => Passwords.Count(p => p.Score >= 80);
}
