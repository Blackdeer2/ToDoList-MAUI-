//using static Xamarin.Google.Crypto.Tink.Shaded.Protobuf.Internal;

namespace ToDoList;

public partial class AddListPage : ContentPage
{
   public AddListPage()
   {
      InitializeComponent();

      
   }
   protected override async void OnAppearing()
   {
      iconList.Source = ImageSource.FromResource("ToDoList.Images.list-ul-alt-svgrepo-com.png");
   }

   private async void GoToMainPage(object sender, EventArgs e)
   {
      await Navigation.PopModalAsync();

   }
}