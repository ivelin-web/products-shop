namespace App
{
    partial class ProductItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtOwner = new System.Windows.Forms.Label();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(172)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 168);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtOwner
            // 
            this.txtOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOwner.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtOwner.Location = new System.Drawing.Point(97, 191);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(153, 25);
            this.txtOwner.TabIndex = 1;
            this.txtOwner.Text = "[Owner Name]";
            this.txtOwner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ownerLabel
            // 
            this.ownerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ownerLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ownerLabel.Location = new System.Drawing.Point(18, 191);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(73, 25);
            this.ownerLabel.TabIndex = 1;
            this.ownerLabel.Text = "Owner:";
            this.ownerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProductName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtProductName.Location = new System.Drawing.Point(97, 227);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(153, 25);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.Text = "[Product Name]";
            this.txtProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productLabel
            // 
            this.productLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.productLabel.Location = new System.Drawing.Point(18, 227);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(73, 25);
            this.productLabel.TabIndex = 1;
            this.productLabel.Text = "Product:";
            this.productLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPrice.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPrice.Location = new System.Drawing.Point(97, 262);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(153, 25);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Text = "[Price Amount]";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priceLabel
            // 
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.priceLabel.Location = new System.Drawing.Point(18, 262);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(73, 25);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "Price:";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.ownerLabel);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.panel1);
            this.Name = "product";
            this.Size = new System.Drawing.Size(253, 314);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label txtOwner;
        private Label ownerLabel;
        private Label txtProductName;
        private Label productLabel;
        private Label txtPrice;
        private Label priceLabel;
    }
}
