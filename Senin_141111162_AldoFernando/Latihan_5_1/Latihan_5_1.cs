using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Latihan_5_1
{
    public partial class Latihan_5_1 : Form
    {
        public Latihan_5_1()
        {
            InitializeComponent();
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Visible = true;
            New_Page f = new New_Page();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            f.BringToFront();
            richTextBox1.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (copyCtrlcToolStripMenuItem.Enabled == true)
            {
                copyCtrlcToolStripMenuItem.Enabled = false;
                cutCtrlxToolStripMenuItem.Enabled = false;
            }
        }

        private void Latihan_5_1_Load(object sender, EventArgs e)
        {
            copyCtrlcToolStripMenuItem.Enabled = false;
            cutCtrlxToolStripMenuItem.Enabled = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Background color")
            {
                button1.Visible = true;
                label1.Visible = true;
            }
            else
            {
                button1.Visible = false;
                label1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult warna = colorDialog1.ShowDialog();

            if (warna == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
                button1.Visible = false;
                label1.Visible = false;
                treeView1.Visible = false;
            }
        }

        private void deleteDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }

        private void copyCtrlcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText, TextDataFormat.UnicodeText);
            richTextBox1.Copy();
        }

        private void pasteCtrlvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                richTextBox1.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        private void cutCtrlxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void menuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            if (copyCtrlcToolStripMenuItem.Enabled == true)
            {
                copyCtrlcToolStripMenuItem.Enabled = false;
                cutCtrlxToolStripMenuItem.Enabled = false;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength == 0)
            {
                cutCtrlxToolStripMenuItem.Enabled = false;
                copyCtrlcToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutCtrlxToolStripMenuItem.Enabled = true;
                copyCtrlcToolStripMenuItem.Enabled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Latihan_5_1 f = new Latihan_5_1();
            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Latihan_5_1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*)";
            saveFileDialog1.DefaultExt = "rtf";
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Latihan_5_1", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
