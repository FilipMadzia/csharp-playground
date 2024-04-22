namespace operator_overloading;

class Tensor(double[,] tab)
{
	private readonly double[,] tab = tab;

	public static Tensor operator +(Tensor left, Tensor right)
	{
		var tensor = new double[3,3];

		for(int i = 0; i < 3; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				tensor[i, j] = left.tab[i, j] + right.tab[i, j];
			}
		}

		return new Tensor(tensor);
	}

	public void Display()
	{
		for(int i = 0; i < tab.GetLength(0); i++)
		{
			for(int j = 0; j < tab.GetLength(1); j++)
			{
				Console.Write(tab[i, j]);
			}
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
