namespace ExpenseTracker
{
    partial class ExpenseForm
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
            this.ExpensesDataGridView = new System.Windows.Forms.DataGridView();
            this.TopBarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCurrentFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomBarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.SumLabelTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.DisplaySumTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.AverageSelectionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.DisplayAverageTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.FilterLabelTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.DisplayFilterNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.clearFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseMethodColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesDataGridView)).BeginInit();
            this.TopBarMenuStrip.SuspendLayout();
            this.BottomBarMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExpensesDataGridView
            // 
            this.ExpensesDataGridView.AllowUserToAddRows = false;
            this.ExpensesDataGridView.AllowUserToDeleteRows = false;
            this.ExpensesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExpensesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ExpensesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpensesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.AmountColumn,
            this.PlaceColumn,
            this.TagColumn,
            this.NotesColumn,
            this.PurchaseMethodColumn,
            this.EditButtonColumn,
            this.DeleteButtonColumn});
            this.ExpensesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpensesDataGridView.Location = new System.Drawing.Point(0, 24);
            this.ExpensesDataGridView.Name = "ExpensesDataGridView";
            this.ExpensesDataGridView.Size = new System.Drawing.Size(800, 426);
            this.ExpensesDataGridView.TabIndex = 0;
            this.ExpensesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpensesDataGridView_CellContentClick);
            this.ExpensesDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.ExpensesDataGridView_SortCompare);
            // 
            // TopBarMenuStrip
            // 
            this.TopBarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expensesToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.TopBarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopBarMenuStrip.Name = "TopBarMenuStrip";
            this.TopBarMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.TopBarMenuStrip.TabIndex = 1;
            this.TopBarMenuStrip.Text = "menuStrip1";
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.expensesToolStripMenuItem.Text = "Expenses";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setCurrentFilterToolStripMenuItem,
            this.clearFiltersToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // setCurrentFilterToolStripMenuItem
            // 
            this.setCurrentFilterToolStripMenuItem.Name = "setCurrentFilterToolStripMenuItem";
            this.setCurrentFilterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setCurrentFilterToolStripMenuItem.Text = "Set Current Filter";
            // 
            // BottomBarMenuStrip
            // 
            this.BottomBarMenuStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomBarMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.BottomBarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SumLabelTextBox,
            this.DisplaySumTextBox,
            this.AverageSelectionComboBox,
            this.DisplayAverageTextBox,
            this.FilterLabelTextBox,
            this.DisplayFilterNameTextBox});
            this.BottomBarMenuStrip.Location = new System.Drawing.Point(0, 423);
            this.BottomBarMenuStrip.Name = "BottomBarMenuStrip";
            this.BottomBarMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.BottomBarMenuStrip.Size = new System.Drawing.Size(800, 27);
            this.BottomBarMenuStrip.TabIndex = 2;
            this.BottomBarMenuStrip.Text = "menuStrip2";
            // 
            // SumLabelTextBox
            // 
            this.SumLabelTextBox.Name = "SumLabelTextBox";
            this.SumLabelTextBox.ReadOnly = true;
            this.SumLabelTextBox.Size = new System.Drawing.Size(100, 23);
            this.SumLabelTextBox.Text = "Sum:";
            // 
            // DisplaySumTextBox
            // 
            this.DisplaySumTextBox.Name = "DisplaySumTextBox";
            this.DisplaySumTextBox.ReadOnly = true;
            this.DisplaySumTextBox.Size = new System.Drawing.Size(100, 23);
            this.DisplaySumTextBox.Text = "SUMHERE";
            // 
            // AverageSelectionComboBox
            // 
            this.AverageSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AverageSelectionComboBox.Items.AddRange(new object[] {
            "Average Per Day",
            "Average Per Week",
            "Average Per Month",
            "Average Per Year",
            "Average Per Decade",
            "Average Per Century",
            "Average Per Item"});
            this.AverageSelectionComboBox.MaxDropDownItems = 7;
            this.AverageSelectionComboBox.Name = "AverageSelectionComboBox";
            this.AverageSelectionComboBox.Size = new System.Drawing.Size(121, 23);
            this.AverageSelectionComboBox.ToolTipText = "Select interval to calculate average";
            this.AverageSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.AverageSelectionComboBox_SelectedIndexChanged);
            // 
            // DisplayAverageTextBox
            // 
            this.DisplayAverageTextBox.Name = "DisplayAverageTextBox";
            this.DisplayAverageTextBox.ReadOnly = true;
            this.DisplayAverageTextBox.Size = new System.Drawing.Size(100, 23);
            this.DisplayAverageTextBox.Text = "AVERAGEHERE";
            // 
            // FilterLabelTextBox
            // 
            this.FilterLabelTextBox.Name = "FilterLabelTextBox";
            this.FilterLabelTextBox.ReadOnly = true;
            this.FilterLabelTextBox.Size = new System.Drawing.Size(100, 23);
            this.FilterLabelTextBox.Text = "Filter:";
            // 
            // DisplayFilterNameTextBox
            // 
            this.DisplayFilterNameTextBox.Name = "DisplayFilterNameTextBox";
            this.DisplayFilterNameTextBox.ReadOnly = true;
            this.DisplayFilterNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.DisplayFilterNameTextBox.Text = "FILTERNAMEHERE";
            // 
            // clearFiltersToolStripMenuItem
            // 
            this.clearFiltersToolStripMenuItem.Name = "clearFiltersToolStripMenuItem";
            this.clearFiltersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearFiltersToolStripMenuItem.Text = "Clear Filters";
            this.clearFiltersToolStripMenuItem.Click += new System.EventHandler(this.clearFiltersToolStripMenuItem_Click);
            // 
            // DateColumn
            // 
            this.DateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DateColumn.Width = 55;
            // 
            // AmountColumn
            // 
            this.AmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AmountColumn.Width = 68;
            // 
            // PlaceColumn
            // 
            this.PlaceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlaceColumn.HeaderText = "Place";
            this.PlaceColumn.Name = "PlaceColumn";
            this.PlaceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PlaceColumn.Width = 59;
            // 
            // TagColumn
            // 
            this.TagColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TagColumn.HeaderText = "Tags";
            this.TagColumn.Name = "TagColumn";
            this.TagColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TagColumn.Width = 37;
            // 
            // NotesColumn
            // 
            this.NotesColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NotesColumn.HeaderText = "Notes";
            this.NotesColumn.Name = "NotesColumn";
            this.NotesColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NotesColumn.Width = 41;
            // 
            // PurchaseMethodColumn
            // 
            this.PurchaseMethodColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchaseMethodColumn.HeaderText = "Purchase Method";
            this.PurchaseMethodColumn.Name = "PurchaseMethodColumn";
            this.PurchaseMethodColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // EditButtonColumn
            // 
            this.EditButtonColumn.HeaderText = "Edit";
            this.EditButtonColumn.Name = "EditButtonColumn";
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.HeaderText = "Delete";
            this.DeleteButtonColumn.Name = "DeleteButtonColumn";
            // 
            // ExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BottomBarMenuStrip);
            this.Controls.Add(this.ExpensesDataGridView);
            this.Controls.Add(this.TopBarMenuStrip);
            this.MainMenuStrip = this.TopBarMenuStrip;
            this.Name = "ExpenseForm";
            this.Text = "ExpenseForm";
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesDataGridView)).EndInit();
            this.TopBarMenuStrip.ResumeLayout(false);
            this.TopBarMenuStrip.PerformLayout();
            this.BottomBarMenuStrip.ResumeLayout(false);
            this.BottomBarMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ExpensesDataGridView;
        private System.Windows.Forms.MenuStrip TopBarMenuStrip;
        private System.Windows.Forms.MenuStrip BottomBarMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCurrentFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SumLabelTextBox;
        private System.Windows.Forms.ToolStripTextBox DisplaySumTextBox;
        private System.Windows.Forms.ToolStripComboBox AverageSelectionComboBox;
        private System.Windows.Forms.ToolStripTextBox DisplayAverageTextBox;
        private System.Windows.Forms.ToolStripTextBox FilterLabelTextBox;
        private System.Windows.Forms.ToolStripTextBox DisplayFilterNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem clearFiltersToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseMethodColumn;
        private System.Windows.Forms.DataGridViewButtonColumn EditButtonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButtonColumn;
    }
}