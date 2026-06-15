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
        _rootLayout = new TableLayoutPanel();
        _headerPanel = new TableLayoutPanel();
        _activityTitleLabel = new Label();
        _titleBox = new TextBox();
        _rootFilenameLabel = new Label();
        _filenameBox = new TextBox();
        _loadButton = new Button();
        _viewButton = new Button();
        _saveButton = new Button();
        _dividerPanel = new Panel();
        _questionPanel = new TableLayoutPanel();
        _oddQuestionLabel = new Label();
        _questionBox = new TextBox();
        _filterPanel = new TableLayoutPanel();
        _occupationLabel = new Label();
        _occupationCombo = new ComboBox();
        _hasCombo = new ComboBox();
        _awardsPanel = new FlowLayoutPanel();
        _bestActorCheck = new CheckBox();
        _bestActressCheck = new CheckBox();
        _bestSupportingActorCheck = new CheckBox();
        _bestSupportingActressCheck = new CheckBox();
        _yearFilter1Group = new GroupBox();
        _yearFilter1Layout = new TableLayoutPanel();
        _yearFilter1FieldCombo = new ComboBox();
        _yearFilter1OperatorCombo = new ComboBox();
        _yearFilter1YearBox = new TextBox();
        _yearFilter2Group = new GroupBox();
        _yearFilter2Layout = new TableLayoutPanel();
        _yearFilter2FieldCombo = new ComboBox();
        _yearFilter2OperatorCombo = new ComboBox();
        _yearFilter2YearBox = new TextBox();
        _searchButton = new Button();
        _stopButton = new Button();
        _resultsPanel = new FlowLayoutPanel();
        _selectedOuterPanel = new TableLayoutPanel();
        _selectedTitleLabel = new Label();
        _selectedPanel = new FlowLayoutPanel();
        _completeQuestionButton = new Button();
        _statusLabel = new Label();
        _rootLayout.SuspendLayout();
        _headerPanel.SuspendLayout();
        _questionPanel.SuspendLayout();
        _filterPanel.SuspendLayout();
        _awardsPanel.SuspendLayout();
        _yearFilter1Group.SuspendLayout();
        _yearFilter1Layout.SuspendLayout();
        _yearFilter2Group.SuspendLayout();
        _yearFilter2Layout.SuspendLayout();
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
        _rootLayout.Controls.Add(_questionPanel, 0, 2);
        _rootLayout.Controls.Add(_filterPanel, 0, 3);
        _rootLayout.Controls.Add(_resultsPanel, 0, 4);
        _rootLayout.Controls.Add(_selectedOuterPanel, 1, 4);
        _rootLayout.Controls.Add(_statusLabel, 0, 5);
        _rootLayout.Dock = DockStyle.Fill;
        _rootLayout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        _rootLayout.Location = new Point(0, 0);
        _rootLayout.Name = "_rootLayout";
        _rootLayout.Padding = new Padding(10);
        _rootLayout.RowCount = 6;
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 146F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        _rootLayout.Size = new Size(1316, 687);
        _rootLayout.TabIndex = 0;
        // 
        // _headerPanel
        // 
        _headerPanel.ColumnCount = 7;
        _rootLayout.SetColumnSpan(_headerPanel, 2);
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
        _headerPanel.Controls.Add(_activityTitleLabel, 0, 0);
        _headerPanel.Controls.Add(_titleBox, 1, 0);
        _headerPanel.Controls.Add(_rootFilenameLabel, 2, 0);
        _headerPanel.Controls.Add(_filenameBox, 3, 0);
        _headerPanel.Controls.Add(_loadButton, 4, 0);
        _headerPanel.Controls.Add(_viewButton, 5, 0);
        _headerPanel.Controls.Add(_saveButton, 6, 0);
        _headerPanel.Dock = DockStyle.Fill;
        _headerPanel.Location = new Point(13, 13);
        _headerPanel.Name = "_headerPanel";
        _headerPanel.RowCount = 1;
        _headerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        _headerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        _headerPanel.Size = new Size(1290, 39);
        _headerPanel.TabIndex = 0;
        // 
        // _activityTitleLabel
        // 
        _activityTitleLabel.Location = new Point(3, 0);
        _activityTitleLabel.Name = "_activityTitleLabel";
        _activityTitleLabel.Size = new Size(103, 24);
        _activityTitleLabel.TabIndex = 0;
        _activityTitleLabel.Text = "Activity title:";
        _activityTitleLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _titleBox
        // 
        _titleBox.Dock = DockStyle.Fill;
        _titleBox.Location = new Point(113, 3);
        _titleBox.Name = "_titleBox";
        _titleBox.Size = new Size(403, 23);
        _titleBox.TabIndex = 1;
        _titleBox.Text = "Which movie star is the odd one out?";
        _titleBox.TextChanged += TitleBox_TextChanged;
        // 
        // _rootFilenameLabel
        // 
        _rootFilenameLabel.Location = new Point(522, 0);
        _rootFilenameLabel.Name = "_rootFilenameLabel";
        _rootFilenameLabel.Size = new Size(123, 24);
        _rootFilenameLabel.TabIndex = 2;
        _rootFilenameLabel.Text = "Root JSON filename:";
        _rootFilenameLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filenameBox
        // 
        _filenameBox.Dock = DockStyle.Fill;
        _filenameBox.Location = new Point(652, 3);
        _filenameBox.Name = "_filenameBox";
        _filenameBox.Size = new Size(372, 23);
        _filenameBox.TabIndex = 3;
        _filenameBox.Text = "movie_odd_one_out";
        // 
        // _loadButton
        // 
        _loadButton.Location = new Point(1030, 3);
        _loadButton.Name = "_loadButton";
        _loadButton.Size = new Size(80, 21);
        _loadButton.TabIndex = 4;
        _loadButton.Text = "Load";
        _loadButton.Click += LoadButton_Click;
        // 
        // _viewButton
        // 
        _viewButton.Location = new Point(1116, 3);
        _viewButton.Name = "_viewButton";
        _viewButton.Size = new Size(80, 21);
        _viewButton.TabIndex = 5;
        _viewButton.Text = "View";
        _viewButton.Click += ViewButton_Click;
        // 
        // _saveButton
        // 
        _saveButton.Location = new Point(1202, 3);
        _saveButton.Name = "_saveButton";
        _saveButton.Size = new Size(80, 21);
        _saveButton.TabIndex = 6;
        _saveButton.Text = "Save";
        _saveButton.Click += SaveButton_Click;
        // 
        // _dividerPanel
        // 
        _dividerPanel.BackColor = Color.Silver;
        _rootLayout.SetColumnSpan(_dividerPanel, 2);
        _dividerPanel.Dock = DockStyle.Fill;
        _dividerPanel.Location = new Point(13, 58);
        _dividerPanel.Name = "_dividerPanel";
        _dividerPanel.Size = new Size(1290, 1);
        _dividerPanel.TabIndex = 1;
        // 
        // _questionPanel
        // 
        _questionPanel.ColumnCount = 2;
        _rootLayout.SetColumnSpan(_questionPanel, 2);
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _questionPanel.Controls.Add(_oddQuestionLabel, 0, 0);
        _questionPanel.Controls.Add(_questionBox, 1, 0);
        _questionPanel.Location = new Point(13, 60);
        _questionPanel.Name = "_questionPanel";
        _questionPanel.Padding = new Padding(0, 8, 0, 8);
        _questionPanel.RowCount = 1;
        _questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        _questionPanel.Size = new Size(1284, 46);
        _questionPanel.TabIndex = 2;
        // 
        // _oddQuestionLabel
        // 
        _oddQuestionLabel.Location = new Point(3, 8);
        _oddQuestionLabel.Name = "_oddQuestionLabel";
        _oddQuestionLabel.Size = new Size(184, 20);
        _oddQuestionLabel.TabIndex = 0;
        _oddQuestionLabel.Text = "Odd-one-out question:";
        _oddQuestionLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _questionBox
        // 
        _questionBox.Dock = DockStyle.Fill;
        _questionBox.Location = new Point(193, 11);
        _questionBox.Name = "_questionBox";
        _questionBox.Size = new Size(1088, 23);
        _questionBox.TabIndex = 1;
        _questionBox.Text = "Which one has not won one of the main acting Oscars?";
        // 
        // _filterPanel
        // 
        _filterPanel.ColumnCount = 10;
        _rootLayout.SetColumnSpan(_filterPanel, 2);
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 236F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 244F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 244F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4F));
        _filterPanel.Controls.Add(_occupationLabel, 0, 0);
        _filterPanel.Controls.Add(_occupationCombo, 1, 0);
        _filterPanel.Controls.Add(_hasCombo, 2, 0);
        _filterPanel.Controls.Add(_awardsPanel, 3, 0);
        _filterPanel.Controls.Add(_yearFilter1Group, 4, 0);
        _filterPanel.Controls.Add(_yearFilter2Group, 5, 0);
        _filterPanel.Controls.Add(_searchButton, 7, 0);
        _filterPanel.Controls.Add(_stopButton, 8, 0);
        _filterPanel.Dock = DockStyle.Fill;
        _filterPanel.Location = new Point(13, 116);
        _filterPanel.Name = "_filterPanel";
        _filterPanel.Padding = new Padding(0, 8, 0, 8);
        _filterPanel.RowCount = 1;
        _filterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
        _filterPanel.Size = new Size(1290, 140);
        _filterPanel.TabIndex = 3;
        // 
        // _occupationLabel
        // 
        _occupationLabel.Dock = DockStyle.Fill;
        _occupationLabel.Location = new Point(3, 8);
        _occupationLabel.Name = "_occupationLabel";
        _occupationLabel.Size = new Size(72, 124);
        _occupationLabel.TabIndex = 0;
        _occupationLabel.Text = "Occupation";
        _occupationLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _occupationCombo
        // 
        _occupationCombo.Dock = DockStyle.Fill;
        _occupationCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _occupationCombo.DropDownWidth = 169;
        _occupationCombo.Items.AddRange(new object[] { "Actor", "Director" });
        _occupationCombo.Location = new Point(81, 11);
        _occupationCombo.Name = "_occupationCombo";
        _occupationCombo.Size = new Size(104, 23);
        _occupationCombo.TabIndex = 1;
        // 
        // _hasCombo
        // 
        _hasCombo.Dock = DockStyle.Top;
        _hasCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _hasCombo.Items.AddRange(new object[] { "has", "has not" });
        _hasCombo.Location = new Point(191, 11);
        _hasCombo.Name = "_hasCombo";
        _hasCombo.Size = new Size(86, 23);
        _hasCombo.TabIndex = 2;
        // 
        // _awardsPanel
        // 
        _awardsPanel.Controls.Add(_bestActorCheck);
        _awardsPanel.Controls.Add(_bestActressCheck);
        _awardsPanel.Controls.Add(_bestSupportingActorCheck);
        _awardsPanel.Controls.Add(_bestSupportingActressCheck);
        _awardsPanel.Dock = DockStyle.Fill;
        _awardsPanel.FlowDirection = FlowDirection.TopDown;
        _awardsPanel.Location = new Point(283, 11);
        _awardsPanel.Name = "_awardsPanel";
        _awardsPanel.Size = new Size(230, 118);
        _awardsPanel.TabIndex = 3;
        _awardsPanel.WrapContents = false;
        // 
        // _bestActorCheck
        // 
        _bestActorCheck.AutoSize = true;
        _bestActorCheck.Checked = true;
        _bestActorCheck.CheckState = CheckState.Checked;
        _bestActorCheck.Location = new Point(3, 3);
        _bestActorCheck.Name = "_bestActorCheck";
        _bestActorCheck.Size = new Size(80, 19);
        _bestActorCheck.TabIndex = 0;
        _bestActorCheck.Text = "Best Actor";
        // 
        // _bestActressCheck
        // 
        _bestActressCheck.AutoSize = true;
        _bestActressCheck.Checked = true;
        _bestActressCheck.CheckState = CheckState.Checked;
        _bestActressCheck.Location = new Point(3, 28);
        _bestActressCheck.Name = "_bestActressCheck";
        _bestActressCheck.Size = new Size(89, 19);
        _bestActressCheck.TabIndex = 1;
        _bestActressCheck.Text = "Best Actress";
        // 
        // _bestSupportingActorCheck
        // 
        _bestSupportingActorCheck.AutoSize = true;
        _bestSupportingActorCheck.Checked = true;
        _bestSupportingActorCheck.CheckState = CheckState.Checked;
        _bestSupportingActorCheck.Location = new Point(3, 53);
        _bestSupportingActorCheck.Name = "_bestSupportingActorCheck";
        _bestSupportingActorCheck.Size = new Size(142, 19);
        _bestSupportingActorCheck.TabIndex = 2;
        _bestSupportingActorCheck.Text = "Best Supporting Actor";
        // 
        // _bestSupportingActressCheck
        // 
        _bestSupportingActressCheck.AutoSize = true;
        _bestSupportingActressCheck.Checked = true;
        _bestSupportingActressCheck.CheckState = CheckState.Checked;
        _bestSupportingActressCheck.Location = new Point(3, 78);
        _bestSupportingActressCheck.Name = "_bestSupportingActressCheck";
        _bestSupportingActressCheck.Size = new Size(151, 19);
        _bestSupportingActressCheck.TabIndex = 3;
        _bestSupportingActressCheck.Text = "Best Supporting Actress";
        // 
        // _yearFilter1Group
        // 
        _yearFilter1Group.Controls.Add(_yearFilter1Layout);
        _yearFilter1Group.Dock = DockStyle.Fill;
        _yearFilter1Group.Location = new Point(519, 11);
        _yearFilter1Group.Name = "_yearFilter1Group";
        _yearFilter1Group.Padding = new Padding(8);
        _yearFilter1Group.Size = new Size(238, 118);
        _yearFilter1Group.TabIndex = 4;
        _yearFilter1Group.TabStop = false;
        _yearFilter1Group.Text = "Year filter";
        // 
        // _yearFilter1Layout
        // 
        _yearFilter1Layout.ColumnCount = 3;
        _yearFilter1Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        _yearFilter1Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
        _yearFilter1Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
        _yearFilter1Layout.Controls.Add(_yearFilter1FieldCombo, 0, 0);
        _yearFilter1Layout.Controls.Add(_yearFilter1OperatorCombo, 1, 0);
        _yearFilter1Layout.Controls.Add(_yearFilter1YearBox, 2, 0);
        _yearFilter1Layout.Dock = DockStyle.Fill;
        _yearFilter1Layout.Location = new Point(8, 24);
        _yearFilter1Layout.Margin = new Padding(2);
        _yearFilter1Layout.Name = "_yearFilter1Layout";
        _yearFilter1Layout.RowCount = 1;
        _yearFilter1Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _yearFilter1Layout.Size = new Size(222, 86);
        _yearFilter1Layout.TabIndex = 0;
        // 
        // _yearFilter1FieldCombo
        // 
        _yearFilter1FieldCombo.Dock = DockStyle.Top;
        _yearFilter1FieldCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _yearFilter1FieldCombo.Items.AddRange(new object[] { "Ignore", "Date of Birth", "Year of award" });
        _yearFilter1FieldCombo.Location = new Point(3, 3);
        _yearFilter1FieldCombo.Name = "_yearFilter1FieldCombo";
        _yearFilter1FieldCombo.Size = new Size(87, 23);
        _yearFilter1FieldCombo.TabIndex = 0;
        // 
        // _yearFilter1OperatorCombo
        // 
        _yearFilter1OperatorCombo.Dock = DockStyle.Top;
        _yearFilter1OperatorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _yearFilter1OperatorCombo.Items.AddRange(new object[] { ">", "=", "<" });
        _yearFilter1OperatorCombo.Location = new Point(96, 3);
        _yearFilter1OperatorCombo.Name = "_yearFilter1OperatorCombo";
        _yearFilter1OperatorCombo.Size = new Size(62, 23);
        _yearFilter1OperatorCombo.TabIndex = 1;
        // 
        // _yearFilter1YearBox
        // 
        _yearFilter1YearBox.Dock = DockStyle.Top;
        _yearFilter1YearBox.Location = new Point(164, 3);
        _yearFilter1YearBox.Name = "_yearFilter1YearBox";
        _yearFilter1YearBox.PlaceholderText = "Year";
        _yearFilter1YearBox.Size = new Size(55, 23);
        _yearFilter1YearBox.TabIndex = 2;
        // 
        // _yearFilter2Group
        // 
        _yearFilter2Group.Controls.Add(_yearFilter2Layout);
        _yearFilter2Group.Dock = DockStyle.Fill;
        _yearFilter2Group.Location = new Point(763, 11);
        _yearFilter2Group.Name = "_yearFilter2Group";
        _yearFilter2Group.Padding = new Padding(8);
        _yearFilter2Group.Size = new Size(238, 118);
        _yearFilter2Group.TabIndex = 5;
        _yearFilter2Group.TabStop = false;
        _yearFilter2Group.Text = "Year filter";
        // 
        // _yearFilter2Layout
        // 
        _yearFilter2Layout.ColumnCount = 3;
        _yearFilter2Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        _yearFilter2Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
        _yearFilter2Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
        _yearFilter2Layout.Controls.Add(_yearFilter2FieldCombo, 0, 0);
        _yearFilter2Layout.Controls.Add(_yearFilter2OperatorCombo, 1, 0);
        _yearFilter2Layout.Controls.Add(_yearFilter2YearBox, 2, 0);
        _yearFilter2Layout.Dock = DockStyle.Fill;
        _yearFilter2Layout.Location = new Point(8, 24);
        _yearFilter2Layout.Margin = new Padding(2);
        _yearFilter2Layout.Name = "_yearFilter2Layout";
        _yearFilter2Layout.RowCount = 1;
        _yearFilter2Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _yearFilter2Layout.Size = new Size(222, 86);
        _yearFilter2Layout.TabIndex = 0;
        // 
        // _yearFilter2FieldCombo
        // 
        _yearFilter2FieldCombo.Dock = DockStyle.Top;
        _yearFilter2FieldCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _yearFilter2FieldCombo.Items.AddRange(new object[] { "Ignore", "Date of Birth", "Year of award" });
        _yearFilter2FieldCombo.Location = new Point(3, 3);
        _yearFilter2FieldCombo.Name = "_yearFilter2FieldCombo";
        _yearFilter2FieldCombo.Size = new Size(87, 23);
        _yearFilter2FieldCombo.TabIndex = 0;
        // 
        // _yearFilter2OperatorCombo
        // 
        _yearFilter2OperatorCombo.Dock = DockStyle.Top;
        _yearFilter2OperatorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _yearFilter2OperatorCombo.Items.AddRange(new object[] { ">", "=", "<" });
        _yearFilter2OperatorCombo.Location = new Point(96, 3);
        _yearFilter2OperatorCombo.Name = "_yearFilter2OperatorCombo";
        _yearFilter2OperatorCombo.Size = new Size(62, 23);
        _yearFilter2OperatorCombo.TabIndex = 1;
        // 
        // _yearFilter2YearBox
        // 
        _yearFilter2YearBox.Dock = DockStyle.Top;
        _yearFilter2YearBox.Location = new Point(164, 3);
        _yearFilter2YearBox.Name = "_yearFilter2YearBox";
        _yearFilter2YearBox.PlaceholderText = "Year";
        _yearFilter2YearBox.Size = new Size(55, 23);
        _yearFilter2YearBox.TabIndex = 2;
        // 
        // _searchButton
        // 
        _searchButton.Dock = DockStyle.Top;
        _searchButton.Location = new Point(1093, 11);
        _searchButton.Name = "_searchButton";
        _searchButton.Size = new Size(92, 34);
        _searchButton.TabIndex = 6;
        _searchButton.Text = "Search";
        _searchButton.Click += SearchButton_Click;
        // 
        // _stopButton
        // 
        _stopButton.Dock = DockStyle.Top;
        _stopButton.Enabled = false;
        _stopButton.Location = new Point(1191, 11);
        _stopButton.Name = "_stopButton";
        _stopButton.Size = new Size(92, 34);
        _stopButton.TabIndex = 7;
        _stopButton.Text = "Stop";
        _stopButton.Click += StopButton_Click;
        // 
        // _resultsPanel
        // 
        _resultsPanel.AutoScroll = true;
        _resultsPanel.BackColor = Color.White;
        _resultsPanel.BorderStyle = BorderStyle.FixedSingle;
        _resultsPanel.Dock = DockStyle.Fill;
        _resultsPanel.Location = new Point(13, 262);
        _resultsPanel.Name = "_resultsPanel";
        _resultsPanel.Padding = new Padding(8);
        _resultsPanel.Size = new Size(978, 380);
        _resultsPanel.TabIndex = 4;
        // 
        // _selectedOuterPanel
        // 
        _selectedOuterPanel.BorderStyle = BorderStyle.FixedSingle;
        _selectedOuterPanel.ColumnCount = 1;
        _selectedOuterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 288F));
        _selectedOuterPanel.Controls.Add(_selectedTitleLabel, 0, 0);
        _selectedOuterPanel.Controls.Add(_selectedPanel, 0, 1);
        _selectedOuterPanel.Controls.Add(_completeQuestionButton, 0, 2);
        _selectedOuterPanel.Dock = DockStyle.Fill;
        _selectedOuterPanel.Location = new Point(997, 262);
        _selectedOuterPanel.Name = "_selectedOuterPanel";
        _selectedOuterPanel.Padding = new Padding(8);
        _selectedOuterPanel.RowCount = 3;
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        _selectedOuterPanel.Size = new Size(306, 380);
        _selectedOuterPanel.TabIndex = 5;
        // 
        // _selectedTitleLabel
        // 
        _selectedTitleLabel.Dock = DockStyle.Fill;
        _selectedTitleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        _selectedTitleLabel.Location = new Point(11, 8);
        _selectedTitleLabel.Name = "_selectedTitleLabel";
        _selectedTitleLabel.Size = new Size(282, 34);
        _selectedTitleLabel.TabIndex = 0;
        _selectedTitleLabel.Text = "Selected for current question";
        _selectedTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _selectedPanel
        // 
        _selectedPanel.AutoScroll = true;
        _selectedPanel.BackColor = Color.WhiteSmoke;
        _selectedPanel.Dock = DockStyle.Fill;
        _selectedPanel.FlowDirection = FlowDirection.TopDown;
        _selectedPanel.Location = new Point(11, 45);
        _selectedPanel.Name = "_selectedPanel";
        _selectedPanel.Size = new Size(282, 280);
        _selectedPanel.TabIndex = 1;
        _selectedPanel.WrapContents = false;
        // 
        // _completeQuestionButton
        // 
        _completeQuestionButton.Dock = DockStyle.Fill;
        _completeQuestionButton.Location = new Point(11, 331);
        _completeQuestionButton.Name = "_completeQuestionButton";
        _completeQuestionButton.Size = new Size(282, 36);
        _completeQuestionButton.TabIndex = 2;
        _completeQuestionButton.Text = "Complete Question";
        _completeQuestionButton.Click += CompleteQuestionButton_Click;
        // 
        // _statusLabel
        // 
        _rootLayout.SetColumnSpan(_statusLabel, 2);
        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.Location = new Point(13, 645);
        _statusLabel.Name = "_statusLabel";
        _statusLabel.Size = new Size(1290, 32);
        _statusLabel.TabIndex = 6;
        _statusLabel.Text = "Ready. Build a query, then press Search.";
        _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MoviesActivityControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_rootLayout);
        Name = "MoviesActivityControl";
        Size = new Size(1316, 687);
        _rootLayout.ResumeLayout(false);
        _headerPanel.ResumeLayout(false);
        _headerPanel.PerformLayout();
        _questionPanel.ResumeLayout(false);
        _questionPanel.PerformLayout();
        _filterPanel.ResumeLayout(false);
        _awardsPanel.ResumeLayout(false);
        _awardsPanel.PerformLayout();
        _yearFilter1Group.ResumeLayout(false);
        _yearFilter1Layout.ResumeLayout(false);
        _yearFilter1Layout.PerformLayout();
        _yearFilter2Group.ResumeLayout(false);
        _yearFilter2Layout.ResumeLayout(false);
        _yearFilter2Layout.PerformLayout();
        _selectedOuterPanel.ResumeLayout(false);
        ResumeLayout(false);

    }
}
