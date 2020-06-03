using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualUI.Access
{
     class Configuration:DbMigrationsConfiguration<FileContext>
    {
        #region Constructor
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FileDatabase";

        }
        #endregion
    }
}
