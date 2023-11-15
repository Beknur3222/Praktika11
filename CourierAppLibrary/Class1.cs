using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.IO;

namespace CourierAppLibrary
{
    public enum Status
    {
        Shipped,
        Delivered,
        Failed
    }

    public class CourierWaybill
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreationDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public Status WaybillStatus { get; set; }

        public CourierWaybill(string number, string senderName, string receiverName)
        {
            Number = number;
            CreationDate = DateTime.Now;
            SenderName = senderName;
            ReceiverName = receiverName;
            WaybillStatus = Status.Shipped;
        }

    }

    public interface IWaybillRepository
    {
        int CreateWaybill(CourierWaybill waybill);
        List<CourierWaybill> GetAllWaybills();
        CourierWaybill GetWaybillById(int id);
    }

    public class LiteDbWaybillRepository : IWaybillRepository
    {
        private readonly string _dbPath;

        public LiteDbWaybillRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public int CreateWaybill(CourierWaybill waybill)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<CourierWaybill>("waybills");
                collection.Insert(waybill);
                return waybill.Id;
            }
        }

        public List<CourierWaybill> GetAllWaybills()
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<CourierWaybill>("waybills");
                return collection.FindAll().ToList();
            }
        }

        public CourierWaybill GetWaybillById(int id)
        {
            using (var db = new LiteDatabase(_dbPath))
            {
                var collection = db.GetCollection<CourierWaybill>("waybills");
                return collection.FindById(id);
            }
        }
    }

    public class FileManager
    {
        public void CopyWaybillFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }
    }

}

