using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crooster.Data;
using Crooster.Api.Models;
using Crooster.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crooster.Api.Models
{
    public class ConfigApp
    {
        public int Id {get;set;}
        public string Prefijo {get;set;}
        public string AppName {get;set;}
    }
}