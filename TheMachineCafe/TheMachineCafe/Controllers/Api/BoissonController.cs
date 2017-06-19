using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheMachineCafe.DAL;
using TheMachineCafe.Models;

namespace TheMachineCafe.Controllers.Api
{
    public class BoissonController : ApiController
    {
        private DalSelection dal = new DalSelection();

        //Get api/Boisson/GetBoissons
        [HttpGet]
        public IEnumerable<Boisson> GetBoissons()
        {
            var boissons = dal.GetBoissons();
            return boissons;
        }

        //Get api/Boisson/GetBoisson
        [HttpGet]
        public Boisson GetBoisson(string name)
        {
            var boisson = dal.GetBoisson(name);
            return boisson;
        }

        //Post api/Boisson/AddBoisson
        [HttpPost]
        public Boisson AddBoisson(Boisson boisson)
        {
            return dal.AddBoisson(boisson);
            
        }

        //Delete api/Boisson/DeleteBoisson
        [HttpDelete]
        public bool DeleteBoisson(string nom)
        { 
            bool Done = dal.DeleteBoisson(nom);
            return Done;
        }

    }
}
