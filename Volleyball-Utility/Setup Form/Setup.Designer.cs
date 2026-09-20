namespace Volleyball_Utility
{
    partial class Setup
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
            this.GmailTextBox = new System.Windows.Forms.TextBox();
            this.SecretaryNoTextBox = new System.Windows.Forms.TextBox();
            this.VerifyUserInputButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SharedAppPwdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GmailTextBox
            // 
            this.GmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GmailTextBox.Location = new System.Drawing.Point(140, 67);
            this.GmailTextBox.Name = "GmailTextBox";
            this.GmailTextBox.Size = new System.Drawing.Size(240, 29);
            this.GmailTextBox.TabIndex = 0;
            this.GmailTextBox.TabStop = false;
            this.GmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SenderEmailTextBox_KeyDown);
            // 
            // SecretaryNoTextBox
            // 
            this.SecretaryNoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecretaryNoTextBox.Location = new System.Drawing.Point(140, 170);
            this.SecretaryNoTextBox.Name = "SecretaryNoTextBox";
            this.SecretaryNoTextBox.Size = new System.Drawing.Size(240, 29);
            this.SecretaryNoTextBox.TabIndex = 1;
            this.SecretaryNoTextBox.TabStop = false;
            this.SecretaryNoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReceiverStuNoTextBox_KeyDown);
            // 
            // VerifyUserInputButton
            // 
            this.VerifyUserInputButton.Location = new System.Drawing.Point(192, 217);
            this.VerifyUserInputButton.Name = "VerifyUserInputButton";
            this.VerifyUserInputButton.Size = new System.Drawing.Size(137, 39);
            this.VerifyUserInputButton.TabIndex = 2;
            this.VerifyUserInputButton.Text = "Enter";
            this.VerifyUserInputButton.UseVisualStyleBackColor = true;
            this.VerifyUserInputButton.Click += new System.EventHandler(this.VerifyUserEmailButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Setup Details";
            // 
            // SharedAppPwdTextBox
            // 
            this.SharedAppPwdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SharedAppPwdTextBox.Location = new System.Drawing.Point(140, 120);
            this.SharedAppPwdTextBox.Name = "SharedAppPwdTextBox";
            this.SharedAppPwdTextBox.Size = new System.Drawing.Size(240, 29);
            this.SharedAppPwdTextBox.TabIndex = 4;
            this.SharedAppPwdTextBox.TabStop = false;
            this.SharedAppPwdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharedAppPwdTextBox_KeyDown);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 268);
            this.Controls.Add(this.SharedAppPwdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerifyUserInputButton);
            this.Controls.Add(this.SecretaryNoTextBox);
            this.Controls.Add(this.GmailTextBox);
            this.Name = "Setup";
            this.Text = "Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GmailTextBox;
        private System.Windows.Forms.TextBox SecretaryNoTextBox;
        private System.Windows.Forms.Button VerifyUserInputButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SharedAppPwdTextBox;
    }
}