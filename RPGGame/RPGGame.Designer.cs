namespace RPGGame
{
    partial class RPGGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(95, 9);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 20);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(95, 41);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 20);
            this.lblGold.TabIndex = 5;
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Location = new System.Drawing.Point(95, 75);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(0, 20);
            this.lblExp.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(95, 110);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 20);
            this.lblLevel.TabIndex = 7;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(820, 601);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(94, 29);
            this.btnUseWeapon.TabIndex = 8;
            this.btnUseWeapon.Text = "Use";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Visible = false;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(817, 573);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Select action:";
            // 
            // cboWeapons
            // 
            this.cboWeapons.BackColor = System.Drawing.SystemColors.Window;
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(569, 601);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(151, 28);
            this.cboWeapons.TabIndex = 10;
            this.cboWeapons.Visible = false;
            this.cboWeapons.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboPotions
            // 
            this.cboPotions.BackColor = System.Drawing.SystemColors.Window;
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(569, 635);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(151, 28);
            this.cboPotions.TabIndex = 11;
            this.cboPotions.Visible = false;
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(602, 465);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(94, 29);
            this.btnWest.TabIndex = 12;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(703, 508);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(94, 29);
            this.btnSouth.TabIndex = 13;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(805, 465);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(94, 29);
            this.btnEast.TabIndex = 14;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(703, 420);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(94, 29);
            this.btnNorth.TabIndex = 15;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(820, 635);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(94, 29);
            this.btnUsePotion.TabIndex = 16;
            this.btnUsePotion.Text = "Use";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Visible = false;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(526, 21);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(452, 120);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(526, 163);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(452, 228);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(12, 163);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.RowHeadersWidth = 51;
            this.dgvQuests.RowTemplate.Height = 29;
            this.dgvQuests.Size = new System.Drawing.Size(499, 329);
            this.dgvQuests.TabIndex = 19;
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 498);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 29;
            this.dgvInventory.Size = new System.Drawing.Size(499, 181);
            this.dgvInventory.TabIndex = 20;
            // 
            // RPGGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 691);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExp);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RPGGame";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblHitPoints;
        private Label lblGold;
        private Label lblExp;
        private Label lblLevel;
        private Button btnUseWeapon;
        private Label label5;
        private ComboBox cboWeapons;
        private ComboBox cboPotions;
        private Button btnWest;
        private Button btnSouth;
        private Button btnEast;
        private Button btnNorth;
        private Button btnUsePotion;
        private RichTextBox rtbLocation;
        private RichTextBox rtbMessages;
        private DataGridView dgvQuests;
        private DataGridView dgvInventory;
    }
}