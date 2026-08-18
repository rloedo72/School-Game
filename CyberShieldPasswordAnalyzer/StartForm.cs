using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CyberShieldPasswordAnalyzer;

public class StartForm : Form
{
    private Button btnStart;
    private TextBox txtName;

    public StartForm()
    {
        // shows welcome msg and asks for the analyst name
        Text = "Start";
        Width = 350;
        Height = 160;
        StartPosition = FormStartPosition.CenterScreen;

        // welcome label + textbox for the name + button to continue
        var lbl = new Label { Text = "Welcome, enter your name:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
        txtName = new TextBox { Location = new System.Drawing.Point(10, 35), Width = 320 };
        btnStart = new Button { Text = "Open Analyzer", Location = new System.Drawing.Point(10, 70), Width = 320 };

        btnStart.Click += BtnStart_Click;

        Controls.Add(lbl);
        Controls.Add(txtName);
        Controls.Add(btnStart);
    }

    private void BtnStart_Click(object? sender, EventArgs e)
    {
        var name = txtName.Text?.Trim() ?? string.Empty;

        // name must be letters and spaces only, at least 2 chars
        if (string.IsNullOrEmpty(name) || name.Length < 2 || !Regex.IsMatch(name, "^[A-Za-z ]+$"))
        {
            MessageBox.Show("Please enter a valid name (letters and spaces only).", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var mf = new MainForm(name);
        mf.Show();
        // Hide instead of Close so the app doesnt fully shut down
        Hide();
    }
}
