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
		var max = int.MinValue;
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
	
	public double[] GetRoots()
	{		
		try
		{
			switch (_coefficients.Length)
			{
				case 2:
					if (_coefficients[1] == 0)
						return new double[0];
					
					var root = -_coefficients[0] / _coefficients[1];
					
					return new double[1] { root };
					break;
				case 3:
					var delta = _coefficients[1] * _coefficients[1] - 4 * _coefficients[2] * _coefficients[0];
					
					if (delta < 0)
						return new double[0];
					else if (delta == 0)
					{
						var x0 = -_coefficients[1] / 2 * _coefficients[2];
						
						return new double[1] { x0 };
					}
					else if (delta > 0)
					{
						var x1 = (-_coefficients[1] - Math.Sqrt(delta)) / 2 * _coefficients[2];
						var x2 = (-_coefficients[1] + Math.Sqrt(delta)) / 2 * _coefficients[2];
						
						return new double[2] { x1, x2 };
					}
					break;
				default:
					return new double[0];
					break;
			}
		}
		catch (Exception ex)
		{			
			return new double[0];
		}
		
		return new double[0];
	}
}