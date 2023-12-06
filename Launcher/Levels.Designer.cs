namespace Launcher
{
    partial class Levels
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
            if (disposing && (components != null))
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
            this.button_level1 = new System.Windows.Forms.Button();
            this.button_level2 = new System.Windows.Forms.Button();
            this.button_level3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_level1
            // 
            this.button_level1.Location = new System.Drawing.Point(317, 77);
            this.button_level1.Name = "button_level1";
            this.button_level1.Size = new System.Drawing.Size(148, 55);
            this.button_level1.TabIndex = 0;
            this.button_level1.Text = "Уровень 1";
            this.button_level1.UseVisualStyleBackColor = true;
            // 
            // button_level2
            // 
            this.button_level2.Location = new System.Drawing.Point(317, 152);
            this.button_level2.Name = "button_level2";
            this.button_level2.Size = new System.Drawing.Size(148, 55);
            this.button_level2.TabIndex = 1;
            this.button_level2.Text = "Уровень 2";
            this.button_level2.UseVisualStyleBackColor = true;
            // 
            // button_level3
            // 
            this.button_level3.Location = new System.Drawing.Point(317, 230);
            this.button_level3.Name = "button_level3";
            this.button_level3.Size = new System.Drawing.Size(148, 55);
            this.button_level3.TabIndex = 2;
            this.button_level3.Text = "Уровень 3";
            this.button_level3.UseVisualStyleBackColor = true;
            // 
            // Levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_level3);
            this.Controls.Add(this.button_level2);
            this.Controls.Add(this.button_level1);
            this.Name = "Levels";
            this.Text = "Levels";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_level1;
        private System.Windows.Forms.Button button_level2;
        private System.Windows.Forms.Button button_level3;
    }
}