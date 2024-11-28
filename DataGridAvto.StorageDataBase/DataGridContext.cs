using DataGridAvto.Contracts.Models;
using System.Data.Entity;

namespace DataGridAvto.StorageDataBase
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DataGridContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста базы данных
        /// </summary>
        public DataGridContext() : base("DataGridAvto")
        {
        }

        /// <summary>
        /// Таблица <see cref="Avto"/> в базе данных
        /// </summary>
        public DbSet<Avto> Avto { get; set; }
    }
}
