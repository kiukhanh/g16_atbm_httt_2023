namespace Phanhe1
{
    partial class Form_thao_tac
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
            this.dvg_user_thaotac = new System.Windows.Forms.DataGridView();
            this.dvg_role_thao_tac = new System.Windows.Forms.DataGridView();
            this.Title_1 = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox1_Password = new System.Windows.Forms.TextBox();
            this.button_CreateUser = new System.Windows.Forms.Button();
            this.button_CreateRole = new System.Windows.Forms.Button();
            this.button_DeleteUser = new System.Windows.Forms.Button();
            this.button_DeleteRole = new System.Windows.Forms.Button();
            this.button_ThayPassword = new System.Windows.Forms.Button();
            this.button_ThayPasswordRole = new System.Windows.Forms.Button();
            this.label_Role = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_user_thaotac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_role_thao_tac)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_user_thaotac
            // 
            this.dvg_user_thaotac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_user_thaotac.Location = new System.Drawing.Point(41, 51);
            this.dvg_user_thaotac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dvg_user_thaotac.Name = "dvg_user_thaotac";
            this.dvg_user_thaotac.RowHeadersWidth = 51;
            this.dvg_user_thaotac.RowTemplate.Height = 24;
            this.dvg_user_thaotac.Size = new System.Drawing.Size(484, 226);
            this.dvg_user_thaotac.TabIndex = 9;
            // 
            // dvg_role_thao_tac
            // 
            this.dvg_role_thao_tac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_role_thao_tac.Location = new System.Drawing.Point(41, 332);
            this.dvg_role_thao_tac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dvg_role_thao_tac.Name = "dvg_role_thao_tac";
            this.dvg_role_thao_tac.RowHeadersWidth = 51;
            this.dvg_role_thao_tac.RowTemplate.Height = 24;
            this.dvg_role_thao_tac.Size = new System.Drawing.Size(484, 292);
            this.dvg_role_thao_tac.TabIndex = 16;
            // 
            // Title_1
            // 
            this.Title_1.AutoSize = true;
            this.Title_1.BackColor = System.Drawing.Color.Transparent;
            this.Title_1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_1.Location = new System.Drawing.Point(559, 51);
            this.Title_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title_1.Name = "Title_1";
            this.Title_1.Size = new System.Drawing.Size(234, 41);
            this.Title_1.TabIndex = 17;
            this.Title_1.Text = "CÁC THAO TÁC";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.BackColor = System.Drawing.Color.Transparent;
            this.label_UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserName.Location = new System.Drawing.Point(556, 101);
            this.label_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(56, 21);
            this.label_UserName.TabIndex = 18;
            this.label_UserName.Text = "Name";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserName.Location = new System.Drawing.Point(560, 125);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_UserName.MaxLength = 50;
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(232, 26);
            this.textBox_UserName.TabIndex = 19;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.BackColor = System.Drawing.Color.Transparent;
            this.label_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(556, 167);
            this.label_password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(82, 21);
            this.label_password.TabIndex = 20;
            this.label_password.Text = "Password";
            // 
            // textBox1_Password
            // 
            this.textBox1_Password.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1_Password.Location = new System.Drawing.Point(559, 192);
            this.textBox1_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1_Password.MaxLength = 16;
            this.textBox1_Password.Name = "textBox1_Password";
            this.textBox1_Password.Size = new System.Drawing.Size(232, 26);
            this.textBox1_Password.TabIndex = 21;
            this.textBox1_Password.UseSystemPasswordChar = true;
            // 
            // button_CreateUser
            // 
            this.button_CreateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_CreateUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CreateUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_CreateUser.Location = new System.Drawing.Point(566, 332);
            this.button_CreateUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_CreateUser.Name = "button_CreateUser";
            this.button_CreateUser.Size = new System.Drawing.Size(88, 41);
            this.button_CreateUser.TabIndex = 22;
            this.button_CreateUser.Text = "Tạo User";
            this.button_CreateUser.UseVisualStyleBackColor = false;
            this.button_CreateUser.Click += new System.EventHandler(this.button_CreateUser_Click);
            // 
            // button_CreateRole
            // 
            this.button_CreateRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_CreateRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CreateRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_CreateRole.Location = new System.Drawing.Point(685, 332);
            this.button_CreateRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_CreateRole.Name = "button_CreateRole";
            this.button_CreateRole.Size = new System.Drawing.Size(88, 41);
            this.button_CreateRole.TabIndex = 23;
            this.button_CreateRole.Text = "Tạo Role";
            this.button_CreateRole.UseVisualStyleBackColor = false;
            this.button_CreateRole.Click += new System.EventHandler(this.button_CreateRole_Click_1);
            // 
            // button_DeleteUser
            // 
            this.button_DeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_DeleteUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_DeleteUser.Location = new System.Drawing.Point(566, 392);
            this.button_DeleteUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_DeleteUser.Name = "button_DeleteUser";
            this.button_DeleteUser.Size = new System.Drawing.Size(88, 37);
            this.button_DeleteUser.TabIndex = 24;
            this.button_DeleteUser.Text = "Xóa User";
            this.button_DeleteUser.UseVisualStyleBackColor = false;
            this.button_DeleteUser.Click += new System.EventHandler(this.button_DeleteUser_Click_1);
            // 
            // button_DeleteRole
            // 
            this.button_DeleteRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_DeleteRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_DeleteRole.Location = new System.Drawing.Point(685, 392);
            this.button_DeleteRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_DeleteRole.Name = "button_DeleteRole";
            this.button_DeleteRole.Size = new System.Drawing.Size(88, 37);
            this.button_DeleteRole.TabIndex = 25;
            this.button_DeleteRole.Text = "Xóa Role";
            this.button_DeleteRole.UseVisualStyleBackColor = false;
            this.button_DeleteRole.Click += new System.EventHandler(this.button_DeleteRole_Click);
            // 
            // button_ThayPassword
            // 
            this.button_ThayPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_ThayPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ThayPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ThayPassword.Location = new System.Drawing.Point(566, 462);
            this.button_ThayPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_ThayPassword.Name = "button_ThayPassword";
            this.button_ThayPassword.Size = new System.Drawing.Size(88, 88);
            this.button_ThayPassword.TabIndex = 26;
            this.button_ThayPassword.Text = "Đổi Password User";
            this.button_ThayPassword.UseVisualStyleBackColor = false;
            this.button_ThayPassword.Click += new System.EventHandler(this.button_ThayPassword_Click);
            // 
            // button_ThayPasswordRole
            // 
            this.button_ThayPasswordRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(95)))), ((int)(((byte)(87)))));
            this.button_ThayPasswordRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ThayPasswordRole.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ThayPasswordRole.Location = new System.Drawing.Point(685, 462);
            this.button_ThayPasswordRole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_ThayPasswordRole.Name = "button_ThayPasswordRole";
            this.button_ThayPasswordRole.Size = new System.Drawing.Size(88, 88);
            this.button_ThayPasswordRole.TabIndex = 27;
            this.button_ThayPasswordRole.Text = "Đổi Password Role";
            this.button_ThayPasswordRole.UseVisualStyleBackColor = false;
            this.button_ThayPasswordRole.Click += new System.EventHandler(this.button_ThayPasswordRole_Click_1);
            // 
            // label_Role
            // 
            this.label_Role.AutoSize = true;
            this.label_Role.BackColor = System.Drawing.Color.White;
            this.label_Role.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Role.ForeColor = System.Drawing.Color.Black;
            this.label_Role.Location = new System.Drawing.Point(210, 291);
            this.label_Role.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(167, 29);
            this.label_Role.TabIndex = 28;
            this.label_Role.Text = "Danh sách Role";
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.BackColor = System.Drawing.Color.White;
            this.label_User.CausesValidation = false;
            this.label_User.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_User.ForeColor = System.Drawing.Color.Black;
            this.label_User.Location = new System.Drawing.Point(191, 7);
            this.label_User.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(169, 29);
            this.label_User.TabIndex = 29;
            this.label_User.Text = "Danh sách User";
            // 
            // Form_thao_tac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phanhe1.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(799, 640);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.label_Role);
            this.Controls.Add(this.button_ThayPasswordRole);
            this.Controls.Add(this.button_ThayPassword);
            this.Controls.Add(this.button_DeleteRole);
            this.Controls.Add(this.button_DeleteUser);
            this.Controls.Add(this.button_CreateRole);
            this.Controls.Add(this.button_CreateUser);
            this.Controls.Add(this.textBox1_Password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.Title_1);
            this.Controls.Add(this.dvg_role_thao_tac);
            this.Controls.Add(this.dvg_user_thaotac);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_thao_tac";
            this.Text = "Form_thao_tac";
            this.Load += new System.EventHandler(this.Form_thao_tac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_user_thaotac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_role_thao_tac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_user_thaotac;
        private System.Windows.Forms.DataGridView dvg_role_thao_tac;
        private System.Windows.Forms.Label Title_1;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox1_Password;
        private System.Windows.Forms.Button button_CreateUser;
        private System.Windows.Forms.Button button_CreateRole;
        private System.Windows.Forms.Button button_DeleteUser;
        private System.Windows.Forms.Button button_DeleteRole;
        private System.Windows.Forms.Button button_ThayPassword;
        private System.Windows.Forms.Button button_ThayPasswordRole;
        private System.Windows.Forms.Label label_Role;
        private System.Windows.Forms.Label label_User;
    }
}