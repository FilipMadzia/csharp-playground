namespace operator_overloading;

class Program
{
	static void Main()
	{
		var tensor1 = new Tensor(new double[,]
		{
			{ 0, 1, 2 },
			{ 0, 1, 2 },
			{ 0, 1, 2 }
		});
		var tensor2 = new Tensor(new double[,]
		{
			{ 3, 1, 2 },
			{ 3, 1, 2 },
			{ 3, 1, 2 }
		});

		tensor1.Display();
		tensor2.Display();

		var tensor3 = tensor1 + tensor2;

		tensor3.Display();
	}
}
