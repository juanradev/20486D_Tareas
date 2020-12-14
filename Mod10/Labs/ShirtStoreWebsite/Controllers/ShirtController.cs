﻿using Microsoft.AspNetCore.Mvc;
using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;

namespace ShirtStoreWebsite.Controllers
{
    public class ShirtController : Controller
    {
        private IShirtRepository _repository;
        private ILogger _logger;

      public ShirtController(IShirtRepository repository, ILogger<ShirtController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public IActionResult Index()
        {
            IEnumerable<Shirt> shirts = _repository.GetShirts(); // Codigo para que pase la prueba
            return View(shirts);

           // return View();
        }

        public IActionResult AddShirt(Shirt shirt)
        {
            _repository.AddShirt(shirt); // Codigo para que pase la prueba
            _logger.LogDebug($"A {shirt.Color.ToString()} shirt of size {shirt.Size.ToString()} with a price of {shirt.GetFormattedTaxedPrice()} was added successfully.");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            /* _repository.RemoveShirt(id);  

             //_repository.RemoveShirt(-1); // código para excepción temoral

             return RedirectToAction("Index");*/
            try
            {
                _repository.RemoveShirt(id);
                _logger.LogDebug($"A shirt with id {id} was removed successfully.");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to delete shirt with id of {id}.");
                throw ex;
            }

        }
    }
}
