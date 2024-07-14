using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
   public class MyListDetail
   {
      private int _idMyList;
      private int _id;
      private bool _done;
      private string _title;
      private string _description;
      private DateTime _dueDate;

      public MyListDetail()
      {

         _done = false;
         _dueDate = DateTime.Now;
      }
      public MyListDetail(string title, string description)
      {
         _done = false;
         _title = title;
         _description = description;
         _dueDate = DateTime.Now;
      }

      [PrimaryKey, AutoIncrement]
      public int Id
      {
         get { return _id; }
         set { _id = value; }
      }
      public bool Done
      {
         get { return _done; }
         set { _done = value; }
      }

      public string Title
      {
         get { return _title; }
         set { _title = value; }
      }
      public string Description
      {
         get { return _description; }
         set { _description = value; }

      }
      public DateTime DueDate
      {
         get { return _dueDate; }
         set { _dueDate = value; }
      }
   }
}
