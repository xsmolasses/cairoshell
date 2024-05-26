﻿using CairoDesktop.AppGrabber;
using CairoDesktop.Application.Interfaces;
using CairoDesktop.Common;
using CairoDesktop.Infrastructure.Services;
using CairoDesktop.Interfaces;
using ManagedShell.AppBar;

namespace CairoDesktop.Services
{
    public class MenuBarWindowService : AppBarWindowService
    {
        private readonly IAppGrabber _appGrabber;
        private readonly ISettingsUIService _settingsUiService;

        public MenuBarWindowService(ICairoApplication cairoApplication, ShellManagerService shellManagerService, IWindowManager windowManager, IAppGrabber appGrabber, ISettingsUIService settingsUiService) : base(cairoApplication, shellManagerService, windowManager)
        {
            _appGrabber = appGrabber;
            _settingsUiService = settingsUiService;

            EnableMultiMon = Settings.Instance.EnableMenuBarMultiMon;
            EnableService = Settings.Instance.EnableMenuBar;
        }

        protected override void HandleSettingChange(string setting)
        {
            switch (setting)
            {
                case "EnableMenuBar":
                    HandleEnableServiceChanged(Settings.Instance.EnableMenuBar);
                    break;
                case "EnableMenuBarMultiMon":
                    HandleEnableMultiMonChanged(Settings.Instance.EnableMenuBarMultiMon);
                    break;
            }
        }

        protected override void OpenWindow(AppBarScreen screen)
        {
            MenuBar newMenuBar = new MenuBar(_cairoApplication, _shellManager, _windowManager, _appGrabber, _settingsUiService, screen, Settings.Instance.MenuBarEdge, Settings.Instance.EnableMenuBarAutoHide ? AppBarMode.AutoHide : AppBarMode.Normal);
            Windows.Add(newMenuBar);
            newMenuBar.Show();
        }
    }
}
