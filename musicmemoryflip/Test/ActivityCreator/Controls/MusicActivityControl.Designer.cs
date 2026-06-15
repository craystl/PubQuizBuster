namespace PubQuizBuster.ActivityCreator;

partial class MusicActivityControl
{
    private System.ComponentModel.IContainer components = null!;

    private TableLayoutPanel _rootLayout = null!;
    private TableLayoutPanel _headerPanel = null!;
    private Panel _dividerPanel = null!;
    private TableLayoutPanel _filterPanel = null!;
    private FlowLayoutPanel _resultsPanel = null!;
    private TableLayoutPanel _selectedOuterPanel = null!;
    private FlowLayoutPanel _stagingPanel = null!;
    private Label _statusLabel = null!;

    private Label _activityTitleLabel = null!;
    private TextBox _titleBox = null!;
    private Label _rootFilenameLabel = null!;
    private TextBox _filenameBox = null!;
    private Button _viewButton = null!;
    private Button _saveButton = null!;

    private Label _genreLabel = null!;
    private ComboBox _genreCombo = null!;
    private Label _limitLabel = null!;
    private NumericUpDown _limitSpinner = null!;
    private Button _searchButton = null!;
    private Button _stopButton = null!;

    private Label _selectedTitleLabel = null!;
    private Button _addPairButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _rootLayout = new TableLayoutPanel();
        _headerPanel = new TableLayoutPanel();
        _activityTitleLabel = new Label();
        _titleBox = new TextBox();
        _rootFilenameLabel = new Label();
        _filenameBox = new TextBox();
        _viewButton = new Button();
        _saveButton = new Button();
        _dividerPanel = new Panel();
        _filterPanel = new TableLayoutPanel();
        _genreLabel = new Label();
        _genreCombo = new ComboBox();
        _limitLabel = new Label();
        _limitSpinner = new NumericUpDown();
        _searchButton = new Button();
        _stopButton = new Button();
        _resultsPanel = new FlowLayoutPanel();
        _selectedOuterPanel = new TableLayoutPanel();
        _selectedTitleLabel = new Label();
        _stagingPanel = new FlowLayoutPanel();
        _addPairButton = new Button();
        _statusLabel = new Label();
        _rootLayout.SuspendLayout();
        _headerPanel.SuspendLayout();
        _filterPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_limitSpinner).BeginInit();
        _selectedOuterPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _rootLayout
        // 
        _rootLayout.ColumnCount = 2;
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76F));
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        _rootLayout.Controls.Add(_headerPanel, 0, 0);
        _rootLayout.Controls.Add(_dividerPanel, 0, 1);
        _rootLayout.Controls.Add(_filterPanel, 0, 2);
        _rootLayout.Controls.Add(_resultsPanel, 0, 3);
        _rootLayout.Controls.Add(_selectedOuterPanel, 1, 3);
        _rootLayout.Controls.Add(_statusLabel, 0, 4);
        _rootLayout.Dock = DockStyle.Fill;
        _rootLayout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        _rootLayout.Location = new Point(0, 0);
        _rootLayout.Margin = new Padding(2);
        _rootLayout.Name = "_rootLayout";
        _rootLayout.Padding = new Padding(14, 17, 14, 17);
        _rootLayout.RowCount = 5;
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
        _rootLayout.Size = new Size(1880, 1145);
        _rootLayout.TabIndex = 0;
        // 
        // _headerPanel
        // 
        _headerPanel.ColumnCount = 6;
        _rootLayout.SetColumnSpan(_headerPanel, 2);
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 186F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
        _headerPanel.Controls.Add(_activityTitleLabel, 0, 0);
        _headerPanel.Controls.Add(_titleBox, 1, 0);
        _headerPanel.Controls.Add(_rootFilenameLabel, 2, 0);
        _headerPanel.Controls.Add(_filenameBox, 3, 0);
        _headerPanel.Controls.Add(_viewButton, 4, 0);
        _headerPanel.Controls.Add(_saveButton, 5, 0);
        _headerPanel.Dock = DockStyle.Fill;
        _headerPanel.Location = new Point(18, 22);
        _headerPanel.Margin = new Padding(4, 5, 4, 5);
        _headerPanel.Name = "_headerPanel";
        _headerPanel.RowCount = 1;
        _headerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
        _headerPanel.Size = new Size(1844, 65);
        _headerPanel.TabIndex = 0;
        // 
        // _activityTitleLabel
        // 
        _activityTitleLabel.Dock = DockStyle.Fill;
        _activityTitleLabel.Location = new Point(4, 0);
        _activityTitleLabel.Margin = new Padding(4, 0, 4, 0);
        _activityTitleLabel.Name = "_activityTitleLabel";
        _activityTitleLabel.Size = new Size(150, 83);
        _activityTitleLabel.TabIndex = 0;
        _activityTitleLabel.Text = "Activity title:";
        _activityTitleLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _titleBox
        // 
        _titleBox.Dock = DockStyle.Fill;
        _titleBox.Location = new Point(162, 5);
        _titleBox.Margin = new Padding(4, 5, 4, 5);
        _titleBox.Name = "_titleBox";
        _titleBox.Size = new Size(645, 31);
        _titleBox.TabIndex = 1;
        _titleBox.Text = "Artist-Album Memory Flip";
        // 
        // _rootFilenameLabel
        // 
        _rootFilenameLabel.Dock = DockStyle.Fill;
        _rootFilenameLabel.Location = new Point(815, 0);
        _rootFilenameLabel.Margin = new Padding(4, 0, 4, 0);
        _rootFilenameLabel.Name = "_rootFilenameLabel";
        _rootFilenameLabel.Size = new Size(178, 83);
        _rootFilenameLabel.TabIndex = 2;
        _rootFilenameLabel.Text = "Root JSON filename:";
        _rootFilenameLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filenameBox
        // 
        _filenameBox.Dock = DockStyle.Fill;
        _filenameBox.Location = new Point(1001, 5);
        _filenameBox.Margin = new Padding(4, 5, 4, 5);
        _filenameBox.Name = "_filenameBox";
        _filenameBox.Size = new Size(594, 31);
        _filenameBox.TabIndex = 3;
        _filenameBox.Text = "music_memory_flip";
        // 
        // _viewButton
        // 
        _viewButton.Dock = DockStyle.Fill;
        _viewButton.Location = new Point(1603, 5);
        _viewButton.Margin = new Padding(4, 5, 4, 5);
        _viewButton.Name = "_viewButton";
        _viewButton.Size = new Size(114, 73);
        _viewButton.TabIndex = 4;
        _viewButton.Text = "View";
        _viewButton.Click += _viewButton_Click;
        // 
        // _saveButton
        // 
        _saveButton.Dock = DockStyle.Fill;
        _saveButton.Location = new Point(1725, 5);
        _saveButton.Margin = new Padding(4, 5, 4, 5);
        _saveButton.Name = "_saveButton";
        _saveButton.Size = new Size(115, 73);
        _saveButton.TabIndex = 5;
        _saveButton.Text = "Save";
        _saveButton.Click += _saveButton_Click;
        // 
        // _dividerPanel
        // 
        _dividerPanel.BackColor = Color.Silver;
        _rootLayout.SetColumnSpan(_dividerPanel, 2);
        _dividerPanel.Dock = DockStyle.Fill;
        _dividerPanel.Location = new Point(18, 97);
        _dividerPanel.Margin = new Padding(4, 5, 4, 5);
        _dividerPanel.Name = "_dividerPanel";
        _dividerPanel.Size = new Size(1844, 1);
        _dividerPanel.TabIndex = 1;
        // 
        // _filterPanel
        // 
        _filterPanel.ColumnCount = 6;
        _rootLayout.SetColumnSpan(_filterPanel, 2);
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        _filterPanel.Controls.Add(_genreLabel, 0, 0);
        _filterPanel.Controls.Add(_genreCombo, 1, 0);
        _filterPanel.Controls.Add(_limitLabel, 2, 0);
        _filterPanel.Controls.Add(_limitSpinner, 3, 0);
        _filterPanel.Controls.Add(_searchButton, 4, 0);
        _filterPanel.Controls.Add(_stopButton, 5, 0);
        _filterPanel.Dock = DockStyle.Fill;
        _filterPanel.Location = new Point(18, 100);
        _filterPanel.Margin = new Padding(4, 5, 4, 5);
        _filterPanel.Name = "_filterPanel";
        _filterPanel.Padding = new Padding(0, 13, 0, 13);
        _filterPanel.RowCount = 1;
        _filterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _filterPanel.Size = new Size(1844, 90);
        _filterPanel.TabIndex = 2;
        // 
        // _genreLabel
        // 
        _genreLabel.Dock = DockStyle.Fill;
        _genreLabel.Location = new Point(4, 13);
        _genreLabel.Margin = new Padding(4, 0, 4, 0);
        _genreLabel.Name = "_genreLabel";
        _genreLabel.Size = new Size(150, 64);
        _genreLabel.TabIndex = 0;
        _genreLabel.Text = "Genre:";
        _genreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _genreCombo
        // 
        _genreCombo.Dock = DockStyle.Top;
        _genreCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _genreCombo.Location = new Point(162, 18);
        _genreCombo.Margin = new Padding(4, 5, 4, 5);
        _genreCombo.Name = "_genreCombo";
        _genreCombo.Size = new Size(1148, 33);
        _genreCombo.TabIndex = 1;
        // 
        // _limitLabel
        // 
        _limitLabel.Dock = DockStyle.Fill;
        _limitLabel.Location = new Point(1318, 13);
        _limitLabel.Margin = new Padding(4, 0, 4, 0);
        _limitLabel.Name = "_limitLabel";
        _limitLabel.Size = new Size(109, 64);
        _limitLabel.TabIndex = 2;
        _limitLabel.Text = "Max artists:";
        _limitLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _limitSpinner
        // 
        _limitSpinner.Dock = DockStyle.Top;
        _limitSpinner.Location = new Point(1435, 18);
        _limitSpinner.Margin = new Padding(4, 5, 4, 5);
        _limitSpinner.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
        _limitSpinner.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
        _limitSpinner.Name = "_limitSpinner";
        _limitSpinner.Size = new Size(125, 31);
        _limitSpinner.TabIndex = 3;
        _limitSpinner.Value = new decimal(new int[] { 50, 0, 0, 0 });
        // 
        // _searchButton
        // 
        _searchButton.Dock = DockStyle.Top;
        _searchButton.Location = new Point(1568, 18);
        _searchButton.Margin = new Padding(4, 5, 4, 5);
        _searchButton.Name = "_searchButton";
        _searchButton.Size = new Size(132, 33);
        _searchButton.TabIndex = 4;
        _searchButton.Text = "Search";
        _searchButton.Click += _searchButton_Click;
        // 
        // _stopButton
        // 
        _stopButton.Dock = DockStyle.Top;
        _stopButton.Enabled = false;
        _stopButton.Location = new Point(1708, 18);
        _stopButton.Margin = new Padding(4, 5, 4, 5);
        _stopButton.Name = "_stopButton";
        _stopButton.Size = new Size(132, 33);
        _stopButton.TabIndex = 5;
        _stopButton.Text = "Stop";
        _stopButton.Click += _stopButton_Click;
        // 
        // _resultsPanel
        // 
        _resultsPanel.AutoScroll = true;
        _resultsPanel.BackColor = Color.White;
        _resultsPanel.BorderStyle = BorderStyle.FixedSingle;
        _resultsPanel.Dock = DockStyle.Fill;
        _resultsPanel.Location = new Point(18, 200);
        _resultsPanel.Margin = new Padding(4, 5, 4, 5);
        _resultsPanel.Name = "_resultsPanel";
        _resultsPanel.Padding = new Padding(12, 13, 12, 13);
        _resultsPanel.Size = new Size(1399, 870);
        _resultsPanel.TabIndex = 3;
        // 
        // _selectedOuterPanel
        // 
        _selectedOuterPanel.BorderStyle = BorderStyle.FixedSingle;
        _selectedOuterPanel.ColumnCount = 1;
        _selectedOuterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _selectedOuterPanel.Controls.Add(_selectedTitleLabel, 0, 0);
        _selectedOuterPanel.Controls.Add(_stagingPanel, 0, 1);
        _selectedOuterPanel.Controls.Add(_addPairButton, 0, 2);
        _selectedOuterPanel.Dock = DockStyle.Fill;
        _selectedOuterPanel.Location = new Point(1425, 200);
        _selectedOuterPanel.Margin = new Padding(4, 5, 4, 5);
        _selectedOuterPanel.Name = "_selectedOuterPanel";
        _selectedOuterPanel.Padding = new Padding(12, 13, 12, 13);
        _selectedOuterPanel.RowCount = 3;
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
        _selectedOuterPanel.Size = new Size(437, 870);
        _selectedOuterPanel.TabIndex = 4;
        // 
        // _selectedTitleLabel
        // 
        _selectedTitleLabel.Dock = DockStyle.Fill;
        _selectedTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        _selectedTitleLabel.Location = new Point(16, 13);
        _selectedTitleLabel.Margin = new Padding(4, 0, 4, 0);
        _selectedTitleLabel.Name = "_selectedTitleLabel";
        _selectedTitleLabel.Size = new Size(403, 57);
        _selectedTitleLabel.TabIndex = 0;
        _selectedTitleLabel.Text = "Staged pair";
        _selectedTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _stagingPanel
        // 
        _stagingPanel.AutoScroll = true;
        _stagingPanel.BackColor = Color.WhiteSmoke;
        _stagingPanel.Dock = DockStyle.Fill;
        _stagingPanel.FlowDirection = FlowDirection.TopDown;
        _stagingPanel.Location = new Point(16, 75);
        _stagingPanel.Margin = new Padding(4, 5, 4, 5);
        _stagingPanel.Name = "_stagingPanel";
        _stagingPanel.Size = new Size(403, 705);
        _stagingPanel.TabIndex = 1;
        _stagingPanel.WrapContents = false;
        // 
        // _addPairButton
        // 
        _addPairButton.Dock = DockStyle.Fill;
        _addPairButton.Location = new Point(16, 790);
        _addPairButton.Margin = new Padding(4, 5, 4, 5);
        _addPairButton.Name = "_addPairButton";
        _addPairButton.Size = new Size(403, 60);
        _addPairButton.TabIndex = 2;
        _addPairButton.Text = "Add Pair";
        _addPairButton.Click += _addPairButton_Click;
        // 
        // _statusLabel
        // 
        _rootLayout.SetColumnSpan(_statusLabel, 2);
        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.Location = new Point(18, 1075);
        _statusLabel.Margin = new Padding(4, 0, 4, 0);
        _statusLabel.Name = "_statusLabel";
        _statusLabel.Size = new Size(1844, 53);
        _statusLabel.TabIndex = 5;
        _statusLabel.Text = "Ready. Select a genre then click Search.";
        _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MusicActivityControl
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_rootLayout);
        Margin = new Padding(4, 5, 4, 5);
        Name = "MusicActivityControl";
        Size = new Size(1880, 1145);
        _rootLayout.ResumeLayout(false);
        _headerPanel.ResumeLayout(false);
        _headerPanel.PerformLayout();
        _filterPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_limitSpinner).EndInit();
        _selectedOuterPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}