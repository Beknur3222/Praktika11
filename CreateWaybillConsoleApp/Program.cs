using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierAppLibrary;


namespace CreateWaybillConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя отправителя: ");
            string senderName = Console.ReadLine();

            Console.Write("Введите имя получателя: ");
            string receiverName = Console.ReadLine();

            var waybill = new CourierWaybill("123456", senderName, receiverName);

            var repository = new LiteDbWaybillRepository("C:\\Users\\wwwas\\source\\repos\\Praktika11\\CourierAppLibrary\\database.db");

            int waybillId = repository.CreateWaybill(waybill);

            Console.WriteLine($"Накладная успешно создана. ID: {waybillId}");
        }
    }
}
