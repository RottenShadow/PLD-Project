
namespace PLD_Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            syntaxListBox = new ListBox();
            button1 = new Button();
            autoParseBtn = new Button();
            lexicalListBox = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AcceptsTab = true;
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(358, 421);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // syntaxListBox
            // 
            syntaxListBox.FormattingEnabled = true;
            syntaxListBox.HorizontalScrollbar = true;
            syntaxListBox.Items.AddRange(new object[] { "Syntax Analyzer" });
            syntaxListBox.Location = new Point(394, 9);
            syntaxListBox.Name = "syntaxListBox";
            syntaxListBox.Size = new Size(620, 144);
            syntaxListBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(218, 449);
            button1.Name = "button1";
            button1.Size = new Size(152, 29);
            button1.TabIndex = 2;
            button1.Text = "Parse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += parseBtn_Click;
            // 
            // autoParseBtn
            // 
            autoParseBtn.Location = new Point(394, 449);
            autoParseBtn.Name = "autoParseBtn";
            autoParseBtn.Size = new Size(145, 29);
            autoParseBtn.TabIndex = 3;
            autoParseBtn.Text = "Auto Parse: Off";
            autoParseBtn.UseVisualStyleBackColor = true;
            autoParseBtn.Click += autoParseBtn_Click;
            // 
            // lexicalListBox
            // 
            lexicalListBox.FormattingEnabled = true;
            lexicalListBox.HorizontalScrollbar = true;
            lexicalListBox.Items.AddRange(new object[] { "Lexical Analyzer" });
            lexicalListBox.Location = new Point(394, 171);
            lexicalListBox.Name = "lexicalListBox";
            lexicalListBox.Size = new Size(620, 264);
            lexicalListBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 490);
            Controls.Add(lexicalListBox);
            Controls.Add(autoParseBtn);
            Controls.Add(button1);
            Controls.Add(syntaxListBox);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "PLD Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ListBox syntaxListBox;
        private Button button1;
        private Button autoParseBtn;
        private ListBox lexicalListBox;
    }
}
