using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using wpf_introduction.Commands;
using wpf_introduction.Models;
using wpf_introduction.Views;

namespace wpf_introduction.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Computer> Computers { get; set; } = ComputerManager.Computers;
    public ICommand ShowWindowCommand { get; set; }

    public MainViewModel()
    {
        ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
    }

    private bool CanShowWindow(object obj)
    {
        return true;
    }

    private void ShowWindow(object obj)
    {
        var addComputerWindow = new AddComputer();
        addComputerWindow.Show();
    }
}