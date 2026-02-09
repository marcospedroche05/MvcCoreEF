using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        //EL CONSTRUCTOR RECIBIRA SIEMPRE LAS OPCIONES PARA ESTE CONTEXTO
        //La clase que recibe es DBContextOptions<Context>
        //ESTAS OPTIONS DEBEMOS ENVIARLAS A LA CLASE BASE/SUPER
        //DEL DBCONTEXT
        public HospitalContext(DbContextOptions<HospitalContext> options):base(options)
        {}

        //DEBEMOS TENER UNA COLECCION POR CADA MODEL
        //DICHA COLECCION DEBE SER DE TIPO DbSet<T>
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
