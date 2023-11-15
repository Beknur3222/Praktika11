using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierAppLibrary;

namespace ReadWaybillsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new LiteDbWaybillRepository("C:\\Users\\wwwas\\source\\repos\\Praktika11\\CourierAppLibrary\\database.db");

            var waybills = repository.GetAllWaybills();

            foreach (var waybill in waybills)
            {
                Console.WriteLine($"Номер: {waybill.Number}, Дата: {waybill.CreationDate}, Отправитель: {waybill.SenderName}, Получатель: {waybill.ReceiverName}");
            }
            Console.ReadKey();
        }
    }
}
