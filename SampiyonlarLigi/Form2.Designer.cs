namespace SampiyonlarLigi
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            dataGridViewTeams = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            txtTeamName = new TextBox();
            txtTeamCountry = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeams).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1070, 665);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewTeams
            // 
            dataGridViewTeams.BackgroundColor = SystemColors.Window;
            dataGridViewTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTeams.Location = new Point(187, 74);
            dataGridViewTeams.Name = "dataGridViewTeams";
            dataGridViewTeams.RowHeadersWidth = 62;
            dataGridViewTeams.Size = new Size(407, 383);
            dataGridViewTeams.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnAdd.Location = new Point(698, 541);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 52);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDelete.Location = new Point(648, 201);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 52);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnClose.Location = new Point(648, 293);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 52);
            btnClose.TabIndex = 5;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // txtTeamName
            // 
            txtTeamName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTeamName.Location = new Point(232, 554);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Size = new Size(190, 39);
            txtTeamName.TabIndex = 6;
            // 
            // txtTeamCountry
            // 
            txtTeamCountry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTeamCountry.Location = new Point(465, 554);
            txtTeamCountry.Name = "txtTeamCountry";
            txtTeamCountry.Size = new Size(190, 39);
            txtTeamCountry.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 667);
            Controls.Add(txtTeamCountry);
            Controls.Add(txtTeamName);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewTeams);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Uefa CL Draw";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewTeams;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClose;
        private TextBox txtTeamName;
        private TextBox txtTeamCountry;
    }
}