using System.Windows.Controls;
using CairoDesktop.SupportingClasses;

namespace CairoDesktop.ObjectModel
{
    public abstract class MenuExtra
    {
        public abstract UserControl StartControl(CairoAppBarWindow menuBar);
    }
}