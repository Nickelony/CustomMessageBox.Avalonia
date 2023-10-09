using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;

namespace CustomMessageBox.Avalonia.Demo;

public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void Button_Traditional_OK(object? sender, RoutedEventArgs e)
	{
		MessageBox.Show(
			"This is a traditional message box with an \"OK\" button.",
			"Traditional 1");
	}

	private void Button_Traditional_YesNoCancel(object? sender, RoutedEventArgs e)
	{
		MessageBox.Show(
			"This is a traditional message box with \"YesNoCancel\" buttons.",
			"Traditional 2",
			MessageBoxButtons.YesNoCancel,
			MessageBoxIcon.Question,
			MessageBoxDefaultButton.Button1,
			"accent");
	}

	private void Button_Traditional_BottomCenter(object? sender, RoutedEventArgs e)
	{
		var messageBox = new MessageBox(
			"This is a traditional message box with \"YesNo\" buttons.\n" +
			"The buttons are aligned to the center.",
			"Traditional 3", MessageBoxIcon.Information)
		{
			HorizontalButtonsPanelAlignment = HorizontalAlignment.Center
		};

		messageBox.Show(MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, "accent");
	}

	private void Button_Traditional_BottomRight(object? sender, RoutedEventArgs e)
	{
		MessageBox.Show(
			"This is a traditional message box with \"YesNo\" buttons.\n" +
			"The buttons are aligned to the right.",
			"Traditional 4",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Error,
			MessageBoxDefaultButton.Button1,
			"accent");
	}

	private void Button_Traditional_BottomLeft(object? sender, RoutedEventArgs e)
	{
		var messageBox = new MessageBox(
			"This is a traditional message box with \"YesNo\" buttons.\n" +
			"The buttons are aligned to the left.",
			"Traditional 5", MessageBoxIcon.Warning)
		{
			HorizontalButtonsPanelAlignment = HorizontalAlignment.Left
		};

		messageBox.Show(MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, "accent");
	}

	private void Button_Traditional_CustomImage(object? sender, RoutedEventArgs e)
	{
		var bitmap = new Bitmap(AssetLoader.Open(new Uri("avares://CustomMessageBox.Avalonia.Demo/Assets/avalonia-logo.ico")));

		var messageBox = new MessageBox(
			"This is a traditional message box with \"YesNo\" buttons.\n" +
			"The message contains a custom icon with its size set to 64 x 64.",
			"Traditional 6", bitmap)
		{
			MaxIconWidth = 64,
			MaxIconHeight = 64
		};

		messageBox.Show(MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, "accent");
	}

	private void Button_Custom1(object? sender, RoutedEventArgs e)
	{
		var textBlock = new TextBlock
		{
			Text = "This is a custom message box with \"YesNoCancel\" buttons.\n" +
				   "The buttons are displayed vertically and to the left.",
			TextAlignment = TextAlignment.Center
		};

		var messageBox = new MessageBox(textBlock, "Custom 1", MessageBoxIcon.Error)
		{
			DialogContentOrientation = Orientation.Horizontal,
			MessagePanelOrientation = Orientation.Vertical,
			ButtonsPanelOrientation = Orientation.Vertical,
			MaxIconWidth = 192,
			MaxIconHeight = 192
		};

		messageBox.Show(
			new MessageBoxButton<MessageBoxResult>(MessageBox.YesText, MessageBoxResult.Yes, SpecialButtonRole.IsDefault, "accent"),
			new MessageBoxButton<MessageBoxResult>(MessageBox.NoText, MessageBoxResult.No),
			new MessageBoxButton<MessageBoxResult>(MessageBox.CancelText, MessageBoxResult.Cancel, SpecialButtonRole.IsCancel)
		);
	}

	private void Button_Custom2(object? sender, RoutedEventArgs e)
	{
		var textBlock = new TextBlock
		{
			Text = "This is a custom message box with custom buttons.\n" +
				   "The icon is displayed above the text.",
			TextAlignment = TextAlignment.Center
		};

		var messageBox = new MessageBox(textBlock, "Custom 2", MessageBoxIcon.Information)
		{
			MessagePanelOrientation = Orientation.Vertical,
			HorizontalButtonsPanelAlignment = HorizontalAlignment.Center,
			MinButtonWidth = 125
		};

		messageBox.Show(
			new MessageBoxButton<MessageBoxResult>("Yes, Confirm", MessageBoxResult.Yes, SpecialButtonRole.IsDefault, "accent"),
			new MessageBoxButton<MessageBoxResult>("No, Cancel", MessageBoxResult.Cancel, SpecialButtonRole.IsCancel)
		);
	}

	private void Button_Custom3(object? sender, RoutedEventArgs e)
	{
		var textBlock = new TextBlock
		{
			Text = "This is a custom message box with custom buttons.\n\n" +
				   "The buttons are displayed vertically and on the bottom.\n" +
				   "The icon is displayed above the text.",
			TextAlignment = TextAlignment.Center
		};

		var messageBox = new MessageBox(textBlock, "Custom 3", MessageBoxIcon.Warning)
		{
			MessagePanelOrientation = Orientation.Vertical,
			HorizontalButtonsPanelAlignment = HorizontalAlignment.Center,
			ButtonsPanelOrientation = Orientation.Vertical
		};

		messageBox.Show(
			new MessageBoxButton<CustomMessageBoxResult>("Accept", CustomMessageBoxResult.Accept, SpecialButtonRole.None, "accent"),
			new MessageBoxButton<CustomMessageBoxResult>("Decline", CustomMessageBoxResult.Decline)
		);
	}

	private async void Button_Custom4(object? sender, RoutedEventArgs e)
	{
		var bitmap = new Bitmap(AssetLoader.Open(new Uri("avares://CustomMessageBox.Avalonia.Demo/Assets/avalonia-logo.ico")));

		var messageBox = new MessageBox(
			"This is a custom message box with custom buttons.\n" +
			"The icon is custom and is displayed above the text.",
			"Custom 4", bitmap)
		{
			Padding = new Thickness(24),
			DialogContentOrientation = Orientation.Horizontal,
			MessagePanelOrientation = Orientation.Vertical,
			ButtonsPanelOrientation = Orientation.Vertical,
			MinButtonWidth = 110,
			MinButtonHeight = 32,
			HorizontalButtonContentAlignment = HorizontalAlignment.Left,
			ButtonSpacing = 12,
			MaxIconWidth = 256,
			MaxIconHeight = 256
		};

		string[] languages = new[] { "English", "Polish", "German", "Spanish", "Italian", "French", "Chinese" };
		string[] flagUris = new[] { "gb.png", "pl.png", "de.png", "es.png", "it.png", "fr.png", "cn.png" };

		var buttons = new List<MessageBoxButton<int>>();
		var iconMargin = new Thickness(6, 0, 6, 0);

		for (int i = 0; i < languages.Length; i++)
		{
			var content = new StackPanel { Orientation = Orientation.Horizontal };
			var flagIcon = new Bitmap(AssetLoader.Open(new Uri($"avares://CustomMessageBox.Avalonia.Demo/Assets/{flagUris[i]}")));
			content.Children.Add(new Image { Source = flagIcon, Margin = iconMargin });
			content.Children.Add(new TextBlock { Text = languages[i] });

			buttons.Add(new MessageBoxButton<int>(content, i + 1, classNames: "LanguageOptionStyle"));
		}

		int result = await messageBox.Show(buttons.ToArray());

		if (result >= 1)
		{
			var content = new StackPanel { Orientation = Orientation.Horizontal };
			content.Children.Add(new TextBlock { Text = $"You have selected " });
			content.Children.Add(new TextBlock
			{
				Text = languages[result - 1],
				FontWeight = FontWeight.Bold,
				Foreground = Brushes.Green
			});

			await MessageBox.Show(content);
		}
		else
			await MessageBox.Show("You have not selected any language.", icon: MessageBoxIcon.Information);
	}
}
