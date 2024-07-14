using MvvmLib.ViewModels;

namespace MvvmLib.Messages;

public class ChangeViewModelMessage(BaseViewModel viewModel) : IMessage
{
    public BaseViewModel ViewModel { get; } = viewModel;
}