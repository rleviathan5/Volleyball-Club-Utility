namespace Volleyball_Utility
{
    partial class Email
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
            this.SenderEmailTextBox = new System.Windows.Forms.TextBox();
            this.ReceiverStuNoTextBox = new System.Windows.Forms.TextBox();
            this.VerifyUserEmailButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SenderEmailTextBox
            // 
            this.SenderEmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderEmailTextBox.Location = new System.Drawing.Point(140, 80);
            this.SenderEmailTextBox.Name = "SenderEmailTextBox";
            this.SenderEmailTextBox.Size = new System.Drawing.Size(240, 29);
            this.SenderEmailTextBox.TabIndex = 0;
            this.SenderEmailTextBox.TabStop = false;
            this.SenderEmailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SenderEmailTextBox_KeyDown);
            // 
            // ReceiverStuNoTextBox
            // 
            this.ReceiverStuNoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverStuNoTextBox.Location = new System.Drawing.Point(140, 132);
            this.ReceiverStuNoTextBox.Name = "ReceiverStuNoTextBox";
            this.ReceiverStuNoTextBox.Size = new System.Drawing.Size(240, 29);
            this.ReceiverStuNoTextBox.TabIndex = 1;
            this.ReceiverStuNoTextBox.TabStop = false;
            this.ReceiverStuNoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReceiverStuNoTextBox_KeyDown);
            // 
            // VerifyUserEmailButton
            // 
            this.VerifyUserEmailButton.Location = new System.Drawing.Point(193, 184);
            this.VerifyUserEmailButton.Name = "VerifyUserEmailButton";
            this.VerifyUserEmailButton.Size = new System.Drawing.Size(137, 39);
            this.VerifyUserEmailButton.TabIndex = 2;
            this.VerifyUserEmailButton.Text = "Enter";
            this.VerifyUserEmailButton.UseVisualStyleBackColor = true;
            this.VerifyUserEmailButton.Click += new System.EventHandler(this.VerifyUserEmailButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Your Details";
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerifyUserEmailButton);
            this.Controls.Add(this.ReceiverStuNoTextBox);
            this.Controls.Add(this.SenderEmailTextBox);
            this.Name = "Email";
            this.Text = "Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SenderEmailTextBox;
        private System.Windows.Forms.TextBox ReceiverStuNoTextBox;
        private System.Windows.Forms.Button VerifyUserEmailButton;
        private System.Windows.Forms.Label label1;
    }
}