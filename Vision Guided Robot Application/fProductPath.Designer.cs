namespace Vision_Guided_Robot_Application
{
    partial class fProductPath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fProductPath));
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbOrient = new System.Windows.Forms.Label();
            this.cbbOrientation = new System.Windows.Forms.ComboBox();
            this.tbColor = new System.Windows.Forms.TextBox();
            this.cbbSize = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbCode = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.listboxSize = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbCode
            // 
            this.tbCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCode.Location = new System.Drawing.Point(0, 35);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(334, 26);
            this.tbCode.TabIndex = 4;
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbName.Location = new System.Drawing.Point(0, 61);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(334, 35);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "Name:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbName.Location = new System.Drawing.Point(0, 96);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(334, 26);
            this.tbName.TabIndex = 6;
            // 
            // lbOrient
            // 
            this.lbOrient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOrient.Location = new System.Drawing.Point(0, 122);
            this.lbOrient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrient.Name = "lbOrient";
            this.lbOrient.Size = new System.Drawing.Size(334, 35);
            this.lbOrient.TabIndex = 7;
            this.lbOrient.Text = "Orientation:";
            this.lbOrient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbOrientation
            // 
            this.cbbOrientation.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbOrientation.FormattingEnabled = true;
            this.cbbOrientation.Items.AddRange(new object[] {
            "L",
            "R",
            "N"});
            this.cbbOrientation.Location = new System.Drawing.Point(0, 157);
            this.cbbOrientation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbOrientation.Name = "cbbOrientation";
            this.cbbOrientation.Size = new System.Drawing.Size(334, 28);
            this.cbbOrientation.TabIndex = 8;
            // 
            // tbColor
            // 
            this.tbColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbColor.Location = new System.Drawing.Point(0, 220);
            this.tbColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbColor.Name = "tbColor";
            this.tbColor.Size = new System.Drawing.Size(334, 26);
            this.tbColor.TabIndex = 1;
            // 
            // cbbSize
            // 
            this.cbbSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbSize.FormattingEnabled = true;
            this.cbbSize.Items.AddRange(new object[] {
            "#3.5",
            "#5",
            "#7",
            "#10",
            "#12"});
            this.cbbSize.Location = new System.Drawing.Point(0, 281);
            this.cbbSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbSize.Name = "cbbSize";
            this.cbbSize.Size = new System.Drawing.Size(334, 28);
            this.cbbSize.TabIndex = 1;
            this.cbbSize.TextChanged += new System.EventHandler(this.cbbSize_TextChanged);
            // 
            // btOK
            // 
            this.btOK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btOK.Location = new System.Drawing.Point(0, 496);
            this.btOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btOK.Name = "btOK";
            this.btOK.Padding = new System.Windows.Forms.Padding(8);
            this.btOK.Size = new System.Drawing.Size(334, 49);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btCancel.Location = new System.Drawing.Point(0, 545);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(8);
            this.btCancel.Size = new System.Drawing.Size(334, 49);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbCode
            // 
            this.lbCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCode.Location = new System.Drawing.Point(0, 0);
            this.lbCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(334, 35);
            this.lbCode.TabIndex = 3;
            this.lbCode.Text = "Code:";
            this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbColor
            // 
            this.lbColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbColor.Location = new System.Drawing.Point(0, 185);
            this.lbColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(334, 35);
            this.lbColor.TabIndex = 9;
            this.lbColor.Text = "Color:";
            this.lbColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSize
            // 
            this.lbSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSize.Location = new System.Drawing.Point(0, 246);
            this.lbSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(334, 35);
            this.lbSize.TabIndex = 10;
            this.lbSize.Text = "Size:";
            this.lbSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listboxSize
            // 
            this.listboxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listboxSize.FormattingEnabled = true;
            this.listboxSize.ItemHeight = 20;
            this.listboxSize.Location = new System.Drawing.Point(0, 309);
            this.listboxSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listboxSize.Name = "listboxSize";
            this.listboxSize.Size = new System.Drawing.Size(334, 187);
            this.listboxSize.TabIndex = 11;
            this.listboxSize.SelectedIndexChanged += new System.EventHandler(this.listBoxSize_SelectedIndexChanged);
            // 
            // fProductPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 594);
            this.Controls.Add(this.listboxSize);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.cbbSize);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.tbColor);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.cbbOrientation);
            this.Controls.Add(this.lbOrient);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.lbCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fProductPath";
            this.Text = "fProductPath";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fProductPath_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbColor;
        private System.Windows.Forms.ComboBox cbbSize;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbOrient;
        private System.Windows.Forms.ComboBox cbbOrientation;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ListBox listboxSize;
    }
}