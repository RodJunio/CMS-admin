using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;
using cms_admin.Models.Dominio.Entidades;

namespace cms_admin.Models.Infraestrutura.DataBase
{
    public class ContextCms : DbContext
    {
        public ContextCms(){}
        public ContextCms(DbContextOptions<ContextCms> options): base(options){}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jappSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseSqlServer(jappSettings["ConexaoSql"].ToString());
        }
        
        public DbSet<Administrador> Administradores { get; set;}
    }
}