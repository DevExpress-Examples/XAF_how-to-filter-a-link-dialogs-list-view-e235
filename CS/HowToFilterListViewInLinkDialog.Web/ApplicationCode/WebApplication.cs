using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace HowToFilterListViewInLinkDialog.Web {
   public partial class HowToFilterListViewInLinkDialogAspNetApplication : WebApplication {
      private DevExpress.ExpressApp.SystemModule.SystemModule module1;
      private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
      private HowToFilterListViewInLinkDialog.Module.HowToFilterListViewInLinkDialogModule module3;
      private HowToFilterListViewInLinkDialog.Module.Web.HowToFilterListViewInLinkDialogAspNetModule module4;
      private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
      private DevExpress.ExpressApp.Security.SecuritySimple securitySimple1;
      private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
      private DevExpress.ExpressApp.Security.AuthenticationActiveDirectory authenticationActiveDirectory1;
      private System.Data.SqlClient.SqlConnection sqlConnection1;
      private DevExpress.ExpressApp.Validation.ValidationModule module5;

      public HowToFilterListViewInLinkDialogAspNetApplication() {
         InitializeComponent();
      }

      private void HowToFilterListViewInLinkDialogAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
         if (System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
         }
         else {
            throw new InvalidOperationException(
               "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
               "The automatical update is disabled, because the application was started without debugging.\r\n" +
               "You should start the application under Visual Studio, or modify the " +
               "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
               "or manually create a database with the help of the 'DBUpdater' tool.");
         }
      }

      private void InitializeComponent() {
         this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
         this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
         this.module3 = new HowToFilterListViewInLinkDialog.Module.HowToFilterListViewInLinkDialogModule();
         this.module4 = new HowToFilterListViewInLinkDialog.Module.Web.HowToFilterListViewInLinkDialogAspNetModule();
         this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
         this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
         this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
         this.securitySimple1 = new DevExpress.ExpressApp.Security.SecuritySimple();
         this.authenticationActiveDirectory1 = new DevExpress.ExpressApp.Security.AuthenticationActiveDirectory();
         this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // securitySimple1
         // 
         this.securitySimple1.Authentication = this.authenticationActiveDirectory1;
         this.securitySimple1.UserType = typeof(DevExpress.Persistent.BaseImpl.BasicUser);
         // 
         // authenticationActiveDirectory1
         // 
         this.authenticationActiveDirectory1.CreateUserAutomatically = true;
         this.authenticationActiveDirectory1.UserType = typeof(DevExpress.Persistent.BaseImpl.BasicUser);
         // 
         // sqlConnection1
         // 
         this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=HowToFilterListViewInLinkDialog;Integrated Security=SSPI;Pooling=false";
         this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
         // 
         // HowToFilterListViewInLinkDialogAspNetApplication
         // 
         this.ApplicationName = "HowToFilterListViewInLinkDialog";
         this.Connection = this.sqlConnection1;
         this.Modules.Add(this.module1);
         this.Modules.Add(this.module2);
         this.Modules.Add(this.module3);
         this.Modules.Add(this.module4);
         this.Modules.Add(this.module5);
         this.Modules.Add(this.module6);

         this.Modules.Add(this.securityModule1);
         this.Security = this.securitySimple1;
         this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.HowToFilterListViewInLinkDialogAspNetApplication_DatabaseVersionMismatch);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }
   }
}