using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using TheMachineCafe.DAL;
using TheMachineCafe.Models;
using TheMachineCafe.Dtos;
using AutoMapper;

namespace TheMachineCafe.Controllers.Api
{
    public class SelectionController : ApiController
    {
        private DalSelection dal = new DalSelection();

        //Get api/Selection/GetLastSelection
        [HttpGet]
        public SelectionDto GetLastSelection()
        {
            var selection = dal.GetLastSelection();
            if (selection == null)
                return null;
            else
            {
                var se = Mapper.Map<Selection, SelectionDto>(selection);
                return se;
            }          
                 
                            
        }
        
        //Get api/Selection/GetBoissons
        [HttpGet]
        public IEnumerable<Boisson> GetBoissons()
        {
            var boissons = dal.GetBoissons();
            return boissons;
        }

        //Post api/Selection/AddSelection
        [HttpPost]
        public SelectionDto AddSelection(SelectionDto selectionDto)
        {
            selectionDto.UserId = dal.GetUserId();
            var selection = Mapper.Map<SelectionDto, Selection>(selectionDto);
            selection = dal.AddSelection(selection);

            selectionDto.Id = selection.Id;
            selectionDto.UserId = selection.UserId;

            return selectionDto;
        }

    }
}
