using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class AulaContext: DbContext
    {
        public AulaContext(): base("keyDBAula") {}
        public DbSet<Aula> Aulas { get; set; }
    }
}