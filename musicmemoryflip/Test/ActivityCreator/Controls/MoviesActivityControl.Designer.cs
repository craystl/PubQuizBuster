namespace PubQuizBuster.ActivityCreator;

partial class MoviesActivityControl
{
    private System.ComponentModel.IContainer components = null!;

    private TableLayoutPanel _rootLayout = null!;
    private TableLayoutPanel _headerPanel = null!;
    private TableLayoutPanel _questionPanel = null!;
    private TableLayoutPanel _filterPanel = null!;
    private TableLayoutPanel _selectedOuterPanel = null!;
    private FlowLayoutPanel _awardsPanel = null!;
    private Panel _dividerPanel = null!;

    private TextBox _titleBox = null!;
    private TextBox _filenameBox = null!;
    private TextBox _questionBox = null!;
    private ComboBox _occupationCombo = null!;
    private ComboBox _hasCombo = null!;
    private CheckBox _bestActorCheck = null!;
    private CheckBox _bestActressCheck = null!;
    private CheckBox _bestSupportingActorCheck = null!;
    private CheckBox _bestSupportingActressCheck = null!;
    private GroupBox _yearFilter1Group = null!;
    private GroupBox _yearFilter2Group = null!;
    private TableLayoutPanel _yearFilter1Layout = null!;
    private TableLayoutPanel _yearFilter2Layout = null!;
    private ComboBox _yearFilter1FieldCombo = null!;
    private ComboBox _yearFilter1OperatorCombo = null!;
    private TextBox _yearFilter1YearBox = null!;
    private ComboBox _yearFilter2FieldCombo = null!;
    private ComboBox _yearFilter2OperatorCombo = null!;
    private TextBox _yearFilter2YearBox = null!;
    private FlowLayoutPanel _resultsPanel = null!;
    private FlowLayoutPanel _selectedPanel = null!;
    private Label _statusLabel = null!;
    private Button _searchButton = null!;
    private Button _stopButton = null!;
    private Button _completeQuestionButton = null!;

