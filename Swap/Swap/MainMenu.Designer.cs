
namespace Swap
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.MenuPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.AccountButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SellButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.BuyButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.FinanceButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuPanel.BackgroundImage")));
            this.MenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MenuPanel.Controls.Add(this.pictureBox2);
            this.MenuPanel.Controls.Add(this.FinanceButton);
            this.MenuPanel.Controls.Add(this.MoneyLabel);
            this.MenuPanel.Controls.Add(this.BuyButton);
            this.MenuPanel.Controls.Add(this.SellButton);
            this.MenuPanel.Controls.Add(this.pictureBox1);
            this.MenuPanel.Controls.Add(this.AccountButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.MenuPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.MenuPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.MenuPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Quality = 10;
            this.MenuPanel.Size = new System.Drawing.Size(269, 554);
            this.MenuPanel.TabIndex = 0;
            // 
            // AccountButton
            // 
            this.AccountButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.AccountButton.BackColor = System.Drawing.Color.Transparent;
            this.AccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AccountButton.BorderRadius = 0;
            this.AccountButton.ButtonText = "Hesap";
            this.AccountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccountButton.DisabledColor = System.Drawing.Color.Gray;
            this.AccountButton.ForeColor = System.Drawing.Color.White;
            this.AccountButton.Iconcolor = System.Drawing.Color.Transparent;
            this.AccountButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("AccountButton.Iconimage")));
            this.AccountButton.Iconimage_right = null;
            this.AccountButton.Iconimage_right_Selected = null;
            this.AccountButton.Iconimage_Selected = null;
            this.AccountButton.IconMarginLeft = 15;
            this.AccountButton.IconMarginRight = 0;
            this.AccountButton.IconRightVisible = false;
            this.AccountButton.IconRightZoom = 0D;
            this.AccountButton.IconVisible = false;
            this.AccountButton.IconZoom = 90D;
            this.AccountButton.IsTab = false;
            this.AccountButton.Location = new System.Drawing.Point(16, 163);
            this.AccountButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Normalcolor = System.Drawing.Color.Transparent;
            this.AccountButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.AccountButton.OnHoverTextColor = System.Drawing.Color.White;
            this.AccountButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AccountButton.selected = false;
            this.AccountButton.Size = new System.Drawing.Size(220, 44);
            this.AccountButton.TabIndex = 1;
            this.AccountButton.Text = "Hesap";
            this.AccountButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AccountButton.Textcolor = System.Drawing.Color.White;
            this.AccountButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SellButton
            // 
            this.SellButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SellButton.BackColor = System.Drawing.Color.Transparent;
            this.SellButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SellButton.BorderRadius = 0;
            this.SellButton.ButtonText = "Ürün Sat";
            this.SellButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SellButton.DisabledColor = System.Drawing.Color.Gray;
            this.SellButton.ForeColor = System.Drawing.Color.White;
            this.SellButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SellButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("SellButton.Iconimage")));
            this.SellButton.Iconimage_right = null;
            this.SellButton.Iconimage_right_Selected = null;
            this.SellButton.Iconimage_Selected = null;
            this.SellButton.IconMarginLeft = 0;
            this.SellButton.IconMarginRight = 0;
            this.SellButton.IconRightVisible = true;
            this.SellButton.IconRightZoom = 0D;
            this.SellButton.IconVisible = false;
            this.SellButton.IconZoom = 90D;
            this.SellButton.IsTab = false;
            this.SellButton.Location = new System.Drawing.Point(16, 267);
            this.SellButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SellButton.Name = "SellButton";
            this.SellButton.Normalcolor = System.Drawing.Color.Transparent;
            this.SellButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.SellButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SellButton.selected = false;
            this.SellButton.Size = new System.Drawing.Size(220, 44);
            this.SellButton.TabIndex = 2;
            this.SellButton.Text = "Ürün Sat";
            this.SellButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SellButton.Textcolor = System.Drawing.Color.White;
            this.SellButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // BuyButton
            // 
            this.BuyButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BuyButton.BackColor = System.Drawing.Color.Transparent;
            this.BuyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BuyButton.BorderRadius = 0;
            this.BuyButton.ButtonText = "Ürün Satın Al";
            this.BuyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuyButton.DisabledColor = System.Drawing.Color.Gray;
            this.BuyButton.ForeColor = System.Drawing.Color.White;
            this.BuyButton.Iconcolor = System.Drawing.Color.Transparent;
            this.BuyButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("BuyButton.Iconimage")));
            this.BuyButton.Iconimage_right = null;
            this.BuyButton.Iconimage_right_Selected = null;
            this.BuyButton.Iconimage_Selected = null;
            this.BuyButton.IconMarginLeft = 0;
            this.BuyButton.IconMarginRight = 0;
            this.BuyButton.IconRightVisible = true;
            this.BuyButton.IconRightZoom = 0D;
            this.BuyButton.IconVisible = false;
            this.BuyButton.IconZoom = 90D;
            this.BuyButton.IsTab = false;
            this.BuyButton.Location = new System.Drawing.Point(16, 319);
            this.BuyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Normalcolor = System.Drawing.Color.Transparent;
            this.BuyButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.BuyButton.OnHoverTextColor = System.Drawing.Color.White;
            this.BuyButton.selected = false;
            this.BuyButton.Size = new System.Drawing.Size(220, 44);
            this.BuyButton.TabIndex = 3;
            this.BuyButton.Text = "Ürün Satın Al";
            this.BuyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuyButton.Textcolor = System.Drawing.Color.White;
            this.BuyButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MoneyLabel.ForeColor = System.Drawing.Color.White;
            this.MoneyLabel.Location = new System.Drawing.Point(12, 120);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(224, 20);
            this.MoneyLabel.TabIndex = 1;
            this.MoneyLabel.Text = "Bakiye: Henüz Onaylanmadı.";
            // 
            // FinanceButton
            // 
            this.FinanceButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.FinanceButton.BackColor = System.Drawing.Color.Transparent;
            this.FinanceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FinanceButton.BorderRadius = 0;
            this.FinanceButton.ButtonText = "Borsa Durumu";
            this.FinanceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinanceButton.DisabledColor = System.Drawing.Color.Gray;
            this.FinanceButton.ForeColor = System.Drawing.Color.White;
            this.FinanceButton.Iconcolor = System.Drawing.Color.Transparent;
            this.FinanceButton.Iconimage = ((System.Drawing.Image)(resources.GetObject("FinanceButton.Iconimage")));
            this.FinanceButton.Iconimage_right = null;
            this.FinanceButton.Iconimage_right_Selected = null;
            this.FinanceButton.Iconimage_Selected = null;
            this.FinanceButton.IconMarginLeft = 0;
            this.FinanceButton.IconMarginRight = 0;
            this.FinanceButton.IconRightVisible = true;
            this.FinanceButton.IconRightZoom = 0D;
            this.FinanceButton.IconVisible = false;
            this.FinanceButton.IconZoom = 90D;
            this.FinanceButton.IsTab = false;
            this.FinanceButton.Location = new System.Drawing.Point(16, 215);
            this.FinanceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FinanceButton.Name = "FinanceButton";
            this.FinanceButton.Normalcolor = System.Drawing.Color.Transparent;
            this.FinanceButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.FinanceButton.OnHoverTextColor = System.Drawing.Color.White;
            this.FinanceButton.selected = false;
            this.FinanceButton.Size = new System.Drawing.Size(220, 44);
            this.FinanceButton.TabIndex = 4;
            this.FinanceButton.Text = "Borsa Durumu";
            this.FinanceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FinanceButton.Textcolor = System.Drawing.Color.White;
            this.FinanceButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-16, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(306, 311);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 554);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel MenuPanel;
        private Bunifu.Framework.UI.BunifuFlatButton AccountButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton BuyButton;
        private Bunifu.Framework.UI.BunifuFlatButton SellButton;
        private System.Windows.Forms.Label MoneyLabel;
        private Bunifu.Framework.UI.BunifuFlatButton FinanceButton;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}