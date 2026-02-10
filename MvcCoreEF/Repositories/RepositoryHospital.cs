using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital> FindHospitalAsync(int idHopsital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHopsital
                           select datos;
            //CUANDO BUSCCAMOS, SI NO ENCUENTRA ALGO, DEBEMOS DEVOLVER NULL
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task CreateHospitalAsync
            (int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = new Hospital
            {
                IdHospital = idHospital,
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                Camas = camas
            };
            //AÑADIMOS NUESTRO OBJETO AL DBSET
            await this.context.Hospitales.AddAsync(hospital);
            //GUARDAR LA INSERCION, SIN ESTO NO SE INSERTA
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int idHospital)
        {
            //BUSCAMOS EL HOSPITAL A ELIMINAR
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            this.context.Hospitales.Remove(hospital);
            await this.context.SaveChangesAsync();
        }

        public async Task EditHospitalAsync
            (int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            await this.context.SaveChangesAsync();
        }
    }
}
