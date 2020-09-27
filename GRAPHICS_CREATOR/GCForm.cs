using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPHICS_CREATOR
{
    public partial class GCForm : Form
    {
        public GCForm()
        {
            InitializeComponent();
            //TreeNode root = new TreeNode("QWQ");
            //imageTreeView.Nodes.Add(root);
            //imageTreeView.
            //root.ContextMenuStrip = imageTreeViewContextMenuStrip;
        }


        private void showBoxStripMenu_AddText_Click(object sender, EventArgs e)
        {
            string[] str = GCInputMessageBox.Show();
            string text = str[0];
            string font = str[1];
            float size = float.Parse(str[2]);
            if (text.Length == 0)
                return;

            HashSet<char> set = new HashSet<char>();
            foreach (var c in text)
            {
                if (c != ' ')
                {
                    set.Add(c);
                }
            }
            TreeNode root = new TreeNode("字符串:[" + text[0] + "...]");
            Dictionary<string, GCImage> imagePairs = new Dictionary<string, GCImage>();
            foreach (var c in set)
            {
                root.Nodes.Add(c.ToString());
                imagePairs.Add(c.ToString(), new GCImage(c, new Font(font, size, FontStyle.Regular, GraphicsUnit.Pixel)));
            }
            if (root.Nodes.Count != 0)
            {
                root.Tag = imagePairs;
                imageTreeView.Nodes.Add(root);
            }
        }

        private void showBoxStripMenu_AddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图片文件(*.jpg,*.gif,*.bmp,*.png)|*.jpg;*.gif;*.bmp;*.png";
            openFileDialog.FileOk += (object _sender, CancelEventArgs _e) =>
            {
                string fileName = openFileDialog.FileName.Substring(
                    openFileDialog.FileName.LastIndexOf("\\") + 1,
                    openFileDialog.FileName.LastIndexOf(".") - openFileDialog.FileName.LastIndexOf("\\") - 1);

                Image image = Image.FromFile(openFileDialog.FileName);
                FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
                int count = image.GetFrameCount(frameDimension);

                Dictionary<string, GCImage> imagePairs = new Dictionary<string, GCImage>();
                TreeNode root = new TreeNode("图片:[" + fileName + "]");

                for (int i = 0; i < count; i++)
                {
                    image.SelectActiveFrame(frameDimension, i);
                    GCImage gCImage = new GCImage((Bitmap)image);
                    imagePairs.Add(fileName + i, gCImage);
                    root.Nodes.Add(fileName + i);
                    if (imagePairs[fileName + i].boxCount > 1024)
                    {
                        root.Nodes[root.Nodes.Count - 1].ForeColor = Color.Red;
                    }
                }
                root.Tag = imagePairs;
                imageTreeView.Nodes.Add(root);
            };
            openFileDialog.ShowDialog();
        }

        private void imageTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Dictionary<string, GCImage> imagePairs = (Dictionary<string, GCImage>)(e.Node.Tag == null ? e.Node.Parent.Tag : e.Node.Tag);
            if (imagePairs.Count == 0)
            {
                return;
            }
            if (imagePairs.ContainsKey(e.Node.Text))
            {
                showBox.Image = imagePairs[e.Node.Text].bitmap;
            }
            else
            {
                showBox.Image = imagePairs[e.Node.FirstNode.Text].bitmap;
            }
        }

        private void imageViewMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (imageTreeView.SelectedNode == null)
            {
                imageViewMenuStrip.Visible = false;
            }
            else
            {
                imageViewMenuStrip.Visible = true;
            }
        }

        private void imageTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void imageViewStripMenu_Remove_Click(object sender, EventArgs e)
        {
            if (imageTreeView.SelectedNode != null)
            {
                Dictionary<string, GCImage> imagePairs = (Dictionary<string, GCImage>)(imageTreeView.SelectedNode.Tag == null ? imageTreeView.SelectedNode.Parent.Tag : imageTreeView.SelectedNode.Tag);

                if (imagePairs.ContainsKey(imageTreeView.SelectedNode.Text))
                {
                    imagePairs.Remove(imageTreeView.SelectedNode.Text);
                    if (imageTreeView.SelectedNode.Parent != null && imageTreeView.SelectedNode.Parent.Nodes.Count == 1)
                    {
                        imageTreeView.SelectedNode.Parent.Remove();
                        return;
                    }
                    imageTreeView.SelectedNode.Remove();
                }
                else
                {
                    imageTreeView.SelectedNode.Remove();
                }
            }

        }

        private void imageViewStripMenu_Export_Click(object sender, EventArgs e)
        {
            if (imageTreeView.SelectedNode != null)
            {
                StringBuilder builder = new StringBuilder();
                Dictionary<string, GCImage> imagePairs = (Dictionary<string, GCImage>)(imageTreeView.SelectedNode.Tag == null ? imageTreeView.SelectedNode.Parent.Tag : imageTreeView.SelectedNode.Tag);
                if (imageTreeView.SelectedNode.Nodes.Count == 0)
                {
                    switch (imagePairs[imageTreeView.SelectedNode.Text].Type)
                    {
                        case "text":
                            builder.Append("'");
                            builder.Append(imageTreeView.SelectedNode.Text);
                            builder.Append(imagePairs[imageTreeView.SelectedNode.Text].data);
                            builder.Append("'\n\r");
                            break;
                        case "bitmap":
                            builder.Append(imageTreeView.SelectedNode.Text);
                            builder.Append(" = '");
                            builder.Append(imagePairs[imageTreeView.SelectedNode.Text].data);
                            builder.Append(" '\n\r");
                            break;
                    }
                }
                else
                {
                    if (imagePairs[imageTreeView.SelectedNode.Nodes[0].Text].Type == "text")
                    {
                        builder.Append("'");
                        foreach (TreeNode node in imageTreeView.SelectedNode.Nodes)
                        {
                            builder.Append(node.Text);
                            builder.Append(imagePairs[node.Text].data);
                            builder.Append(" ");
                        }
                        builder.Append("'");
                    }
                    else
                    {
                        foreach (TreeNode node in imageTreeView.SelectedNode.Nodes)
                        {
                            builder.Append(node.Text);
                            builder.Append(" = '");
                            builder.Append(imagePairs[node.Text].data);
                            builder.Append(" '\n\r");
                        }
                    }

                }

                Clipboard.SetDataObject(builder.ToString(), true);
                MessageBox.Show("成功复制到剪贴板,字符串长度:"+ builder.Length);
            }
        }

        private void showBox_Click(object sender, EventArgs e)
        {

        }
    }
}

