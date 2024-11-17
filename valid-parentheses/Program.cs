namespace valid_parentheses;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(ValidParentheses("(){}[]"));
		Console.WriteLine(ValidParentheses("({[]})"));
		Console.WriteLine(ValidParentheses("(}[({"));
	}
	static bool ValidParentheses(string s)
	{
		var stack = new Stack<char>();
		
		foreach (var c in s)
		{
			switch(c)
			{
				case '(':
					stack.Push(c);
					break;
				case ')':
					if (stack.Count == 0)
						return false;
					if (stack.Peek() == '(')
					{
						stack.Pop();
					}
					else
					{
						stack.Push(c);
					}
                    
					break;
				case '{':
					stack.Push(c);
					break;
				case '}':
					if (stack.Count == 0)
						return false;
					if (stack.Peek() == '{')
					{
						stack.Pop();
					}
					else
					{
						stack.Push(c);
					}
                    
					break;
				case '[':
					stack.Push(c);
					break;
				case ']':
					if (stack.Count == 0)
						return false;
					if (stack.Peek() == '[')
					{
						stack.Pop();
					}
					else
					{
						stack.Push(c);
					}
                    
					break;
				default:
					throw new Exception();
			}
		}

		var areParenthesesValid = stack.Count == 0;
		
		return areParenthesesValid;
	}
}