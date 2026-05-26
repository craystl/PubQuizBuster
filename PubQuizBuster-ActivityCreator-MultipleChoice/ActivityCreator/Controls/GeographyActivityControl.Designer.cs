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
        _minLandmassLabel = new Label();
        _maxLandmassLabel = new Label();
        _maxLandmassTextBox = new TextBox();
        _minLandmassTextBox = new TextBox();
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
        btnSearch = new Button();
        _correctAnswerPanel = new TableLayoutPanel();
        _correctAnswerLabel = new Label();
        _correctAnswerCheckBox = new CheckBox();
        _filterCountryLayout = new TableLayoutPanel();
        _CountryFilterLabel = new Label();
        _countryFilterNameLabel = new Label();
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
        _selectContinentPanel.SuspendLayout();
        _landmassFilterPanel.SuspendLayout();
        _populationFilterPanel.SuspendLayout();
        _selectCategoryPanel.SuspendLayout();
        _searchPanel.SuspendLayout();
        _correctAnswerPanel.SuspendLayout();
        _filterCountryLayout.SuspendLayout();
        _selectedOuterPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _placeholderLabel
        // 
        _placeholderLabel.Dock = DockStyle.Fill;
        _placeholderLabel.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
        _placeholderLabel.ForeColor = Color.DimGray;
        _placeholderLabel.Location = new Point(0, 0);
        _placeholderLabel.Margin = new Padding(6, 0, 6, 0);
        _placeholderLabel.Name = "_placeholderLabel";
        _placeholderLabel.Size = new Size(2433, 1453);
        _placeholderLabel.TabIndex = 0;
        _placeholderLabel.Text = "Multiple Choice Geography Questions. To be implemented ...";
        _placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _rootLayout
        // 
        _rootLayout.ColumnCount = 2;
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.04651F));
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.95349F));
        _rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37F));
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
        _rootLayout.Margin = new Padding(6);
        _rootLayout.Name = "_rootLayout";
        _rootLayout.Padding = new Padding(19, 21, 19, 21);
        _rootLayout.RowCount = 6;
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 4F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 311F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
        _rootLayout.Size = new Size(2433, 1453);
        _rootLayout.TabIndex = 1;
        // 
        // _headerPanel
        // 
        _headerPanel.ColumnCount = 7;
        _rootLayout.SetColumnSpan(_headerPanel, 2);
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 204F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 241F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        _headerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
        _headerPanel.Controls.Add(_activityTitleLabel, 0, 0);
        _headerPanel.Controls.Add(_titleBox, 1, 0);
        _headerPanel.Controls.Add(_rootFilenameLabel, 2, 0);
        _headerPanel.Controls.Add(_filenameBox, 3, 0);
        _headerPanel.Controls.Add(_loadButton, 4, 0);
        _headerPanel.Controls.Add(_viewButton, 5, 0);
        _headerPanel.Controls.Add(_saveButton, 6, 0);
        _headerPanel.Dock = DockStyle.Fill;
        _headerPanel.Location = new Point(25, 27);
        _headerPanel.Margin = new Padding(6);
        _headerPanel.Name = "_headerPanel";
        _headerPanel.RowCount = 1;
        _headerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
        _headerPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
        _headerPanel.Size = new Size(2383, 84);
        _headerPanel.TabIndex = 0;
        // 
        // _activityTitleLabel
        // 
        _activityTitleLabel.Location = new Point(6, 0);
        _activityTitleLabel.Margin = new Padding(6, 0, 6, 0);
        _activityTitleLabel.Name = "_activityTitleLabel";
        _activityTitleLabel.Size = new Size(191, 51);
        _activityTitleLabel.TabIndex = 0;
        _activityTitleLabel.Text = "Activity title:";
        _activityTitleLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _titleBox
        // 
        _titleBox.Dock = DockStyle.Fill;
        _titleBox.Location = new Point(210, 6);
        _titleBox.Margin = new Padding(6);
        _titleBox.Name = "_titleBox";
        _titleBox.Size = new Size(743, 39);
        _titleBox.TabIndex = 1;
        _titleBox.Text = "Select all correct answers to this geography question";
        // 
        // _rootFilenameLabel
        // 
        _rootFilenameLabel.Location = new Point(965, 0);
        _rootFilenameLabel.Margin = new Padding(6, 0, 6, 0);
        _rootFilenameLabel.Name = "_rootFilenameLabel";
        _rootFilenameLabel.Size = new Size(228, 51);
        _rootFilenameLabel.TabIndex = 2;
        _rootFilenameLabel.Text = "Root JSON filename:";
        _rootFilenameLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filenameBox
        // 
        _filenameBox.Dock = DockStyle.Fill;
        _filenameBox.Location = new Point(1206, 6);
        _filenameBox.Margin = new Padding(6);
        _filenameBox.Name = "_filenameBox";
        _filenameBox.Size = new Size(685, 39);
        _filenameBox.TabIndex = 3;
        _filenameBox.Text = "geography_multiple_choice";
        // 
        // _loadButton
        // 
        _loadButton.Location = new Point(1903, 6);
        _loadButton.Margin = new Padding(6);
        _loadButton.Name = "_loadButton";
        _loadButton.Size = new Size(148, 45);
        _loadButton.TabIndex = 4;
        _loadButton.Text = "Load";
        // 
        // _viewButton
        // 
        _viewButton.Location = new Point(2063, 6);
        _viewButton.Margin = new Padding(6);
        _viewButton.Name = "_viewButton";
        _viewButton.Size = new Size(148, 45);
        _viewButton.TabIndex = 5;
        _viewButton.Text = "View";
        // 
        // _saveButton
        // 
        _saveButton.Location = new Point(2223, 6);
        _saveButton.Margin = new Padding(6);
        _saveButton.Name = "_saveButton";
        _saveButton.Size = new Size(149, 45);
        _saveButton.TabIndex = 6;
        _saveButton.Text = "Save";
        // 
        // _dividerPanel
        // 
        _dividerPanel.BackColor = Color.Silver;
        _rootLayout.SetColumnSpan(_dividerPanel, 2);
        _dividerPanel.Dock = DockStyle.Fill;
        _dividerPanel.Location = new Point(25, 123);
        _dividerPanel.Margin = new Padding(6);
        _dividerPanel.Name = "_dividerPanel";
        _dividerPanel.Size = new Size(2383, 1);
        _dividerPanel.TabIndex = 1;
        // 
        // _questionPanel
        // 
        _questionPanel.ColumnCount = 2;
        _rootLayout.SetColumnSpan(_questionPanel, 2);
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 353F));
        _questionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _questionPanel.Controls.Add(_questionBox, 1, 0);
        _questionPanel.Controls.Add(_multQuestionLabel, 0, 0);
        _questionPanel.Location = new Point(25, 127);
        _questionPanel.Margin = new Padding(6);
        _questionPanel.Name = "_questionPanel";
        _questionPanel.Padding = new Padding(0, 17, 0, 17);
        _questionPanel.RowCount = 1;
        _questionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
        _questionPanel.Size = new Size(2383, 98);
        _questionPanel.TabIndex = 2;
        // 
        // _questionBox
        // 
        _questionBox.Dock = DockStyle.Fill;
        _questionBox.Location = new Point(359, 23);
        _questionBox.Margin = new Padding(6);
        _questionBox.Name = "_questionBox";
        _questionBox.Size = new Size(2018, 39);
        _questionBox.TabIndex = 1;
        _questionBox.Text = "What is the Capital City of New Zealand?";
        // 
        // _multQuestionLabel
        // 
        _multQuestionLabel.Anchor = AnchorStyles.None;
        _multQuestionLabel.Location = new Point(6, 27);
        _multQuestionLabel.Margin = new Padding(6, 0, 6, 0);
        _multQuestionLabel.Name = "_multQuestionLabel";
        _multQuestionLabel.Size = new Size(341, 43);
        _multQuestionLabel.TabIndex = 0;
        _multQuestionLabel.Text = "Multiple-Choice Question:";
        _multQuestionLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _filterPanel
        // 
        _filterPanel.ColumnCount = 7;
        _rootLayout.SetColumnSpan(_filterPanel, 2);
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 396F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 370F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 317F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 325F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 442F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
        _filterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
        _filterPanel.Controls.Add(_selectContinentPanel, 0, 0);
        _filterPanel.Controls.Add(_landmassFilterPanel, 4, 0);
        _filterPanel.Controls.Add(_populationFilterPanel, 3, 0);
        _filterPanel.Controls.Add(_selectCategoryPanel, 1, 0);
        _filterPanel.Controls.Add(_searchPanel, 7, 0);
        _filterPanel.Controls.Add(_correctAnswerPanel, 2, 0);
        _filterPanel.Controls.Add(_filterCountryLayout, 5, 0);
        _filterPanel.Dock = DockStyle.Fill;
        _filterPanel.Location = new Point(25, 246);
        _filterPanel.Margin = new Padding(6);
        _filterPanel.Name = "_filterPanel";
        _filterPanel.Padding = new Padding(0, 17, 0, 17);
        _filterPanel.RowCount = 1;
        _filterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 265F));
        _filterPanel.Size = new Size(2383, 299);
        _filterPanel.TabIndex = 3;
        // 
        // _selectContinentPanel
        // 
        _selectContinentPanel.ColumnCount = 1;
        _selectContinentPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _selectContinentPanel.Controls.Add(_continentCombo, 0, 1);
        _selectContinentPanel.Controls.Add(_selectContinentLabel, 0, 0);
        _selectContinentPanel.Location = new Point(6, 23);
        _selectContinentPanel.Margin = new Padding(6);
        _selectContinentPanel.Name = "_selectContinentPanel";
        _selectContinentPanel.RowCount = 2;
        _selectContinentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.59322F));
        _selectContinentPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 64.40678F));
        _selectContinentPanel.Size = new Size(384, 252);
        _selectContinentPanel.TabIndex = 9;
        // 
        // _continentCombo
        // 
        _continentCombo.FormattingEnabled = true;
        _continentCombo.Items.AddRange(new object[] { "Any", "Europe", "Asia", "Africa", "North America", "South America", "Oceania" });
        _continentCombo.Location = new Point(6, 95);
        _continentCombo.Margin = new Padding(6);
        _continentCombo.Name = "_continentCombo";
        _continentCombo.Size = new Size(370, 40);
        _continentCombo.TabIndex = 4;
        _continentCombo.SelectedIndexChanged += _continentCombo_SelectedIndexChanged;
        // 
        // _selectContinentLabel
        // 
        _selectContinentLabel.Anchor = AnchorStyles.None;
        _selectContinentLabel.AutoSize = true;
        _selectContinentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _selectContinentLabel.Location = new Point(86, 26);
        _selectContinentLabel.Margin = new Padding(6, 0, 6, 0);
        _selectContinentLabel.Name = "_selectContinentLabel";
        _selectContinentLabel.Size = new Size(211, 37);
        _selectContinentLabel.TabIndex = 5;
        _selectContinentLabel.Text = "Select Continent";
        // 
        // _landmassFilterPanel
        // 
        _landmassFilterPanel.ColumnCount = 1;
        _landmassFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _landmassFilterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _landmassFilterPanel.Controls.Add(_minLandmassLabel, 0, 2);
        _landmassFilterPanel.Controls.Add(_maxLandmassLabel, 0, 0);
        _landmassFilterPanel.Controls.Add(_maxLandmassTextBox, 0, 1);
        _landmassFilterPanel.Controls.Add(_minLandmassTextBox, 0, 3);
        _landmassFilterPanel.Location = new Point(1226, 23);
        _landmassFilterPanel.Margin = new Padding(6);
        _landmassFilterPanel.Name = "_landmassFilterPanel";
        _landmassFilterPanel.RowCount = 4;
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
        _landmassFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        _landmassFilterPanel.Size = new Size(313, 252);
        _landmassFilterPanel.TabIndex = 7;
        // 
        // _minLandmassLabel
        // 
        _minLandmassLabel.Anchor = AnchorStyles.None;
        _minLandmassLabel.AutoSize = true;
        _minLandmassLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _minLandmassLabel.Location = new Point(63, 138);
        _minLandmassLabel.Margin = new Padding(6, 0, 6, 0);
        _minLandmassLabel.Name = "_minLandmassLabel";
        _minLandmassLabel.Size = new Size(187, 37);
        _minLandmassLabel.TabIndex = 6;
        _minLandmassLabel.Text = "Min Landmass";
        _minLandmassLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxLandmassLabel
        // 
        _maxLandmassLabel.Anchor = AnchorStyles.None;
        _maxLandmassLabel.AutoSize = true;
        _maxLandmassLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _maxLandmassLabel.Location = new Point(61, 11);
        _maxLandmassLabel.Margin = new Padding(6, 0, 6, 0);
        _maxLandmassLabel.Name = "_maxLandmassLabel";
        _maxLandmassLabel.Size = new Size(191, 37);
        _maxLandmassLabel.TabIndex = 5;
        _maxLandmassLabel.Text = "Max Landmass";
        _maxLandmassLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxLandmassTextBox
        // 
        _maxLandmassTextBox.Location = new Point(6, 66);
        _maxLandmassTextBox.Margin = new Padding(6);
        _maxLandmassTextBox.Name = "_maxLandmassTextBox";
        _maxLandmassTextBox.Size = new Size(301, 39);
        _maxLandmassTextBox.TabIndex = 7;
        _maxLandmassTextBox.TextChanged += _maxLandmassTextBox_TextChanged;
        // 
        // _minLandmassTextBox
        // 
        _minLandmassTextBox.Location = new Point(6, 195);
        _minLandmassTextBox.Margin = new Padding(6);
        _minLandmassTextBox.Name = "_minLandmassTextBox";
        _minLandmassTextBox.Size = new Size(301, 39);
        _minLandmassTextBox.TabIndex = 8;
        _minLandmassTextBox.TextChanged += _minLandmassTextBox_TextChanged;
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
        _populationFilterPanel.Location = new Point(909, 23);
        _populationFilterPanel.Margin = new Padding(6);
        _populationFilterPanel.Name = "_populationFilterPanel";
        _populationFilterPanel.RowCount = 4;
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.3333321F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.6666679F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
        _populationFilterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        _populationFilterPanel.Size = new Size(305, 252);
        _populationFilterPanel.TabIndex = 5;
        // 
        // _minPopulationLabel
        // 
        _minPopulationLabel.Anchor = AnchorStyles.None;
        _minPopulationLabel.AutoSize = true;
        _minPopulationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _minPopulationLabel.Location = new Point(53, 138);
        _minPopulationLabel.Margin = new Padding(6, 0, 6, 0);
        _minPopulationLabel.Name = "_minPopulationLabel";
        _minPopulationLabel.Size = new Size(199, 37);
        _minPopulationLabel.TabIndex = 6;
        _minPopulationLabel.Text = "Min Population";
        _minPopulationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxPopulationLabel
        // 
        _maxPopulationLabel.Anchor = AnchorStyles.None;
        _maxPopulationLabel.AutoSize = true;
        _maxPopulationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _maxPopulationLabel.Location = new Point(51, 11);
        _maxPopulationLabel.Margin = new Padding(6, 0, 6, 0);
        _maxPopulationLabel.Name = "_maxPopulationLabel";
        _maxPopulationLabel.Size = new Size(203, 37);
        _maxPopulationLabel.TabIndex = 5;
        _maxPopulationLabel.Text = "Max Population";
        _maxPopulationLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _maxPopulationTextBox
        // 
        _maxPopulationTextBox.Location = new Point(6, 66);
        _maxPopulationTextBox.Margin = new Padding(6);
        _maxPopulationTextBox.Name = "_maxPopulationTextBox";
        _maxPopulationTextBox.Size = new Size(293, 39);
        _maxPopulationTextBox.TabIndex = 7;
        _maxPopulationTextBox.TextChanged += _maxPopulationTextBox_TextChanged;
        // 
        // _minPopulationTextBox
        // 
        _minPopulationTextBox.Location = new Point(6, 195);
        _minPopulationTextBox.Margin = new Padding(6);
        _minPopulationTextBox.Name = "_minPopulationTextBox";
        _minPopulationTextBox.Size = new Size(293, 39);
        _minPopulationTextBox.TabIndex = 8;
        _minPopulationTextBox.TextChanged += _minPopulationTextBox_TextChanged;
        // 
        // _selectCategoryPanel
        // 
        _selectCategoryPanel.ColumnCount = 1;
        _selectCategoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _selectCategoryPanel.Controls.Add(_selectCategoryLabel, 0, 0);
        _selectCategoryPanel.Controls.Add(_categoryCombo, 0, 1);
        _selectCategoryPanel.Location = new Point(402, 23);
        _selectCategoryPanel.Margin = new Padding(6);
        _selectCategoryPanel.Name = "_selectCategoryPanel";
        _selectCategoryPanel.RowCount = 2;
        _selectCategoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35.59322F));
        _selectCategoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 64.40678F));
        _selectCategoryPanel.Size = new Size(358, 252);
        _selectCategoryPanel.TabIndex = 8;
        // 
        // _selectCategoryLabel
        // 
        _selectCategoryLabel.Anchor = AnchorStyles.None;
        _selectCategoryLabel.AutoSize = true;
        _selectCategoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _selectCategoryLabel.Location = new Point(78, 26);
        _selectCategoryLabel.Margin = new Padding(6, 0, 6, 0);
        _selectCategoryLabel.Name = "_selectCategoryLabel";
        _selectCategoryLabel.Size = new Size(202, 37);
        _selectCategoryLabel.TabIndex = 6;
        _selectCategoryLabel.Text = "Select Category";
        // 
        // _categoryCombo
        // 
        _categoryCombo.FormattingEnabled = true;
        _categoryCombo.Items.AddRange(new object[] { "Country", "State/Territory", "City" });
        _categoryCombo.Location = new Point(6, 95);
        _categoryCombo.Margin = new Padding(6);
        _categoryCombo.Name = "_categoryCombo";
        _categoryCombo.Size = new Size(344, 40);
        _categoryCombo.TabIndex = 4;
        _categoryCombo.SelectedIndexChanged += _categoryCombo_SelectedIndexChanged;
        // 
        // _searchPanel
        // 
        _searchPanel.ColumnCount = 1;
        _searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _searchPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _searchPanel.Controls.Add(_stopButton, 0, 1);
        _searchPanel.Controls.Add(btnSearch, 0, 0);
        _searchPanel.Location = new Point(1993, 23);
        _searchPanel.Margin = new Padding(6);
        _searchPanel.Name = "_searchPanel";
        _searchPanel.RowCount = 2;
        _searchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _searchPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _searchPanel.Size = new Size(384, 252);
        _searchPanel.TabIndex = 10;
        // 
        // _stopButton
        // 
        _stopButton.Anchor = AnchorStyles.None;
        _stopButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        _stopButton.Location = new Point(91, 135);
        _stopButton.Margin = new Padding(6);
        _stopButton.Name = "_stopButton";
        _stopButton.Size = new Size(202, 107);
        _stopButton.TabIndex = 2;
        _stopButton.Text = "Stop";
        _stopButton.UseVisualStyleBackColor = true;
        // 
        // btnSearch
        // 
        btnSearch.Anchor = AnchorStyles.None;
        btnSearch.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        btnSearch.Location = new Point(91, 9);
        btnSearch.Margin = new Padding(6);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(202, 107);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        // 
        // _correctAnswerPanel
        // 
        _correctAnswerPanel.ColumnCount = 1;
        _correctAnswerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _correctAnswerPanel.Controls.Add(_correctAnswerLabel, 0, 0);
        _correctAnswerPanel.Controls.Add(_correctAnswerCheckBox, 0, 1);
        _correctAnswerPanel.Location = new Point(772, 23);
        _correctAnswerPanel.Margin = new Padding(6);
        _correctAnswerPanel.Name = "_correctAnswerPanel";
        _correctAnswerPanel.RowCount = 2;
        _correctAnswerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 36.4406776F));
        _correctAnswerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 63.5593224F));
        _correctAnswerPanel.Size = new Size(124, 252);
        _correctAnswerPanel.TabIndex = 12;
        // 
        // _correctAnswerLabel
        // 
        _correctAnswerLabel.Anchor = AnchorStyles.None;
        _correctAnswerLabel.AutoSize = true;
        _correctAnswerLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _correctAnswerLabel.Location = new Point(10, 0);
        _correctAnswerLabel.Margin = new Padding(6, 0, 6, 0);
        _correctAnswerLabel.Name = "_correctAnswerLabel";
        _correctAnswerLabel.Size = new Size(103, 91);
        _correctAnswerLabel.TabIndex = 5;
        _correctAnswerLabel.Text = "Correct Answer?";
        _correctAnswerLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _correctAnswerCheckBox
        // 
        _correctAnswerCheckBox.Anchor = AnchorStyles.None;
        _correctAnswerCheckBox.CheckAlign = ContentAlignment.MiddleCenter;
        _correctAnswerCheckBox.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        _correctAnswerCheckBox.Location = new Point(34, 139);
        _correctAnswerCheckBox.Margin = new Padding(6);
        _correctAnswerCheckBox.Name = "_correctAnswerCheckBox";
        _correctAnswerCheckBox.Size = new Size(56, 64);
        _correctAnswerCheckBox.TabIndex = 6;
        _correctAnswerCheckBox.UseVisualStyleBackColor = true;
        _correctAnswerCheckBox.CheckedChanged += _correctAnswerCheckBox_CheckedChanged;
        // 
        // _filterCountryLayout
        // 
        _filterCountryLayout.ColumnCount = 1;
        _filterCountryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _filterCountryLayout.Controls.Add(_CountryFilterLabel, 0, 0);
        _filterCountryLayout.Controls.Add(_countryFilterNameLabel, 0, 1);
        _filterCountryLayout.Location = new Point(1551, 23);
        _filterCountryLayout.Margin = new Padding(6);
        _filterCountryLayout.Name = "_filterCountryLayout";
        _filterCountryLayout.RowCount = 2;
        _filterCountryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 38.1355934F));
        _filterCountryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 61.8644066F));
        _filterCountryLayout.Size = new Size(430, 252);
        _filterCountryLayout.TabIndex = 14;
        // 
        // _CountryFilterLabel
        // 
        _CountryFilterLabel.Anchor = AnchorStyles.None;
        _CountryFilterLabel.AutoSize = true;
        _CountryFilterLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _CountryFilterLabel.Location = new Point(29, 29);
        _CountryFilterLabel.Margin = new Padding(6, 0, 6, 0);
        _CountryFilterLabel.Name = "_CountryFilterLabel";
        _CountryFilterLabel.Size = new Size(371, 37);
        _CountryFilterLabel.TabIndex = 7;
        _CountryFilterLabel.Text = "Currently Filtering By Country:";
        _CountryFilterLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _countryFilterNameLabel
        // 
        _countryFilterNameLabel.Anchor = AnchorStyles.None;
        _countryFilterNameLabel.AutoSize = true;
        _countryFilterNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _countryFilterNameLabel.Location = new Point(174, 155);
        _countryFilterNameLabel.Margin = new Padding(6, 0, 6, 0);
        _countryFilterNameLabel.Name = "_countryFilterNameLabel";
        _countryFilterNameLabel.Size = new Size(82, 37);
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
        _resultsPanel.Location = new Point(25, 557);
        _resultsPanel.Margin = new Padding(6);
        _resultsPanel.Name = "_resultsPanel";
        _resultsPanel.Padding = new Padding(15, 17, 15, 17);
        _resultsPanel.Size = new Size(1809, 801);
        _resultsPanel.TabIndex = 4;
        // 
        // _selectedOuterPanel
        // 
        _selectedOuterPanel.BorderStyle = BorderStyle.FixedSingle;
        _selectedOuterPanel.ColumnCount = 1;
        _selectedOuterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 535F));
        _selectedOuterPanel.Controls.Add(_selectedTitleLabel, 0, 0);
        _selectedOuterPanel.Controls.Add(_selectedPanel, 0, 1);
        _selectedOuterPanel.Controls.Add(_completeQuestionButton, 0, 2);
        _selectedOuterPanel.Dock = DockStyle.Fill;
        _selectedOuterPanel.Location = new Point(1846, 557);
        _selectedOuterPanel.Margin = new Padding(6);
        _selectedOuterPanel.Name = "_selectedOuterPanel";
        _selectedOuterPanel.Padding = new Padding(15, 17, 15, 17);
        _selectedOuterPanel.RowCount = 3;
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 73F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _selectedOuterPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        _selectedOuterPanel.Size = new Size(562, 801);
        _selectedOuterPanel.TabIndex = 5;
        // 
        // _selectedTitleLabel
        // 
        _selectedTitleLabel.Dock = DockStyle.Fill;
        _selectedTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _selectedTitleLabel.Location = new Point(21, 17);
        _selectedTitleLabel.Margin = new Padding(6, 0, 6, 0);
        _selectedTitleLabel.Name = "_selectedTitleLabel";
        _selectedTitleLabel.Size = new Size(523, 73);
        _selectedTitleLabel.TabIndex = 0;
        _selectedTitleLabel.Text = "Currently Saved Questions (0 / 10)";
        _selectedTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _selectedPanel
        // 
        _selectedPanel.AutoScroll = true;
        _selectedPanel.BackColor = Color.WhiteSmoke;
        _selectedPanel.Dock = DockStyle.Fill;
        _selectedPanel.FlowDirection = FlowDirection.TopDown;
        _selectedPanel.Location = new Point(21, 96);
        _selectedPanel.Margin = new Padding(6);
        _selectedPanel.Name = "_selectedPanel";
        _selectedPanel.Size = new Size(523, 590);
        _selectedPanel.TabIndex = 1;
        _selectedPanel.WrapContents = false;
        // 
        // _completeQuestionButton
        // 
        _completeQuestionButton.Dock = DockStyle.Fill;
        _completeQuestionButton.Location = new Point(21, 698);
        _completeQuestionButton.Margin = new Padding(6);
        _completeQuestionButton.Name = "_completeQuestionButton";
        _completeQuestionButton.Size = new Size(523, 78);
        _completeQuestionButton.TabIndex = 2;
        _completeQuestionButton.Text = "Complete Question";
        // 
        // _statusLabel
        // 
        _rootLayout.SetColumnSpan(_statusLabel, 2);
        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.Location = new Point(25, 1364);
        _statusLabel.Margin = new Padding(6, 0, 6, 0);
        _statusLabel.Name = "_statusLabel";
        _statusLabel.Size = new Size(2383, 68);
        _statusLabel.TabIndex = 6;
        _statusLabel.Text = "Ready. Build a query, then press Search.";
        _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // GeographyActivityControl
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_rootLayout);
        Controls.Add(_placeholderLabel);
        Margin = new Padding(6);
        Name = "GeographyActivityControl";
        Size = new Size(2433, 1453);
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
    private Label _minLandmassLabel;
    private Label _maxLandmassLabel;
    private TextBox _maxLandmassTextBox;
    private TextBox _minLandmassTextBox;
    private TableLayoutPanel _selectContinentPanel;
    private ComboBox _continentCombo;
    private TableLayoutPanel _selectCategoryPanel;
    private ComboBox _categoryCombo;
    private Label _selectContinentLabel;
    private TableLayoutPanel _searchPanel;
    private Button _stopButton;
    private Button btnSearch;
    private TableLayoutPanel _correctAnswerPanel;
    private Label _correctAnswerLabel;
    private CheckBox _correctAnswerCheckBox;
    private Label _selectCategoryLabel;
    private TableLayoutPanel _filterCountryLayout;
    private Label _CountryFilterLabel;
    private Label _countryFilterNameLabel;
}
