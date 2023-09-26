using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomMessageBox.Avalonia
{
	[TemplatePart(Name = "PART_ButtonsPanel", Type = typeof(StackPanel))]
	public partial class MessageBox : Window
	{
		#region MessageBoxIcon enum icons

		// Using Fluent Icons for Avalonia: http://avaloniaui.github.io/icons.html

		public static Geometry QuestionIconGeometry { get; set; } = Geometry.Parse("M24 4C35.0457 4 44 12.9543 44 24C44 35.0457 35.0457 44 24 44C12.9543 44 4 35.0457 4 24C4 12.9543 12.9543 4 24 4ZM24 6.5C14.335 6.5 6.5 14.335 6.5 24C6.5 33.665 14.335 41.5 24 41.5C33.665 41.5 41.5 33.665 41.5 24C41.5 14.335 33.665 6.5 24 6.5ZM24.25 32C25.0784 32 25.75 32.6716 25.75 33.5C25.75 34.3284 25.0784 35 24.25 35C23.4216 35 22.75 34.3284 22.75 33.5C22.75 32.6716 23.4216 32 24.25 32ZM24.25 13C27.6147 13 30.5 15.8821 30.5 19.2488C30.502 21.3691 29.7314 22.7192 27.8216 24.7772L26.8066 25.8638C25.7842 27.0028 25.3794 27.7252 25.3409 28.5793L25.3379 28.7411L25.3323 28.8689L25.3143 28.9932C25.2018 29.5636 24.7009 29.9957 24.0968 30.0001C23.4065 30.0049 22.8428 29.4493 22.8379 28.7589C22.8251 26.9703 23.5147 25.7467 25.1461 23.9739L26.1734 22.8762C27.5312 21.3837 28.0012 20.503 28 19.25C28 17.2634 26.2346 15.5 24.25 15.5C22.3307 15.5 20.6142 17.1536 20.5055 19.0587L20.4935 19.3778C20.4295 20.0081 19.8972 20.5 19.25 20.5C18.5596 20.5 18 19.9404 18 19.25C18 15.8846 20.8864 13 24.25 13Z");
		public static Geometry ErrorIconGeometry { get; set; } = Geometry.Parse("M12,2 C17.523,2 22,6.478 22,12 C22,17.522 17.523,22 12,22 C6.477,22 2,17.522 2,12 C2,6.478 6.477,2 12,2 Z M12,3.667 C7.405,3.667 3.667,7.405 3.667,12 C3.667,16.595 7.405,20.333 12,20.333 C16.595,20.333 20.333,16.595 20.333,12 C20.333,7.405 16.595,3.667 12,3.667 Z M11.9986626,14.5022358 C12.5502088,14.5022358 12.9973253,14.9493523 12.9973253,15.5008984 C12.9973253,16.0524446 12.5502088,16.4995611 11.9986626,16.4995611 C11.4471165,16.4995611 11,16.0524446 11,15.5008984 C11,14.9493523 11.4471165,14.5022358 11.9986626,14.5022358 Z M11.9944624,7 C12.3741581,6.99969679 12.6881788,7.28159963 12.7381342,7.64763535 L12.745062,7.7494004 L12.7486629,12.2509944 C12.7489937,12.6652079 12.4134759,13.0012627 11.9992625,13.0015945 C11.6195668,13.0018977 11.3055461,12.7199949 11.2555909,12.3539592 L11.2486629,12.2521941 L11.245062,7.7506001 C11.2447312,7.33638667 11.580249,7.00033178 11.9944624,7 Z");
		public static Geometry WarningIconGeometry { get; set; } = Geometry.Parse("M10.9093922,2.78216375 C11.9491636,2.20625071 13.2471955,2.54089334 13.8850247,3.52240345 L13.9678229,3.66023048 L21.7267791,17.6684928 C21.9115773,18.0021332 22.0085303,18.3772743 22.0085303,18.7586748 C22.0085303,19.9495388 21.0833687,20.9243197 19.9125791,21.003484 L19.7585303,21.0086748 L4.24277801,21.0086748 C3.86146742,21.0086748 3.48641186,20.9117674 3.15282824,20.7270522 C2.11298886,20.1512618 1.7079483,18.8734454 2.20150311,17.8120352 L2.27440063,17.668725 L10.0311968,3.66046274 C10.2357246,3.291099 10.5400526,2.98673515 10.9093922,2.78216375 Z M20.4146132,18.3952808 L12.6556571,4.3870185 C12.4549601,4.02467391 11.9985248,3.89363262 11.6361802,4.09432959 C11.5438453,4.14547244 11.4637001,4.21532637 11.4006367,4.29899869 L11.3434484,4.38709592 L3.58665221,18.3953582 C3.385998,18.7577265 3.51709315,19.2141464 3.87946142,19.4148006 C3.96285732,19.4609794 4.05402922,19.4906942 4.14802472,19.5026655 L4.24277801,19.5086748 L19.7585303,19.5086748 C20.1727439,19.5086748 20.5085303,19.1728883 20.5085303,18.7586748 C20.5085303,18.6633247 20.4903516,18.5691482 20.455275,18.4811011 L20.4146132,18.3952808 L12.6556571,4.3870185 L20.4146132,18.3952808 Z M12.0004478,16.0017852 C12.5519939,16.0017852 12.9991104,16.4489016 12.9991104,17.0004478 C12.9991104,17.5519939 12.5519939,17.9991104 12.0004478,17.9991104 C11.4489016,17.9991104 11.0017852,17.5519939 11.0017852,17.0004478 C11.0017852,16.4489016 11.4489016,16.0017852 12.0004478,16.0017852 Z M11.9962476,8.49954934 C12.3759432,8.49924613 12.689964,8.78114897 12.7399193,9.14718469 L12.7468472,9.24894974 L12.750448,13.7505438 C12.7507788,14.1647572 12.4152611,14.5008121 12.0010476,14.5011439 C11.621352,14.5014471 11.3073312,14.2195442 11.257376,13.8535085 L11.250448,13.7517435 L11.2468472,9.25014944 C11.2465164,8.83593601 11.5820341,8.49988112 11.9962476,8.49954934 Z");
		public static Geometry InformationIconGeometry { get; set; } = Geometry.Parse("M14,2 C20.6274,2 26,7.37258 26,14 C26,20.6274 20.6274,26 14,26 C7.37258,26 2,20.6274 2,14 C2,7.37258 7.37258,2 14,2 Z M14,3.5 C8.20101,3.5 3.5,8.20101 3.5,14 C3.5,19.799 8.20101,24.5 14,24.5 C19.799,24.5 24.5,19.799 24.5,14 C24.5,8.20101 19.799,3.5 14,3.5 Z M14,11 C14.3796833,11 14.6934889,11.2821653 14.7431531,11.6482323 L14.75,11.75 L14.75,19.25 C14.75,19.6642 14.4142,20 14,20 C13.6203167,20 13.3065111,19.7178347 13.2568469,19.3517677 L13.25,19.25 L13.25,11.75 C13.25,11.3358 13.5858,11 14,11 Z M14,7 C14.5523,7 15,7.44772 15,8 C15,8.55228 14.5523,9 14,9 C13.4477,9 13,8.55228 13,8 C13,7.44772 13.4477,7 14,7 Z");

		public static IBrush QuestionIconColor { get; set; } = new SolidColorBrush(new Color(255, 64, 128, 255));
		public static IBrush ErrorIconColor { get; set; } = new SolidColorBrush(new Color(255, 255, 64, 64));
		public static IBrush WarningIconColor { get; set; } = new SolidColorBrush(new Color(255, 255, 128, 64));
		public static IBrush InformationIconColor { get; set; } = new SolidColorBrush(new Color(255, 64, 128, 255));

		#endregion MessageBoxIcon enum icons

		#region Button texts (can be used for static translations)

		public static string OKText { get; set; } = "OK";
		public static string YesText { get; set; } = "Yes";
		public static string NoText { get; set; } = "No";
		public static string AbortText { get; set; } = "Abort";
		public static string RetryText { get; set; } = "Retry";
		public static string IgnoreText { get; set; } = "Ignore";
		public static string CancelText { get; set; } = "Cancel";
		public static string TryAgainText { get; set; } = "Try Again";
		public static string ContinueText { get; set; } = "Continue";

		#endregion Button texts (can be used for static translations)

		#region Styled properties

		public static StyledProperty<double> IconWidthProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(IconWidth), 32);
		public static StyledProperty<double> IconHeightProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(IconHeight), 32);

		public static StyledProperty<double> MinButtonWidthProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(MinButtonWidth), 100);

		public static StyledProperty<double> IconToMessageSpacingProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(IconToMessageSpacing), 16);
		public static StyledProperty<double> MessagePanelToButtonsPanelSpacingProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(MessagePanelToButtonsPanelSpacing), 16);
		public static StyledProperty<double> ButtonSpacingProperty = AvaloniaProperty.Register<MessageBox, double>(nameof(ButtonSpacing), 8);

		public static StyledProperty<Orientation> DialogContentOrientationProperty = AvaloniaProperty.Register<MessageBox, Orientation>(nameof(DialogContentOrientation), Orientation.Vertical);
		public static StyledProperty<Orientation> MessagePanelOrientationProperty = AvaloniaProperty.Register<MessageBox, Orientation>(nameof(MessagePanelOrientation), Orientation.Horizontal);
		public static StyledProperty<Orientation> ButtonsPanelOrientationProperty = AvaloniaProperty.Register<MessageBox, Orientation>(nameof(ButtonsPanelOrientation), Orientation.Horizontal);

		public static StyledProperty<HorizontalAlignment> HorizontalMessagePanelAlignmentProperty = AvaloniaProperty.Register<MessageBox, HorizontalAlignment>(nameof(HorizontalMessagePanelAlignment), HorizontalAlignment.Center);
		public static StyledProperty<VerticalAlignment> VerticalMessagePanelAlignmentProperty = AvaloniaProperty.Register<MessageBox, VerticalAlignment>(nameof(VerticalMessagePanelAlignment), VerticalAlignment.Center);

		public static StyledProperty<HorizontalAlignment> HorizontalButtonsPanelAlignmentProperty = AvaloniaProperty.Register<MessageBox, HorizontalAlignment>(nameof(HorizontalButtonsPanelAlignment), HorizontalAlignment.Right);
		public static StyledProperty<VerticalAlignment> VerticalButtonsPanelAlignmentProperty = AvaloniaProperty.Register<MessageBox, VerticalAlignment>(nameof(VerticalButtonsPanelAlignment), VerticalAlignment.Center);

		public static StyledProperty<HorizontalAlignment> HorizontalIconAlignmentProperty = AvaloniaProperty.Register<MessageBox, HorizontalAlignment>(nameof(HorizontalIconAlignment), HorizontalAlignment.Center);
		public static StyledProperty<VerticalAlignment> VerticalIconAlignmentProperty = AvaloniaProperty.Register<MessageBox, VerticalAlignment>(nameof(VerticalIconAlignment), VerticalAlignment.Center);

		public static StyledProperty<HorizontalAlignment> HorizontalMessageAlignmentProperty = AvaloniaProperty.Register<MessageBox, HorizontalAlignment>(nameof(HorizontalMessageAlignment), HorizontalAlignment.Center);
		public static StyledProperty<VerticalAlignment> VerticalMessageAlignmentProperty = AvaloniaProperty.Register<MessageBox, VerticalAlignment>(nameof(VerticalMessageAlignment), VerticalAlignment.Center);

		/// <summary>
		/// Width of the icon which is shown inside the Message Panel.
		/// </summary>
		public double IconWidth
		{
			get => GetValue(IconWidthProperty);
			set => SetValue(IconWidthProperty, value);
		}

		/// <summary>
		/// Height of the icon which is shown inside the Message Panel.
		/// </summary>
		public double IconHeight
		{
			get => GetValue(IconHeightProperty);
			set => SetValue(IconHeightProperty, value);
		}

		/// <summary>
		/// Minimum width of the generated buttons.
		/// </summary>
		public double MinButtonWidth
		{
			get => GetValue(MinButtonWidthProperty);
			set => SetValue(MinButtonWidthProperty, value);
		}

		/// <summary>
		/// The spacing between the Icon and the Message inside the Message Panel.
		/// </summary>
		public double IconToMessageSpacing
		{
			get => GetValue(IconToMessageSpacingProperty);
			set => SetValue(IconToMessageSpacingProperty, value);
		}

		/// <summary>
		/// The spacing between the Message Panel (Icon + Message) and the Buttons Panel.
		/// </summary>
		public double MessagePanelToButtonsPanelSpacing
		{
			get => GetValue(MessagePanelToButtonsPanelSpacingProperty);
			set => SetValue(MessagePanelToButtonsPanelSpacingProperty, value);
		}

		/// <summary>
		/// The spacing between each generated button.
		/// </summary>
		public double ButtonSpacing
		{
			get => GetValue(ButtonSpacingProperty);
			set => SetValue(ButtonSpacingProperty, value);
		}

		/// <summary>
		/// The main orientation of the dialog. Change this if you want the buttons to be either at the <b>Bottom</b> or to the <b>Right</b> (<i>Left</i> in RTL).
		/// </summary>
		public Orientation DialogContentOrientation
		{
			get => GetValue(DialogContentOrientationProperty);
			set => SetValue(DialogContentOrientationProperty, value);
		}

		/// <summary>
		/// The orientation of the Message Panel (Icon + Message). Change this if you want the Icon to be either above the Message (Vertical) or next to it (Horizontal).
		/// </summary>
		public Orientation MessagePanelOrientation
		{
			get => GetValue(MessagePanelOrientationProperty);
			set => SetValue(MessagePanelOrientationProperty, value);
		}

		/// <summary>
		/// The orientation of the Buttons Panel.
		/// </summary>
		public Orientation ButtonsPanelOrientation
		{
			get => GetValue(ButtonsPanelOrientationProperty);
			set => SetValue(ButtonsPanelOrientationProperty, value);
		}

		/// <summary>
		/// Horizontal alignment of the Message Panel (Icon + Message).
		/// </summary>
		public HorizontalAlignment HorizontalMessagePanelAlignment
		{
			get => GetValue(HorizontalMessagePanelAlignmentProperty);
			set => SetValue(HorizontalMessagePanelAlignmentProperty, value);
		}

		/// <summary>
		/// Vertical alignment of the Message Panel (Icon + Message).
		/// </summary>
		public VerticalAlignment VerticalMessagePanelAlignment
		{
			get => GetValue(VerticalMessagePanelAlignmentProperty);
			set => SetValue(VerticalMessagePanelAlignmentProperty, value);
		}

		/// <summary>
		/// Horizontal alignment of the Buttons Panel.
		/// </summary>
		public HorizontalAlignment HorizontalButtonsPanelAlignment
		{
			get => GetValue(HorizontalButtonsPanelAlignmentProperty);
			set => SetValue(HorizontalButtonsPanelAlignmentProperty, value);
		}

		/// <summary>
		/// Vertical alignment of the Buttons Panel.
		/// </summary>
		public VerticalAlignment VerticalButtonsPanelAlignment
		{
			get => GetValue(VerticalButtonsPanelAlignmentProperty);
			set => SetValue(VerticalButtonsPanelAlignmentProperty, value);
		}

		/// <summary>
		/// Horizontal alignment of the Icon inside the Message Panel.
		/// </summary>
		public HorizontalAlignment HorizontalIconAlignment
		{
			get => GetValue(HorizontalIconAlignmentProperty);
			set => SetValue(HorizontalIconAlignmentProperty, value);
		}

		/// <summary>
		/// Vertical alignment of the Icon inside the Message Panel.
		/// </summary>
		public VerticalAlignment VerticalIconAlignment
		{
			get => GetValue(VerticalIconAlignmentProperty);
			set => SetValue(VerticalIconAlignmentProperty, value);
		}

		/// <summary>
		/// Horizontal alignment of the Message inside the Message Panel.
		/// </summary>
		public HorizontalAlignment HorizontalMessageAlignment
		{
			get => GetValue(HorizontalMessageAlignmentProperty);
			set => SetValue(HorizontalMessageAlignmentProperty, value);
		}

		/// <summary>
		/// Vertical alignment of the Message inside the Message Panel.
		/// </summary>
		public VerticalAlignment VerticalMessageAlignment
		{
			get => GetValue(VerticalMessageAlignmentProperty);
			set => SetValue(VerticalMessageAlignmentProperty, value);
		}

		#endregion Styled properties

		#region Construction

		private MessageBox()
		{
			InitializeComponent();

			Padding = new Thickness(16);
			ShowInTaskbar = false;
		}

		public MessageBox(object message, string caption) : this()
		{
			Title = caption;
			SetMessageContent(message);
			SetMessageIcon(null);
		}

		public MessageBox(object message, string caption, MessageBoxIcon icon) : this(message, caption)
			=> SetMessageIcon(icon);

		public MessageBox(object message, string caption, Bitmap? icon) : this(message, caption)
			=> SetMessageIcon(icon);

		#endregion Construction

		#region Show()

		/// <summary>
		/// Shows the message box with the specified buttons.
		/// <para>The owner of the dialog is determined by the currently active Window or the MainWindow.</para>
		/// </summary>
		public Task<TResult> Show<TResult>(params MessageBoxButton<TResult>[] buttons) where TResult : struct
			=> Show(WindowHelper.FindViableOwner(), buttons);

		/// <summary>
		/// Shows the message box with the specified buttons.
		/// </summary>
		public Task<TResult> Show<TResult>(Window? owner, params MessageBoxButton<TResult>[] buttons) where TResult : struct
		{
			Icon = owner?.Icon;

			StackPanel buttonPanel = this.FindControl<StackPanel>("PART_ButtonsPanel")!;
			TResult result = default;

			void AddButton(MessageBoxButton<TResult> messageBoxButton)
			{
				var button = new Button
				{
					Content = messageBoxButton.Content,
					IsDefault = messageBoxButton.SpecialRole == SpecialButtonRole.IsDefault,
					IsCancel = messageBoxButton.SpecialRole == SpecialButtonRole.IsCancel
				};

				Array.ForEach(messageBoxButton.ClassNames, className => button.Classes.Add(className));

				button.Click += delegate
				{
					result = messageBoxButton.Result;
					Close();
				};

				buttonPanel.Children.Add(button);
			}

			Array.ForEach(buttons, AddButton);

			var completionSource = new TaskCompletionSource<TResult>();
			Closed += delegate { completionSource.TrySetResult(result); };

			if (owner != null)
				ShowDialog(owner);
			else
				Show();

			return completionSource.Task;
		}

		#endregion Show()

		#region Static Show()

		/// <summary>
		/// The classic way of showing a message box.
		/// <para>You can additionally pass custom style classes for the default button to make it stand out.</para>
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="buttons">An enum of preset buttons which should appear in the <see cref="MessageBox" />.</param>
		/// <param name="icon">Determines the preset icon which should appear inside the Message Panel.</param>
		/// <param name="defaultButton">Determines which <see cref="Button" /> should have its <c>IsDefault</c> value set to <see langword="true" />.</param>
		/// <param name="defaultButtonClassNames">The style class names which should be applied onto the <see cref="Button" />, which has <c>IsDefault</c> set to <see langword="true" />.</param>
		/// <returns>A <see cref="MessageBoxResult"/>.</returns>
		public static Task<MessageBoxResult> Show(object message, string caption,
			MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None,
			MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.None, params string[] defaultButtonClassNames)
			=> Show(WindowHelper.FindViableOwner(), message, caption, buttons, icon, defaultButton, defaultButtonClassNames);

		/// <summary>
		/// Opens a message box with the specified content.
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="icon">Determines the preset icon which should appear inside the Message Panel.</param>
		/// <param name="buttons">A collection of custom buttons which should appear in the <see cref="MessageBox" />.</param>
		public static Task<TResult> Show<TResult>(object message, string caption,
			MessageBoxIcon icon = MessageBoxIcon.None, params MessageBoxButton<TResult>[] buttons) where TResult : struct
			=> Show(WindowHelper.FindViableOwner(), message, caption, icon, buttons);

		/// <summary>
		/// Opens a message box with the specified custom icon and message.
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="icon">The custom icon which should appear inside the Message Panel.</param>
		/// <param name="buttons">A collection of custom buttons which should appear in the <see cref="MessageBox" />.</param>
		public static Task<TResult> Show<TResult>(object message, string caption,
			Bitmap? icon = null, params MessageBoxButton<TResult>[] buttons) where TResult : struct
			=> Show(WindowHelper.FindViableOwner(), message, caption, icon, buttons);

		/// <summary>
		/// The classic way of showing a message box.
		/// <para>You can additionally pass custom style classes for the default button to make it stand out.</para>
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="buttons">An enum of preset buttons which should appear in the <see cref="MessageBox" />.</param>
		/// <param name="icon">Determines the preset icon which should appear inside the Message Panel.</param>
		/// <param name="defaultButton">Determines which <see cref="Button" /> should have its <c>IsDefault</c> value set to <see langword="true" />.</param>
		/// <param name="defaultButtonClassNames">The style class names which should be applied onto the <see cref="Button" />, which has <c>IsDefault</c> set to <see langword="true" />.</param>
		/// <returns>A <see cref="MessageBoxResult"/>.</returns>
		public static Task<MessageBoxResult> Show(Window? owner, object message, string caption,
			MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None,
			MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.None, params string[] defaultButtonClassNames)
		{
			var buttonList = new List<MessageBoxButton<MessageBoxResult>>();

			void AddButtonToList(MessageBoxButton<MessageBoxResult> messageBoxButton)
			{
				if (buttonList.Count == (int)defaultButton)
					messageBoxButton.SpecialRole = SpecialButtonRole.IsDefault;

				if (messageBoxButton.SpecialRole == SpecialButtonRole.IsDefault && defaultButtonClassNames != null)
					messageBoxButton.ClassNames = defaultButtonClassNames;

				buttonList.Add(messageBoxButton);
			}

			if (buttons == MessageBoxButtons.OK || buttons == MessageBoxButtons.OKCancel)
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(OKText, MessageBoxResult.OK));

			if (buttons == MessageBoxButtons.YesNo || buttons == MessageBoxButtons.YesNoCancel)
			{
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(YesText, MessageBoxResult.Yes));
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(NoText, MessageBoxResult.No));
			}

			if (buttons == MessageBoxButtons.AbortRetryIgnore)
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(AbortText, MessageBoxResult.Abort));

			if (buttons == MessageBoxButtons.AbortRetryIgnore || buttons == MessageBoxButtons.RetryCancel)
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(RetryText, MessageBoxResult.Retry));

			if (buttons == MessageBoxButtons.AbortRetryIgnore)
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(IgnoreText, MessageBoxResult.Ignore));

			if (buttons == MessageBoxButtons.OKCancel ||
				buttons == MessageBoxButtons.YesNoCancel ||
				buttons == MessageBoxButtons.RetryCancel ||
				buttons == MessageBoxButtons.CancelTryContinue)
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(CancelText, MessageBoxResult.Cancel, SpecialButtonRole.IsCancel));

			if (buttons == MessageBoxButtons.CancelTryContinue)
			{
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(TryAgainText, MessageBoxResult.TryAgain));
				AddButtonToList(new MessageBoxButton<MessageBoxResult>(ContinueText, MessageBoxResult.Continue));
			}

			return Show(owner, message, caption, icon, buttonList.ToArray());
		}

		/// <summary>
		/// Opens a message box with the specified content.
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="icon">Determines the preset icon which should appear inside the Message Panel.</param>
		/// <param name="buttons">A collection of custom buttons which should appear in the <see cref="MessageBox" />.</param>
		public static Task<TResult> Show<TResult>(Window? owner, object message, string caption,
			MessageBoxIcon icon = MessageBoxIcon.None, params MessageBoxButton<TResult>[] buttons) where TResult : struct
		{
			var box = new MessageBox(message, caption, icon);
			return box.Show(owner, buttons);
		}

		/// <summary>
		/// Opens a message box with the specified custom icon and message.
		/// </summary>
		/// <param name="message">Custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.</param>
		/// <param name="caption">The title of the <see cref="MessageBox" /> dialog.</param>
		/// <param name="icon">The custom icon which should appear inside the Message Panel.</param>
		/// <param name="buttons">A collection of custom buttons which should appear in the <see cref="MessageBox" />.</param>
		public static Task<TResult> Show<TResult>(Window? owner, object message, string caption,
			Bitmap? icon = null, params MessageBoxButton<TResult>[] buttons) where TResult : struct
		{
			var box = new MessageBox(message, caption, icon);
			return box.Show(owner, buttons);
		}

		#endregion Static Show()

		#region Other methods

		/// <summary>
		/// Sets the preset icon which should be shown inside the Message Panel.
		/// </summary>
		public void SetMessageIcon(MessageBoxIcon icon)
		{
			if (this.FindControl<Image>("PART_ImageIcon") is Image image)
				image.IsVisible = false;

			if (this.FindControl<PathIcon>("PART_PathIcon") is PathIcon pathIcon)
			{
				pathIcon.IsVisible = true;

				pathIcon.Data = icon switch
				{
					MessageBoxIcon.Question => QuestionIconGeometry,
					MessageBoxIcon.Error => ErrorIconGeometry,
					MessageBoxIcon.Warning => WarningIconGeometry,
					MessageBoxIcon.Information => InformationIconGeometry,
					_ => Geometry.Parse(string.Empty)
				};

				pathIcon.Foreground = icon switch
				{
					MessageBoxIcon.Question => QuestionIconColor,
					MessageBoxIcon.Error => ErrorIconColor,
					MessageBoxIcon.Warning => WarningIconColor,
					MessageBoxIcon.Information => InformationIconColor,
					_ => Brushes.Transparent
				};
			}

			if (icon == MessageBoxIcon.None && this.FindControl<Grid>("PART_IconGrid") is Grid grid)
				grid.IsVisible = false;
		}

		/// <summary>
		/// Sets a custom icon which should be shown inside the Message Panel.
		/// </summary>
		public void SetMessageIcon(Bitmap? icon)
		{
			if (this.FindControl<PathIcon>("PART_PathIcon") is PathIcon pathIcon)
				pathIcon.IsVisible = false;

			if (this.FindControl<Image>("PART_ImageIcon") is Image image)
			{
				image.IsVisible = true;
				image.Source = icon;

				if (icon != null)
				{
					image.Width = icon.PixelSize.Width;
					image.Height = icon.PixelSize.Height;
				}
			}
		}

		/// <summary>
		/// Sets the custom content of the <see cref="MessageBox" />. This doesn't have to be just text, but may also be a custom control.
		/// </summary>
		public void SetMessageContent(object content)
		{
			if (this.FindControl<ContentPresenter>("PART_ContentPresenter") is ContentPresenter contentPresenter)
				contentPresenter.Content = content;
		}

		#endregion Other methods
	}
}
