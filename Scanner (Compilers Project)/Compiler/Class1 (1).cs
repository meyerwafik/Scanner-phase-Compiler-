
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public partial class Class1
{
    public List<Tokenrecord> tokenrecords;
    public int tokenindex;
    public int line;
    public Class1()
    {
    }


    public void Compile(String x)
    {
        line = 1;
        tokenrecords = new List<Tokenrecord>();
        tokenindex = 0;
        int i = 0;
        int startoflexem = 0;//start of the lexem
        int endoflexem = 0;
        string currentlexem = null;
        bool z, flag; ;//z is for the identification of multiple stopping conditions

        Char[] stoppingcondition = { '+', '-', '*', '/', ':', '=', '<', '>', '&', '|', ',', '(', ')', '{', '}', ';','"' };
        String[] reservedword = {"int","float","string","read","write",
            "repeat","until","if","elseif","else","then","return","endl"};

        while (i < x.Length)
        {

            z = false;
            flag = false;
            if (x[i].Equals(' '))
            {
                endoflexem = i - 1;

                if (i != 0)
                {
                    for (int t = 0; t < stoppingcondition.Length; t++)
                    {
                        if (x[i - 1] == stoppingcondition[t])
                        {   
                            z = true;
                            break;
                        }
                    }//if the previous char is a stopping condition there will be no concatination
                     //and the variables start and end of lexem will be given new values

                    if (!(x[i - 1].Equals(' ') || x[i - 1] == '\r' || x[i - 1] == '\n' || z))
                    {

                        for (int j = startoflexem; j <= endoflexem; j++)
                        {
                            currentlexem += x[j];

                        }

                        //used to check the stopping conditions and spaces before concatination
                        //be put in the token record
                        
                        Tokenrecord t = new Tokenrecord();

                        t.lexem = currentlexem;
                        t.t = scan(t.lexem);
                        if (t.t == Tokenrecord.Tokenvalue.T_Number)
                        {
                            t.numvalue = float.Parse(t.lexem.ToString());
                        }
                        t.lineoflexem = line;
                        tokenrecords.Add(t);
                        tokenindex++;
                        currentlexem = null;
                        


                    }
                }
                startoflexem = i + 1;
                endoflexem += 2;
                i++;

                continue;
            }
            if (x[i] == '\n')
            {
                line++;
                endoflexem = i - 1;

                if (i != 0)
                {
                    for (int t = 0; t < stoppingcondition.Length; t++)
                    {
                        if (x[i - 1] == stoppingcondition[t])
                        {
                            z = true;
                            break;
                        }
                    }//if the previous char is a stopping condition there will be no concatination
                     //and the variables start and end of lexem will be given new values

                    if (!(x[i - 1].Equals(' ') || x[i - 1] == '\r' || x[i - 1] == '\n' || z))
                    {
                        for (int j = startoflexem; j <= endoflexem; j++)
                        {
                            currentlexem += x[j];

                        }

                        //used to check the stopping conditions and spaces before concatination
                        //be put in the token record
                        
                        Tokenrecord t = new Tokenrecord();

                        t.lexem = currentlexem;
                        t.t = scan(t.lexem);
                        t.lineoflexem = line-1;
                        if (t.t == Tokenrecord.Tokenvalue.T_Number)
                        {
                            t.numvalue = float.Parse(t.lexem.ToString());
                        }
                        tokenrecords.Add(t);
                        tokenindex++;
                        currentlexem = null;
                        



                    }
                }
                startoflexem = i + 1;
                endoflexem += 2;
                i++;

                continue;
            }

            if (x[i] == '\r')
            {

                endoflexem = i - 1;

                if (i != 0)
                {
                    for (int t = 0; t < stoppingcondition.Length; t++)
                    {
                        if (x[i - 1] == stoppingcondition[t])
                        {
                            z = true;
                            break;
                        }
                    }//if the previous char is a stopping condition there will be no concatination
                     //and the variables start and end of lexem will be given new values

                    if (!(x[i - 1].Equals(' ') || x[i - 1] == '\r' || x[i - 1] == '\n' || z))
                    {
                        for (int j = startoflexem; j <= endoflexem; j++)
                        {
                            currentlexem += x[j];

                        }

                        //used to check the stopping conditions and spaces before concatination
                        //be put in the token record
                        
                        Tokenrecord t = new Tokenrecord();

                        t.lexem = currentlexem;
                        t.t = scan(t.lexem);
                
                        if (t.t == Tokenrecord.Tokenvalue.T_Number)
                        {
                            t.numvalue = float.Parse(t.lexem.ToString());
                        }
                        t.lineoflexem = line-1;
                        tokenrecords.Add(t);
                        tokenindex++;
                        currentlexem = null;
                        



                    }
                }
                startoflexem = i + 1;
                endoflexem += 2;
                i++;

                continue;
            }

            for (int s = 0; s < stoppingcondition.Length; s++)
            {
                if (x[i] == stoppingcondition[s])
                {
                    flag = true;
                    break;
                }
            }



            if (flag)
            {
                if (i != 0)
                {
                    for (int t = 0; t < stoppingcondition.Length; t++)
                    {
                        if (x[i - 1] == stoppingcondition[t])
                        {
                            z = true;
                            break;
                        }
                    }//if the previous char is a stopping condition there will be no concatination
                     //and the variables start and end of lexem will be given new values
                    if (!(x[i - 1].Equals(' ') || x[i - 1] == '\r' || x[i - 1] == '\n' || z))
                    {
                        for (int j = startoflexem; j <= i - 1; j++)
                        {
                            currentlexem += x[j];
                        }
                        

                        Tokenrecord t = new Tokenrecord();

                        t.lexem = currentlexem;
                        t.t = scan(t.lexem);
                        if (t.t == Tokenrecord.Tokenvalue.T_Number)
                        {
                            t.numvalue = float.Parse(t.lexem.ToString());
                        }
                        t.lineoflexem = line;
                        tokenrecords.Add(t);
                        tokenindex++;
                        currentlexem = null;
                    }
                }//used to check the stopping conditions and spaces before concatination
                startoflexem = i + 1;//change the value of the start of the lexem
                endoflexem = i + 1;//change the value of the end of the lexem
                switch (x[i])
                {
                    case '/':
                        {
                            //checking the start of comment
                            if (i+1!=x.Length)
                            {
                                if (x[i + 1] == '*')
                                {
                                    i = i + 2;//after start of comment
                                    if (i == x.Length)
                                    {
                                        string message = " Incomplete comment \n " + "The error is in line " + line;
                                        string title = "Error Message";
                                        MessageBox.Show(message, title);
                                        
                                    }
                                    while ( i<x.Length  ) {
                                        
                                        if (x[i] == '*' && x[i + 1] == '/')
                                        {
                                            break;
                                        }
                                        else if (i == x.Length-2) {
                                            string message = " Incomplete comment \n " + "The error is in line " + line;
                                            string title = "Error Message";
                                            MessageBox.Show(message, title);
                                            break;
                                        }
                                            else i++;
                                    }
                                    
                                    i = i + 2;//after end of comment
                                    startoflexem = i;//update start of lexem after the comment
                                    endoflexem = i;//update end of lexem after the comment
                                    break;

                                }

                                else
                                {
                                    
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = Char.ToString(x[i]);
                                    t.t = Tokenrecord.Tokenvalue.T_DIV;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i++;
                                    break;
                                }
                            }
                            else
                            {
                                
                                Tokenrecord t = new Tokenrecord();
                                t.lexem = Char.ToString(x[i]);
                                t.t = Tokenrecord.Tokenvalue.T_DIV;
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                tokenindex++;
                                i++;
                                break;
                            }
                           

                        }

                    case '-':
                        {
                            
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            if (tokenrecords[tokenindex - 1].t == Tokenrecord.Tokenvalue.T_id || tokenrecords[tokenindex - 1].t == Tokenrecord.Tokenvalue.T_Number)
                            { t.t = Tokenrecord.Tokenvalue.T_SUB; }
                            else { 
                                t.t = Tokenrecord.Tokenvalue.ERROR;
                                string message = " Numbers must be unsigned \n " + "The error is in line " + line;
                                string title = "Error Message";
                                MessageBox.Show(message, title);
                            }
                           
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                           


                        }
                    case ',':
                        {
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_COMMA;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }



                    case '+':
                        {
                            
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_ADD;
                            
                            t.t = Tokenrecord.Tokenvalue.T_ADD; 
                            
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case '*':
                        {
                            
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_MULT;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
    

                    case ':':
                        {
                            if (i + 1 != x.Length  )
                            {
                                if (x[i + 1] == '=')
                                {
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = "" + x[i] + x[i + 1];
                                    t.t = Tokenrecord.Tokenvalue.T_Assignment_Operator;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i = i + 2;
                                    startoflexem = i;//now added 
                                    endoflexem = i;//now
                                }
                                    
                                else
                                {
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = Char.ToString(x[i]);
                                    t.t = Tokenrecord.Tokenvalue.ERROR;
                                    string message = " incorrect assignment operator \n " + "The error is in line " + line;
                                    string title = "Error Message";
                                    MessageBox.Show(message, title);
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i++;

                                }

                            }
                            else
                            {
                                Tokenrecord t = new Tokenrecord();
                                t.lexem = Char.ToString(x[i]);
                                t.t = Tokenrecord.Tokenvalue.ERROR;
                                string message = " incorrect assignment operator \n " + "The error is in line " + line;
                                string title = "Error Message";
                                MessageBox.Show(message, title);
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                tokenindex++;
                                i++;

                            }
                            
                            break;
                        
                        }
                    case '=':
                        {
                           
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_EQUAL;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;

                            break;
                        }
                    case '<':
                        {
                            if ((i + 1 != x.Length) )
                            {
                                if (x[i + 1] == '>')
                                {

                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = "" + x[i] + x[i + 1];
                                    t.t = Tokenrecord.Tokenvalue.T_NOT_EQUAL;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i = i + 2;
                                    startoflexem = i;
                                    endoflexem = i;
                                }
                                
                                    
                                 else
                                {
                                    
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = Char.ToString(x[i]);
                                    t.t = Tokenrecord.Tokenvalue.T_LessThan;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i++;

                                }

                            }
                            else
                            {
                                
                                Tokenrecord t = new Tokenrecord();
                                t.lexem = Char.ToString(x[i]);
                                t.t = Tokenrecord.Tokenvalue.T_LessThan;
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                tokenindex++;
                                i++;

                            }
                            break;
                        }
                    case '>':
                        {
                            
                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_GreaterThan;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case '&':
                        {
                            if ((i + 1) != x.Length  )
                            {
                                if (x[i + 1] == '&')
                                {
 
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = "" + x[i] + x[i + 1];
                                    t.t = Tokenrecord.Tokenvalue.T_AND_Op;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i = i + 2;
                                    startoflexem = i;
                                    endoflexem = i;
                                }

                                else
                                {
                                    
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = Char.ToString(x[i]);
                                    t.t = Tokenrecord.Tokenvalue.ERROR;
                                    string message = " incorrect AND operator \n " + "The error is in line " + line;
                                    string title = "Error Message";
                                    MessageBox.Show(message, title);
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    
                                    tokenindex++;
                                    i++;

                                }

                            }
                            else
                            {
                                
                                Tokenrecord t = new Tokenrecord();
                                t.lexem = Char.ToString(x[i]);
                                t.t = Tokenrecord.Tokenvalue.ERROR;
                                string message = " incorrect AND operator \n " + "The error is in line " + line;
                                string title = "Error Message";
                                MessageBox.Show(message, title);
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                
                                tokenindex++;
                                i++;

                            }
                            
                            break;

                        }
                    case '|':
                        {
                            if ((i+1)!=x.Length) {
                                if (x[i + 1] == '|')
                                {
                                    
                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = "" + x[i] + x[i + 1];
                                    t.t = Tokenrecord.Tokenvalue.T_OR_Op;
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    tokenindex++;
                                    i = i + 2;
                                    startoflexem = i;
                                    endoflexem = i;
                                    break;
                                }
                                else
                                {

                                    Tokenrecord t = new Tokenrecord();
                                    t.lexem = Char.ToString(x[i]);
                                    t.t = Tokenrecord.Tokenvalue.ERROR;
                                    string message = " incorrect OR operator \n " + "The error is in line " + line;
                                    string title = "Error Message";
                                    MessageBox.Show(message, title);
                                    t.lineoflexem = line;
                                    tokenrecords.Add(t);
                                    
                                    tokenindex++;
                                    i++;
                                    break;
                                }

                            }
                            else 
                            {

                                Tokenrecord t = new Tokenrecord();
                                t.lexem = Char.ToString(x[i]);
                                t.t = Tokenrecord.Tokenvalue.ERROR;
                                string message = " incorrect OR operator \n " + "The error is in line " + line;
                                string title = "Error Message";
                                MessageBox.Show(message, title);
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                
                                tokenindex++;
                                i++;
                                break;
                            }
                            
                        }
                    case '{':
                        {
                            

                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_LEFT_BRACE;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case '}':
                        {
                            

                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_RIGHT_BRACE;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }

                    case '(':
                        {
                            

                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_LEFT_BRACKET;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case ')':
                        {
                            

                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_RIGHT_BRACKET;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case ';':
                        {
                          

                            Tokenrecord t = new Tokenrecord();
                            t.lexem = Char.ToString(x[i]);
                            t.t = Tokenrecord.Tokenvalue.T_SEMICOLON;
                            t.lineoflexem = line;
                            tokenrecords.Add(t);
                            tokenindex++;
                            i++;
                            break;
                        }
                    case '\"':
                        {
                           
                            startoflexem = i+1;
                            endoflexem = i+1;
                            i++;
                            while (!(x[i] == '\"'))
                            {
                                currentlexem += x[i];
                                i++;
                                if (i == x.Length) {
                                    string message = " unmatched string \n " + "The error is in line " + line;
                                    string title = "Error Message";
                                    MessageBox.Show(message, title);

                                    break; 
                                }
                                    

                            }


                            if (i != x.Length)
                            {
                                Tokenrecord t = new Tokenrecord();
                                t.lexem = currentlexem;
                                t.t = Tokenrecord.Tokenvalue.STRING;
                                t.lineoflexem = line;
                                tokenrecords.Add(t);
                                tokenindex++;
                            }
                            else
                            { break; }
                            

                                currentlexem = null;
                            i = i + 1;
                            startoflexem = i;
                            endoflexem = i;
                            break;
                        }
                }
                
            }
            else
            {
                i++;

                if (i== x.Length)
                {

                    for (int j = startoflexem; j <= endoflexem; j++)
                    {
                        currentlexem += x[j];
                    }
                    Tokenrecord t = new Tokenrecord();
                    t.lexem = currentlexem;
                    t.t = scan(t.lexem);

                    if (t.t == Tokenrecord.Tokenvalue.T_Number)
                    {
                        t.numvalue = float.Parse(t.lexem.ToString());
                    }
                    t.lineoflexem = line;
                    tokenrecords.Add(t);
                    tokenindex++;
                   


                }
                endoflexem++;
            }

        }
        
    }
    public Tokenrecord.Tokenvalue scan(string s)
    {
        switch (s)
        {
            case "int":
                return Tokenrecord.Tokenvalue.T_Int;
            case "float":
                return Tokenrecord.Tokenvalue.T_Float;
            case "string":
                return Tokenrecord.Tokenvalue.T_String;
            case "read":
                return Tokenrecord.Tokenvalue.T_Read;
            case "write":
                return Tokenrecord.Tokenvalue.T_Write;
            case "repeat":
                return Tokenrecord.Tokenvalue.T_Repeat;
            case "until":
                return Tokenrecord.Tokenvalue.T_Until;
            case "if":
                return Tokenrecord.Tokenvalue.T_IF;
            case "elseif":
                return Tokenrecord.Tokenvalue.T_ELSE_IF;
            case "else":
                return Tokenrecord.Tokenvalue.T_ELSE;
            case "then":
                return Tokenrecord.Tokenvalue.T_THEN;
            case "return":
                return Tokenrecord.Tokenvalue.T_Return;
            case "endl":
                return Tokenrecord.Tokenvalue.T_ENDL;

        }
        if (Char.IsLetter(s[0]))
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (!(Char.IsLetterOrDigit(s[i])))
                {
                    string message = " Identifer must contain only letters and digits \n "+ "The error is in line "+ line;
                    string title = "Error Message";
                    MessageBox.Show(message, title);
                    return Tokenrecord.Tokenvalue.ERROR;

                }
            }
            return Tokenrecord.Tokenvalue.T_id;
        }
        int d = 0;
        bool flag = true;
        if (Char.IsDigit(s[0]))
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (!(char.IsDigit(s[i]) || (s[i]=='.')))
                {
                    flag = false;
                }


                if (s[i]=='.') { d++; }

            }
            if ((d <= 1) && flag)
            {
                return Tokenrecord.Tokenvalue.T_Number;
            }
            else {
                string message = " Invalid number/identifer \n " + "The error is in line " + line;
                string ti = "Error Message";
                MessageBox.Show(message, ti);
                return Tokenrecord.Tokenvalue.ERROR;
            }

        }
        string me = " Invalid character \n " + "The error is in line " + line;
        string tit = "Error Message";
        MessageBox.Show(me,tit);
        return Tokenrecord.Tokenvalue.ERROR;
    }

}




