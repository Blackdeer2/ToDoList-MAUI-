using SQLite;
using System.Collections.ObjectModel;
using ToDoList.Models;
using ToDoList.Persistence;
//using static ABI.System.Windows.Input.ICommand_Delegates;

namespace ToDoList
{
   public partial class MainPage : ContentPage
   {
      private MyListDatabase _mylistdatabase;
      private ObservableCollection<MyList> _myLists = new ObservableCollection<MyList>();
      public MainPage(MyListDatabase mylistdatabase)
      {
         InitializeComponent();
         _mylistdatabase = mylistdatabase;
      }

      protected override async void OnAppearing()
      {
         //IMAGES
         // Start 
         dandruff.Source = ImageSource.FromResource("ToDoList.Images.magnifying-glass-svgrepo-com.png");
         toDay.Source = ImageSource.FromResource("ToDoList.Images.calendar-add-svgrepo-com.png");
         schedule.Source = ImageSource.FromResource("ToDoList.Images.calendar-svgrepo-com.png");
         all.Source = ImageSource.FromResource("ToDoList.Images.arhive-alt-small-svgrepo-com.png");
         executed.Source = ImageSource.FromResource("ToDoList.Images.check-ring-svgrepo-com.png");
         newReminder.Source = ImageSource.FromResource("ToDoList.Images.add-svgrepo-com.png");
         //var iconList =  ImageSource.FromResource("ToDoList.Images.list-ul-alt-svgrepo-com.png");
         //iconArrowList = ImageSource.FromResource("ToDoList.Images.arrow-right-circle-svgrepo-com.png");
         // End
         await _mylistdatabase.GetMyListAsync();
         _myLists = new ObservableCollection<MyList>(await _mylistdatabase.GetMyListAsync());
         listview.ItemsSource = _myLists;

      }

      /*      private async void ButtonClick(object sender, EventArgs e)
           {
              buttonSend.Text = "Cliked";
              await DisplayAlert("lol", "text", "ok");
           }*/
      async void OnSaveCliked(Object sender, EventArgs e)
      {
         string listName = listNameEntry.Text;
         if (!string.IsNullOrEmpty(listName))
         {
            var newList = new MyList(listName);
            await _mylistdatabase.SaveMyListAsync(newList);
            _myLists.Add(newList);
         }
         listNameEntry.Text = null;
      }
       async void DeleteMyList(object sender, EventArgs e)
      {
         var list = (sender as MenuItem).CommandParameter as MyList;
         await _mylistdatabase.DeleteMyListAsync(list);
         _myLists.Remove(list);
      }

      private async void GoToExecuted(object sender, EventArgs e)
      {
         await Navigation.PushAsync(new Executed());
      }
      private async void GoToAll(object sender, EventArgs e)
      {
         await Navigation.PushAsync(new All());
      }
      private async void GoToToday(object sender, EventArgs e)
      {
         await Navigation.PushAsync(new Today());
      }
      private async void GoToSchedule(object sender, EventArgs e)
      {
         await Navigation.PushAsync(new Schedule());
      }
      private async void GoToNewReminder(object sender, EventArgs e)
      {
         await Navigation.PushModalAsync(new NewReminderPage());
      }
      private async void GoToAddListPage(object sender, EventArgs e)
      {
         await Navigation.PushModalAsync(new AddListPage());
      }


      private async void InfoClicked(object sender, EventArgs e)
      {
         await DisplayAlert("lol", "text", "ok");
      }

      private async void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
      {
         if (e.SelectedItem == null)
            return;

         var list = e.SelectedItem as MyList;
         await Navigation.PushAsync(new ListDetailPage(list));
         listview.SelectedItem = null;
      }

   }

}
