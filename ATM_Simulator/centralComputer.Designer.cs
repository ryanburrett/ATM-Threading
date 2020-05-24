namespace ATM_Simulator
{
    partial class centralComputer
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
            this.launchNewATM = new System.Windows.Forms.Button();
            this.threadSafeCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // launchNewATM
            // 
            this.launchNewATM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchNewATM.Location = new System.Drawing.Point(266, 347);
            this.launchNewATM.Name = "launchNewATM";
            this.launchNewATM.Size = new System.Drawing.Size(170, 68);
            this.launchNewATM.TabIndex = 0;
            this.launchNewATM.Text = "Start a new ATM";
            this.launchNewATM.UseVisualStyleBackColor = true;
            this.launchNewATM.Click += new System.EventHandler(this.launchNewATM_Click);
            // 
            // threadSafeCheckBox
            // 
            this.threadSafeCheckBox.AutoSize = true;
            this.threadSafeCheckBox.Location = new System.Drawing.Point(266, 447);
            this.threadSafeCheckBox.Name = "threadSafeCheckBox";
            this.threadSafeCheckBox.Size = new System.Drawing.Size(160, 17);
            this.threadSafeCheckBox.TabIndex = 1;
            this.threadSafeCheckBox.Text = "SET THREAD SAFE MODE";
            this.threadSafeCheckBox.UseVisualStyleBackColor = true;
            this.threadSafeCheckBox.CheckedChanged += new System.EventHandler(this.threadSafeCheckBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ATM_Simulator.Properties.Resources.logoATM2;
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 314);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // centralComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 493);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.threadSafeCheckBox);
            this.Controls.Add(this.launchNewATM);
            this.Name = "centralComputer";
            this.Text = "b";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchNewATM;
        private System.Windows.Forms.CheckBox threadSafeCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}