namespace ToDoList.Extensions;

public partial class BlueUnderlinedText : Label
{
   public static readonly BindableProperty LabelProperty =
         BindableProperty.Create("Lable", typeof(string), typeof(BlueUnderlinedText));
   public string Lable
   {
      get { return (string)GetValue(LabelProperty); }
      set { SetValue(LabelProperty, value); }
   }

   public BlueUnderlinedText()
	{
		InitializeComponent();
      BindingContext = this;
   }
}