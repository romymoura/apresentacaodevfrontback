using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Apresentacao.Data.Extensions
{
    internal static class CommadQueryExtension
    {
        public static void SqlBulkCopy<T>(ApplicationDbContext db, IList<T> list, string schema, string tableName)
        {
            using (db)
            using (var bulkCopy = new SqlBulkCopy(db.Database.GetDbConnection().ConnectionString, SqlBulkCopyOptions.Default))
            {
                if (db.Database.GetDbConnection().State == ConnectionState.Closed)
                    db.Database.GetDbConnection().Open();

                bulkCopy.DestinationTableName = $"{schema}.{tableName}";

                var teste = list.ConvertToDataTable<T>();

                bulkCopy.WriteToServer(list.ConvertToDataTable<T>());

                if (db.Database.GetDbConnection().State == ConnectionState.Open)
                    db.Database.GetDbConnection().Close();
            }
        }
    }
}
