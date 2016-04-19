using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Driver;
using RehberMongoDB.Models;

namespace RehberMongoDB.Models
{
    public class rehberModel
    {
        [Key]
        public ObjectId id { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string telNo {get; set;}

    }
    public class ObjectIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext con_context, ModelBindingContext bind_context)
        {
            ValueProviderResult result = bind_context.ValueProvider.GetValue(bind_context.ModelName);
            return new ObjectId(result.AttemptedValue);
        }
    }
    
}