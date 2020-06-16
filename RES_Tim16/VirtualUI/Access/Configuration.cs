using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualUI.Access
{
    [ExcludeFromCodeCoverage]
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
