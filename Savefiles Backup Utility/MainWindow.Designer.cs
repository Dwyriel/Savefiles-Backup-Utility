﻿
namespace Savefiles_Backup_Utility
{
    partial class MainWindow
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
            this.presetComboBox = new System.Windows.Forms.ComboBox();
            this.newPresetBtn = new System.Windows.Forms.Button();
            this.deletePresetBtn = new System.Windows.Forms.Button();
            this.presetLabel = new System.Windows.Forms.Label();
            this.backupFolderTxtBox = new System.Windows.Forms.TextBox();
            this.backupFolderLabel = new System.Windows.Forms.Label();
            this.backupFolderSearchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // presetComboBox
            // 
            this.presetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetComboBox.FormattingEnabled = true;
            this.presetComboBox.Location = new System.Drawing.Point(27, 32);
            this.presetComboBox.Name = "presetComboBox";
            this.presetComboBox.Size = new System.Drawing.Size(227, 26);
            this.presetComboBox.TabIndex = 0;
            this.presetComboBox.SelectedIndexChanged += new System.EventHandler(this.presetComboBox_SelectedIndexChanged);
            // 
            // newPresetBtn
            // 
            this.newPresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPresetBtn.Location = new System.Drawing.Point(260, 32);
            this.newPresetBtn.Name = "newPresetBtn";
            this.newPresetBtn.Size = new System.Drawing.Size(68, 26);
            this.newPresetBtn.TabIndex = 1;
            this.newPresetBtn.Text = "New";
            this.newPresetBtn.UseVisualStyleBackColor = true;
            this.newPresetBtn.Click += new System.EventHandler(this.newPresetBtn_Click);
            // 
            // deletePresetBtn
            // 
            this.deletePresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePresetBtn.Location = new System.Drawing.Point(334, 32);
            this.deletePresetBtn.Name = "deletePresetBtn";
            this.deletePresetBtn.Size = new System.Drawing.Size(68, 26);
            this.deletePresetBtn.TabIndex = 2;
            this.deletePresetBtn.Text = "Delete";
            this.deletePresetBtn.UseVisualStyleBackColor = true;
            this.deletePresetBtn.Click += new System.EventHandler(this.deletePresetBtn_Click);
            // 
            // presetLabel
            // 
            this.presetLabel.AutoSize = true;
            this.presetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetLabel.Location = new System.Drawing.Point(12, 9);
            this.presetLabel.Name = "presetLabel";
            this.presetLabel.Size = new System.Drawing.Size(59, 20);
            this.presetLabel.TabIndex = 600;
            this.presetLabel.Text = "Preset:";
            // 
            // backupFolderTxtBox
            // 
            this.backupFolderTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderTxtBox.Location = new System.Drawing.Point(27, 92);
            this.backupFolderTxtBox.Name = "backupFolderTxtBox";
            this.backupFolderTxtBox.Size = new System.Drawing.Size(301, 23);
            this.backupFolderTxtBox.TabIndex = 3;
            this.backupFolderTxtBox.Leave += new System.EventHandler(this.backupFolderTxtBox_Leave);
            // 
            // backupFolderLabel
            // 
            this.backupFolderLabel.AutoSize = true;
            this.backupFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderLabel.Location = new System.Drawing.Point(12, 69);
            this.backupFolderLabel.Name = "backupFolderLabel";
            this.backupFolderLabel.Size = new System.Drawing.Size(116, 20);
            this.backupFolderLabel.TabIndex = 601;
            this.backupFolderLabel.Text = "Backup Folder:";
            // 
            // backupFolderSearchBtn
            // 
            this.backupFolderSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderSearchBtn.Location = new System.Drawing.Point(334, 90);
            this.backupFolderSearchBtn.Name = "backupFolderSearchBtn";
            this.backupFolderSearchBtn.Size = new System.Drawing.Size(68, 27);
            this.backupFolderSearchBtn.TabIndex = 602;
            this.backupFolderSearchBtn.Text = "Search";
            this.backupFolderSearchBtn.UseVisualStyleBackColor = true;
            this.backupFolderSearchBtn.Click += new System.EventHandler(this.backupFolderSearchBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.backupFolderSearchBtn);
            this.Controls.Add(this.backupFolderLabel);
            this.Controls.Add(this.backupFolderTxtBox);
            this.Controls.Add(this.presetLabel);
            this.Controls.Add(this.deletePresetBtn);
            this.Controls.Add(this.newPresetBtn);
            this.Controls.Add(this.presetComboBox);
            this.Name = "MainWindow";
            this.Text = "Savefiles Backup Utility";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox presetComboBox;
        private System.Windows.Forms.Button newPresetBtn;
        private System.Windows.Forms.Button deletePresetBtn;
        private System.Windows.Forms.Label presetLabel;
        private System.Windows.Forms.TextBox backupFolderTxtBox;
        private System.Windows.Forms.Label backupFolderLabel;
        private System.Windows.Forms.Button backupFolderSearchBtn;
    }
}

