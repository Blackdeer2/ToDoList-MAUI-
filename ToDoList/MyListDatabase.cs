using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList
{
   public class MyListDatabase
   {
      SQLiteAsyncConnection Database;

      public MyListDatabase()
      {
      }

      async Task Init()
      {
         if (Database is not null)
            return;

         Database = new SQLiteAsyncConnection(Constants.MyListDatabasePath, Constants.Flags);
         var result = await Database.CreateTableAsync<MyList>();
      }

      public async Task<List<MyList>> GetMyListAsync()
      {
         await Init();
         return await Database.Table<MyList>().ToListAsync();
      }

      public async Task<MyList> GetMyListAsync(int id)
      {
         await Init();
         return await Database.Table<MyList>().Where(i => i.Id == id).FirstOrDefaultAsync();
      }

      public async Task<int> SaveMyListAsync(MyList mylist)
      {
         await Init();
         if (mylist.Id != 0)
            return await Database.UpdateAsync(mylist);
         else
            return await Database.InsertAsync(mylist);
      }

      public async Task<int> DeleteMyListAsync(MyList myList)
      {
         await Init();
         return await Database.DeleteAsync(myList);
      }

   }
}
