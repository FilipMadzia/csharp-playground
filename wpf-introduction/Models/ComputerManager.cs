using System.Collections.ObjectModel;

namespace wpf_introduction.Models;

public class ComputerManager
{
    public static ObservableCollection<Computer> Computers { get; set; } = [ new() { Name = "Lenovo Station", Cpu = "Intel i3-12", Ram = "16GB", Hdd = "Toshiba 1TB", GraphicsCard = "RTX 3060"}, new() { Name = "Dell Station", Cpu = "Intel i5-13", Ram = "32GB", Hdd = "Toshiba 2TB", GraphicsCard = "RTX 4060"} ];
}