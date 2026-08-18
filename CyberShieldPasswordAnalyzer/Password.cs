using System;
using System.Linq;

namespace CyberShieldPasswordAnalyzer;

public abstract class Password
{
    // stores the password and the score/recommendation after Analyse() runs
    public string PasswordText { get; protected set; }
    public int Score { get; protected set; }
    public string Recommendation { get; protected set; } = string.Empty;

    protected Password(string text)
    {
        PasswordText = text ?? string.Empty;
        // score starts at 0 until Analyse() is called
        Score = 0;
    }

    public abstract void Analyse();

    // works out weak/moderate/strong from the score
    public string Strength()
    {
        if (Score >= 80) return "Strong";
        if (Score >= 50) return "Moderate";
        return "Weak";
    }
}

public class StandardPassword : Password
{
    public StandardPassword(string text) : base(text) { }

    public override void Analyse()
    {
        // length score, max 50 points
        var lengthScore = Math.Min(50, PasswordText.Length * 4);
        var variety = 0;
        if (PasswordText.Any(char.IsDigit)) variety += 10;
        if (PasswordText.Any(char.IsUpper)) variety += 15;
        if (PasswordText.Any(ch => "!@#$%^&*()-_=+[]{};:'\",.<>/?`~".Contains(ch))) variety += 25;
        // no separate points for lowercase, its assumed by default

        Score = lengthScore + variety;
        if (Score > 100) Score = 100;

        Recommendation = Score >= 80 ? "Looks good." : "Try longer and add symbols.";
    }
}

public class PersonalPassword : Password
{
    public PersonalPassword(string text) : base(text) { }

    public override void Analyse()
    {
        // Personal: longer is better; penalise obvious personal markers.
        Score = Math.Min(100, PasswordText.Length * 5);
        if (PasswordText.ToLower().Contains("name") || PasswordText.ToLower().Contains("123"))
        {
            Score = Math.Max(0, Score - 20);
            Recommendation = "Don't use names, numbers or obvious patterns.";
        }
        else
        {
            Recommendation = "Good. Use a long phrase. Add symbols for extra strength.";
        }
    }
}

public class BusinessPassword : Password
{
    public BusinessPassword(string text) : base(text) { }

    public override void Analyse()
    {
        // Business: reward digits, upper-case and symbols; clamp final score.
        Score = Math.Min(100, PasswordText.Length * 4);
        if (PasswordText.Any(char.IsUpper)) Score += 10; else Score -= 5;
        if (PasswordText.Any(char.IsDigit)) Score += 10; else Score -= 5;
        if (PasswordText.Any(ch => "!@#$%^&*()".Contains(ch))) Score += 15;

        Score = Math.Clamp(Score, 0, 100);
        Recommendation = "Use big+small letters, numbers and symbols.";
    }
}

public class AdministratorPassword : Password
{
    public AdministratorPassword(string text) : base(text) { }

    public override void Analyse()
    {
        // Admin: strict scoring with extra weight for length and symbols.
        Score = PasswordText.Length * 6;
        if (PasswordText.Any(char.IsUpper)) Score += 10;
        if (PasswordText.Any(char.IsLower)) Score += 5;
        if (PasswordText.Any(char.IsDigit)) Score += 10;
        if (PasswordText.Any(ch => "!@#$%^&*()-_=+".Contains(ch))) Score += 15;

        if (Score > 100) Score = 100;
        Recommendation = Score >= 90 ? "Nice. Maybe use a token too." : "Admins need very strong passwords and MFA.";
    }
}
