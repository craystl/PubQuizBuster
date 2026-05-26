namespace PubQuizBuster.ActivityCreator;

partial class PQBActivityForm
{
    private System.ComponentModel.IContainer components = null!;

    private TabControl _tabs = null!;
    private TabPage _moviesTab = null!;
    private TabPage _musicTab = null!;
    private TabPage _geographyTab = null!;
    private MoviesActivityControl _moviesControl = null!;
    private MusicActivityControl _musicControl = null!;
    private GeographyActivityControl _geographyControl = null!;

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
        this._tabs = new System.Windows.Forms.TabControl();
        this._moviesTab = new System.Windows.Forms.TabPage();
        this._musicTab = new System.Windows.Forms.TabPage();
        this._geographyTab = new System.Windows.Forms.TabPage();
        this._moviesControl = new PubQuizBuster.ActivityCreator.MoviesActivityControl();
        this._musicControl = new PubQuizBuster.ActivityCreator.MusicActivityControl();
        this._geographyControl = new PubQuizBuster.ActivityCreator.GeographyActivityControl();
        this._tabs.SuspendLayout();
        this._moviesTab.SuspendLayout();
        this._musicTab.SuspendLayout();
        this._geographyTab.SuspendLayout();
        this.SuspendLayout();
        // 
        // _tabs
        // 
        this._tabs.Controls.Add(this._moviesTab);
        this._tabs.Controls.Add(this._musicTab);
        this._tabs.Controls.Add(this._geographyTab);
        this._tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        this._tabs.Font = new System.Drawing.Font("Segoe UI", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this._tabs.Location = new System.Drawing.Point(0, 0);
        this._tabs.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._tabs.Name = "_tabs";
        this._tabs.Padding = new System.Drawing.Point(15, 3);
        this._tabs.SelectedIndex = 0;
        this._tabs.Size = new System.Drawing.Size(2264, 1432);
        this._tabs.TabIndex = 0;
        // 
        // _moviesTab
        // 
        this._moviesTab.Controls.Add(this._moviesControl);
        this._moviesTab.Location = new System.Drawing.Point(4, 54);
        this._moviesTab.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._moviesTab.Name = "_moviesTab";
        this._moviesTab.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._moviesTab.Size = new System.Drawing.Size(2256, 1374);
        this._moviesTab.TabIndex = 0;
        this._moviesTab.Text = "Movies";
        // 
        // _moviesControl
        // 
        this._moviesControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this._moviesControl.Location = new System.Drawing.Point(5, 6);
        this._moviesControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._moviesControl.Name = "_moviesControl";
        this._moviesControl.Size = new System.Drawing.Size(2246, 1362);
        this._moviesControl.TabIndex = 0;
        // 
        // _musicTab
        // 
        this._musicTab.Controls.Add(this._musicControl);
        this._musicTab.Location = new System.Drawing.Point(4, 54);
        this._musicTab.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._musicTab.Name = "_musicTab";
        this._musicTab.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._musicTab.Size = new System.Drawing.Size(2256, 1374);
        this._musicTab.TabIndex = 1;
        this._musicTab.Text = "Music";
        // 
        // _musicControl
        // 
        this._musicControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this._musicControl.Location = new System.Drawing.Point(5, 6);
        this._musicControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._musicControl.Name = "_musicControl";
        this._musicControl.Size = new System.Drawing.Size(2246, 1362);
        this._musicControl.TabIndex = 0;
        // 
        // _geographyTab
        // 
        this._geographyTab.Controls.Add(this._geographyControl);
        this._geographyTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this._geographyTab.Location = new System.Drawing.Point(4, 54);
        this._geographyTab.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._geographyTab.Name = "_geographyTab";
        this._geographyTab.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._geographyTab.Size = new System.Drawing.Size(2256, 1374);
        this._geographyTab.TabIndex = 2;
        this._geographyTab.Text = "Geography";
        // 
        // _geographyControl
        // 
        this._geographyControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this._geographyControl.Location = new System.Drawing.Point(5, 6);
        this._geographyControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this._geographyControl.Name = "_geographyControl";
        this._geographyControl.Size = new System.Drawing.Size(2246, 1362);
        this._geographyControl.TabIndex = 0;
        // 
        // PQBActivityForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(2264, 1432);
        this.Controls.Add(this._tabs);
        this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this.MinimumSize = new System.Drawing.Size(2126, 1496);
        this.Name = "PQBActivityForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Pub Quiz Buster!";
        this._tabs.ResumeLayout(false);
        this._moviesTab.ResumeLayout(false);
        this._musicTab.ResumeLayout(false);
        this._geographyTab.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
