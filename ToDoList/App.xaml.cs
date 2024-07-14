namespace ToDoList
{
   public partial class App : Application
   {
      public App(MyListDatabase myListDatabase)
      {
         InitializeComponent();

         MainPage = new NavigationPage(new MainPage(myListDatabase));
      }
   }
}
