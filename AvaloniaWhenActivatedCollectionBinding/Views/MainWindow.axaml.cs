using System.Reactive.Disposables;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaWhenActivatedCollectionBinding.ViewModels;
using ReactiveUI;

namespace AvaloniaWhenActivatedCollectionBinding.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d =>
        {
            this.OneWayBind(ViewModel, vm => vm.Strings, v => v.ComboBox.ItemsSource).DisposeWith(d);
        });
    }
}