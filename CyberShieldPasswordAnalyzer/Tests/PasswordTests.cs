using Xunit;
using CyberShieldPasswordAnalyzer;

namespace CyberShieldPasswordAnalyzer.Tests;

// PasswordTests.cs
// Unit tests (xUnit) for the various password types in CyberShieldPasswordAnalyzer.
// Covers StandardPassword, PersonalPassword, BusinessPassword, and AdministratorPassword,
// verifying that Analyse() produces the expected Score, Strength(), and Recommendation
// for representative password inputs.
public class PasswordTests
{
    [Fact]
    public void StandardPassword_LongWithSymbols_IsStrong()
    {
        var p = new StandardPassword("LongPassword123!");
        p.Analyse();
        Assert.True(p.Score >= 80);
        Assert.Equal("Strong", p.Strength());
    }

    [Fact]
    public void PersonalPassword_WithName_IsPenalized()
    {
        var p = new PersonalPassword("john123");
        p.Analyse();
        Assert.Contains("Don't use", p.Recommendation);
    }

    [Fact]
    public void BusinessPassword_RewardsDigitsAndUpper()
    {
        var p = new BusinessPassword("BizPass1A");
        p.Analyse();
        Assert.True(p.Score >= 50);
    }

    [Fact]
    public void AdminPassword_VeryStrong_WhenLong()
    {
        var p = new AdministratorPassword("SuperStrongPass123!@#");
        p.Analyse();
        Assert.Equal("Strong", p.Strength());
    }
}
