namespace ChangePasswordForm
{
    partial class ChangePwd_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePwd_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.input_newpwd = new System.Windows.Forms.TextBox();
            this.input_confirmpwd = new System.Windows.Forms.TextBox();
            this.input_usn = new System.Windows.Forms.TextBox();
            this.usn_txtbox = new System.Windows.Forms.RichTextBox();
            this.newpass_txtbox = new System.Windows.Forms.RichTextBox();
            this.curpass_txtbox = new System.Windows.Forms.RichTextBox();
            this.cfpass_txtbox = new System.Windows.Forms.RichTextBox();
            this.input_curpwd = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(129, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // input_newpwd
            // 
            this.input_newpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_newpwd.Location = new System.Drawing.Point(337, 454);
            this.input_newpwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.input_newpwd.Multiline = true;
            this.input_newpwd.Name = "input_newpwd";
            this.input_newpwd.Size = new System.Drawing.Size(205, 34);
            this.input_newpwd.TabIndex = 1;
            // 
            // input_confirmpwd
            // 
            this.input_confirmpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_confirmpwd.Location = new System.Drawing.Point(337, 523);
            this.input_confirmpwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.input_confirmpwd.Multiline = true;
            this.input_confirmpwd.Name = "input_confirmpwd";
            this.input_confirmpwd.Size = new System.Drawing.Size(205, 34);
            this.input_confirmpwd.TabIndex = 2;
            // 
            // input_usn
            // 
            this.input_usn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_usn.Location = new System.Drawing.Point(337, 321);
            this.input_usn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.input_usn.MaximumSize = new System.Drawing.Size(665, 245);
            this.input_usn.Multiline = true;
            this.input_usn.Name = "input_usn";
            this.input_usn.Size = new System.Drawing.Size(205, 34);
            this.input_usn.TabIndex = 3;
            // 
            // usn_txtbox
            // 
            this.usn_txtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(184)))));
            this.usn_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usn_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usn_txtbox.Location = new System.Drawing.Point(69, 321);
            this.usn_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usn_txtbox.Name = "usn_txtbox";
            this.usn_txtbox.ReadOnly = true;
            this.usn_txtbox.Size = new System.Drawing.Size(260, 34);
            this.usn_txtbox.TabIndex = 4;
            this.usn_txtbox.TabStop = false;
            this.usn_txtbox.Text = "Username";
            // 
            // newpass_txtbox
            // 
            this.newpass_txtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(184)))));
            this.newpass_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newpass_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpass_txtbox.Location = new System.Drawing.Point(69, 454);
            this.newpass_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newpass_txtbox.Name = "newpass_txtbox";
            this.newpass_txtbox.ReadOnly = true;
            this.newpass_txtbox.Size = new System.Drawing.Size(260, 43);
            this.newpass_txtbox.TabIndex = 5;
            this.newpass_txtbox.TabStop = false;
            this.newpass_txtbox.Text = "New Password";
            // 
            // curpass_txtbox
            // 
            this.curpass_txtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(184)))));
            this.curpass_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.curpass_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curpass_txtbox.Location = new System.Drawing.Point(69, 391);
            this.curpass_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.curpass_txtbox.Name = "curpass_txtbox";
            this.curpass_txtbox.ReadOnly = true;
            this.curpass_txtbox.Size = new System.Drawing.Size(260, 41);
            this.curpass_txtbox.TabIndex = 6;
            this.curpass_txtbox.TabStop = false;
            this.curpass_txtbox.Text = "Current Password";
            // 
            // cfpass_txtbox
            // 
            this.cfpass_txtbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(184)))));
            this.cfpass_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cfpass_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfpass_txtbox.Location = new System.Drawing.Point(69, 523);
            this.cfpass_txtbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cfpass_txtbox.Name = "cfpass_txtbox";
            this.cfpass_txtbox.ReadOnly = true;
            this.cfpass_txtbox.Size = new System.Drawing.Size(260, 42);
            this.cfpass_txtbox.TabIndex = 7;
            this.cfpass_txtbox.TabStop = false;
            this.cfpass_txtbox.Text = "Confirm Password";
            // 
            // input_curpwd
            // 
            this.input_curpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_curpwd.Location = new System.Drawing.Point(337, 391);
            this.input_curpwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.input_curpwd.Multiline = true;
            this.input_curpwd.Name = "input_curpwd";
            this.input_curpwd.Size = new System.Drawing.Size(205, 34);
            this.input_curpwd.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(233, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 185);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(257, 603);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 50);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePwd_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(214)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(645, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.input_curpwd);
            this.Controls.Add(this.cfpass_txtbox);
            this.Controls.Add(this.curpass_txtbox);
            this.Controls.Add(this.newpass_txtbox);
            this.Controls.Add(this.usn_txtbox);
            this.Controls.Add(this.input_usn);
            this.Controls.Add(this.input_confirmpwd);
            this.Controls.Add(this.input_newpwd);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChangePwd_Form";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_newpwd;
        private System.Windows.Forms.TextBox input_confirmpwd;
        private System.Windows.Forms.TextBox input_usn;
        private System.Windows.Forms.RichTextBox usn_txtbox;
        private System.Windows.Forms.RichTextBox newpass_txtbox;
        private System.Windows.Forms.RichTextBox curpass_txtbox;
        private System.Windows.Forms.RichTextBox cfpass_txtbox;
        private System.Windows.Forms.TextBox input_curpwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}

