using com.calitha.goldparser;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PLD_Project
{
    public partial class Form1 : Form
    {
        bool isAutoParse = false;
        private GUIParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new GUIParser("Grammer.cgt", syntaxListBox, lexicalListBox);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isAutoParse) startParsing();
        }

        private void parseBtn_Click(object sender, EventArgs e)
        {
            startParsing();
        }

        private void autoParseBtn_Click(object sender, EventArgs e)
        {
            if (isAutoParse) autoParseBtn.Text = "Auto Parse: Off";
            else autoParseBtn.Text = "Auto Parse: On";
            isAutoParse = !isAutoParse;
            startParsing();
        }

        private void startParsing()
        {
            if (textBox1.Text.Length == 0)
            {
                resetForm();
                return;
            }
            syntaxListBox.Items.Clear();
            lexicalListBox.Items.Clear();
            parser.Parse(textBox1.Text);

            if (syntaxListBox.Items.Count == 0)
            {
                var msg = "Syntax looks good to me :)";
                syntaxListBox.Items.Add(msg);
            }
        }
        private void resetForm()
        {
            syntaxListBox.Items.Clear();
            syntaxListBox.Items.Add("Syntax Analyzer");
            lexicalListBox.Items.Clear();
            lexicalListBox.Items.Add("Lexical Analyzer");
        }
        
    
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Add Spaces for Cleaner View ref => 80% ChatGPT :)
            //Not needed for Grammer analysis or anything related :)

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                int caretIndex = textBox1.SelectionStart;
                int currentLineIndex = textBox1.GetLineFromCharIndex(caretIndex);
                string[] lines = textBox1.Lines;

                if (currentLineIndex >= 0 && currentLineIndex < lines.Length)
                {
                    string currentLine = lines[currentLineIndex];
                    string leadingWhitespace = new(currentLine.TakeWhile(char.IsWhiteSpace).ToArray());

                    // Add More Spaces if line ends with : symbol
                    // Used with condition and loop statements
                    if (currentLine.EndsWith(":")) leadingWhitespace += "  ";

                    // Remove More Spaces if line ends with 'end' symbol (reverse the effect mentioned above)
                    if (currentLine.EndsWith("end"))
                    {
                        if (leadingWhitespace.Length >= 2) 
                            leadingWhitespace = leadingWhitespace.Remove(leadingWhitespace.Length - 2);

                        else leadingWhitespace = "";
                    }

                    // Insert new line + same indentation
                    string insertText = Environment.NewLine + leadingWhitespace;
                    textBox1.Text = textBox1.Text.Insert(caretIndex, insertText);
                    textBox1.SelectionStart = caretIndex + insertText.Length;
                }
            }
        }
    }
}


