using CommunityToolkit.Mvvm.Input;
using PropertyChanged;

namespace GrpcSample;

[AddINotifyPropertyChangedInterface]
public partial class MainViewModel : IMainViewModel
{
    public int MyProperty { get; set; } = 1;

    [RelayCommand]
    private void Increment() => ++MyProperty;
}
