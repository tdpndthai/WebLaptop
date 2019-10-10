using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLaptop_Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WebLaptopDbContext dbContext;

        public WebLaptopDbContext Init()
        {
            return dbContext ?? (dbContext = new WebLaptopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
