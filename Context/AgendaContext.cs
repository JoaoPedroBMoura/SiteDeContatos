using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Front_End_com_ASP.NET.Models;

namespace Front_End_com_ASP.NET.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options){

        }

        public DbSet<Contato> Contatos{ get; set;}

    }
}