using System.Windows;
using System.Windows.Controls;

namespace ContentControl1.Common
{
    public class MainViewTemplateSelector : DataTemplateSelector
    {
        public DataTemplate View1Template { get; set; }
        public DataTemplate View2Template { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is string viewName)
            {
                switch (viewName)
                {
                    case "View1":
                        return View1Template;
                    case "View2":
                        return View2Template;
                }
            }
            return null;
        }

    }
}
