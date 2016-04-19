using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RehberMongoDB.Models;
using RehberMongoDB.Controllers;
using System.Data.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace RehberMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private MongoDatabase DB()
        {
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoServer server = new MongoServer(settings);
            MongoDatabase db = server.GetDatabase("rehber");
            return db;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
           
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(rehberModel yeni)
        {
                     
            MongoDatabase db = DB();
            MongoCollection<BsonDocument> eklenen = db.GetCollection<BsonDocument>("kisiler");
            eklenen.Insert<rehberModel>(yeni);
            ViewBag.Mesaage = "Kayıt basarılı";
            return View();
            
        }
        
        public ActionResult Listele()
        {
          
              MongoDatabase db = DB();
              MongoCollection<rehberModel> liste = db.GetCollection<rehberModel>("kisiler");
          
              return View(liste.FindAll().ToList<rehberModel>());

        }
        public ActionResult Sil(ObjectId id)
        {
            MongoDatabase db = DB();
            MongoCollection<rehberModel> coll = db.GetCollection<rehberModel>("kisiler");
            var qDoc = new QueryDocument { { "id", id } };
            coll.Remove(qDoc);        
            return RedirectToAction("Listele");
         
        }
      
        public ActionResult Duzenle(ObjectId id)
        {
            MongoDatabase db = DB();
            MongoCollection<rehberModel> updateColl = db.GetCollection<rehberModel>("kisiler");
            rehberModel edit = (from r in updateColl.AsQueryable() where r.id == id select r).FirstOrDefault();
            
            return View("Duzenle",edit);
        }      
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(rehberModel duzenle)
        {
            
            MongoDatabase db = DB();
            MongoCollection<rehberModel> updateColl = db.GetCollection<rehberModel>("kisiler");
            rehberModel sil = (from r in updateColl.AsQueryable() where r.id == duzenle.id select r).FirstOrDefault();
    
            sil.adi = duzenle.adi;
            sil.soyadi = duzenle.soyadi;
            sil.telNo = duzenle.telNo;

            var qDoc = new QueryDocument { { "id", duzenle.id } };
            var u = new UpdateDocument { { "$set", new BsonDocument("adi", sil.adi ).Set("soyadi",sil.soyadi).Set("telNo",sil.telNo) } };
            updateColl.Update(qDoc, u);
            return RedirectToAction("Listele");
        }
    }
}
