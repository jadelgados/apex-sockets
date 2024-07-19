namespace DeviceSimulator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtIpAddress = new TextBox();
            txtPort = new TextBox();
            txtProductDescription = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            cboProductType = new ComboBox();
            lblStatus = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(72, 19);
            label1.TabIndex = 0;
            label1.Text = "IP address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 59);
            label2.Name = "label2";
            label2.Size = new Size(34, 19);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // txtIpAddress
            // 
            txtIpAddress.Location = new Point(86, 22);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.Size = new Size(145, 25);
            txtIpAddress.TabIndex = 2;
            txtIpAddress.Text = "127.0.0.1";
            txtIpAddress.TextChanged += txtIpAddress_TextChanged;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(86, 54);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(72, 25);
            txtPort.TabIndex = 3;
            txtPort.Text = "11000";
            // 
            // txtProductDescription
            // 
            txtProductDescription.Location = new Point(365, 59);
            txtProductDescription.Name = "txtProductDescription";
            txtProductDescription.Size = new Size(130, 25);
            txtProductDescription.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 59);
            label3.Name = "label3";
            label3.Size = new Size(78, 19);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(274, 26);
            label4.Name = "label4";
            label4.Size = new Size(88, 19);
            label4.TabIndex = 4;
            label4.Text = "Product type";
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.LightSteelBlue;
            button1.Location = new Point(420, 92);
            button1.Name = "button1";
            button1.Size = new Size(75, 26);
            button1.TabIndex = 8;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cboProductType
            // 
            cboProductType.AutoCompleteCustomSource.AddRange(new string[] { "Liquid base", "Industrial color" });
            cboProductType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboProductType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProductType.FormattingEnabled = true;
            cboProductType.Items.AddRange(new object[] { "Pintura", "Sellador" });
            cboProductType.Location = new Point(365, 22);
            cboProductType.Name = "cboProductType";
            cboProductType.Size = new Size(130, 25);
            cboProductType.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(0, 192, 0);
            lblStatus.ForeColor = SystemColors.ButtonHighlight;
            lblStatus.Location = new Point(160, 56);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 26);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Connected";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(517, 145);
            Controls.Add(lblStatus);
            Controls.Add(cboProductType);
            Controls.Add(button1);
            Controls.Add(txtProductDescription);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtPort);
            Controls.Add(txtIpAddress);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            Text = "Device simulator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIpAddress;
        private TextBox txtPort;
        private TextBox txtProductDescription;
        private Label label3;
        private Label label4;
        private Button button1;
        private ComboBox cboProductType;
        private Label lblStatus;
        private ErrorProvider errorProvider1;
    }
}
