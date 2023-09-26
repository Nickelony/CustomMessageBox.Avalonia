namespace CustomMessageBox.Avalonia
{
	public struct MessageBoxButton<TResult> where TResult : struct
	{
		public object Content { get; set; }
		public TResult Result { get; set; }
		public string[] ClassNames { get; set; }
		public SpecialButtonRole SpecialRole { get; set; }

		public MessageBoxButton(object content, TResult result, SpecialButtonRole specialRole = SpecialButtonRole.None)
			: this(content, result, specialRole, string.Empty)
		{ }

		public MessageBoxButton(object content, TResult result, SpecialButtonRole specialRole = SpecialButtonRole.None, params string[] classNames)
		{
			Content = content;
			Result = result;
			ClassNames = classNames;
			SpecialRole = specialRole;
		}
	}
}
