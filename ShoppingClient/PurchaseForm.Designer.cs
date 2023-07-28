﻿
namespace ShoppingClient
{
    partial class PurchaseForm
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
            this.components = new System.ComponentModel.Container();
            this.ProductCombobox = new System.Windows.Forms.ComboBox();
            this.PurchaseBttn = new System.Windows.Forms.Button();
            this.Refreshbttn = new System.Windows.Forms.Button();
            this.CustomerPurchaseTxtBox = new System.Windows.Forms.TextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.welcomelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProductCombobox
            // 
            this.ProductCombobox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ProductCombobox.FormattingEnabled = true;
            this.ProductCombobox.Location = new System.Drawing.Point(218, 83);
            this.ProductCombobox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProductCombobox.Name = "ProductCombobox";
            this.ProductCombobox.Size = new System.Drawing.Size(263, 24);
            this.ProductCombobox.TabIndex = 0;
            this.ProductCombobox.Text = "Products";
            // 
            // PurchaseBttn
            // 
            this.PurchaseBttn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PurchaseBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchaseBttn.Location = new System.Drawing.Point(396, 439);
            this.PurchaseBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PurchaseBttn.Name = "PurchaseBttn";
            this.PurchaseBttn.Size = new System.Drawing.Size(100, 73);
            this.PurchaseBttn.TabIndex = 1;
            this.PurchaseBttn.Text = "Purchase";
            this.PurchaseBttn.UseVisualStyleBackColor = false;
            this.PurchaseBttn.Click += new System.EventHandler(this.PurchaseBttn_Click);
            // 
            // Refreshbttn
            // 
            this.Refreshbttn.BackColor = System.Drawing.Color.Orange;
            this.Refreshbttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refreshbttn.Location = new System.Drawing.Point(161, 439);
            this.Refreshbttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Refreshbttn.Name = "Refreshbttn";
            this.Refreshbttn.Size = new System.Drawing.Size(124, 73);
            this.Refreshbttn.TabIndex = 2;
            this.Refreshbttn.Text = "Refresh";
            this.Refreshbttn.UseVisualStyleBackColor = false;
            this.Refreshbttn.Click += new System.EventHandler(this.Refreshbttn_Click);
            // 
            // CustomerPurchaseTxtBox
            // 
            this.CustomerPurchaseTxtBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CustomerPurchaseTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerPurchaseTxtBox.Location = new System.Drawing.Point(143, 143);
            this.CustomerPurchaseTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CustomerPurchaseTxtBox.Multiline = true;
            this.CustomerPurchaseTxtBox.Name = "CustomerPurchaseTxtBox";
            this.CustomerPurchaseTxtBox.Size = new System.Drawing.Size(391, 248);
            this.CustomerPurchaseTxtBox.TabIndex = 3;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 20;
            // 
            // welcomelbl
            // 
            this.welcomelbl.AutoSize = true;
            this.welcomelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomelbl.Location = new System.Drawing.Point(318, 9);
            this.welcomelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomelbl.Name = "welcomelbl";
            this.welcomelbl.Size = new System.Drawing.Size(122, 29);
            this.welcomelbl.TabIndex = 4;
            this.welcomelbl.Text = "Welcome";
            this.welcomelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(755, 589);
            this.Controls.Add(this.welcomelbl);
            this.Controls.Add(this.CustomerPurchaseTxtBox);
            this.Controls.Add(this.Refreshbttn);
            this.Controls.Add(this.PurchaseBttn);
            this.Controls.Add(this.ProductCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchaseForm_FormClosed);
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProductCombobox;
        private System.Windows.Forms.Button PurchaseBttn;
        private System.Windows.Forms.Button Refreshbttn;
        private System.Windows.Forms.TextBox CustomerPurchaseTxtBox;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label welcomelbl;
    }
}