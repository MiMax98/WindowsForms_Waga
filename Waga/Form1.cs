using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Waga
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnOblicz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Podaj wzrost", "Błąd");
                return;
            }
            if (!double.TryParse(textBox1.Text, out double wzrost))
            {
                MessageBox.Show("Nieprawidłowy wzrost", "Błąd");
                return;
            }
            double standardowa = wzrost - 100;
            var results = new List<string>();
            if (checkBox1.Checked)
            {
                results.Add($"Twoja standardowa waga powinna wynosić: {standardowa} kg");
            }
            if (checkBox2.Checked)
            {
                if (!rdoKobieta.Checked && !rdoMezczyzna.Checked)
                {
                    MessageBox.Show("Podaj płeć", "Błąd");
                    return;
                }
                var wsp = rdoKobieta.Checked ? 0.85 : 0.9;
                double idealna = standardowa * wsp;
                results.Add($"Twoja idealna waga powinna wynosić: {idealna} kg");
            }
            lblWynik.Text = string.Join('\n', results);
        }
    }
}
