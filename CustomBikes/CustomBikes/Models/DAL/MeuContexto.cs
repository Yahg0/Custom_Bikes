using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomBikes.Models.DAL
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
            Database.SetInitializer<MeuContexto>(new DropCreateDatabaseIfModelChanges<MeuContexto>());
        }

    }
}