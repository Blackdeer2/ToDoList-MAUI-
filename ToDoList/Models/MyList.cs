using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ToDoList.Models
{
   public class MyList
   {

      private int _id;
      private string _name;
      private int _count;
      private string _iconList;

      [PrimaryKey, AutoIncrement]
      public int Id
      {
         get { return _id; }
         set { _id = value; }
      }
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }
      public int Count
      {
         get { return _count; }
         set { _count = value; }
      }
      public string IconList
      {
         get { return _iconList; }
         set { _iconList = value; }
      }

      public MyList()
        {
         _iconList = "Itproger.Image.list-ul-alt-svgrepo-com.png";
      }

        public MyList(string name)
      {

         _name = name;

         _iconList = "Itproger.Image.list-ul-alt-svgrepo-com.png";
         // _iconList = ImageSource.FromResource("Itproger.Image.list-ul-alt-svgrepo-com.png");
         //_iconArrowList = "Itproger.Image.arrow-right-circle-svgrepo-com.png";
         //  _iconArrowList = ImageSource.FromResource("Itproger.Image.arrow-right-circle-svgrepo-com.png");
      }

      /*      public void AddListDetail(string title, string des)
            {
               lists.Add(new MyListDetail(title, des));
               Count = lists.Count;
            }*/


   }
}
