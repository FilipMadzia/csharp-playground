namespace stairs_exercise
{
	public partial class MainPage : ContentPage
	{
		const int minHeight = 14;
		const int maxHeight = 19;
		const int minDepth = 25;
		const int maxDepth = 32;

		public MainPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			var availableHeight = int.Parse(inputHeight.Text);
			var availableDepth = int.Parse(inputDepth.Text);

			if(availableHeight < minHeight || availableDepth < minDepth)
			{
				resultLayout.IsVisible = false;
				errorLabel.Text = "Za małe wartości";

				return;
			}

			for(int height = maxHeight; height >= minHeight; --height)
			{
				for(int depth = maxDepth; depth >= minDepth; --depth)
				{
					int stepsByHeight = availableHeight / height;
					int stepsByDepth = availableDepth / depth;

					if(stepsByHeight * height <= availableHeight && stepsByDepth * depth <= availableDepth)
					{
						resultLayout.IsVisible = true;

						stairsCountLabel.Text = "Ilość schodów: " + stepsByHeight;
						heightOfEachStairLabel.Text = "Wysokość każdego stopnia: " + height;
						depthOfEachStairLabel.Text = "Głębokość każdego stopnia: " + depth;
					}
				}
			}
		}
	}

}
