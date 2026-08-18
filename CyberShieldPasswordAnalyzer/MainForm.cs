using System;
using System.Windows.Forms;

namespace CyberShieldPasswordAnalyzer;

public class MainForm : Form
{
    private TextBox txtPassword;
    private ComboBox cbType;
    private Button btnAnalyse;
    private Button btnReport;
    private ListBox lstPasswords;
    private PasswordManager manager = new PasswordManager();
    private string analystName;

    public MainForm(string analystName)
    {
        this.analystName = analystName;

        // main window, enter password + type and hit check
        Text = $"Password Analyzer - {analystName}";
        Width = 500;
        Height = 360;
        StartPosition = FormStartPosition.CenterScreen;

        var lbl = new Label { Text = "Password:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
        txtPassword = new TextBox { Width = 260, Location = new System.Drawing.Point(80, 8) };

        cbType = new ComboBox { Location = new System.Drawing.Point(350, 8), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
        cbType.Items.AddRange(new[] { "Standard", "Personal", "Business", "Administrator" });
        cbType.SelectedIndex = 0;

        btnAnalyse = new Button { Text = "Check", Location = new System.Drawing.Point(10, 40), Width = 100 };
        btnAnalyse.Click += BtnAnalyse_Click;

        btnReport = new Button { Text = "Show report", Location = new System.Drawing.Point(120, 40), Width = 100 };
        btnReport.Click += (s, e) =>
        {
            var rf = new ReportForm(manager);
            rf.ShowDialog();
        };

        lstPasswords = new ListBox { Location = new System.Drawing.Point(10, 80), Width = 460, Height = 240 };

        Controls.Add(lbl);
        Controls.Add(txtPassword);
        Controls.Add(cbType);
        Controls.Add(btnAnalyse);
        Controls.Add(btnReport);
        Controls.Add(lstPasswords);
    }

    private void BtnAnalyse_Click(object? sender, EventArgs e)
    {
        // grab whatever was typed in the password box
        var text = txtPassword.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Type a password, please.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            Password p = cbType.SelectedItem?.ToString() switch
            {
                "Personal" => new PersonalPassword(text),
                "Business" => new BusinessPassword(text),
                "Administrator" => new AdministratorPassword(text),
                _ => new StandardPassword(text)
            };

            p.Analyse();
            manager.AddPassword(p);
            lstPasswords.Items.Add($"{p.PasswordText} - {p.Score} - {p.Strength()} - {p.Recommendation}");
            txtPassword.Clear();
        }
        catch (Exception ex)
        {
            // just in case something breaks, show error instead of crashing
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
