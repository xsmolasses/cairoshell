using CairoDesktop.AppGrabber;
using CairoDesktop.Application.Interfaces;
using CairoDesktop.Infrastructure.Services;

namespace CairoDesktop.Services
{
    public class SettingsUIService : ISettingsUIService
    {
        private readonly IAppGrabber _appGrabber;
        private readonly ICairoApplication _cairoApplication;
        private readonly ShellManagerService _shellManager;
        private readonly IThemeService _themeService;

        internal SettingsUI SettingsUi;
        
        public SettingsUIService(ICairoApplication cairoApplication, IAppGrabber appGrabber,
            ShellManagerService shellManager, IThemeService themeService)
        {
            _appGrabber = appGrabber;
            _cairoApplication = cairoApplication;
            _shellManager = shellManager;
            _themeService = themeService;
        }
        
        public void Show()
        {
            if (SettingsUi == null)
            {
                SettingsUi = new SettingsUI(_cairoApplication, this, _shellManager, _appGrabber, _themeService);
            }
            
            SettingsUi.Show();
            SettingsUi.Activate();
        }

        public void Show(string tabIdentifier)
        {
            // Eventually extensions should be able to add their own tab to the settings window. To show their tab, they pass their extension GUID here.

            Show();
            
            switch (tabIdentifier)
            {
                case "desktop":
                    SettingsUi.TabDesktop.IsSelected = true;
                    break;
            }
        }
    }
}
