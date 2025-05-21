# PLD-Project **--> [YouTube Video](https://youtu.be/lJbIjeWyer0)**

This C# GUI parser program is designed to perform both syntax and lexical analysis on input code, leveraging the capabilities of the GOLD Parser Framework. The application provides a user-friendly interface that allows users to input source code and receive immediate feedback regarding its syntactic correctness and lexical structure.

# Key Features:
1. **User Interface**: The program features a simple GUI built using Windows Forms, allowing users to easily input code, view errors, and navigate through the parsing process.

2. **Lexical Analysis**: Utilizing the GOLD Parser, the program performs lexical analysis to identify tokens in the input code. It recognizes keywords, identifiers, operators, and other language constructs, ensuring that the lexical rules are adhered to.

3. **Syntax Analysis**: The program conducts syntax analysis by evaluating the structured arrangement of tokens according to predefined grammar rules. It checks for correct syntax based on the specified grammar, highlighting errors and providing detailed feedback.

4. **Grammar Definition**: Users can load custom grammar definitions by **overwriting "Parser.cs" file and change the method "CreateObject" from private to protected**, allowing for flexibility and adaptability to various syntax rules.

5. **Real-Time Feedback**: As users edit their code, the program offers real-time feedback on any syntax or lexical errors, enabling immediate corrections and improving coding efficiency.
