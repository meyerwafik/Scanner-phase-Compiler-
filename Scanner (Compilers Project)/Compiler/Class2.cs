using System;

public class Tokenrecord
{
    public string lexem;
    public Tokenvalue t;
    public float numvalue;
    public int lineoflexem;
    public Tokenrecord()
    {

    }

    public enum Tokenvalue
    {

        T_Number,
        T_String,
        T_Comment_Statemenet,
        T_id,
        T_Assignment_Operator,
        T_Int,
        T_Float,
        T_Write,
        T_Read,
        T_Return,
        T_GreaterThan,
        T_EQUAL,
        T_LessThan,
        T_AND_Op,
        T_OR_Op,
        T_IF,
        T_Repeat,
        T_Until,
        T_ELSE_IF,
        T_ELSE,
        T_THEN,
        T_ENDL,
        T_LEFT_BRACKET,
        T_RIGHT_BRACKET,
        T_NOT_EQUAL,
        T_ADD,
        T_SUB,
        T_MULT,
        T_DIV,
        T_LEFT_BRACE,
        T_RIGHT_BRACE,
        T_COMMA,
        T_SEMICOLON,
        STRING,
        ERROR
      
    }

}
