using System.Text;
using System.Windows.Forms;

namespace wf_hw_five
{
    public partial class Form1 : Form
    {
        private int saved;
        private string currentFileName;
        private string currentPath;

        public Form1()
        {
            InitializeComponent();
            Text = "Untitled - Padnote";
            richTextBox1.WordWrap = false;
            saved = 0;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == 0 && Text[0] == '*')
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files | *.txt";
                saveFileDialog.DefaultExt = "txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                        file.Write(bytes, 0, bytes.Length);
                    }
                    richTextBox1.Text = "";
                    richTextBox1.ForeColor = Color.Black;
                    Text = "Untitled - Padnote";
                    saved = 0;
                }
                else
                {
                    return;
                }
            }
            else if (saved == 1)
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
                Text = "Untitled - Padnote";
                saved = 0;
            }
            else if (saved == 2)
            {
                var result = MessageBox.Show("Do you want to save changes in text?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files | *.txt";
                    saveFileDialog.DefaultExt = "txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                        {
                            byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                            file.Write(bytes, 0, bytes.Length);
                        }
                        richTextBox1.Text = "";
                        richTextBox1.ForeColor = Color.Black;
                        Text = "Untitled - Padnote";
                        saved = 0;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (result == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    richTextBox1.ForeColor = Color.Black;
                    Text = "Untitled - Padnote";
                    saved = 0;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files | *.txt";
                openFileDialog.DefaultExt = "txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        byte[] bytes = new byte[(int)file.Length];
                        file.Read(bytes, 0, bytes.Length);
                        richTextBox1.Text = Encoding.Default.GetString(bytes);
                    }
                    richTextBox1.ForeColor = Color.Black;
                    richTextBox1.Font = new Font("Segoe UI", 9F);
                    saved = 1;
                    currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                    currentPath = openFileDialog.FileName;
                    Text = $"{currentFileName} - Padnote";
                }
            }
            else if (saved == 0 && Text[0] == '*')
            {
                var result = MessageBox.Show("Do you want to save this text?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files | *.txt";
                    saveFileDialog.DefaultExt = "txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                            file.Write(bytes, 0, bytes.Length);
                        }
                    }
                    else
                    {
                        return;
                    }
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text Files | *.txt";
                    openFileDialog.DefaultExt = "txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            byte[] bytes = new byte[(int)file.Length];
                            file.Read(bytes, 0, bytes.Length);
                            richTextBox1.Text = Encoding.Default.GetString(bytes);
                        }
                        richTextBox1.ForeColor = Color.Black;
                        richTextBox1.Font = new Font("Segoe UI", 9F);
                        saved = 1;
                        currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                        currentPath = openFileDialog.FileName;
                        Text = $"{currentFileName} - Padnote";
                    }
                }
                else if (result == DialogResult.No)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text Files | *.txt";
                    openFileDialog.DefaultExt = "txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            byte[] bytes = new byte[(int)file.Length];
                            file.Read(bytes, 0, bytes.Length);
                            richTextBox1.Text = Encoding.Default.GetString(bytes);
                        }
                        richTextBox1.ForeColor = Color.Black;
                        richTextBox1.Font = new Font("Segoe UI", 9F);
                        saved = 1;
                        currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                        currentPath = openFileDialog.FileName;
                        Text = $"{currentFileName} - Padnote";
                    }
                }
            }
            else if (saved == 1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files | *.txt";
                openFileDialog.DefaultExt = "txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        byte[] bytes = new byte[(int)file.Length];
                        file.Read(bytes, 0, bytes.Length);
                        richTextBox1.Text = Encoding.Default.GetString(bytes);
                    }
                    richTextBox1.ForeColor = Color.Black;
                    richTextBox1.Font = new Font("Segoe UI", 9F);
                    currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                    currentPath = openFileDialog.FileName;
                    Text = $"{currentFileName} - Padnote";
                }
            }
            else if (saved == 2)
            {
                var result = MessageBox.Show("Do you want to save changes in text?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files | *.txt";
                    saveFileDialog.DefaultExt = "txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                        {
                            byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                            file.Write(bytes, 0, bytes.Length);
                        }
                    }
                    else
                    {
                        return;
                    }
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text Files | *.txt";
                    openFileDialog.DefaultExt = "txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            byte[] bytes = new byte[(int)file.Length];
                            file.Read(bytes, 0, bytes.Length);
                            richTextBox1.Text = Encoding.Default.GetString(bytes);
                        }
                        richTextBox1.ForeColor = Color.Black;
                        richTextBox1.Font = new Font("Segoe UI", 9F);
                        saved = 1;
                        currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                        currentPath = openFileDialog.FileName;
                        Text = $"{currentFileName} - Padnote";
                    }
                }
                else if (result == DialogResult.No)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text Files | *.txt";
                    openFileDialog.DefaultExt = "txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            byte[] bytes = new byte[(int)file.Length];
                            file.Read(bytes, 0, bytes.Length);
                            richTextBox1.Text = Encoding.Default.GetString(bytes);
                        }
                        richTextBox1.ForeColor = Color.Black;
                        richTextBox1.Font = new Font("Segoe UI", 9F);
                        saved = 1;
                        currentFileName = openFileDialog.SafeFileName[0..(openFileDialog.SafeFileName.Length - 4)].ToString();
                        currentPath = openFileDialog.FileName;
                        Text = $"{currentFileName} - Padnote";
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == 0 && Text[0] == '*')
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files | *.txt";
                saveFileDialog.DefaultExt = "txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                        file.Write(bytes, 0, bytes.Length);
                    }
                    saved = 1;
                    currentFileName = string.Empty;
                    for (int i = saveFileDialog.FileName.Length - 4; saveFileDialog.FileName[i] != '/'; i--)
                    {
                        currentFileName = currentFileName.Prepend(saveFileDialog.FileName[i]).ToString()!;
                    }
                    Text = $"{currentFileName} - Padnote";
                }
            }
            else if (saved == 1)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files | *.txt";
                saveFileDialog.DefaultExt = "txt";
                using (FileStream file = new FileStream(currentPath, FileMode.Create))
                {
                    byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                    file.Write(bytes, 0, bytes.Length);
                }
                Text = $"{currentFileName} - Padnote";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (saved == 0 && Text[0] != '*')
            {
                Text = "*Untitled - Padnote";
            }
            else if (saved == 1)
            {
                Text = $"*{currentFileName} - Padnote";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == 0 && Text[0] == '*')
            {
                var result = MessageBox.Show("Do you want to save this text?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files | *.txt";
                    saveFileDialog.DefaultExt = "txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                            file.Write(bytes, 0, bytes.Length);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            else if (saved == 2)
            {
                var result = MessageBox.Show("Do you want to save changes in text?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files | *.txt";
                    saveFileDialog.DefaultExt = "txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                        {
                            byte[] bytes = Encoding.Default.GetBytes(richTextBox1.Text);
                            file.Write(bytes, 0, bytes.Length);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length != 0)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                }
                else
                {
                    richTextBox1.Font = fontDialog.Font;
                }
            }
            else
            {
                return;
            }
        }

        private void colToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length != 0)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
                else
                {
                    richTextBox1.ForeColor = colorDialog.Color;
                }
            }
            else
            {
                return;
            }
        }

        private void hotkeyHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ctrl + N - Creates new file\nCtrl + O - Opens file\nCtrl + S - Saves current file\nCtrl + P - Opens print dialog\nCtrl + Q - Exits");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My name is Rasul and this is my Padnote (Notepad)!");
        }
    }
}