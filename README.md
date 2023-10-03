# Custom MessageBox for Avalonia
A highly customizable MessageBox pop-up for Avalonia with pre-set and custom buttons and plenty of layout options.

# Examples
Fluent:

![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/e88a03a5-7d4d-4979-a5af-9544f2fac5a0)

![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/9ead634b-50b6-4b2a-ad13-10bfc2daafc3)

Simple:

![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/825bb0ec-8cbb-4628-81cf-aa8352301d26)

![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/38bc6f43-68d2-40c3-ad8b-448ec87ebbcc)

```cs
MessageBox.Show(
  "This is a traditional message box with an \"OK\" button.",
  "Traditional 1", MessageBoxButtons.OK);
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/cdfaa29c-4681-40bf-ba1a-907ff498f21a)

```cs
MessageBoxResult result = MessageBox.Show(
  "This is a traditional message box with \"YesNoCancel\" buttons.",
  "Traditional 2",
  MessageBoxButtons.YesNoCancel,
  MessageBoxIcon.Question,
  MessageBoxDefaultButton.Button1,
  "accent");
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/6e0b8e30-3a75-49a8-9567-7ba5435b755b)

```cs
var messageBox = new MessageBox(
  "This is a traditional message box with \"YesNo\" buttons.\n" +
  "The buttons are aligned to the center.",
  "Traditional 3", MessageBoxIcon.Information)
{
  HorizontalButtonsPanelAlignment = HorizontalAlignment.Center
};

var result = messageBox.Show(MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, "accent");
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/50416bdf-a7d9-4e10-9c4a-7f7b060c9756)

```cs
var bitmap = new Bitmap(AssetLoader.Open(new Uri("avares://CustomMessageBox.Avalonia.Demo/Assets/avalonia-logo.ico")));

var messageBox = new MessageBox(
  "This is a traditional message box with \"YesNo\" buttons.\n" +
  "The message contains a custom icon with its size set to 64 x 64.",
  "Traditional 6", bitmap)
{
  IconWidth = 64,
  IconHeight = 64
};

var result = messageBox.Show(MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, "accent");
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/966d04d7-e219-471f-8585-e7730066f551)

```cs
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

var result = messageBox.Show(
  new MessageBoxButton<MessageBoxResult>(MessageBox.YesText, MessageBoxResult.Yes, SpecialButtonRole.IsDefault, "accent"),
  new MessageBoxButton<MessageBoxResult>(MessageBox.NoText, MessageBoxResult.No),
  new MessageBoxButton<MessageBoxResult>(MessageBox.CancelText, MessageBoxResult.Cancel, SpecialButtonRole.IsCancel)
);
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/28756ccd-cfb9-46ef-ba57-dc783943682a)

```cs
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

var result = messageBox.Show(
  new MessageBoxButton<MessageBoxResult>("Yes, Confirm", MessageBoxResult.Yes, SpecialButtonRole.IsDefault, "accent"),
  new MessageBoxButton<MessageBoxResult>("No, Cancel", MessageBoxResult.Cancel, SpecialButtonRole.IsCancel)
);
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/75fa3bea-215b-4d16-abbb-9ef73aaa5df3)

```cs
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

CustomMessageBoxResult result = messageBox.Show(
  new MessageBoxButton<CustomMessageBoxResult>("Accept", CustomMessageBoxResult.Accept, SpecialButtonRole.None, "accent"),
  new MessageBoxButton<CustomMessageBoxResult>("Decline", CustomMessageBoxResult.Decline)
);
```
---
![image](https://github.com/Nickelony/CustomMessageBox.Avalonia/assets/20436882/1d6ab0f5-313c-4554-9559-0884a306aa92)

```cs
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

int result = messageBox.Show(
  new MessageBoxButton<int>("English", 1),
  new MessageBoxButton<int>("Polish", 2),
  new MessageBoxButton<int>("German", 3),
  new MessageBoxButton<int>("Spanish", 4),
  new MessageBoxButton<int>("Italian", 5),
  new MessageBoxButton<int>("French", 6),
  new MessageBoxButton<int>("Chinese", 7)
);
```
