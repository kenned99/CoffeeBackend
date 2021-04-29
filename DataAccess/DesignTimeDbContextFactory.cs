using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<APIDbContext>
    {
        public APIDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<APIDbContext>();
            builder.UseSqlServer(@"Data Source=mssql4.unoeuro.com,1433\\SQLEXPRESS;Initial Catalog=thecoffeecollection_dk_db_test;persist security info=True;user id=thecoffeecollection_dk;password=R95bz3Ak6dhn;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
            return new APIDbContext(builder.Options);
        }
    }
}
