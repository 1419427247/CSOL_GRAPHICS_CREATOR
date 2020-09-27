namespace GRAPHICS_CREATOR
{
    partial class GCForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.showBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showBoxStripMenu_AddText = new System.Windows.Forms.ToolStripMenuItem();
            this.showBoxStripMenu_AddImage = new System.Windows.Forms.ToolStripMenuItem();
            this.imageTreeView = new System.Windows.Forms.TreeView();
            this.imageViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageViewStripMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewStripMenu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.showBox = new GRAPHICS_CREATOR.GCPictureBox();
            this.showBoxMenuStrip.SuspendLayout();
            this.imageViewMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showBox)).BeginInit();
            this.SuspendLayout();
            // 
            // showBoxMenuStrip
            // 
            this.showBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showBoxStripMenu_AddText,
            this.showBoxStripMenu_AddImage});
            this.showBoxMenuStrip.Name = "imageTreeViewContextMenuStrip";
            this.showBoxMenuStrip.Size = new System.Drawing.Size(125, 48);
            // 
            // showBoxStripMenu_AddText
            // 
            this.showBoxStripMenu_AddText.Name = "showBoxStripMenu_AddText";
            this.showBoxStripMenu_AddText.Size = new System.Drawing.Size(124, 22);
            this.showBoxStripMenu_AddText.Text = "添加文本";
            this.showBoxStripMenu_AddText.Click += new System.EventHandler(this.showBoxStripMenu_AddText_Click);
            // 
            // showBoxStripMenu_AddImage
            // 
            this.showBoxStripMenu_AddImage.Name = "showBoxStripMenu_AddImage";
            this.showBoxStripMenu_AddImage.Size = new System.Drawing.Size(124, 22);
            this.showBoxStripMenu_AddImage.Text = "添加图片";
            this.showBoxStripMenu_AddImage.Click += new System.EventHandler(this.showBoxStripMenu_AddImage_Click);
            // 
            // imageTreeView
            // 
            this.imageTreeView.ContextMenuStrip = this.imageViewMenuStrip;
            this.imageTreeView.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageTreeView.HotTracking = true;
            this.imageTreeView.ItemHeight = 30;
            this.imageTreeView.Location = new System.Drawing.Point(572, 3);
            this.imageTreeView.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.imageTreeView.Name = "imageTreeView";
            this.imageTreeView.Size = new System.Drawing.Size(200, 554);
            this.imageTreeView.TabIndex = 4;
            this.imageTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.imageTreeView_BeforeSelect);
            this.imageTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.imageTreeView_AfterSelect);
            // 
            // imageViewMenuStrip
            // 
            this.imageViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageViewStripMenu_Remove,
            this.imageViewStripMenu_Export});
            this.imageViewMenuStrip.Name = "imageTreeViewContextMenuStrip";
            this.imageViewMenuStrip.Size = new System.Drawing.Size(149, 48);
            this.imageViewMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.imageViewMenuStrip_Opening);
            // 
            // imageViewStripMenu_Remove
            // 
            this.imageViewStripMenu_Remove.Name = "imageViewStripMenu_Remove";
            this.imageViewStripMenu_Remove.Size = new System.Drawing.Size(148, 22);
            this.imageViewStripMenu_Remove.Text = "移除";
            this.imageViewStripMenu_Remove.Click += new System.EventHandler(this.imageViewStripMenu_Remove_Click);
            // 
            // imageViewStripMenu_Export
            // 
            this.imageViewStripMenu_Export.Name = "imageViewStripMenu_Export";
            this.imageViewStripMenu_Export.Size = new System.Drawing.Size(148, 22);
            this.imageViewStripMenu_Export.Text = "导出到剪切板";
            this.imageViewStripMenu_Export.Click += new System.EventHandler(this.imageViewStripMenu_Export_Click);
            // 
            // showBox
            // 
            this.showBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.showBox.ContextMenuStrip = this.showBoxMenuStrip;
            this.showBox.Location = new System.Drawing.Point(12, 3);
            this.showBox.Name = "showBox";
            this.showBox.Size = new System.Drawing.Size(554, 554);
            this.showBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showBox.TabIndex = 2;
            this.showBox.TabStop = false;
            this.showBox.Click += new System.EventHandler(this.showBox_Click);
            // 
            // GCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.imageTreeView);
            this.Controls.Add(this.showBox);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRAPHICS_CREATOR";
            this.showBoxMenuStrip.ResumeLayout(false);
            this.imageViewMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GCPictureBox showBox;
        private System.Windows.Forms.TreeView imageTreeView;
        private System.Windows.Forms.ContextMenuStrip showBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showBoxStripMenu_AddText;
        private System.Windows.Forms.ToolStripMenuItem showBoxStripMenu_AddImage;
        private System.Windows.Forms.ContextMenuStrip imageViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem imageViewStripMenu_Remove;
        private System.Windows.Forms.ToolStripMenuItem imageViewStripMenu_Export;
    }
}

