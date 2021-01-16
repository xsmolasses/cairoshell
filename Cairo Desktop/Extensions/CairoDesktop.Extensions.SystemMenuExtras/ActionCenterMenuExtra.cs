using CairoDesktop.ObjectModel;
using System.Windows.Controls;
using CairoDesktop.Configuration;
using CairoDesktop.SupportingClasses;
using ManagedShell.Common.Helpers;

namespace CairoDesktop.Extensions.SystemMenuExtras
{
    class ActionCenterMenuExtra : MenuExtra
    {
        public override UserControl StartControl(CairoAppBarWindow menuBar)
        {
            if (Settings.Instance.EnableMenuExtraActionCenter && EnvironmentHelper.IsWindows10OrBetter && !EnvironmentHelper.IsAppRunningAsShell)
            {
                return new ActionCenter(menuBar);
            }

            return null;
        }
    }
}