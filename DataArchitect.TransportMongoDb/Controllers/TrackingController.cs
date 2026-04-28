using AutoMapper;
using DataArchitect.TransportMongoDb.Entities;
using DataArchitect.TransportMongoDb.Models;
using DataArchitect.TransportMongoDb.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DataArchitect.TransportMongoDb.Controllers
{
    public class TrackingController : Controller
    {
        //private readonly IMongoCollection<Shipment> _shipments;

        //public TrackingController(IMongoDatabase database)
        //{
        //    _shipments = database.GetCollection<Shipment>("Shipments");
        //}

        private readonly IMongoCollection<Shipment> _shipmentCollection;
        

        public TrackingController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); //client değişken aracılığıyla mongodb bağlantısına erişim sağlandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);// database değişken aracılığıyla clienttaki bağlantı üzerinden veri tabanına erişiliyor
            _shipmentCollection = database.GetCollection<Shipment>(_databaseSettings.ShipmentCollectionName);//database aracılığıyla tabloya erişildi
          
        }


        public async Task<IActionResult> Index(string? trackingNumber)
        {
            if (string.IsNullOrWhiteSpace(trackingNumber))
                return View(null as TrackingResultViewModel);

            var shipment = await _shipmentCollection
                .Find(s => s.TrackingNumber == trackingNumber.Trim().ToUpper())
                .FirstOrDefaultAsync();

            if (shipment is null)
            {
                ViewBag.NotFound = true;
                ViewBag.SearchedNumber = trackingNumber;
                return View(null as TrackingResultViewModel);
            }

            // En yeni event üstte görünsün
            var events = (shipment.Trackings ?? new List<ShipmentTracking>())
                .OrderByDescending(t => t.EventDate)
                .Select(t => new TrackingEventViewModel
                {
                    EventDate = t.EventDate,
                    Location = t.Location,
                    Description = t.Description,
                    TrackingStatus = t.TrackingStatus
                })
                .ToList();

            var vm = new TrackingResultViewModel
            {
                TrackingNumber = shipment.TrackingNumber,
                SenderName = shipment.SenderName,
                ReceiverName = shipment.ReceiverName,
                OriginCity = shipment.OriginCity,
                OriginDistrict = shipment.OriginDistrict,
                DestinationCity = shipment.DestinationCity,
                DestinationDistrict = shipment.DestinationDistrict,
                Address = shipment.Address,
                CreatedDate = shipment.CreatedDate,
                CurrentStatus = shipment.CurrentStatus,
                Events = events
            };

            return View(vm);
        }

    }
}
