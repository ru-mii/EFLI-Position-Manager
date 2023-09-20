﻿
namespace EFLI_Position_Manager
{
    partial class Main
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
            this.label_HotkeyLoadPlayerPosition = new System.Windows.Forms.Label();
            this.label_HotkeySavePlayerPosition = new System.Windows.Forms.Label();
            this.button_Hotkeys = new System.Windows.Forms.Button();
            this.button_LoadPlayerPosition = new System.Windows.Forms.Button();
            this.button_SavePlayerPosition = new System.Windows.Forms.Button();
            this.textBox_PlayerPositionZ = new System.Windows.Forms.TextBox();
            this.textBox_PlayerPositionY = new System.Windows.Forms.TextBox();
            this.textBox_PlayerPositionX = new System.Windows.Forms.TextBox();
            this.backgroundWorker_CheckProcess = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.selector = new System.Windows.Forms.Label();
            this.backgroundWorker_PatchUpdate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label_HotkeyLoadPlayerPosition
            // 
            this.label_HotkeyLoadPlayerPosition.Location = new System.Drawing.Point(118, 9);
            this.label_HotkeyLoadPlayerPosition.Name = "label_HotkeyLoadPlayerPosition";
            this.label_HotkeyLoadPlayerPosition.Size = new System.Drawing.Size(100, 19);
            this.label_HotkeyLoadPlayerPosition.TabIndex = 17;
            this.label_HotkeyLoadPlayerPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_HotkeySavePlayerPosition
            // 
            this.label_HotkeySavePlayerPosition.Location = new System.Drawing.Point(12, 9);
            this.label_HotkeySavePlayerPosition.Name = "label_HotkeySavePlayerPosition";
            this.label_HotkeySavePlayerPosition.Size = new System.Drawing.Size(100, 19);
            this.label_HotkeySavePlayerPosition.TabIndex = 16;
            this.label_HotkeySavePlayerPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Hotkeys
            // 
            this.button_Hotkeys.Location = new System.Drawing.Point(224, 29);
            this.button_Hotkeys.Name = "button_Hotkeys";
            this.button_Hotkeys.Size = new System.Drawing.Size(100, 23);
            this.button_Hotkeys.TabIndex = 15;
            this.button_Hotkeys.Text = "hotkeys";
            this.button_Hotkeys.UseVisualStyleBackColor = true;
            this.button_Hotkeys.Click += new System.EventHandler(this.button_Hotkeys_Click);
            // 
            // button_LoadPlayerPosition
            // 
            this.button_LoadPlayerPosition.Location = new System.Drawing.Point(118, 29);
            this.button_LoadPlayerPosition.Name = "button_LoadPlayerPosition";
            this.button_LoadPlayerPosition.Size = new System.Drawing.Size(100, 23);
            this.button_LoadPlayerPosition.TabIndex = 14;
            this.button_LoadPlayerPosition.Text = "load position";
            this.button_LoadPlayerPosition.UseVisualStyleBackColor = true;
            this.button_LoadPlayerPosition.Click += new System.EventHandler(this.button_LoadPlayerPosition_Click);
            // 
            // button_SavePlayerPosition
            // 
            this.button_SavePlayerPosition.Location = new System.Drawing.Point(12, 29);
            this.button_SavePlayerPosition.Name = "button_SavePlayerPosition";
            this.button_SavePlayerPosition.Size = new System.Drawing.Size(100, 23);
            this.button_SavePlayerPosition.TabIndex = 13;
            this.button_SavePlayerPosition.Text = "save position";
            this.button_SavePlayerPosition.UseVisualStyleBackColor = true;
            this.button_SavePlayerPosition.Click += new System.EventHandler(this.button_SavePlayerPosition_Click);
            // 
            // textBox_PlayerPositionZ
            // 
            this.textBox_PlayerPositionZ.Location = new System.Drawing.Point(224, 58);
            this.textBox_PlayerPositionZ.Name = "textBox_PlayerPositionZ";
            this.textBox_PlayerPositionZ.Size = new System.Drawing.Size(100, 20);
            this.textBox_PlayerPositionZ.TabIndex = 12;
            // 
            // textBox_PlayerPositionY
            // 
            this.textBox_PlayerPositionY.Location = new System.Drawing.Point(118, 58);
            this.textBox_PlayerPositionY.Name = "textBox_PlayerPositionY";
            this.textBox_PlayerPositionY.Size = new System.Drawing.Size(100, 20);
            this.textBox_PlayerPositionY.TabIndex = 11;
            // 
            // textBox_PlayerPositionX
            // 
            this.textBox_PlayerPositionX.Location = new System.Drawing.Point(12, 58);
            this.textBox_PlayerPositionX.Name = "textBox_PlayerPositionX";
            this.textBox_PlayerPositionX.Size = new System.Drawing.Size(100, 20);
            this.textBox_PlayerPositionX.TabIndex = 10;
            // 
            // backgroundWorker_CheckProcess
            // 
            this.backgroundWorker_CheckProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_CheckProcess_DoWork);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // selector
            // 
            this.selector.AutoSize = true;
            this.selector.Location = new System.Drawing.Point(32000, 32000);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(0, 13);
            this.selector.TabIndex = 18;
            // 
            // backgroundWorker_PatchUpdate
            // 
            this.backgroundWorker_PatchUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_PatchUpdate_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 87);
            this.Controls.Add(this.selector);
            this.Controls.Add(this.label_HotkeyLoadPlayerPosition);
            this.Controls.Add(this.label_HotkeySavePlayerPosition);
            this.Controls.Add(this.button_Hotkeys);
            this.Controls.Add(this.button_LoadPlayerPosition);
            this.Controls.Add(this.button_SavePlayerPosition);
            this.Controls.Add(this.textBox_PlayerPositionZ);
            this.Controls.Add(this.textBox_PlayerPositionY);
            this.Controls.Add(this.textBox_PlayerPositionX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "EFLI Position Manager";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_HotkeyLoadPlayerPosition;
        private System.Windows.Forms.Label label_HotkeySavePlayerPosition;
        private System.Windows.Forms.Button button_Hotkeys;
        private System.Windows.Forms.Button button_LoadPlayerPosition;
        private System.Windows.Forms.Button button_SavePlayerPosition;
        private System.Windows.Forms.TextBox textBox_PlayerPositionZ;
        private System.Windows.Forms.TextBox textBox_PlayerPositionY;
        private System.Windows.Forms.TextBox textBox_PlayerPositionX;
        private System.ComponentModel.BackgroundWorker backgroundWorker_CheckProcess;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label selector;
        private System.ComponentModel.BackgroundWorker backgroundWorker_PatchUpdate;
    }
}

