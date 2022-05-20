﻿using Laboratorio5.Handlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Laboratorio5.Controllers
{
    public class PaisesController : Controller
    {
        public IActionResult Index()
        {
            PaisesHandler paisesHandler = new PaisesHandler();
            var paises = paisesHandler.ObtenerPaises();
            ViewBag.MainTitle = "Lista de países";
            return View(paises);
        }
    }
}
