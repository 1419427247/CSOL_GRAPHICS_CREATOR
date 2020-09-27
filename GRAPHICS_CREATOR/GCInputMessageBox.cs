using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPHICS_CREATOR
{
    public partial class GCInputMessageBox : Form
    {
        private string text = "";
        private string font = "";
        private string size = "";
        private GCInputMessageBox()
        {
            InitializeComponent();
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (var f in fonts.Families)
            {
                fontComboBox.Items.Add(f.Name);
            }
        }

        public static new string[] Show()
        {
            GCInputMessageBox inputMessageBox = new GCInputMessageBox();
            inputMessageBox.ShowDialog();
            return new string[] { inputMessageBox.text, inputMessageBox.font, inputMessageBox.size};
        }

        private void submit_Click(object sender, EventArgs e)
        {
            text = inputBox.Text;
            font = fontComboBox.Text;
            size = fontSizeNumericUpDown.Value.ToString();
            Close();
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
