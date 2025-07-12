using System.Windows;
using System.Windows.Controls;

namespace DefendTheBase;

public partial class DebugWindow : Window
{
	public Point MousePosition
	{
		set => MousePositionLbl.Content = $"Mouse Position: {value}";
	}
	
	public DebugWindow()
	{
		InitializeComponent();
	}
}