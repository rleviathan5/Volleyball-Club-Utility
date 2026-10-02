namespace Volleyball_Utility
{
    partial class SetupForm
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
            this.titleLabel = new System.Windows.Forms.Label();
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
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(140, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(240, 42);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Setup Details";
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
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 268);
            this.Controls.Add(this.SharedAppPwdTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.VerifyUserInputButton);
            this.Controls.Add(this.SecretaryNoTextBox);
            this.Controls.Add(this.GmailTextBox);
            this.Name = "SetupForm";
            this.Text = "Email";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.Resize += new System.EventHandler(this.SetupForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GmailTextBox;
        private System.Windows.Forms.TextBox SecretaryNoTextBox;
        private System.Windows.Forms.Button VerifyUserInputButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox SharedAppPwdTextBox;
    }
}