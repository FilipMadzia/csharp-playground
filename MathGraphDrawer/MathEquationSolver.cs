using System.Text.RegularExpressions;

namespace MathGraphDrawer;

public class MathEquationSolver
{
	private string _equation;
	private double[] _coefficients = [];

	public MathEquationSolver(string equation)
	{
		_equation = equation;
		
		_coefficients = ParsePolynomial(_equation);
	}
	
	private double[] ParsePolynomial(string input)
	{
		input = input.Replace("-", "+-").Replace(" ", "").ToLower();

		var termPattern = new Regex(@"([+-]?\d*\.?\d*)x\^?(\d*)|([+-]?\d+)");
		var matches = termPattern.Matches(input);

		var coeffDict = new Dictionary<int, double>();

		foreach (Match match in matches)
		{
			if (match.Groups[1].Success)
			{
				var coeffStr = match.Groups[1].Value;
				var coeff = coeffStr == "+" || coeffStr == "" ? 1 :
					coeffStr == "-" ? -1 : double.Parse(coeffStr);
				var power = match.Groups[2].Success && match.Groups[2].Value != ""
					? int.Parse(match.Groups[2].Value)
					: 1;

				if (!coeffDict.ContainsKey(power))
					coeffDict[power] = 0;
				coeffDict[power] += coeff;
			}
			else if (match.Groups[3].Success)
			{
				var constant = double.Parse(match.Groups[3].Value);
				if (!coeffDict.ContainsKey(0))
					coeffDict[0] = 0;
				coeffDict[0] += constant;
			}
		}

		var degree = coeffDict.Count > 0 ? Math.Max(0, Math.Max(0, MaxKey(coeffDict))) : 0;
		var result = new double[degree + 1];
		for (int i = 0; i <= degree; i++)
		{
			result[i] = coeffDict.ContainsKey(i) ? coeffDict[i] : 0;
		}

		return result;
	}
	
	private int MaxKey(Dictionary<int, double> dict)
	{
		int max = int.MinValue;
		foreach (var key in dict.Keys)
		{
			if (key > max) max = key;
		}
		return max;
	}
	
	public double SolveEquationForX(double x)
	{
		var result = 0d;

		for (var i = 0; i < _coefficients.Length; i++)
		{
			result += _coefficients[i] * Math.Pow(x, i);
		}
		
		return result;
	}
}