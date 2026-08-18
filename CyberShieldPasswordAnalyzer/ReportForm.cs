using System;
using System.Windows.Forms;

namespace CyberShieldPasswordAnalyzer;

public class ReportForm : Form
{
    public ReportForm(PasswordManager manager)
    {
        //Console.WriteLine(manager.TotalPasswords); // quick check while testing
        Text = "Report";
        Width = 360;
        Height = 300;

        var y = 10;
        void addLabel(string t)
        {
            var l = new Label { Text = t, AutoSize = true, Location = new System.Drawing.Point(10, y) };
            Controls.Add(l);
            y += 24;
        }

        addLabel($"Total: {manager.TotalPasswords}");
        // :F1 rounds the average to 1 decimal place, otherwise it looks messy
        addLabel($"Average score: {manager.AverageScore:F1}");
        addLabel($"Highest: {manager.HighestScore}");
        addLabel($"Lowest: {manager.LowestScore}");
        addLabel($"Weak: {manager.CountWeak}");
        addLabel($"Moderate: {manager.CountModerate}");
        addLabel($"Strong: {manager.CountStrong}");
        // no "Very Strong" category in this version, might add later

        var btn = new Button { Text = "Done", Location = new System.Drawing.Point(10, y + 10) };
        // closes the report window when done is clicked
        btn.Click += (s, e) => Close();
        Controls.Add(btn);
    }
}