    private Button _loadButton = null!;
    private Button _viewButton = null!;
    private Button _saveButton = null!;
    private Label _activityTitleLabel = null!;
    private Label _rootFilenameLabel = null!;
    private Label _oddQuestionLabel = null!;
    private Label _occupationLabel = null!;
    private Label _selectedTitleLabel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this._rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this._headerPanel = new System.Windows.Forms.TableLayoutPanel();
            this._activityTitleLabel = new System.Windows.Forms.Label();
            this._titleBox = new System.Windows.Forms.TextBox();
            this._rootFilenameLabel = new System.Windows.Forms.Label();
            this._filenameBox = new System.Windows.Forms.TextBox();
            this._loadButton = new System.Windows.Forms.Button();
            this._viewButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._dividerPanel = new System.Windows.Forms.Panel();
            this._questionPanel = new System.Windows.Forms.TableLayoutPanel();
            this._oddQuestionLabel = new System.Windows.Forms.Label();
            this._questionBox = new System.Windows.Forms.TextBox();
            this._filterPanel = new System.Windows.Forms.TableLayoutPanel();
            this._occupationLabel = new System.Windows.Forms.Label();
            this._occupationCombo = new System.Windows.Forms.ComboBox();
            this._hasCombo = new System.Windows.Forms.ComboBox();
            this._awardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._bestActorCheck = new System.Windows.Forms.CheckBox();
            this._bestActressCheck = new System.Windows.Forms.CheckBox();
            this._bestSupportingActorCheck = new System.Windows.Forms.CheckBox();
            this._bestSupportingActressCheck = new System.Windows.Forms.CheckBox();
            this._yearFilter1Group = new System.Windows.Forms.GroupBox();
            this._yearFilter1Layout = new System.Windows.Forms.TableLayoutPanel();
            this._yearFilter1FieldCombo = new System.Windows.Forms.ComboBox();
            this._yearFilter1OperatorCombo = new System.Windows.Forms.ComboBox();
            this._yearFilter1YearBox = new System.Windows.Forms.TextBox();
            this._yearFilter2Group = new System.Windows.Forms.GroupBox();
            this._yearFilter2Layout = new System.Windows.Forms.TableLayoutPanel();
            this._yearFilter2FieldCombo = new System.Windows.Forms.ComboBox();
            this._yearFilter2OperatorCombo = new System.Windows.Forms.ComboBox();
            this._yearFilter2YearBox = new System.Windows.Forms.TextBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this._resultsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._selectedOuterPanel = new System.Windows.Forms.TableLayoutPanel();
            this._selectedTitleLabel = new System.Windows.Forms.Label();
            this._selectedPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._completeQuestionButton = new System.Windows.Forms.Button();
            this._statusLabel = new System.Windows.Forms.Label();
            this._rootLayout.SuspendLayout();
            this._headerPanel.SuspendLayout();
            this._questionPanel.SuspendLayout();
            this._filterPanel.SuspendLayout();
            this._awardsPanel.SuspendLayout();
            this._yearFilter1Group.SuspendLayout();
            this._yearFilter1Layout.SuspendLayout();
            this._yearFilter2Group.SuspendLayout();
            this._yearFilter2Layout.SuspendLayout();
            this._selectedOuterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rootLayout
            // 
            this._rootLayout.ColumnCount = 2;
            this._rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this._rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this._rootLayout.Controls.Add(this._headerPanel, 0, 0);
            this._rootLayout.Controls.Add(this._dividerPanel, 0, 1);
            this._rootLayout.Controls.Add(this._questionPanel, 0, 2);
            this._rootLayout.Controls.Add(this._filterPanel, 0, 3);
            this._rootLayout.Controls.Add(this._resultsPanel, 0, 4);
            this._rootLayout.Controls.Add(this._selectedOuterPanel, 1, 4);
            this._rootLayout.Controls.Add(this._statusLabel, 0, 5);
            this._rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rootLayout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._rootLayout.Location = new System.Drawing.Point(0, 0);
            this._rootLayout.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._rootLayout.Name = "_rootLayout";
            this._rootLayout.Padding = new System.Windows.Forms.Padding(17, 20, 17, 20);
            this._rootLayout.RowCount = 6;
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this._rootLayout.Size = new System.Drawing.Size(2256, 1374);
            this._rootLayout.TabIndex = 0;
            // 
            // _headerPanel
            // 
            this._headerPanel.ColumnCount = 7;
            this._rootLayout.SetColumnSpan(this._headerPanel, 2);
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this._headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this._headerPanel.Controls.Add(this._activityTitleLabel, 0, 0);
            this._headerPanel.Controls.Add(this._titleBox, 1, 0);
            this._headerPanel.Controls.Add(this._rootFilenameLabel, 2, 0);
            this._headerPanel.Controls.Add(this._filenameBox, 3, 0);
            this._headerPanel.Controls.Add(this._loadButton, 4, 0);
            this._headerPanel.Controls.Add(this._viewButton, 5, 0);
            this._headerPanel.Controls.Add(this._saveButton, 6, 0);
            this._headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._headerPanel.Location = new System.Drawing.Point(22, 26);
            this._headerPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._headerPanel.Name = "_headerPanel";
            this._headerPanel.RowCount = 1;
            this._headerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this._headerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this._headerPanel.Size = new System.Drawing.Size(2212, 78);
            this._headerPanel.TabIndex = 0;
            // 
            // _activityTitleLabel
            // 
            this._activityTitleLabel.Location = new System.Drawing.Point(5, 0);
            this._activityTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._activityTitleLabel.Name = "_activityTitleLabel";
            this._activityTitleLabel.Size = new System.Drawing.Size(179, 48);
            this._activityTitleLabel.TabIndex = 0;
            this._activityTitleLabel.Text = "Activity title:";
            this._activityTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _titleBox
            // 
            this._titleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._titleBox.Location = new System.Drawing.Point(194, 6);
            this._titleBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._titleBox.Name = "_titleBox";
            this._titleBox.Size = new System.Drawing.Size(696, 35);
            this._titleBox.TabIndex = 1;
            this._titleBox.Text = "Which movie star is the odd one out?";
            this._titleBox.TextChanged += new System.EventHandler(this.TitleBox_TextChanged);
            // 
            // _rootFilenameLabel
            // 
            this._rootFilenameLabel.Location = new System.Drawing.Point(900, 0);
            this._rootFilenameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._rootFilenameLabel.Name = "_rootFilenameLabel";
            this._rootFilenameLabel.Size = new System.Drawing.Size(213, 48);
            this._rootFilenameLabel.TabIndex = 2;
            this._rootFilenameLabel.Text = "Root JSON filename:";
            this._rootFilenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _filenameBox
            // 
            this._filenameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filenameBox.Location = new System.Drawing.Point(1123, 6);
            this._filenameBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._filenameBox.Name = "_filenameBox";
            this._filenameBox.Size = new System.Drawing.Size(642, 35);
            this._filenameBox.TabIndex = 3;
            this._filenameBox.Text = "movie_odd_one_out";
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(1775, 6);
            this._loadButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(137, 42);
            this._loadButton.TabIndex = 4;
            this._loadButton.Text = "Load";
            this._loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // _viewButton
            // 
            this._viewButton.Location = new System.Drawing.Point(1922, 6);
            this._viewButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._viewButton.Name = "_viewButton";
            this._viewButton.Size = new System.Drawing.Size(137, 42);
            this._viewButton.TabIndex = 5;
            this._viewButton.Text = "View";
            this._viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(2069, 6);
            this._saveButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(138, 42);
            this._saveButton.TabIndex = 6;
            this._saveButton.Text = "Save";
            this._saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // _dividerPanel
            // 
            this._dividerPanel.BackColor = System.Drawing.Color.Silver;
            this._rootLayout.SetColumnSpan(this._dividerPanel, 2);
            this._dividerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dividerPanel.Location = new System.Drawing.Point(22, 116);
            this._dividerPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._dividerPanel.Name = "_dividerPanel";
            this._dividerPanel.Size = new System.Drawing.Size(2212, 1);
            this._dividerPanel.TabIndex = 1;
            // 
            // _questionPanel
            // 
            this._questionPanel.ColumnCount = 2;
            this._rootLayout.SetColumnSpan(this._questionPanel, 2);
            this._questionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this._questionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._questionPanel.Controls.Add(this._oddQuestionLabel, 0, 0);
            this._questionPanel.Controls.Add(this._questionBox, 1, 0);
            this._questionPanel.Location = new System.Drawing.Point(22, 120);
            this._questionPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._questionPanel.Name = "_questionPanel";
            this._questionPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this._questionPanel.RowCount = 1;
            this._questionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._questionPanel.Size = new System.Drawing.Size(2202, 92);
            this._questionPanel.TabIndex = 2;
            // 
            // _oddQuestionLabel
            // 
            this._oddQuestionLabel.Location = new System.Drawing.Point(5, 16);
            this._oddQuestionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._oddQuestionLabel.Name = "_oddQuestionLabel";
            this._oddQuestionLabel.Size = new System.Drawing.Size(316, 41);
            this._oddQuestionLabel.TabIndex = 0;
            this._oddQuestionLabel.Text = "Odd-one-out question:";
            this._oddQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _questionBox
            // 
            this._questionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._questionBox.Location = new System.Drawing.Point(331, 22);
            this._questionBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._questionBox.Name = "_questionBox";
            this._questionBox.Size = new System.Drawing.Size(1866, 35);
            this._questionBox.TabIndex = 1;
            this._questionBox.Text = "Which one has not won one of the main acting Oscars?";
            // 
            // _filterPanel
            // 
            this._filterPanel.ColumnCount = 10;
            this._rootLayout.SetColumnSpan(this._filterPanel, 2);
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 405F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this._filterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this._filterPanel.Controls.Add(this._occupationLabel, 0, 0);
            this._filterPanel.Controls.Add(this._occupationCombo, 1, 0);
            this._filterPanel.Controls.Add(this._hasCombo, 2, 0);
            this._filterPanel.Controls.Add(this._awardsPanel, 3, 0);
            this._filterPanel.Controls.Add(this._yearFilter1Group, 4, 0);
            this._filterPanel.Controls.Add(this._yearFilter2Group, 5, 0);
            this._filterPanel.Controls.Add(this._searchButton, 7, 0);
            this._filterPanel.Controls.Add(this._stopButton, 8, 0);
            this._filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filterPanel.Location = new System.Drawing.Point(22, 231);
            this._filterPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._filterPanel.Name = "_filterPanel";
            this._filterPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this._filterPanel.RowCount = 1;
            this._filterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._filterPanel.Size = new System.Drawing.Size(2212, 279);
            this._filterPanel.TabIndex = 3;
            // 
            // _occupationLabel
            // 
            this._occupationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._occupationLabel.Location = new System.Drawing.Point(5, 16);
            this._occupationLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._occupationLabel.Name = "_occupationLabel";
            this._occupationLabel.Size = new System.Drawing.Size(124, 247);
            this._occupationLabel.TabIndex = 0;
            this._occupationLabel.Text = "Occupation";
            this._occupationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _occupationCombo
            // 
            this._occupationCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._occupationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._occupationCombo.DropDownWidth = 169;
            this._occupationCombo.Items.AddRange(new object[] {
            "Actor",
            "Director"});
            this._occupationCombo.Location = new System.Drawing.Point(139, 22);
            this._occupationCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._occupationCombo.Name = "_occupationCombo";
            this._occupationCombo.Size = new System.Drawing.Size(179, 38);
            this._occupationCombo.TabIndex = 1;
            // 
            // _hasCombo
            // 
            this._hasCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this._hasCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._hasCombo.Items.AddRange(new object[] {
            "has",
            "has not"});
            this._hasCombo.Location = new System.Drawing.Point(328, 22);
            this._hasCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._hasCombo.Name = "_hasCombo";
            this._hasCombo.Size = new System.Drawing.Size(148, 38);
            this._hasCombo.TabIndex = 2;
            // 
            // _awardsPanel
            // 
            this._awardsPanel.Controls.Add(this._bestActorCheck);
            this._awardsPanel.Controls.Add(this._bestActressCheck);
            this._awardsPanel.Controls.Add(this._bestSupportingActorCheck);
            this._awardsPanel.Controls.Add(this._bestSupportingActressCheck);
            this._awardsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._awardsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._awardsPanel.Location = new System.Drawing.Point(486, 22);
            this._awardsPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._awardsPanel.Name = "_awardsPanel";
            this._awardsPanel.Size = new System.Drawing.Size(395, 235);
            this._awardsPanel.TabIndex = 3;
            this._awardsPanel.WrapContents = false;
            // 
            // _bestActorCheck
            // 
            this._bestActorCheck.AutoSize = true;
            this._bestActorCheck.Checked = true;
            this._bestActorCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this._bestActorCheck.Location = new System.Drawing.Point(5, 6);
            this._bestActorCheck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bestActorCheck.Name = "_bestActorCheck";
            this._bestActorCheck.Size = new System.Drawing.Size(134, 34);
            this._bestActorCheck.TabIndex = 0;
            this._bestActorCheck.Text = "Best Actor";
            // 
            // _bestActressCheck
            // 
            this._bestActressCheck.AutoSize = true;
            this._bestActressCheck.Checked = true;
            this._bestActressCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this._bestActressCheck.Location = new System.Drawing.Point(5, 52);
            this._bestActressCheck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bestActressCheck.Name = "_bestActressCheck";
            this._bestActressCheck.Size = new System.Drawing.Size(151, 34);
            this._bestActressCheck.TabIndex = 1;
            this._bestActressCheck.Text = "Best Actress";
            // 
            // _bestSupportingActorCheck
            // 
            this._bestSupportingActorCheck.AutoSize = true;
            this._bestSupportingActorCheck.Checked = true;
            this._bestSupportingActorCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this._bestSupportingActorCheck.Location = new System.Drawing.Point(5, 98);
            this._bestSupportingActorCheck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bestSupportingActorCheck.Name = "_bestSupportingActorCheck";
            this._bestSupportingActorCheck.Size = new System.Drawing.Size(242, 34);
            this._bestSupportingActorCheck.TabIndex = 2;
            this._bestSupportingActorCheck.Text = "Best Supporting Actor";
            // 
            // _bestSupportingActressCheck
            // 
            this._bestSupportingActressCheck.AutoSize = true;
            this._bestSupportingActressCheck.Checked = true;
            this._bestSupportingActressCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this._bestSupportingActressCheck.Location = new System.Drawing.Point(5, 144);
            this._bestSupportingActressCheck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._bestSupportingActressCheck.Name = "_bestSupportingActressCheck";
            this._bestSupportingActressCheck.Size = new System.Drawing.Size(259, 34);
            this._bestSupportingActressCheck.TabIndex = 3;
            this._bestSupportingActressCheck.Text = "Best Supporting Actress";
            // 
            // _yearFilter1Group
            // 
            this._yearFilter1Group.Controls.Add(this._yearFilter1Layout);
            this._yearFilter1Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this._yearFilter1Group.Location = new System.Drawing.Point(891, 22);
            this._yearFilter1Group.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter1Group.Name = "_yearFilter1Group";
            this._yearFilter1Group.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this._yearFilter1Group.Size = new System.Drawing.Size(408, 235);
            this._yearFilter1Group.TabIndex = 4;
            this._yearFilter1Group.TabStop = false;
            this._yearFilter1Group.Text = "Year filter";
            // 
            // _yearFilter1Layout
            // 
            this._yearFilter1Layout.ColumnCount = 3;
            this._yearFilter1Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this._yearFilter1Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this._yearFilter1Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this._yearFilter1Layout.Controls.Add(this._yearFilter1FieldCombo, 0, 0);
            this._yearFilter1Layout.Controls.Add(this._yearFilter1OperatorCombo, 1, 0);
            this._yearFilter1Layout.Controls.Add(this._yearFilter1YearBox, 2, 0);
            this._yearFilter1Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._yearFilter1Layout.Location = new System.Drawing.Point(14, 44);
            this._yearFilter1Layout.Name = "_yearFilter1Layout";
            this._yearFilter1Layout.RowCount = 1;
            this._yearFilter1Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._yearFilter1Layout.Size = new System.Drawing.Size(380, 175);
            this._yearFilter1Layout.TabIndex = 0;
            // 
            // _yearFilter1FieldCombo
            // 
            this._yearFilter1FieldCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter1FieldCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearFilter1FieldCombo.Items.AddRange(new object[] {
            "Ignore",
            "Date of Birth",
            "Year of award"});
            this._yearFilter1FieldCombo.Location = new System.Drawing.Point(5, 6);
            this._yearFilter1FieldCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter1FieldCombo.Name = "_yearFilter1FieldCombo";
            this._yearFilter1FieldCombo.Size = new System.Drawing.Size(149, 38);
            this._yearFilter1FieldCombo.TabIndex = 0;
            // 
            // _yearFilter1OperatorCombo
            // 
            this._yearFilter1OperatorCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter1OperatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearFilter1OperatorCombo.Items.AddRange(new object[] {
            ">",
            "=",
            "<"});
            this._yearFilter1OperatorCombo.Location = new System.Drawing.Point(164, 6);
            this._yearFilter1OperatorCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter1OperatorCombo.Name = "_yearFilter1OperatorCombo";
            this._yearFilter1OperatorCombo.Size = new System.Drawing.Size(107, 38);
            this._yearFilter1OperatorCombo.TabIndex = 1;
            // 
            // _yearFilter1YearBox
            // 
            this._yearFilter1YearBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter1YearBox.Location = new System.Drawing.Point(281, 6);
            this._yearFilter1YearBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter1YearBox.Name = "_yearFilter1YearBox";
            this._yearFilter1YearBox.PlaceholderText = "Year";
            this._yearFilter1YearBox.Size = new System.Drawing.Size(94, 35);
            this._yearFilter1YearBox.TabIndex = 2;
            // 
            // _yearFilter2Group
            // 
            this._yearFilter2Group.Controls.Add(this._yearFilter2Layout);
            this._yearFilter2Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this._yearFilter2Group.Location = new System.Drawing.Point(1309, 22);
            this._yearFilter2Group.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter2Group.Name = "_yearFilter2Group";
            this._yearFilter2Group.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this._yearFilter2Group.Size = new System.Drawing.Size(408, 235);
            this._yearFilter2Group.TabIndex = 5;
            this._yearFilter2Group.TabStop = false;
            this._yearFilter2Group.Text = "Year filter";
            // 
            // _yearFilter2Layout
            // 
            this._yearFilter2Layout.ColumnCount = 3;
            this._yearFilter2Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this._yearFilter2Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
            this._yearFilter2Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this._yearFilter2Layout.Controls.Add(this._yearFilter2FieldCombo, 0, 0);
            this._yearFilter2Layout.Controls.Add(this._yearFilter2OperatorCombo, 1, 0);
            this._yearFilter2Layout.Controls.Add(this._yearFilter2YearBox, 2, 0);
            this._yearFilter2Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._yearFilter2Layout.Location = new System.Drawing.Point(14, 44);
            this._yearFilter2Layout.Name = "_yearFilter2Layout";
            this._yearFilter2Layout.RowCount = 1;
            this._yearFilter2Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._yearFilter2Layout.Size = new System.Drawing.Size(380, 175);
            this._yearFilter2Layout.TabIndex = 0;
            // 
            // _yearFilter2FieldCombo
            // 
            this._yearFilter2FieldCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter2FieldCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearFilter2FieldCombo.Items.AddRange(new object[] {
            "Ignore",
            "Date of Birth",
            "Year of award"});
            this._yearFilter2FieldCombo.Location = new System.Drawing.Point(5, 6);
            this._yearFilter2FieldCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter2FieldCombo.Name = "_yearFilter2FieldCombo";
            this._yearFilter2FieldCombo.Size = new System.Drawing.Size(149, 38);
            this._yearFilter2FieldCombo.TabIndex = 0;
            // 
            // _yearFilter2OperatorCombo
            // 
            this._yearFilter2OperatorCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter2OperatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._yearFilter2OperatorCombo.Items.AddRange(new object[] {
            ">",
            "=",
            "<"});
            this._yearFilter2OperatorCombo.Location = new System.Drawing.Point(164, 6);
            this._yearFilter2OperatorCombo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter2OperatorCombo.Name = "_yearFilter2OperatorCombo";
            this._yearFilter2OperatorCombo.Size = new System.Drawing.Size(107, 38);
            this._yearFilter2OperatorCombo.TabIndex = 1;
            // 
            // _yearFilter2YearBox
            // 
            this._yearFilter2YearBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._yearFilter2YearBox.Location = new System.Drawing.Point(281, 6);
            this._yearFilter2YearBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._yearFilter2YearBox.Name = "_yearFilter2YearBox";
            this._yearFilter2YearBox.PlaceholderText = "Year";
            this._yearFilter2YearBox.Size = new System.Drawing.Size(94, 35);
            this._yearFilter2YearBox.TabIndex = 2;
            // 
            // _searchButton
            // 
            this._searchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._searchButton.Location = new System.Drawing.Point(1874, 22);
            this._searchButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(158, 68);
            this._searchButton.TabIndex = 6;
            this._searchButton.Text = "Search";
            this._searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // _stopButton
            // 
            this._stopButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._stopButton.Enabled = false;
            this._stopButton.Location = new System.Drawing.Point(2042, 22);
            this._stopButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(158, 68);
            this._stopButton.TabIndex = 7;
            this._stopButton.Text = "Stop";
            this._stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // _resultsPanel
            // 
            this._resultsPanel.AutoScroll = true;
            this._resultsPanel.BackColor = System.Drawing.Color.White;
            this._resultsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._resultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._resultsPanel.Location = new System.Drawing.Point(22, 522);
            this._resultsPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._resultsPanel.Name = "_resultsPanel";
            this._resultsPanel.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this._resultsPanel.Size = new System.Drawing.Size(1678, 762);
            this._resultsPanel.TabIndex = 4;
            // 
            // _selectedOuterPanel
            // 
            this._selectedOuterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._selectedOuterPanel.ColumnCount = 1;
            this._selectedOuterPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._selectedOuterPanel.Controls.Add(this._selectedTitleLabel, 0, 0);
            this._selectedOuterPanel.Controls.Add(this._selectedPanel, 0, 1);
            this._selectedOuterPanel.Controls.Add(this._completeQuestionButton, 0, 2);
            this._selectedOuterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedOuterPanel.Location = new System.Drawing.Point(1710, 522);
            this._selectedOuterPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._selectedOuterPanel.Name = "_selectedOuterPanel";
            this._selectedOuterPanel.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            this._selectedOuterPanel.RowCount = 3;
            this._selectedOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this._selectedOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._selectedOuterPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this._selectedOuterPanel.Size = new System.Drawing.Size(524, 762);
            this._selectedOuterPanel.TabIndex = 5;
            // 
            // _selectedTitleLabel
            // 
            this._selectedTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._selectedTitleLabel.Location = new System.Drawing.Point(19, 16);
            this._selectedTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._selectedTitleLabel.Name = "_selectedTitleLabel";
            this._selectedTitleLabel.Size = new System.Drawing.Size(484, 68);
            this._selectedTitleLabel.TabIndex = 0;
            this._selectedTitleLabel.Text = "Selected for current question";
            this._selectedTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _selectedPanel
            // 
            this._selectedPanel.AutoScroll = true;
            this._selectedPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this._selectedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._selectedPanel.Location = new System.Drawing.Point(19, 90);
            this._selectedPanel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._selectedPanel.Name = "_selectedPanel";
            this._selectedPanel.Size = new System.Drawing.Size(484, 564);
            this._selectedPanel.TabIndex = 1;
            this._selectedPanel.WrapContents = false;
            // 
            // _completeQuestionButton
            // 
            this._completeQuestionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._completeQuestionButton.Location = new System.Drawing.Point(19, 666);
            this._completeQuestionButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this._completeQuestionButton.Name = "_completeQuestionButton";
            this._completeQuestionButton.Size = new System.Drawing.Size(484, 72);
            this._completeQuestionButton.TabIndex = 2;
            this._completeQuestionButton.Text = "Complete Question";
            this._completeQuestionButton.Click += new System.EventHandler(this.CompleteQuestionButton_Click);
            // 
            // _statusLabel
            // 
            this._rootLayout.SetColumnSpan(this._statusLabel, 2);
            this._statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statusLabel.Location = new System.Drawing.Point(22, 1290);
            this._statusLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(2212, 64);
            this._statusLabel.TabIndex = 6;
            this._statusLabel.Text = "Ready. Build a query, then press Search.";
            this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MoviesActivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._rootLayout);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MoviesActivityControl";
            this.Size = new System.Drawing.Size(2256, 1374);
            this._rootLayout.ResumeLayout(false);
            this._headerPanel.ResumeLayout(false);
            this._headerPanel.PerformLayout();
            this._questionPanel.ResumeLayout(false);
            this._questionPanel.PerformLayout();
            this._filterPanel.ResumeLayout(false);
            this._awardsPanel.ResumeLayout(false);
            this._awardsPanel.PerformLayout();
            this._yearFilter1Group.ResumeLayout(false);
            this._yearFilter1Layout.ResumeLayout(false);
            this._yearFilter1Layout.PerformLayout();
            this._yearFilter2Group.ResumeLayout(false);
            this._yearFilter2Layout.ResumeLayout(false);
            this._yearFilter2Layout.PerformLayout();
            this._selectedOuterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

    }
}
