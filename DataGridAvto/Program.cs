using DataGridAvto.AvtoManager;
using DataGridAvto.StorageMemory;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace DataGridAvto
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var factory = LoggerFactory.Create(builder => builder.AddDebug());
            var logger = factory.CreateLogger(nameof(DataGrid));

            var storage = new MemoryCarStorage();
            var manager = new CarManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
