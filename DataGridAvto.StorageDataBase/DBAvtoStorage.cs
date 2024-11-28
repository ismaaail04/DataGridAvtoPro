using DataGridAvto.Contracts;
using DataGridAvto.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataGridAvto.StorageDataBase
{
    /// <summary>
    /// Этот класс реализует интерфейс ICarStorage с использованием базы данных.
    /// </summary>
    public class DBAvtoStorage : ICarStorage
    {

        /// <summary>
        /// Добавляет новый авто в базу данных.
        /// </summary>
        public async Task<Avto> AddAsync(Avto avto)
        {
            using (var context = new DataGridContext())
            {
                context.Avto.Add(avto);
                await context.SaveChangesAsync();
            }

            return avto;
        }

        /// <summary>
        /// Удаляет авто из базы данных по идентификатору.
        /// </summary>
        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var context = new DataGridContext())
            {
                var item = await context.Avto.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    context.Avto.Remove(item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Обновляет существующий авто в базе данных.
        /// </summary>
        public async Task EditAsync(Avto avto)
        {
            using (var context = new DataGridContext())
            {
                var target = await context.Avto.FirstOrDefaultAsync(x => x.Id == avto.Id);
                if (target != null)
                {
                    target.Mark = avto.Mark;
                    target.Number = avto.Number;
                    target.Probeg = avto.Probeg;
                    target.AvgFuelCons = avto.AvgFuelCons;
                    target.CurrFuel = avto.CurrFuel;
                    target.CostRent = avto.CostRent;
                }
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает все авто из базы данных.
        /// </summary>
        public async Task<IReadOnlyCollection<Avto>> GetAllAsync()
        {
            using (var context = new DataGridContext())
            {
                var items = await context.Avto
                    .OrderByDescending(x => x.Mark)
                    .ToListAsync()
                    ;
                return items;
            }
        }
    }
}
