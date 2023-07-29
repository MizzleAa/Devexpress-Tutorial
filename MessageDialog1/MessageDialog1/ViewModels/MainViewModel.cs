using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MessageDialog1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        IMessageBoxService MessageBoxService1 { get { return GetService<IMessageBoxService>(ServiceSearchMode.PreferParents); } }

        
        private DelegateCommand test1Command;
        public ICommand Test1Command => test1Command ??= new DelegateCommand(Test1);

        private DelegateCommand test2Command;
        public ICommand Test2Command => test2Command ??= new DelegateCommand(Test2);

        private DelegateCommand test3Command;
        public ICommand Test3Command => test3Command ??= new DelegateCommand(Test3);

        private void Test1()
        {
            MessageBoxService1.Show("This is ChildView");
        }

        private void Test2()
        {
            MessageResult result = MessageBoxService1.ShowMessage(
                messageBoxText: "Save Changes?",
                caption: "DXApplication",
                icon: MessageIcon.Question,
                button: MessageButton.YesNoCancel,
                defaultResult: MessageResult.Cancel
            );
            switch (result)
            {
                case MessageResult.Yes:
                    break;
                case MessageResult.No:
                    break;
                case MessageResult.Cancel:
                    break;
            }
        }

        private void Test3()
        {
            MessageBoxResult result = ThemedMessageBox.Show(
                title: "Button properties",
                text: "Do you want to rename this button",
                messageBoxButtons: MessageBoxButton.YesNo
            );
            if (result == MessageBoxResult.Yes)
            {

            }
        }
    }
}
