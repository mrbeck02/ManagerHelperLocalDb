using System.Windows.Input;

namespace ManagerHelperLocalDb.ViewModels.Support
{
    internal interface IRaiseCanExecuteChanged
    {
        void RaiseCanExecuteChanged();
    }

    // And an extension method to make it easy to raise changed events
    public static class CommandExtensions
    {
        public static void RaiseCanExecuteChanged(this ICommand command)
        {
            var canExecuteChanged = command as IRaiseCanExecuteChanged;

            canExecuteChanged?.RaiseCanExecuteChanged();
        }
    }
}
