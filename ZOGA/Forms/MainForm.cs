using System;
using System.Globalization;
using System.Windows.Forms;
using ZOGA.Classes;

namespace ZOGA.Forms
{
    public partial class MainForm : Form
    {
        const float GAMMA_STEP = 0.1f;

        private NumberFormatInfo numberFormat = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetTrackBarGamma(float value)
        {
            GammaTrackBar.Value = (int)Math.Round((value - Gamma.MinValue) / GAMMA_STEP);
            GammaTrackBar_Scroll(GammaTrackBar, EventArgs.Empty); // Yes, I know this is ugly
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Gamma.SetGamma(1.0f);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GammaTrackBar.Minimum = 0;
            GammaTrackBar.Maximum = (int)Math.Round((Gamma.MaxValue - Gamma.MinValue) / GAMMA_STEP);
            
            SetTrackBarGamma(1.0f);

            Application.ApplicationExit += this.Application_ApplicationExit;
        }

        private void GammaTrackBar_Scroll(object sender, EventArgs e)
        {
            float gamma = (float)Math.Round(Gamma.MinValue + (GammaTrackBar.Value * GAMMA_STEP), 1);
            gamma = MathHelper.Clamp(gamma, Gamma.MinValue, Gamma.MaxValue);

            Gamma.SetGamma(gamma);
            GammaLabel.Text = "Gamma: " + gamma.ToString("0.0", numberFormat);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetTrackBarGamma(1.0f);
        }
    }
}
