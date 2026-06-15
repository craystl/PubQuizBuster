namespace PubQuizBuster.ActivityCreator;

partial class MusicActivityControl
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
        this._placeholderLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // _placeholderLabel
        // 
        this._placeholderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this._placeholderLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this._placeholderLabel.ForeColor = System.Drawing.Color.DimGray;
        this._placeholderLabel.Location = new System.Drawing.Point(0, 0);
        this._placeholderLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        this._placeholderLabel.Name = "_placeholderLabel";
        this._placeholderLabel.Size = new System.Drawing.Size(2246, 1362);
        this._placeholderLabel.TabIndex = 0;
        this._placeholderLabel.Text = "Collect Artist/Album images for Matching Pair Activity. To be implemented ...";
        this._placeholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // MusicActivityControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this._placeholderLabel);
        this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
        this.Name = "MusicActivityControl";
        this.Size = new System.Drawing.Size(2246, 1362);
        this.ResumeLayout(false);
    }
}
