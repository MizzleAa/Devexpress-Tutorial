using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using ModuleInjectionFramework1.Common;
using System;

namespace ModuleInjectionFramework1.Modules
{
    public class ModuleViewModel : IDocumentModule, ISupportState<ModuleViewModel.Info>
    {
        public string Caption { get; set; }

        public bool IsActive { get; set; }

        public ModuleViewModel()
        {

        }

        public static ModuleViewModel Create(string caption)
        {
            return ViewModelSource.Create(() => new ModuleViewModel()
            {
                Caption = caption,
            });
        }

        #region Serialization
        [Serializable]
        public class Info
        {
            public string Caption { get; set; }
        }
        Info ISupportState<Info>.SaveState()
        {
            return new Info()
            {
                Caption = this.Caption,
            };
        }
        void ISupportState<Info>.RestoreState(Info state)
        {
            this.Caption = state.Caption;
        }
        #endregion
    }
}
