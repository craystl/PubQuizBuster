namespace PubQuizBuster.ActivityCreator;

partial class GeographyActivityControl
{
    private System.ComponentModel.IContainer components = null!;
    private Label _placeholderLabel = null!;

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
        _placeholderLabel = new Label();
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
        _questionBox = new TextBox();
        _multQuestionLabel = new Label();
        _filterPanel = new TableLayoutPanel();
        _selectContinentPanel = new TableLayoutPanel();
        _continentCombo = new ComboBox();
        _selectContinentLabel = new Label();
        _landmassFilterPanel = new TableLayoutPanel();
        _minAreaLabel = new Label();
        _maxAreaLabel = new Label();
        _maxAreaTextBox = new TextBox();
        _minAreaTextBox = new TextBox();
        _populationFilterPanel = new TableLayoutPanel();
        _minPopulationLabel = new Label();
        _maxPopulationLabel = new Label();
        _maxPopulationTextBox = new TextBox();
        _minPopulationTextBox = new TextBox();
        _selectCategoryPanel = new TableLayoutPanel();
        _selectCategoryLabel = new Label();
        _categoryCombo = new ComboBox();
        _searchPanel = new TableLayoutPanel();
        _stopButton = new Button();
        _searchButton = new Button();
        _correctAnswerPanel = new TableLayoutPanel();
        _correctAnswerLabel = new Label();
        _correctAnswerCheckBox = new CheckBox();
        _filterCountryLayout = new TableLayoutPanel();
        _countrySelectionInfoLabel = new Label();
        _CountryFilterLabel = new Label();
        _countryFilterNameLabel = new Label();
        _resultsPanel = new FlowLayoutPanel();
        _selectedOuterPanel = new TableLayoutPanel();
        _selectedTitleLabel = new Label();
        _selectedPanel = new FlowLayoutPanel();
        _messageTextBox = new TextBox();
        _jsonTextBox = new TextBox();
        _completeQuestionButton = new Button();
        _statusLabel = new Label();
        _rootLayout.SuspendLayout();
        _headerPanel.SuspendLayout();
        _questionPanel.SuspendLayout();
        _filterPanel.SuspendLayout();
        _selectContinentPanel.SuspendLayout();
        _landmassFilterPanel.SuspendLayout();
        _populationFilterPanel.SuspendLayout();
        _selectCategoryPanel.SuspendLayout();
        _searchPanel.SuspendLayout();
        _correctAnswerPanel.SuspendLayout();
        _filterCountryLayout.SuspendLayout();
        _selectedOuterPanel.SuspendLayout();
        _selectedPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _placeholderLabel
        // 
        _placeholderLabel.Dock = DockStyle.Fill;
        _placeholderLabel.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
        _placeholderLabel.ForeColor = Color.DimGray;
        _placeholderLabel.Location = new Point(0, 0);
        _placeholderLabel.Name = "_placeholderLabel";
        _placeholderLabel.Size = new Size(1310, 681);
        _placeholderLabel.TabIndex = 0;
        _placeholderLabel.Text = "Multiple Choice Geography Questions. To be implemented ...";
        _placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _rootLayout
        // 
        _rootLayout.ColumnCount = 2;
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.04651F));
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.95349F));
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
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
        _rootLayout.Size = new Size(1310, 681);
        _rootLayout.TabIndex = 1;
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
        _headerPanel.Size = new Size(1284, 39);
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
        _titleBox.Size = new Size(400, 23);
        _titleBox.TabIndex = 1;
        _titleBox.Text = "Select all correct answers to this geography question";
        // 
        // _rootFilenameLabel
        // 
        _rootFilenameLabel.Location = new Point(519, 0);
        _rootFilenameLabel.Name = "_rootFilenameLabel";
        _rootFilenameLabel.Size = new Size(123, 24);
        _rootFilenameLabel.TabIndex = 2;
        _rootFilenameLabel.Text = "Root JSON filename:";
        _rootFilenameLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filenameBox
        // 
        _filenameBox.Dock = DockStyle.Fill;
        _filenameBox.Location = new Point(649, 3);
        _filenameBox.Name = "_filenameBox";
        _filenameBox.Size = new Size(369, 23);
        _filenameBox.TabIndex = 3;
        _filenameBox.Text = "geography_multiple_choice";
        // 
        // _loadButton
        // 
        _loadButton.Location = new Point(1024, 3);
        _loadButton.Name = "_loadButton";
        _loadButton.Size = new Size(80, 21);
        _loadButton.TabIndex = 4;
        _loadButton.Text = "Load";
        // 
        // _viewButton
        // 
        _viewButton.Location = new Point(1110, 3);
        _viewButton.Name = "_viewButton";
        _viewButton.Size = new Size(80, 21);
        _viewButton.TabIndex = 5;
        _viewButton.Text = "View";
        // 
        // _saveButton
        // 
        _saveButton.Location = new Point(1196, 3);
        _saveButton.Name = "_saveButton";
        _saveButton.Size = new Size(80, 21);
        _saveButton.TabIndex = 6;
        _saveButton.Text = "Save";
        // 
        // _dividerPanel
        // 
        _dividerPanel.BackColor = Color.Silver;
        _rootLayout.SetColumnSpan(_dividerPanel, 2);
        _dividerPanel.Dock = DockStyle.Fill;
        _dividerPanel.Location = new Point(13, 58);
        _dividerPanel.Name = "_dividerPanel";
        _dividerPanel.Size = new Size(1284, 1);
        _dividerPanel.TabIndex = 1;
        // 
        // _questionPanel
        // 
        _questionPanel.ColumnCount = 2;
        _rootLayout.SetColumnSpan(_questionPanel, 2);
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _questionPanel.Controls.Add(_questionBox, 1, 0);
        _questionPanel.Controls.Add(_multQuestionLabel, 0, 0);
        _questionPanel.Location = new Point(13, 60);
        _questionPanel.Name = "_questionPanel";
        _questionPanel.Padding = new Padding(0, 8, 0, 8);
        _questionPanel.RowCount = 2;
        _questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        _questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
        _questionPanel.Size = new Size(1283, 46);
        _questionPanel.TabIndex = 2;
        // 
        // _questionBox
        // 
        _questionBox.Dock = DockStyle.Fill;
        _questionBox.Location = new Point(193, 11);
        _questionBox.Name = "_questionBox";
        _questionBox.Size = new Size(1087, 23);
        _questionBox.TabIndex = 1;
        _questionBox.Text = "What is the Capital City of New Zealand?";
        // 
        // _multQuestionLabel
        // 
        _multQuestionLabel.Anchor = AnchorStyles.None;
        _multQuestionLabel.Location = new Point(3, 13);
        _multQuestionLabel.Name = "_multQuestionLabel";
        _multQuestionLabel.Size = new Size(184, 20);
        _multQuestionLabel.TabIndex = 0;
        _multQuestionLabel.Text = "Multiple-Choice Question:";
        _multQuestionLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filterPanel
        // 
        _filterPanel.ColumnCount = 7;
        _rootLayout.SetColumnSpan(_filterPanel, 2);
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 213F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 199F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 171F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 238F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 214F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
        _filterPanel.Controls.Add(_selectContinentPanel, 0, 0);
        _filterPanel.Controls.Add(_landmassFilterPanel, 4, 0);
        _filterPanel.Controls.Add(_populationFilterPanel, 3, 0);
        _filterPanel.Controls.Add(_selectCategoryPanel, 1, 0);
        _filterPanel.Controls.Add(_searchPanel, 7, 0);
        _filterPanel.Controls.Add(_correctAnswerPanel, 2, 0);
        _filterPanel.Controls.Add(_filterCountryLayout, 5, 0);
        _filterPanel.Dock = DockStyle.Fill;
        _filterPanel.Location = new Point(13, 116);
        _filterPanel.Name = "_filterPanel";
        _filterPanel.Padding = new Padding(0, 8, 0, 8);
        _filterPanel.RowCount = 1;
        _filterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
        _filterPanel.Size = new Size(1284, 140);
        _filterPanel.TabIndex = 3;
        // 
        // _selectContinentPanel
        // 
        _selectContinentPanel.ColumnCount = 1;
        _selectContinentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _selectContinentPanel.Controls.Add(_continentCombo, 0, 1);
        _selectContinentPanel.Controls.Add(_selectContinentLabel, 0, 0);
        _selectContinentPanel.Location = new Point(3, 11);
        _selectContinentPanel.Name = "_selectContinentPanel";
        _selectContinentPanel.RowCount = 2;
        _selectContinentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.59322F));
        _selectContinentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 64.40678F));
        _selectContinentPanel.Size = new Size(207, 118);
        _selectContinentPanel.TabIndex = 9;
        // 
        // _continentCombo
        // 
        _continentCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _continentCombo.FormattingEnabled = true;
        _continentCombo.Items.AddRange(new object[] { "Any", "Europe", "Asia", "Africa", "North America", "South America", "Oceania" });
        _continentCombo.Location = new Point(3, 45);
        _continentCombo.Name = "_continentCombo";
        _continentCombo.Size = new Size(201, 23);
        _continentCombo.TabIndex = 4;
        // 
        // _selectContinentLabel
        // 
        _selectContinentLabel.Anchor = AnchorStyles.None;
        _selectContinentLabel.AutoSize = true;
        _selectContinentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _selectContinentLabel.Location = new Point(49, 11);
        _selectContinentLabel.Name = "_selectContinentLabel";
        _selectContinentLabel.Size = new Size(109, 19);
        _selectContinentLabel.TabIndex = 5;
        _selectContinentLabel.Text = "Select Continent";
        // 
        // _landmassFilterPanel
        // 
        _landmassFilterPanel.ColumnCount = 1;
        _landmassFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _landmassFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _landmassFilterPanel.Controls.Add(_minAreaLabel, 0, 2);
        _landmassFilterPanel.Controls.Add(_maxAreaLabel, 0, 0);
        _landmassFilterPanel.Controls.Add(_maxAreaTextBox, 0, 1);
        _landmassFilterPanel.Controls.Add(_minAreaTextBox, 0, 3);
        _landmassFilterPanel.Location = new Point(660, 11);
        _landmassFilterPanel.Name = "_landmassFilterPanel";
        _landmassFilterPanel.RowCount = 4;
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        _landmassFilterPanel.Size = new Size(169, 118);
        _landmassFilterPanel.TabIndex = 7;
        // 
        // _minAreaLabel
        // 
        _minAreaLabel.Anchor = AnchorStyles.None;
        _minAreaLabel.AutoSize = true;
        _minAreaLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _minAreaLabel.Location = new Point(35, 63);
        _minAreaLabel.Name = "_minAreaLabel";
        _minAreaLabel.Size = new Size(99, 19);
        _minAreaLabel.TabIndex = 6;
        _minAreaLabel.Text = "Min Land Area";
        _minAreaLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxAreaLabel
        // 
        _maxAreaLabel.Anchor = AnchorStyles.None;
        _maxAreaLabel.AutoSize = true;
        _maxAreaLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _maxAreaLabel.Location = new Point(34, 4);
        _maxAreaLabel.Name = "_maxAreaLabel";
        _maxAreaLabel.Size = new Size(101, 19);
        _maxAreaLabel.TabIndex = 5;
        _maxAreaLabel.Text = "Max Land Area";
        _maxAreaLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxAreaTextBox
        // 
        _maxAreaTextBox.Location = new Point(3, 31);
        _maxAreaTextBox.Name = "_maxAreaTextBox";
        _maxAreaTextBox.Size = new Size(163, 23);
        _maxAreaTextBox.TabIndex = 7;
        // 
        // _minAreaTextBox
        // 
        _minAreaTextBox.Location = new Point(3, 91);
        _minAreaTextBox.Name = "_minAreaTextBox";
        _minAreaTextBox.Size = new Size(163, 23);
        _minAreaTextBox.TabIndex = 8;
        // 
        // _populationFilterPanel
        // 
        _populationFilterPanel.ColumnCount = 1;
        _populationFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _populationFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _populationFilterPanel.Controls.Add(_minPopulationLabel, 0, 2);
        _populationFilterPanel.Controls.Add(_maxPopulationLabel, 0, 0);
        _populationFilterPanel.Controls.Add(_maxPopulationTextBox, 0, 1);
        _populationFilterPanel.Controls.Add(_minPopulationTextBox, 0, 3);
        _populationFilterPanel.Location = new Point(489, 11);
        _populationFilterPanel.Name = "_populationFilterPanel";
        _populationFilterPanel.RowCount = 4;
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
        _populationFilterPanel.Size = new Size(164, 118);
        _populationFilterPanel.TabIndex = 5;
        // 
        // _minPopulationLabel
        // 
        _minPopulationLabel.Anchor = AnchorStyles.None;
        _minPopulationLabel.AutoSize = true;
        _minPopulationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _minPopulationLabel.Location = new Point(31, 63);
        _minPopulationLabel.Name = "_minPopulationLabel";
        _minPopulationLabel.Size = new Size(102, 19);
        _minPopulationLabel.TabIndex = 6;
        _minPopulationLabel.Text = "Min Population";
        _minPopulationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxPopulationLabel
        // 
        _maxPopulationLabel.Anchor = AnchorStyles.None;
        _maxPopulationLabel.AutoSize = true;
        _maxPopulationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _maxPopulationLabel.Location = new Point(30, 4);
        _maxPopulationLabel.Name = "_maxPopulationLabel";
        _maxPopulationLabel.Size = new Size(104, 19);
        _maxPopulationLabel.TabIndex = 5;
        _maxPopulationLabel.Text = "Max Population";
        _maxPopulationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxPopulationTextBox
        // 
        _maxPopulationTextBox.Location = new Point(3, 31);
        _maxPopulationTextBox.Name = "_maxPopulationTextBox";
        _maxPopulationTextBox.Size = new Size(158, 23);
        _maxPopulationTextBox.TabIndex = 7;
        // 
        // _minPopulationTextBox
        // 
        _minPopulationTextBox.Location = new Point(3, 91);
        _minPopulationTextBox.Name = "_minPopulationTextBox";
        _minPopulationTextBox.Size = new Size(158, 23);
        _minPopulationTextBox.TabIndex = 8;
        // 
        // _selectCategoryPanel
        // 
        _selectCategoryPanel.ColumnCount = 1;
        _selectCategoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _selectCategoryPanel.Controls.Add(_selectCategoryLabel, 0, 0);
        _selectCategoryPanel.Controls.Add(_categoryCombo, 0, 1);
        _selectCategoryPanel.Location = new Point(216, 11);
        _selectCategoryPanel.Name = "_selectCategoryPanel";
        _selectCategoryPanel.RowCount = 2;
        _selectCategoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.59322F));
        _selectCategoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 64.40678F));
        _selectCategoryPanel.Size = new Size(193, 118);
        _selectCategoryPanel.TabIndex = 8;
        // 
        // _selectCategoryLabel
        // 
        _selectCategoryLabel.Anchor = AnchorStyles.None;
        _selectCategoryLabel.AutoSize = true;
        _selectCategoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _selectCategoryLabel.Location = new Point(44, 11);
        _selectCategoryLabel.Name = "_selectCategoryLabel";
        _selectCategoryLabel.Size = new Size(104, 19);
        _selectCategoryLabel.TabIndex = 6;
        _selectCategoryLabel.Text = "Select Category";
        // 
        // _categoryCombo
        // 
        _categoryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _categoryCombo.FormattingEnabled = true;
        _categoryCombo.Items.AddRange(new object[] { "Country", "State/Territory", "City" });
        _categoryCombo.Location = new Point(3, 45);
        _categoryCombo.Name = "_categoryCombo";
        _categoryCombo.Size = new Size(187, 23);
        _categoryCombo.TabIndex = 4;
        // 
        // _searchPanel
        // 
        _searchPanel.ColumnCount = 1;
        _searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _searchPanel.Controls.Add(_stopButton, 0, 1);
        _searchPanel.Controls.Add(_searchButton, 0, 0);
        _searchPanel.Location = new Point(1073, 11);
        _searchPanel.Name = "_searchPanel";
        _searchPanel.RowCount = 2;
        _searchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _searchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _searchPanel.Size = new Size(207, 118);
        _searchPanel.TabIndex = 10;
        // 
        // _stopButton
        // 
        _stopButton.Anchor = AnchorStyles.None;
        _stopButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        _stopButton.Location = new Point(3, 63);
        _stopButton.Name = "_stopButton";
        _stopButton.Size = new Size(200, 50);
        _stopButton.TabIndex = 2;
        _stopButton.Text = "Stop";
        _stopButton.UseVisualStyleBackColor = true;
        // 
        // _searchButton
        // 
        _searchButton.Anchor = AnchorStyles.None;
        _searchButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        _searchButton.Location = new Point(3, 4);
        _searchButton.Name = "_searchButton";
        _searchButton.Size = new Size(200, 50);
        _searchButton.TabIndex = 1;
        _searchButton.Text = "Search";
        _searchButton.UseVisualStyleBackColor = true;
        _searchButton.Click += _searchButton_Click;
        // 
        // _correctAnswerPanel
        // 
        _correctAnswerPanel.ColumnCount = 1;
        _correctAnswerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _correctAnswerPanel.Controls.Add(_correctAnswerLabel, 0, 0);
        _correctAnswerPanel.Controls.Add(_correctAnswerCheckBox, 0, 1);
        _correctAnswerPanel.Location = new Point(415, 11);
        _correctAnswerPanel.Name = "_correctAnswerPanel";
        _correctAnswerPanel.RowCount = 2;
        _correctAnswerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 36.4406776F));
        _correctAnswerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 63.5593224F));
        _correctAnswerPanel.Size = new Size(67, 118);
        _correctAnswerPanel.TabIndex = 12;
        // 
        // _correctAnswerLabel
        // 
        _correctAnswerLabel.Anchor = AnchorStyles.None;
        _correctAnswerLabel.AutoSize = true;
        _correctAnswerLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _correctAnswerLabel.Location = new Point(3, 2);
        _correctAnswerLabel.Name = "_correctAnswerLabel";
        _correctAnswerLabel.Size = new Size(60, 38);
        _correctAnswerLabel.TabIndex = 5;
        _correctAnswerLabel.Text = "Correct Answer?";
        _correctAnswerLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _correctAnswerCheckBox
        // 
        _correctAnswerCheckBox.Anchor = AnchorStyles.None;
        _correctAnswerCheckBox.CheckAlign = ContentAlignment.MiddleCenter;
        _correctAnswerCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        _correctAnswerCheckBox.Location = new Point(18, 65);
        _correctAnswerCheckBox.Name = "_correctAnswerCheckBox";
        _correctAnswerCheckBox.Size = new Size(30, 30);
        _correctAnswerCheckBox.TabIndex = 6;
        _correctAnswerCheckBox.UseVisualStyleBackColor = true;
        // 
        // _filterCountryLayout
        // 
        _filterCountryLayout.ColumnCount = 1;
        _filterCountryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _filterCountryLayout.Controls.Add(_countrySelectionInfoLabel, 0, 0);
        _filterCountryLayout.Controls.Add(_CountryFilterLabel, 0, 1);
        _filterCountryLayout.Controls.Add(_countryFilterNameLabel, 0, 2);
        _filterCountryLayout.Location = new Point(835, 11);
        _filterCountryLayout.Name = "_filterCountryLayout";
        _filterCountryLayout.RowCount = 3;
        _filterCountryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 73.11828F));
        _filterCountryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 26.88172F));
        _filterCountryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        _filterCountryLayout.Size = new Size(232, 118);
        _filterCountryLayout.TabIndex = 14;
        // 
        // _countrySelectionInfoLabel
        // 
        _countrySelectionInfoLabel.Anchor = AnchorStyles.None;
        _countrySelectionInfoLabel.AutoSize = true;
        _countrySelectionInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        _countrySelectionInfoLabel.Location = new Point(5, 4);
        _countrySelectionInfoLabel.Name = "_countrySelectionInfoLabel";
        _countrySelectionInfoLabel.Size = new Size(221, 60);
        _countrySelectionInfoLabel.TabIndex = 0;
        _countrySelectionInfoLabel.Text = "When searching for countries, click once to select it as a filter, a second time to instead select it as an answer, and a third time for both.";
        _countrySelectionInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _CountryFilterLabel
        // 
        _CountryFilterLabel.Anchor = AnchorStyles.None;
        _CountryFilterLabel.AutoSize = true;
        _CountryFilterLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _CountryFilterLabel.Location = new Point(18, 71);
        _CountryFilterLabel.Name = "_CountryFilterLabel";
        _CountryFilterLabel.Size = new Size(195, 19);
        _CountryFilterLabel.TabIndex = 7;
        _CountryFilterLabel.Text = "Currently Filtering By Country:";
        _CountryFilterLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _countryFilterNameLabel
        // 
        _countryFilterNameLabel.Anchor = AnchorStyles.None;
        _countryFilterNameLabel.AutoSize = true;
        _countryFilterNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _countryFilterNameLabel.Location = new Point(95, 96);
        _countryFilterNameLabel.Name = "_countryFilterNameLabel";
        _countryFilterNameLabel.Size = new Size(42, 19);
        _countryFilterNameLabel.TabIndex = 9;
        _countryFilterNameLabel.Text = "None";
        _countryFilterNameLabel.TextAlign = ContentAlignment.MiddleCenter;
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
        _resultsPanel.Size = new Size(975, 374);
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
        _selectedOuterPanel.Location = new Point(994, 262);
        _selectedOuterPanel.Name = "_selectedOuterPanel";
        _selectedOuterPanel.Padding = new Padding(8);
        _selectedOuterPanel.RowCount = 3;
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        _selectedOuterPanel.Size = new Size(303, 374);
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
        _selectedTitleLabel.Text = "Selected Answers for this Question (Max of 8)";
        _selectedTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _selectedPanel
        // 
        _selectedPanel.AutoScroll = true;
        _selectedPanel.BackColor = Color.WhiteSmoke;
        _selectedPanel.Controls.Add(_messageTextBox);
        _selectedPanel.Controls.Add(_jsonTextBox);
        _selectedPanel.Dock = DockStyle.Fill;
        _selectedPanel.FlowDirection = FlowDirection.TopDown;
        _selectedPanel.Location = new Point(11, 45);
        _selectedPanel.Name = "_selectedPanel";
        _selectedPanel.Size = new Size(282, 274);
        _selectedPanel.TabIndex = 1;
        _selectedPanel.WrapContents = false;
        // 
        // _messageTextBox
        // 
        _messageTextBox.Location = new Point(3, 3);
        _messageTextBox.Name = "_messageTextBox";
        _messageTextBox.Size = new Size(134, 23);
        _messageTextBox.TabIndex = 0;
        // 
        // _jsonTextBox
        // 
        _jsonTextBox.Location = new Point(3, 32);
        _jsonTextBox.Name = "_jsonTextBox";
        _jsonTextBox.Size = new Size(134, 23);
        _jsonTextBox.TabIndex = 1;
        // 
        // _completeQuestionButton
        // 
        _completeQuestionButton.Dock = DockStyle.Fill;
        _completeQuestionButton.Location = new Point(11, 325);
        _completeQuestionButton.Name = "_completeQuestionButton";
        _completeQuestionButton.Size = new Size(282, 36);
        _completeQuestionButton.TabIndex = 2;
        _completeQuestionButton.Text = "Complete Question";
        // 
        // _statusLabel
        // 
        _rootLayout.SetColumnSpan(_statusLabel, 2);
        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.Location = new Point(13, 639);
        _statusLabel.Name = "_statusLabel";
        _statusLabel.Size = new Size(1284, 32);
        _statusLabel.TabIndex = 6;
        _statusLabel.Text = "Ready. Build a query, then press Search.";
        _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // GeographyActivityControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_rootLayout);
        Controls.Add(_placeholderLabel);
        Name = "GeographyActivityControl";
        Size = new Size(1310, 681);
        _rootLayout.ResumeLayout(false);
        _headerPanel.ResumeLayout(false);
        _headerPanel.PerformLayout();
        _questionPanel.ResumeLayout(false);
        _questionPanel.PerformLayout();
        _filterPanel.ResumeLayout(false);
        _selectContinentPanel.ResumeLayout(false);
        _selectContinentPanel.PerformLayout();
        _landmassFilterPanel.ResumeLayout(false);
        _landmassFilterPanel.PerformLayout();
        _populationFilterPanel.ResumeLayout(false);
        _populationFilterPanel.PerformLayout();
        _selectCategoryPanel.ResumeLayout(false);
        _selectCategoryPanel.PerformLayout();
        _searchPanel.ResumeLayout(false);
        _correctAnswerPanel.ResumeLayout(false);
        _correctAnswerPanel.PerformLayout();
        _filterCountryLayout.ResumeLayout(false);
        _filterCountryLayout.PerformLayout();
        _selectedOuterPanel.ResumeLayout(false);
        _selectedPanel.ResumeLayout(false);
        _selectedPanel.PerformLayout();
        ResumeLayout(false);
    }

    private TableLayoutPanel _rootLayout;
    private TableLayoutPanel _headerPanel;
    private Label _activityTitleLabel;
    private TextBox _titleBox;
    private Label _rootFilenameLabel;
    private TextBox _filenameBox;
    private Button _loadButton;
    private Button _viewButton;
    private Button _saveButton;
    private Panel _dividerPanel;
    private TableLayoutPanel _questionPanel;
    private Label _multQuestionLabel;
    private TextBox _questionBox;
    private TableLayoutPanel _filterPanel;
    private FlowLayoutPanel _resultsPanel;
    private TableLayoutPanel _selectedOuterPanel;
    private Label _selectedTitleLabel;
    private FlowLayoutPanel _selectedPanel;
    private Button _completeQuestionButton;
    private Label _statusLabel;
    private TableLayoutPanel _populationFilterPanel;
    private Label _minPopulationLabel;
    private Label _maxPopulationLabel;
    private TextBox _maxPopulationTextBox;
    private TextBox _minPopulationTextBox;
    private TableLayoutPanel _landmassFilterPanel;
    private Label _minAreaLabel;
    private Label _maxAreaLabel;
    private TextBox _maxAreaTextBox;
    private TextBox _minAreaTextBox;
    private TableLayoutPanel _selectContinentPanel;
    private ComboBox _continentCombo;
    private TableLayoutPanel _selectCategoryPanel;
    private ComboBox _categoryCombo;
    private Label _selectContinentLabel;
    private TableLayoutPanel _searchPanel;
    private Button _stopButton;
    private Button _searchButton;
    private TableLayoutPanel _correctAnswerPanel;
    private Label _correctAnswerLabel;
    private CheckBox _correctAnswerCheckBox;
    private Label _selectCategoryLabel;
    private TableLayoutPanel _filterCountryLayout;
    private Label _CountryFilterLabel;
    private Label _countryFilterNameLabel;
    private TextBox _messageTextBox;
    private TextBox _jsonTextBox;
    private Label _countrySelectionInfoLabel;
}
