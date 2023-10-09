using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DialogService1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        readonly RegistrationViewModel registrationViewModel = new ();

        IDialogService DialogService { get { return GetService<IDialogService>(); } }
        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }

        private DelegateCommand dialogService1Command;
        public ICommand DialogService1Command => dialogService1Command ??= new DelegateCommand(DialogService1Button);

        private void DialogService1Button()
        {
            UICommand registerAsyncCommand = new UICommand(
               id: null,
               caption: "Register Async",
               command: new AsyncCommand<CancelEventArgs>(
                   async cancelArgs => {
                       try
                       {
                           await MyAsyncExecuteMethod();
                       }
                       catch (Exception e)
                       {
                           MessageBoxService.ShowMessage(e.Message, "Error", MessageButton.OK);
                           cancelArgs.Cancel = true;
                       }
                   },
                   cancelArgs => !string.IsNullOrEmpty(registrationViewModel.UserName)
               ),
               asyncDisplayMode: AsyncDisplayMode.Wait,
               isDefault: false,
               isCancel: false
           );

            UICommand registerCommand = new UICommand(
                id: null,
                caption: "Register",
                command: new DelegateCommand<CancelEventArgs>(
                    cancelArgs => {
                        try
                        {
                            MyExecuteMethod();
                        }
                        catch (Exception e)
                        {
                            MessageBoxService.ShowMessage(e.Message, "Error", MessageButton.OK);
                            cancelArgs.Cancel = true;
                        }
                    },
                    cancelArgs => !string.IsNullOrEmpty(registrationViewModel.UserName) && !((IAsyncCommand)registerAsyncCommand.Command).IsExecuting
                ),
                isDefault: true,
                isCancel: false
            );

            UICommand cancelCommand = new UICommand(
                id: MessageBoxResult.Cancel,
                caption: "Cancel",
                command: null,
                isDefault: false,
                isCancel: true
            );

            UICommand result = DialogService.ShowDialog(
                dialogCommands: new List<UICommand>() { registerAsyncCommand, registerCommand, cancelCommand },
                title: "Registration Dialog",
                viewModel: registrationViewModel
            );

            if (result == registerCommand)
            {
                // ...
            }
        }

        void MyExecuteMethod()
        {
            // ...
        }

        async Task MyAsyncExecuteMethod()
        {
            await Task.Delay(2000);
            // ...
        }
    }
}
