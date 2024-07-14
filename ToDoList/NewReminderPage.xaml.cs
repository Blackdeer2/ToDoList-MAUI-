namespace ToDoList;

public partial class NewReminderPage : ContentPage
{
	public NewReminderPage()
	{
		InitializeComponent();
	}

   protected override void OnAppearing()
   {
      //IMAGES
      // Start 
      iconList.Source = ImageSource.FromResource("Itproger.Image.list-ul-alt-svgrepo-com.png");
      ImageSource arrow = ImageSource.FromResource("Itproger.Image.arrow-right-circle-svgrepo-com.png");
      arrowDetail.Source = arrow;
      arrowList.Source = arrow;
      // End

   }

   private async void GoToMainPage(object sender, EventArgs e)
   {
      await Navigation.PopModalAsync();

   }
   void OnEditorTextChanged(object sender, TextChangedEventArgs e)
   {
      const int maxHeight = 500;
      var editor = (Editor)sender;
      var newHeight = CalculateHeight(editor.Text);
      if (newHeight < maxHeight)
      {
         editor.HeightRequest = newHeight;
      }
   }
   double CalculateHeight(string text)
   {
      const double lineHeight = 20;

      var lineCount = text.Split('\n').Length;

      return lineHeight * lineCount;
   }
}