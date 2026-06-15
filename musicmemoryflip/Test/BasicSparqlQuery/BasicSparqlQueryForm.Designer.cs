namespace PubQuizBuster.BasicSparqlQuery;

partial class BasicSparqlQueryForm
{
    private System.ComponentModel.IContainer components = null;
    private RadioButton _musiciansRadioButton;
    private RadioButton _movieActorsRadioButton;
    private CheckBox _withFanbaseCheckBox;
    private Label _queryLabel;
    private TextBox _queryTextBox;
    private Button _executeButton;
    private TextBox _jsonTextBox;
    private ListBox _resultsListBox;
    private Label _resultsLabel;
    private TextBox _messageTextBox;
    private Label _messageLabel;
    private TableLayoutPanel _mainLayout;
    private TableLayoutPanel _leftLayout;
    private FlowLayoutPanel _selectorPanel;
    private Panel _queryPanel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _mainLayout = new TableLayoutPanel();
        _leftLayout = new TableLayoutPanel();
        _selectorPanel = new FlowLayoutPanel();
        _musiciansRadioButton = new RadioButton();
        _movieActorsRadioButton = new RadioButton();
        _withFanbaseCheckBox = new CheckBox();
        _queryLabel = new Label();
        _queryPanel = new Panel();
        _queryTextBox = new TextBox();
        _executeButton = new Button();
        _jsonTextBox = new TextBox();
        _resultsLabel = new Label();
        _resultsListBox = new ListBox();
        _messageLabel = new Label();
        _messageTextBox = new TextBox();
        _mainLayout.SuspendLayout();
        _leftLayout.SuspendLayout();
        _selectorPanel.SuspendLayout();
        _queryPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _mainLayout
        // 
        _mainLayout.ColumnCount = 2;
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        _mainLayout.Controls.Add(_leftLayout, 0, 0);
        _mainLayout.Controls.Add(_resultsLabel, 1, 0);
        _mainLayout.Controls.Add(_resultsListBox, 1, 1);
        _mainLayout.Controls.Add(_messageLabel, 0, 2);
        _mainLayout.Controls.Add(_messageTextBox, 0, 3);
        _mainLayout.Dock = DockStyle.Fill;
        _mainLayout.Location = new Point(0, 0);
        _mainLayout.Name = "_mainLayout";
        _mainLayout.Padding = new Padding(12);
        _mainLayout.RowCount = 4;
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
        _mainLayout.Size = new Size(1184, 761);
        _mainLayout.TabIndex = 0;
        // 
        // _leftLayout
        // 
        _leftLayout.ColumnCount = 1;
        _leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _leftLayout.Controls.Add(_selectorPanel, 0, 0);
        _leftLayout.Controls.Add(_queryLabel, 0, 1);
        _leftLayout.Controls.Add(_queryPanel, 0, 2);
        _leftLayout.Controls.Add(_jsonTextBox, 0, 3);
        _leftLayout.Dock = DockStyle.Fill;
        _leftLayout.Location = new Point(15, 15);
        _leftLayout.Name = "_leftLayout";
        _leftLayout.RowCount = 4;
        _mainLayout.SetRowSpan(_leftLayout, 2);
        _leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        _leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        _leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        _leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
        _leftLayout.Size = new Size(829, 621);
        _leftLayout.TabIndex = 0;
        // 
        // _selectorPanel
        // 
        _selectorPanel.Controls.Add(_musiciansRadioButton);
        _selectorPanel.Controls.Add(_movieActorsRadioButton);
        _selectorPanel.Controls.Add(_withFanbaseCheckBox);
        _selectorPanel.Dock = DockStyle.Fill;
        _selectorPanel.Location = new Point(3, 3);
        _selectorPanel.Name = "_selectorPanel";
        _selectorPanel.Size = new Size(823, 36);
        _selectorPanel.TabIndex = 0;
        _selectorPanel.WrapContents = false;
        // 
        // _musiciansRadioButton
        // 
        _musiciansRadioButton.AutoSize = true;
        _musiciansRadioButton.Checked = true;
        _musiciansRadioButton.Location = new Point(3, 7);
        _musiciansRadioButton.Margin = new Padding(3, 7, 18, 3);
        _musiciansRadioButton.Name = "_musiciansRadioButton";
        _musiciansRadioButton.Size = new Size(117, 19);
        _musiciansRadioButton.TabIndex = 0;
        _musiciansRadioButton.TabStop = true;
        _musiciansRadioButton.Text = "Musicians/Bands";
        _musiciansRadioButton.UseVisualStyleBackColor = true;
        _musiciansRadioButton.CheckedChanged += SelectionChanged;
        // 
        // _movieActorsRadioButton
        // 
        _movieActorsRadioButton.AutoSize = true;
        _movieActorsRadioButton.Location = new Point(141, 7);
        _movieActorsRadioButton.Margin = new Padding(3, 7, 24, 3);
        _movieActorsRadioButton.Name = "_movieActorsRadioButton";
        _movieActorsRadioButton.Size = new Size(93, 19);
        _movieActorsRadioButton.TabIndex = 1;
        _movieActorsRadioButton.Text = "Movie Actors";
        _movieActorsRadioButton.UseVisualStyleBackColor = true;
        _movieActorsRadioButton.CheckedChanged += SelectionChanged;
        // 
        // _withFanbaseCheckBox
        // 
        _withFanbaseCheckBox.AutoSize = true;
        _withFanbaseCheckBox.Location = new Point(261, 7);
        _withFanbaseCheckBox.Margin = new Padding(3, 7, 3, 3);
        _withFanbaseCheckBox.Name = "_withFanbaseCheckBox";
        _withFanbaseCheckBox.Size = new Size(183, 19);
        _withFanbaseCheckBox.TabIndex = 2;
        _withFanbaseCheckBox.Text = "with fanbase (i.e., well-known)";
        _withFanbaseCheckBox.UseVisualStyleBackColor = true;
        _withFanbaseCheckBox.CheckedChanged += SelectionChanged;
        // 
        // _queryLabel
        // 
        _queryLabel.AutoSize = true;
        _queryLabel.Dock = DockStyle.Fill;
        _queryLabel.Location = new Point(3, 42);
        _queryLabel.Name = "_queryLabel";
        _queryLabel.Size = new Size(823, 28);
        _queryLabel.TabIndex = 1;
        _queryLabel.Text = "SPARQL query for https://query.wikidata.org/sparql";
        _queryLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _queryPanel
        // 
        _queryPanel.Controls.Add(_queryTextBox);
        _queryPanel.Controls.Add(_executeButton);
        _queryPanel.Dock = DockStyle.Fill;
        _queryPanel.Location = new Point(3, 73);
        _queryPanel.Name = "_queryPanel";
        _queryPanel.Size = new Size(823, 242);
        _queryPanel.TabIndex = 2;
        // 
        // _queryTextBox
        // 
        _queryTextBox.AcceptsReturn = true;
        _queryTextBox.AcceptsTab = true;
        _queryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _queryTextBox.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _queryTextBox.Location = new Point(0, 0);
        _queryTextBox.Multiline = true;
        _queryTextBox.Name = "_queryTextBox";
        _queryTextBox.ScrollBars = ScrollBars.Both;
        _queryTextBox.Size = new Size(688, 242);
        _queryTextBox.TabIndex = 0;
        _queryTextBox.WordWrap = false;
        // 
        // _executeButton
        // 
        _executeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _executeButton.Location = new Point(704, 0);
        _executeButton.Name = "_executeButton";
        _executeButton.Size = new Size(116, 50);
        _executeButton.TabIndex = 1;
        _executeButton.Text = "Execute Query";
        _executeButton.UseVisualStyleBackColor = true;
        _executeButton.Click += ExecuteButton_Click;
        // 
        // _jsonTextBox
        // 
        _jsonTextBox.Dock = DockStyle.Fill;
        _jsonTextBox.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _jsonTextBox.Location = new Point(3, 321);
        _jsonTextBox.Multiline = true;
        _jsonTextBox.Name = "_jsonTextBox";
        _jsonTextBox.ReadOnly = true;
        _jsonTextBox.ScrollBars = ScrollBars.Both;
        _jsonTextBox.Size = new Size(823, 297);
        _jsonTextBox.TabIndex = 3;
        _jsonTextBox.WordWrap = false;
        // 
        // _resultsLabel
        // 
        _resultsLabel.AutoSize = true;
        _resultsLabel.Dock = DockStyle.Fill;
        _resultsLabel.Location = new Point(850, 12);
        _resultsLabel.Name = "_resultsLabel";
        _resultsLabel.Size = new Size(319, 28);
        _resultsLabel.TabIndex = 1;
        _resultsLabel.Text = "Returned names";
        _resultsLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _resultsListBox
        // 
        _resultsListBox.Dock = DockStyle.Fill;
        _resultsListBox.FormattingEnabled = true;
        _resultsListBox.ItemHeight = 15;
        _resultsListBox.Location = new Point(850, 43);
        _resultsListBox.Name = "_resultsListBox";
        _resultsListBox.Size = new Size(319, 593);
        _resultsListBox.TabIndex = 2;
        // 
        // _messageLabel
        // 
        _messageLabel.AutoSize = true;
        _messageLabel.Dock = DockStyle.Fill;
        _messageLabel.Location = new Point(15, 639);
        _messageLabel.Name = "_messageLabel";
        _mainLayout.SetColumnSpan(_messageLabel, 2);
        _messageLabel.Size = new Size(1154, 24);
        _messageLabel.TabIndex = 3;
        _messageLabel.Text = "Messages";
        _messageLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // _messageTextBox
        // 
        _mainLayout.SetColumnSpan(_messageTextBox, 2);
        _messageTextBox.Dock = DockStyle.Fill;
        _messageTextBox.Location = new Point(15, 666);
        _messageTextBox.Multiline = true;
        _messageTextBox.Name = "_messageTextBox";
        _messageTextBox.ReadOnly = true;
        _messageTextBox.ScrollBars = ScrollBars.Vertical;
        _messageTextBox.Size = new Size(1154, 80);
        _messageTextBox.TabIndex = 4;
        // 
        // BasicSparqlQueryForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1184, 761);
        Controls.Add(_mainLayout);
        MinimumSize = new Size(950, 650);
        Name = "BasicSparqlQueryForm";
        Text = "Pub Quiz Buster - Basic SPARQL Query";
        _mainLayout.ResumeLayout(false);
        _mainLayout.PerformLayout();
        _leftLayout.ResumeLayout(false);
        _leftLayout.PerformLayout();
        _selectorPanel.ResumeLayout(false);
        _selectorPanel.PerformLayout();
        _queryPanel.ResumeLayout(false);
        _queryPanel.PerformLayout();
        ResumeLayout(false);
    }
}
