namespace SafeUnsafeAdder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstNumbers = new System.Windows.Forms.ListBox();
            this.btnCalculateSafe = new System.Windows.Forms.Button();
            this.btnCalculateUnsafe = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSafeTotal = new System.Windows.Forms.Label();
            this.lblUnsafeTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(12, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(250, 20);
            this.txtNumber.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(274, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Number";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstNumbers
            // 
            this.lstNumbers.FormattingEnabled = true;
            this.lstNumbers.Location = new System.Drawing.Point(12, 45);
            this.lstNumbers.Name = "lstNumbers";
            this.lstNumbers.Size = new System.Drawing.Size(382, 225);
            this.lstNumbers.TabIndex = 2;
            // 
            // btnCalculateSafe
            // 
            this.btnCalculateSafe.Location = new System.Drawing.Point(12, 280);
            this.btnCalculateSafe.Name = "btnCalculateSafe";
            this.btnCalculateSafe.Size = new System.Drawing.Size(185, 30);
            this.btnCalculateSafe.TabIndex = 3;
            this.btnCalculateSafe.Text = "Total (Safe Code)";
            this.btnCalculateSafe.UseVisualStyleBackColor = true;
            this.btnCalculateSafe.Click += new System.EventHandler(this.btnCalculateSafe_Click);
            // 
            // btnCalculateUnsafe
            // 
            this.btnCalculateUnsafe.Location = new System.Drawing.Point(209, 280);
            this.btnCalculateUnsafe.Name = "btnCalculateUnsafe";
            this.btnCalculateUnsafe.Size = new System.Drawing.Size(185, 30);
            this.btnCalculateUnsafe.TabIndex = 4;
            this.btnCalculateUnsafe.Text = "Total (Unsafe Code)";
            this.btnCalculateUnsafe.UseVisualStyleBackColor = true;
            this.btnCalculateUnsafe.Click += new System.EventHandler(this.btnCalculateUnsafe_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(274, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Database";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSafeTotal
            // 
            this.lblSafeTotal.AutoSize = true;
            this.lblSafeTotal.Location = new System.Drawing.Point(12, 325);
            this.lblSafeTotal.Name = "lblSafeTotal";
            this.lblSafeTotal.Size = new System.Drawing.Size(100, 13);
            this.lblSafeTotal.TabIndex = 5;
            this.lblSafeTotal.Text = "Safe total: -";
            // 
            // lblUnsafeTotal
            // 
            this.lblUnsafeTotal.AutoSize = true;
            this.lblUnsafeTotal.Location = new System.Drawing.Point(12, 350);
            this.lblUnsafeTotal.Name = "lblUnsafeTotal";
            this.lblUnsafeTotal.Size = new System.Drawing.Size(100, 13);
            this.lblUnsafeTotal.TabIndex = 6;
            this.lblUnsafeTotal.Text = "Unsafe total: -";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 412);
            this.Controls.Add(this.lblUnsafeTotal);
            this.Controls.Add(this.lblSafeTotal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculateUnsafe);
            this.Controls.Add(this.btnCalculateSafe);
            this.Controls.Add(this.lstNumbers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROG7312 ICE Task 2 - Safe and Unsafe Addition";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstNumbers;
        private System.Windows.Forms.Button btnCalculateSafe;
        private System.Windows.Forms.Button btnCalculateUnsafe;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSafeTotal;
        private System.Windows.Forms.Label lblUnsafeTotal;
    }
}
