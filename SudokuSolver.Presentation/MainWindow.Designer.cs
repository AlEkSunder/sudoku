namespace SudokuSolver.Presentation
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.nextStepBtn = new System.Windows.Forms.Button();
            this.fieldDataGridView = new System.Windows.Forms.DataGridView();
            this.sudokuSolverViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.finishLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudokuSolverViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nextStepBtn
            // 
            this.nextStepBtn.Location = new System.Drawing.Point(536, 570);
            this.nextStepBtn.Name = "nextStepBtn";
            this.nextStepBtn.Size = new System.Drawing.Size(133, 43);
            this.nextStepBtn.TabIndex = 1;
            this.nextStepBtn.Text = "Step";
            this.nextStepBtn.UseVisualStyleBackColor = true;
            this.nextStepBtn.Click += new System.EventHandler(this.OnNextStep_Click);
            // 
            // fieldDataGridView
            // 
            this.fieldDataGridView.AllowUserToAddRows = false;
            this.fieldDataGridView.AllowUserToDeleteRows = false;
            this.fieldDataGridView.AllowUserToResizeColumns = false;
            this.fieldDataGridView.AllowUserToResizeRows = false;
            this.fieldDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fieldDataGridView.ColumnHeadersHeight = 60;
            this.fieldDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fieldDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fieldDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.fieldDataGridView.Enabled = false;
            this.fieldDataGridView.Location = new System.Drawing.Point(12, 12);
            this.fieldDataGridView.Name = "fieldDataGridView";
            this.fieldDataGridView.ReadOnly = true;
            this.fieldDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.fieldDataGridView.RowHeadersVisible = false;
            this.fieldDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.fieldDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.fieldDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fieldDataGridView.RowTemplate.DefaultCellStyle.NullValue = null;
            this.fieldDataGridView.RowTemplate.Height = 60;
            this.fieldDataGridView.Size = new System.Drawing.Size(656, 543);
            this.fieldDataGridView.TabIndex = 2;
            // 
            // finishLabel
            // 
            this.finishLabel.AutoSize = true;
            this.finishLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finishLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.finishLabel.Location = new System.Drawing.Point(60, 570);
            this.finishLabel.Name = "finishLabel";
            this.finishLabel.Size = new System.Drawing.Size(209, 28);
            this.finishLabel.TabIndex = 3;
            this.finishLabel.Text = "The puzzle is solved!";
            this.finishLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 635);
            this.Controls.Add(this.finishLabel);
            this.Controls.Add(this.fieldDataGridView);
            this.Controls.Add(this.nextStepBtn);
            this.Name = "MainWindow";
            this.Text = "Suudoku solver";
            this.Load += new System.EventHandler(this.OnMainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sudokuSolverViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button nextStepBtn;
        private DataGridView fieldDataGridView;
        private BindingSource sudokuSolverViewModelBindingSource;
        private Label finishLabel;
    }
}