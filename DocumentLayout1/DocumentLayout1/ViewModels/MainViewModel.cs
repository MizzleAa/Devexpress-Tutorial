using DevExpress.Mvvm;
using DocumentLayout1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace DocumentLayout1.ViewModels
{
    public class ControlRegion : ViewModelBase
    {
        private Guid uid;
        public Guid Uid { get => uid; set => SetValue(ref uid, value); }

        private object viewRegion;
        public object ViewRegion { get => viewRegion; set => SetValue(ref viewRegion, value); }

        private string caption = DateTime.Now.ToString();
        public string Caption { get => caption; set => SetValue(ref caption, value); }

        private string sample = string.Empty;
        public string Sample { get => sample; set => SetValue(ref sample, value); }

        public ControlRegion(string sample) 
        {
            Sample = sample;
            Uid = Guid.NewGuid();
            var model = new DocumentViewModel
            {
                Sample = Sample,
            };
            ViewRegion = new DocumentView(model);
        }
    }

    public class MainViewModel : ViewModelBase
    {
        private readonly Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;
        public virtual IList<ControlRegion> DocumentGroupPanels { get; set; }

        private int documentGroupPanelsSelectedTabIndex;
        public int DocumentGroupPanelsSelectedTabIndex { get => documentGroupPanelsSelectedTabIndex; set => SetValue(ref documentGroupPanelsSelectedTabIndex, value, changedCallback: Callback); }


        private DelegateCommand addCommand;
        public ICommand AddCommand => addCommand ??= new DelegateCommand(Add);

        public MainViewModel()
        {
            DocumentGroupPanels = new ObservableCollection<ControlRegion> { };
        }

        private void Add()
        {
            Dispatcher.Invoke(() =>
            {
                DocumentGroupPanels.Add(new ControlRegion(Guid.NewGuid().ToString()));
            });
        }

        private void Callback()
        {
        }
    }

}
