
namespace ZOGA.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GammaLabel = new System.Windows.Forms.Label();
            this.GammaTrackBar = new System.Windows.Forms.TrackBar();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GammaTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // GammaLabel
            // 
            this.GammaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GammaLabel.Location = new System.Drawing.Point(12, 9);
            this.GammaLabel.Name = "GammaLabel";
            this.GammaLabel.Size = new System.Drawing.Size(364, 22);
            this.GammaLabel.TabIndex = 0;
            this.GammaLabel.Text = "Gamma: 1.0";
            this.GammaLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // GammaTrackBar
            // 
            this.GammaTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GammaTrackBar.LargeChange = 1;
            this.GammaTrackBar.Location = new System.Drawing.Point(12, 34);
            this.GammaTrackBar.Maximum = 1;
            this.GammaTrackBar.Name = "GammaTrackBar";
            this.GammaTrackBar.Size = new System.Drawing.Size(364, 45);
            this.GammaTrackBar.TabIndex = 1;
            this.GammaTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.GammaTrackBar.Scroll += new System.EventHandler(this.GammaTrackBar_Scroll);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResetButton.Location = new System.Drawing.Point(157, 86);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 121);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.GammaTrackBar);
            this.Controls.Add(this.GammaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZOGA - Zandronum OpenGL Gamma Adjuster";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GammaTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GammaLabel;
        private System.Windows.Forms.TrackBar GammaTrackBar;
        private System.Windows.Forms.Button ResetButton;
    }
}

