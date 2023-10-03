using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace CustomMessageBox.Avalonia.Demo;

public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void Button_Traditional_OK(object? sender, RoutedEventArgs e)
	{
		MessageBox.Show(
			"This is a traditional message box with an \"OK\" button.",
			"Traditional 1", MessageBoxButtons.OK);
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
			IconWidth = 64,
			IconHeight = 64
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
			IconWidth = 192,
			IconHeight = 192
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

	private void Button_Custom4(object? sender, RoutedEventArgs e)
	{
		var bitmap = new Bitmap(AssetLoader.Open(new Uri("avares://CustomMessageBox.Avalonia.Demo/Assets/avalonia-logo.ico")));

		var messageBox = new MessageBox(
			"This is a custom message box with custom buttons.\n" +
			"The icon is custom and is displayed above the text.",
			"Custom 4", bitmap)
		{
			DialogContentOrientation = Orientation.Horizontal,
			MessagePanelOrientation = Orientation.Vertical,
			ButtonsPanelOrientation = Orientation.Vertical,
			IconWidth = 256,
			IconHeight = 256
		};

		messageBox.Show(
			new MessageBoxButton<int>("English", 1),
			new MessageBoxButton<int>("Polish", 2),
			new MessageBoxButton<int>("German", 3),
			new MessageBoxButton<int>("Spanish", 4),
			new MessageBoxButton<int>("Italian", 5),
			new MessageBoxButton<int>("French", 6),
			new MessageBoxButton<int>("Chinese", 7)
		);
	}
}
