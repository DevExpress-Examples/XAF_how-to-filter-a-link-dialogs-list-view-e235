using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

using System.ComponentModel;
using DevExpress.Data.Filtering;

namespace HowToFilterListViewInLinkDialog.Module {

   [DefaultClassOptions]
   public class Contact : Person {
      public Contact(Session session) : base(session) {}
      private Position position;
      public Position Position {
         get {
            return position;
         }
         set {
            SetPropertyValue("Position", ref position, value);
            // Refresh the Tasks property data source
            RefreshAvailableTasks();
         }
      }
      [Association("Contact-DemoTask", typeof(DemoTask))]
      // Set the AvailableTasks collection as data source for the Tasks property
      [DataSourceProperty("AvailableTasks")]
      public XPCollection Tasks {
         get {
            return GetCollection("Tasks");
         }
      }
      private XPCollection<DemoTask> availableTasks;
      [Browsable(false)] // Prohibits showing the AvailableTasks collection separately
      public XPCollection<DemoTask> AvailableTasks {
         get {
            if (availableTasks == null) {
               // Retrieve all Task objects
               availableTasks = new XPCollection<DemoTask>(Session);
            }
            // Filter the retieved collection according to the current conditions
            RefreshAvailableTasks();
            // Return the filtered collection of Task objects
            return availableTasks;
         }
      }
      private void RefreshAvailableTasks() {
         if (availableTasks == null)
            return;
         if ((Position != null) && (Position.Title == "Manager")) {
            //Filter the collection
            availableTasks.Criteria = CriteriaOperator.Parse("[Priority] = 'High'");
         }
         else {
            //Remove the applied filter
            availableTasks.Criteria = null;
         }
      }
   }
   [DefaultClassOptions]
   [System.ComponentModel.DefaultProperty("Title")]
   public class Position : BaseObject {
      public Position(Session session) : base(session) { }
      private string title;
      public string Title {
         get {
            return title;
         }
         set {
            SetPropertyValue("Title", ref title, value);
         }
      }
   }
   [DefaultClassOptions]
   public class DemoTask : Task {
      private Priority priority;
      public DemoTask(Session session) : base(session) { }
      public Priority Priority {
         get {
            return priority;
         }
         set {
            SetPropertyValue("Priority", ref priority, value);
         }
      }
      [Association("Contact-DemoTask", typeof(Contact))]
      public XPCollection Contacts {
         get {
            return GetCollection("Contacts");
         }
      }
      //...
   }
   public enum Priority {
      Low = 0,
      Normal = 1,
      High = 2
   }
}
