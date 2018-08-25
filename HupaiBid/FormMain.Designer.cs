namespace HupaiBid
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.timerCal = new System.Windows.Forms.Timer(this.components);
            this.timerBid = new System.Windows.Forms.Timer(this.components);
            this.textBoxCap = new System.Windows.Forms.TextBox();
            this.buttonCap = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonBid = new System.Windows.Forms.Button();
            this.buttonCal = new System.Windows.Forms.Button();
            this.timerCap = new System.Windows.Forms.Timer(this.components);
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(16, 316);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(210, 231);
            this.textBoxLog.TabIndex = 5;
            this.textBoxLog.TextChanged += new System.EventHandler(this.textBoxLog_TextChanged);
            // 
            // timerCal
            // 
            this.timerCal.Interval = 10;
            this.timerCal.Tick += new System.EventHandler(this.timerCal_Tick);
            // 
            // timerBid
            // 
            this.timerBid.Tick += new System.EventHandler(this.timerBid_Tick);
            // 
            // textBoxCap
            // 
            this.textBoxCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCap.Location = new System.Drawing.Point(16, 198);
            this.textBoxCap.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCap.Name = "textBoxCap";
            this.textBoxCap.Size = new System.Drawing.Size(210, 35);
            this.textBoxCap.TabIndex = 7;
            // 
            // buttonCap
            // 
            this.buttonCap.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCap.Image = global::HupaiBid.Properties.Resources.cap;
            this.buttonCap.Location = new System.Drawing.Point(16, 244);
            this.buttonCap.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCap.Name = "buttonCap";
            this.buttonCap.Size = new System.Drawing.Size(210, 50);
            this.buttonCap.TabIndex = 6;
            this.buttonCap.Text = "验证码";
            this.buttonCap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCap.UseVisualStyleBackColor = true;
            this.buttonCap.Click += new System.EventHandler(this.buttonCap_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSet.Image = global::HupaiBid.Properties.Resources.set;
            this.buttonSet.Location = new System.Drawing.Point(16, 138);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(210, 50);
            this.buttonSet.TabIndex = 3;
            this.buttonSet.Text = "方案设定";
            this.buttonSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonBid
            // 
            this.buttonBid.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBid.Image = global::HupaiBid.Properties.Resources.bid;
            this.buttonBid.Location = new System.Drawing.Point(16, 76);
            this.buttonBid.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBid.Name = "buttonBid";
            this.buttonBid.Size = new System.Drawing.Size(210, 50);
            this.buttonBid.TabIndex = 2;
            this.buttonBid.Text = "自动拍牌";
            this.buttonBid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBid.UseVisualStyleBackColor = true;
            this.buttonBid.Click += new System.EventHandler(this.buttonBid_Click);
            // 
            // buttonCal
            // 
            this.buttonCal.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCal.Image = global::HupaiBid.Properties.Resources.cal;
            this.buttonCal.Location = new System.Drawing.Point(16, 17);
            this.buttonCal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCal.Name = "buttonCal";
            this.buttonCal.Size = new System.Drawing.Size(210, 50);
            this.buttonCal.TabIndex = 1;
            this.buttonCal.Text = "屏幕校准";
            this.buttonCal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCal.UseVisualStyleBackColor = true;
            this.buttonCal.Click += new System.EventHandler(this.buttonCal_Click);
            // 
            // timerCap
            // 
            this.timerCap.Interval = 500;
            this.timerCap.Tick += new System.EventHandler(this.timerCap_Tick);
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 60000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelTime.Location = new System.Drawing.Point(152, 568);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(74, 19);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "11:00:00.1";
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonCap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 594);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.textBoxCap);
            this.Controls.Add(this.buttonCap);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonBid);
            this.Controls.Add(this.buttonCal);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "沪牌助手";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCal;
        private System.Windows.Forms.Button buttonBid;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Timer timerCal;
        private System.Windows.Forms.Timer timerBid;
        private System.Windows.Forms.Button buttonCap;
        private System.Windows.Forms.TextBox textBoxCap;
        private System.Windows.Forms.Timer timerCap;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerTime;
    }
}

