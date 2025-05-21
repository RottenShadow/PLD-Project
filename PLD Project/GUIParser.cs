
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{
    public class GUIParser : MyParser
    {
        private LALRParser? parser;
        private ListBox syntaxListBox;
        private ListBox lexicalListBox;

        public GUIParser(string filename, ListBox syntaxListBox, ListBox lexicalListBox) : base(filename)
        {
            this.syntaxListBox = syntaxListBox;
            this.lexicalListBox = lexicalListBox;
            FileStream stream = new FileStream(
                filename,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            Init(stream);
            stream.Close();
        }

        protected void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }


        public new void Parse(string source)
        {
            NonterminalToken? token = parser?.Parse(source);
            if (token != null)
            {
                Object obj = base.CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            var msg = "Token error with input: '" + args.Token.ToString() + "'" + " in line " + args.Token.Location.LineNr;
            syntaxListBox.Items.Add(msg);
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            var msg = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'" + " in line " + args.UnexpectedToken.Location.LineNr;
            var msg2 = "Expected token: " + args.ExpectedTokens; 
            syntaxListBox.Items.Add(msg);
            syntaxListBox.Items.Add(msg2);
        }
        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            var msg = args.Token.Text + "\t \t" + (SymbolConstants)args.Token.Symbol.Id;
            lexicalListBox.Items.Add(msg);
        }
    }
}