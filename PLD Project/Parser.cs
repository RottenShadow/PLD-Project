
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_MINUSMINUS  =  4, // '--'
        SYMBOL_EXCLAMEQ    =  5, // '!='
        SYMBOL_AMPAMP      =  6, // '&&'
        SYMBOL_LPAREN      =  7, // '('
        SYMBOL_RPAREN      =  8, // ')'
        SYMBOL_TIMES       =  9, // '*'
        SYMBOL_TIMESTIMES  = 10, // '**'
        SYMBOL_DIV         = 11, // '/'
        SYMBOL_COLON       = 12, // ':'
        SYMBOL_SEMI        = 13, // ';'
        SYMBOL_PIPEPIPE    = 14, // '||'
        SYMBOL_PLUS        = 15, // '+'
        SYMBOL_PLUSPLUS    = 16, // '++'
        SYMBOL_LT          = 17, // '<'
        SYMBOL_LTEQ        = 18, // '<='
        SYMBOL_EQ          = 19, // '='
        SYMBOL_EQEQ        = 20, // '=='
        SYMBOL_GT          = 21, // '>'
        SYMBOL_GTEQ        = 22, // '>='
        SYMBOL_DIGITS      = 23, // Digits
        SYMBOL_DOUBLE      = 24, // double
        SYMBOL_ELIF        = 25, // elif
        SYMBOL_ELSE        = 26, // else
        SYMBOL_END         = 27, // end
        SYMBOL_FOR         = 28, // for
        SYMBOL_GO          = 29, // go
        SYMBOL_IDENTIFIER  = 30, // Identifier
        SYMBOL_IF          = 31, // if
        SYMBOL_IN          = 32, // in
        SYMBOL_INT         = 33, // int
        SYMBOL_NUM         = 34, // num
        SYMBOL_PRINT       = 35, // print
        SYMBOL_STRING      = 36, // String
        SYMBOL_WHILE       = 37, // while
        SYMBOL_ASSIGNMENT  = 38, // <Assignment>
        SYMBOL_CONDITION   = 39, // <Condition>
        SYMBOL_DATA        = 40, // <Data>
        SYMBOL_ELIF_STMTS  = 41, // <Elif_Stmts>
        SYMBOL_ELSE_STMT   = 42, // <Else_Stmt>
        SYMBOL_EXPRESSION  = 43, // <Expression>
        SYMBOL_FOR_IN_STMT = 44, // <For_In_Stmt>
        SYMBOL_FOR_STMT    = 45, // <For_Stmt>
        SYMBOL_IF_STMT     = 46, // <If_Stmt>
        SYMBOL_MULTEXP     = 47, // <Mult Exp>
        SYMBOL_NEGATEEXP   = 48, // <Negate Exp>
        SYMBOL_OP          = 49, // <op>
        SYMBOL_ORANDOP     = 50, // <OrAndOp>
        SYMBOL_POWEXP      = 51, // <Pow Exp>
        SYMBOL_PRINT_STMT  = 52, // <Print_Stmt>
        SYMBOL_PROGRAM     = 53, // <Program>
        SYMBOL_STEP        = 54, // <Step>
        SYMBOL_STMS_LIST   = 55, // <Stms_list>
        SYMBOL_STMT        = 56, // <Stmt>
        SYMBOL_VALUE       = 57, // <Value>
        SYMBOL_WHILE_STMT  = 58  // <While_Stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_GO_END                                     =  0, // <Program> ::= go <Stms_list> end
        RULE_STMS_LIST                                          =  1, // <Stms_list> ::= <Stmt>
        RULE_STMS_LIST2                                         =  2, // <Stms_list> ::= <Stmt> <Stms_list>
        RULE_STMT                                               =  3, // <Stmt> ::= <Assignment>
        RULE_STMT2                                              =  4, // <Stmt> ::= <Print_Stmt>
        RULE_STMT3                                              =  5, // <Stmt> ::= <If_Stmt>
        RULE_STMT4                                              =  6, // <Stmt> ::= <While_Stmt>
        RULE_STMT5                                              =  7, // <Stmt> ::= <For_Stmt>
        RULE_STMT6                                              =  8, // <Stmt> ::= <For_In_Stmt>
        RULE_DATA_INT                                           =  9, // <Data> ::= int
        RULE_DATA_DOUBLE                                        = 10, // <Data> ::= double
        RULE_DATA_NUM                                           = 11, // <Data> ::= num
        RULE_DATA_STRING                                        = 12, // <Data> ::= String
        RULE_ASSIGNMENT_IDENTIFIER_EQ                           = 13, // <Assignment> ::= Identifier '=' <Expression>
        RULE_ASSIGNMENT_IDENTIFIER_EQ2                          = 14, // <Assignment> ::= <Data> Identifier '=' <Expression>
        RULE_PRINT_STMT_PRINT_LPAREN_RPAREN                     = 15, // <Print_Stmt> ::= print '(' <Expression> ')'
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END                 = 16, // <If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END2                = 17, // <If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end <Elif_Stmts> <Else_Stmt>
        RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END3                = 18, // <If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end <Else_Stmt>
        RULE_ELIF_STMTS_ELIF_LPAREN_RPAREN_COLON_END            = 19, // <Elif_Stmts> ::= elif '(' <Condition> ')' ':' <Stms_list> end <Elif_Stmts>
        RULE_ELIF_STMTS_ELIF_LPAREN_RPAREN_COLON_END2           = 20, // <Elif_Stmts> ::= elif '(' <Condition> ')' ':' <Stms_list> end
        RULE_ELSE_STMT_ELSE_COLON_END                           = 21, // <Else_Stmt> ::= else ':' <Stms_list> end
        RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON_END           = 22, // <While_Stmt> ::= while '(' <Condition> ')' ':' <Stms_list> end
        RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON_END     = 23, // <For_Stmt> ::= for '(' <Assignment> ';' <Condition> ';' <Step> ')' ':' <Stms_list> end
        RULE_FOR_IN_STMT_FOR_IDENTIFIER_IN_IDENTIFIER_COLON_END = 24, // <For_In_Stmt> ::= for Identifier in Identifier ':' <Stms_list> end
        RULE_OP_GT                                              = 25, // <op> ::= '>'
        RULE_OP_LT                                              = 26, // <op> ::= '<'
        RULE_OP_LTEQ                                            = 27, // <op> ::= '<='
        RULE_OP_GTEQ                                            = 28, // <op> ::= '>='
        RULE_OP_EQEQ                                            = 29, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                        = 30, // <op> ::= '!='
        RULE_ORANDOP_PIPEPIPE                                   = 31, // <OrAndOp> ::= '||'
        RULE_ORANDOP_AMPAMP                                     = 32, // <OrAndOp> ::= '&&'
        RULE_CONDITION                                          = 33, // <Condition> ::= <Expression> <op> <Expression>
        RULE_CONDITION2                                         = 34, // <Condition> ::= <Expression> <op> <Expression> <OrAndOp> <Condition>
        RULE_EXPRESSION_PLUS                                    = 35, // <Expression> ::= <Expression> '+' <Mult Exp>
        RULE_EXPRESSION_MINUS                                   = 36, // <Expression> ::= <Expression> '-' <Mult Exp>
        RULE_EXPRESSION                                         = 37, // <Expression> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                      = 38, // <Mult Exp> ::= <Mult Exp> '*' <Pow Exp>
        RULE_MULTEXP_DIV                                        = 39, // <Mult Exp> ::= <Mult Exp> '/' <Pow Exp>
        RULE_MULTEXP                                            = 40, // <Mult Exp> ::= <Pow Exp>
        RULE_POWEXP_TIMESTIMES                                  = 41, // <Pow Exp> ::= <Pow Exp> '**' <Negate Exp>
        RULE_POWEXP                                             = 42, // <Pow Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS                                    = 43, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                          = 44, // <Negate Exp> ::= <Value>
        RULE_VALUE_DIGITS                                       = 45, // <Value> ::= Digits
        RULE_VALUE_IDENTIFIER                                   = 46, // <Value> ::= Identifier
        RULE_VALUE_LPAREN_RPAREN                                = 47, // <Value> ::= '(' <Expression> ')'
        RULE_STEP_PLUSPLUS_IDENTIFIER                           = 48, // <Step> ::= '++' Identifier
        RULE_STEP_MINUSMINUS_IDENTIFIER                         = 49, // <Step> ::= '--' Identifier
        RULE_STEP_IDENTIFIER_PLUSPLUS                           = 50, // <Step> ::= Identifier '++'
        RULE_STEP_IDENTIFIER_MINUSMINUS                         = 51, // <Step> ::= Identifier '--'
        RULE_STEP                                               = 52  // <Step> ::= <Assignment>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        protected Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGITS :
                //Digits
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF :
                //elif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GO :
                //go
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<Condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<Data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF_STMTS :
                //<Elif_Stmts>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE_STMT :
                //<Else_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_IN_STMT :
                //<For_In_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<For_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<If_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ORANDOP :
                //<OrAndOp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POWEXP :
                //<Pow Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT :
                //<Print_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<Step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMS_LIST :
                //<Stms_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<While_Stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_GO_END :
                //<Program> ::= go <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMS_LIST :
                //<Stms_list> ::= <Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMS_LIST2 :
                //<Stms_list> ::= <Stmt> <Stms_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<Stmt> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<Stmt> ::= <Print_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT3 :
                //<Stmt> ::= <If_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT4 :
                //<Stmt> ::= <While_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT5 :
                //<Stmt> ::= <For_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT6 :
                //<Stmt> ::= <For_In_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<Data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<Data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_NUM :
                //<Data> ::= num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<Data> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ :
                //<Assignment> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ2 :
                //<Assignment> ::= <Data> Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN_RPAREN :
                //<Print_Stmt> ::= print '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END :
                //<If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END2 :
                //<If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end <Elif_Stmts> <Else_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_COLON_END3 :
                //<If_Stmt> ::= if '(' <Condition> ')' ':' <Stms_list> end <Else_Stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_STMTS_ELIF_LPAREN_RPAREN_COLON_END :
                //<Elif_Stmts> ::= elif '(' <Condition> ')' ':' <Stms_list> end <Elif_Stmts>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_STMTS_ELIF_LPAREN_RPAREN_COLON_END2 :
                //<Elif_Stmts> ::= elif '(' <Condition> ')' ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_STMT_ELSE_COLON_END :
                //<Else_Stmt> ::= else ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_LPAREN_RPAREN_COLON_END :
                //<While_Stmt> ::= while '(' <Condition> ')' ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON_END :
                //<For_Stmt> ::= for '(' <Assignment> ';' <Condition> ';' <Step> ')' ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_IN_STMT_FOR_IDENTIFIER_IN_IDENTIFIER_COLON_END :
                //<For_In_Stmt> ::= for Identifier in Identifier ':' <Stms_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ORANDOP_PIPEPIPE :
                //<OrAndOp> ::= '||'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ORANDOP_AMPAMP :
                //<OrAndOp> ::= '&&'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<Condition> ::= <Expression> <op> <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION2 :
                //<Condition> ::= <Expression> <op> <Expression> <OrAndOp> <Condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<Expression> ::= <Expression> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<Expression> ::= <Expression> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Pow Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Pow Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Pow Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWEXP_TIMESTIMES :
                //<Pow Exp> ::= <Pow Exp> '**' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWEXP :
                //<Pow Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_DIGITS :
                //<Value> ::= Digits
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS_IDENTIFIER :
                //<Step> ::= '++' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS_IDENTIFIER :
                //<Step> ::= '--' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_IDENTIFIER_PLUSPLUS :
                //<Step> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_IDENTIFIER_MINUSMINUS :
                //<Step> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<Step> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
