namespace WF_DGV
{
    partial class MainForm
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
            this.dGV_search = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGV_filter = new System.Windows.Forms.DataGridView();
            this.filter_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_filter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filter_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV_search
            // 
            this.dGV_search.AllowUserToResizeColumns = false;
            this.dGV_search.AllowUserToResizeRows = false;
            this.dGV_search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_search.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dGV_search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_search.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Search});
            this.dGV_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_search.Location = new System.Drawing.Point(0, 0);
            this.dGV_search.Name = "dGV_search";
            this.dGV_search.RowHeadersVisible = false;
            this.dGV_search.Size = new System.Drawing.Size(486, 296);
            this.dGV_search.TabIndex = 0;
            this.dGV_search.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_search_CellValidated);
            this.dGV_search.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dGV_search_EditingControlShowing);
            // 
            // Search
            // 
            this.Search.HeaderText = "Search";
            this.Search.Name = "Search";
            // 
            // dGV_filter
            // 
            this.dGV_filter.AllowUserToAddRows = false;
            this.dGV_filter.AllowUserToDeleteRows = false;
            this.dGV_filter.AllowUserToResizeColumns = false;
            this.dGV_filter.AllowUserToResizeRows = false;
            this.dGV_filter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_filter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGV_filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_filter.Location = new System.Drawing.Point(0, 0);
            this.dGV_filter.MultiSelect = false;
            this.dGV_filter.Name = "dGV_filter";
            this.dGV_filter.ReadOnly = true;
            this.dGV_filter.RowHeadersVisible = false;
            this.dGV_filter.Size = new System.Drawing.Size(219, 296);
            this.dGV_filter.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(486, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dGV_filter);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(219, 296);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(705, 296);
            this.Controls.Add(this.dGV_search);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Search and Filter Data in DataGridView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_filter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filter_bindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV_search;       
        private System.Windows.Forms.DataGridViewTextBoxColumn Search;
        private System.Windows.Forms.DataGridView dGV_filter;
        private System.Windows.Forms.BindingSource filter_bindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

