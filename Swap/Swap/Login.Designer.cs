
namespace Swap
{
    partial class Login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginRightPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.SwapLogoLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.PassTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.NameTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.LoginImageButton = new Bunifu.Framework.UI.BunifuTileButton();
            this.RegisterButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.UserTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginRightPanel
            // 
            this.LoginRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginRightPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginRightPanel.BackgroundImage")));
            this.LoginRightPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginRightPanel.Controls.Add(this.SwapLogoLabel);
            this.LoginRightPanel.Controls.Add(this.pictureBox2);
            this.LoginRightPanel.Controls.Add(this.pictureBox1);
            this.LoginRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.LoginRightPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginRightPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginRightPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginRightPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginRightPanel.Location = new System.Drawing.Point(358, 0);
            this.LoginRightPanel.Margin = new System.Windows.Forms.Padding(2);
            this.LoginRightPanel.Name = "LoginRightPanel";
            this.LoginRightPanel.Quality = 10;
            this.LoginRightPanel.Size = new System.Drawing.Size(214, 441);
            this.LoginRightPanel.TabIndex = 0;
            // 
            // SwapLogoLabel
            // 
            this.SwapLogoLabel.AutoSize = true;
            this.SwapLogoLabel.BackColor = System.Drawing.Color.Transparent;
            this.SwapLogoLabel.Font = new System.Drawing.Font("Lato", 10F);
            this.SwapLogoLabel.ForeColor = System.Drawing.Color.White;
            this.SwapLogoLabel.Location = new System.Drawing.Point(46, 205);
            this.SwapLogoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SwapLogoLabel.Name = "SwapLogoLabel";
            this.SwapLogoLabel.Size = new System.Drawing.Size(134, 34);
            this.SwapLogoLabel.TabIndex = 11;
            this.SwapLogoLabel.Text = "Modern dünyada\r\ntarıma dair alışveriş...";
            this.SwapLogoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-38, 272);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 233);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.ActiveBorderThickness = 1;
            this.LoginButton.ActiveCornerRadius = 20;
            this.LoginButton.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.LoginButton.ActiveForecolor = System.Drawing.Color.White;
            this.LoginButton.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.LoginButton.BackColor = System.Drawing.Color.White;
            this.LoginButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginButton.BackgroundImage")));
            this.LoginButton.ButtonText = "Giriş Yap";
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Font = new System.Drawing.Font("Lato", 10F);
            this.LoginButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.LoginButton.IdleBorderThickness = 1;
            this.LoginButton.IdleCornerRadius = 20;
            this.LoginButton.IdleFillColor = System.Drawing.Color.White;
            this.LoginButton.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginButton.Location = new System.Drawing.Point(116, 240);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(113, 39);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PassTextBox
            // 
            this.PassTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassTextBox.Font = new System.Drawing.Font("Lato", 10F);
            this.PassTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.PassTextBox.HintForeColor = System.Drawing.Color.DarkGray;
            this.PassTextBox.HintText = "Sifre";
            this.PassTextBox.isPassword = false;
            this.PassTextBox.LineFocusedColor = System.Drawing.Color.Green;
            this.PassTextBox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.PassTextBox.LineMouseHoverColor = System.Drawing.Color.Green;
            this.PassTextBox.LineThickness = 3;
            this.PassTextBox.Location = new System.Drawing.Point(102, 148);
            this.PassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(148, 27);
            this.PassTextBox.TabIndex = 3;
            this.PassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NameTextBox.Font = new System.Drawing.Font("Lato", 10F);
            this.NameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.NameTextBox.HintForeColor = System.Drawing.Color.Gray;
            this.NameTextBox.HintText = "Kullanıcı Adı";
            this.NameTextBox.isPassword = false;
            this.NameTextBox.LineFocusedColor = System.Drawing.Color.Green;
            this.NameTextBox.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.NameTextBox.LineMouseHoverColor = System.Drawing.Color.Green;
            this.NameTextBox.LineThickness = 3;
            this.NameTextBox.Location = new System.Drawing.Point(102, 115);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(148, 27);
            this.NameTextBox.TabIndex = 4;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // LoginImageButton
            // 
            this.LoginImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginImageButton.color = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginImageButton.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginImageButton.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.LoginImageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.LoginImageButton.Image = ((System.Drawing.Image)(resources.GetObject("LoginImageButton.Image")));
            this.LoginImageButton.ImagePosition = 15;
            this.LoginImageButton.ImageZoom = 70;
            this.LoginImageButton.LabelPosition = 0;
            this.LoginImageButton.LabelText = "";
            this.LoginImageButton.Location = new System.Drawing.Point(132, 14);
            this.LoginImageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginImageButton.Name = "LoginImageButton";
            this.LoginImageButton.Size = new System.Drawing.Size(87, 82);
            this.LoginImageButton.TabIndex = 8;
            // 
            // RegisterButton
            // 
            this.RegisterButton.ActiveBorderThickness = 1;
            this.RegisterButton.ActiveCornerRadius = 20;
            this.RegisterButton.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.RegisterButton.ActiveForecolor = System.Drawing.Color.White;
            this.RegisterButton.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.RegisterButton.BackColor = System.Drawing.Color.White;
            this.RegisterButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegisterButton.BackgroundImage")));
            this.RegisterButton.ButtonText = "Kayıt Ol";
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.Font = new System.Drawing.Font("Lato", 10F);
            this.RegisterButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.RegisterButton.IdleBorderThickness = 1;
            this.RegisterButton.IdleCornerRadius = 20;
            this.RegisterButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.RegisterButton.IdleForecolor = System.Drawing.Color.White;
            this.RegisterButton.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(82)))));
            this.RegisterButton.Location = new System.Drawing.Point(116, 278);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(113, 40);
            this.RegisterButton.TabIndex = 9;
            this.RegisterButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Lato", 10F);
            this.RegisterLabel.Location = new System.Drawing.Point(93, 331);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(165, 51);
            this.RegisterLabel.TabIndex = 10;
            this.RegisterLabel.Text = "Hesabın yok mu?\r\nHadi birlikte oluşturalım.\r\n\"Kayıt Ol\" butonuna tıkla!";
            this.RegisterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserTypeComboBox
            // 
            this.UserTypeComboBox.FormattingEnabled = true;
            this.UserTypeComboBox.Items.AddRange(new object[] {
            "Admin",
            "Kullanici"});
            this.UserTypeComboBox.Location = new System.Drawing.Point(102, 204);
            this.UserTypeComboBox.Name = "UserTypeComboBox";
            this.UserTypeComboBox.Size = new System.Drawing.Size(148, 21);
            this.UserTypeComboBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kullanıcı  Tipi:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserTypeComboBox);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginImageButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.LoginRightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.LoginRightPanel.ResumeLayout(false);
            this.LoginRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel LoginRightPanel;
        private Bunifu.Framework.UI.BunifuThinButton2 LoginButton;
        private Bunifu.Framework.UI.BunifuMaterialTextbox PassTextBox;
        private Bunifu.Framework.UI.BunifuMaterialTextbox NameTextBox;
        private Bunifu.Framework.UI.BunifuTileButton LoginImageButton;
        private Bunifu.Framework.UI.BunifuThinButton2 RegisterButton;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SwapLogoLabel;
        private System.Windows.Forms.ComboBox UserTypeComboBox;
        private System.Windows.Forms.Label label1;
    }
}

