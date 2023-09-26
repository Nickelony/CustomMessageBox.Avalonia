using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Linq;

namespace CustomMessageBox.Avalonia
{
	internal static class WindowHelper
	{
		internal static Window? FindViableOwner()
		{
			if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				Window? activeWindow = desktop.Windows.FirstOrDefault(window => window.IsActive);
				return activeWindow ?? desktop.MainWindow;
			}
			else
				throw new NotSupportedException("Only ClassicDesktopStyleApplicationLifetime is supported.");
		}
	}
}
