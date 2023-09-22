﻿using Bit.App.Utilities;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using UIKit;
using Microsoft.Maui.Platform;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Bit.iOS.Core.Utilities
{
    public static class ThemeHelpers
    {
        public static bool LightTheme = true;

        public static UIColor SplashBackgroundColor
        {
            get => ThemeManager.GetResourceColor("SplashBackgroundColor").ToUIColor();
        }
        public static UIColor BackgroundColor
        {
            get => ThemeManager.GetResourceColor("BackgroundColor").ToUIColor();
        }
        public static UIColor MutedColor
        {
            get => ThemeManager.GetResourceColor("MutedColor").ToUIColor();
        }
        public static UIColor SuccessColor
        {
            get => ThemeManager.GetResourceColor("SuccessColor").ToUIColor();
        }
        public static UIColor DangerColor
        {
            get => ThemeManager.GetResourceColor("DangerColor").ToUIColor();
        }
        public static UIColor PrimaryColor
        {
            get => ThemeManager.GetResourceColor("PrimaryColor").ToUIColor();
        }
        public static UIColor TextColor
        {
            get => ThemeManager.GetResourceColor("TextColor").ToUIColor();
        }
        public static UIColor SeparatorColor
        {
            get => ThemeManager.GetResourceColor("SeparatorColor").ToUIColor();
        }
        public static UIColor ListHeaderBackgroundColor
        {
            get => ThemeManager.GetResourceColor("ListHeaderBackgroundColor").ToUIColor();
        }
        public static UIColor NavBarBackgroundColor
        {
            get => ThemeManager.GetResourceColor("NavigationBarBackgroundColor").ToUIColor();
        }
        public static UIColor NavBarTextColor
        {
            get => ThemeManager.GetResourceColor("NavigationBarTextColor").ToUIColor();
        }
        public static UIColor TabBarBackgroundColor
        {
            get => ThemeManager.GetResourceColor("TabBarBackgroundColor").ToUIColor();
        }
        public static UIColor TabBarItemColor
        {
            get => ThemeManager.GetResourceColor("TabBarItemColor").ToUIColor();
        }
        public static UIColor BoxBorderColor
        {
            get => ThemeManager.GetResourceColor("BoxBorderColor").ToUIColor();
        }

        public static void SetAppearance(string theme, bool osDarkModeEnabled)
        {
            SetThemeVariables(theme, osDarkModeEnabled);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UIStepper.Appearance.TintColor = MutedColor;
            if (!LightTheme)
            {
                UISwitch.Appearance.TintColor = MutedColor;
            }
        }

        public static UIFont GetDangerFont()
        {
            // TODO: [MAUI-Migration] [Deprecated] NamedSizes are deprecated on MAUI
            return Microsoft.Maui.Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Small, typeof(UILabel)), FontWeight.Bold).ToUIFont();
        }

        private static void SetThemeVariables(string theme, bool osDarkModeEnabled)
        {
            if (string.IsNullOrWhiteSpace(theme) && osDarkModeEnabled)
            {
                theme = ThemeManager.Dark;
            }

            if (theme == ThemeManager.Dark || theme == ThemeManager.Black || theme == ThemeManager.Nord)
            {
                LightTheme = false;
            }
            else
            {
                LightTheme = true;
            }
        }
    }
}
