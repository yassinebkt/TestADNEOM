using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TheMachineCafe.Models;
using System.Security.Principal;
using System.Threading;

namespace TheMachineCafe.DAL
{
    public class DalSelection
    {
        private ApplicationDbContext bdd;

        public DalSelection()
        {
            bdd = new ApplicationDbContext();
        }

        public DalSelection(ApplicationDbContext context)
        {
            bdd = context;
        }

        //Get the user Id by Name
        public string GetUserId()
        {
            string id = null;
            try
            {
                id = bdd.Users.FirstOrDefault(u => u.UserName == System.Web.HttpContext.Current.User.Identity.Name).Id;
                return id;
            }
            catch
            {
                var idUser = "Test@machine.fr";
                id = bdd.Users.FirstOrDefault(u => u.UserName == idUser).Id;
                return id;

            };

        }

        //Get the last selected choice
        public Selection GetLastSelection()
        {
            var idUser = GetUserId();
            var selection = bdd.Selections.Include(c => c.boisson).FirstOrDefault(u => u.UserId == idUser);
            return selection;
        }


        //Add the selected choice
        public Selection AddSelection(Selection selection)
        {
            var lastSelection = bdd.Selections.FirstOrDefault(u => u.UserId == selection.UserId);
            if(lastSelection != null)
                bdd.Selections.Remove(lastSelection);

            bdd.Selections.Add(selection);
            bdd.SaveChanges();
            return selection;
        }


        //Get all boisson
        public IEnumerable<Boisson> GetBoissons()
        {
            var boissons = bdd.Boissons.ToList();
            return boissons;
        }

        // Get one Boisson by name
        public Boisson GetBoisson(string nom)
        {
            var boisson = bdd.Boissons.Where(n => n.nom== nom).FirstOrDefault();
            return boisson;
        }

        //Add one Boisson
        public Boisson AddBoisson(Boisson boisson)
        {
            boisson = bdd.Boissons.Add(boisson);
            bdd.SaveChanges();
            return boisson;
        }

        //Delete Boisson
        public bool DeleteBoisson(string nom)
        {
            bool done = false;
            var boisson = bdd.Boissons.Where(n => n.nom == nom).FirstOrDefault();
            bdd.Boissons.Remove(boisson);
            bdd.SaveChanges();
            done = true;
            return done;
        }



    }
}