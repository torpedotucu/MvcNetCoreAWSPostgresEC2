using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;
using System.Diagnostics.CodeAnalysis;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;
        public RepositoryHospitales(HospitalContext context)
        {
            this.context=context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento>FindDepartamento(int idDept)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento==idDept);
        }

        public async Task InsertDepartamento(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento=id;
            dept.Nombre=nombre;
            dept.Localidad=localidad;
            await this.context.Departamentos.AddAsync(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
