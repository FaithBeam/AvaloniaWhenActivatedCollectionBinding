using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using DynamicData;
using ReactiveUI;

namespace AvaloniaWhenActivatedCollectionBinding.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IActivatableViewModel
{
    private readonly ReadOnlyObservableCollection<string> _strings;
    public MainWindowViewModel()
    {
        Activator = new ViewModelActivator();
        var sourceList = new SourceList<string>();
        sourceList.Connect().Bind(out _strings).Subscribe();
        this.WhenActivated(d =>
        {
            sourceList.Edit(x => x.Add("First"));
            this.RaisePropertyChanged(nameof(Strings));
            Disposable.Create(() => { }).DisposeWith(d);
        });
    }
    public ReadOnlyObservableCollection<string> Strings => _strings;
    public ViewModelActivator Activator { get; }
}