using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Contrato;

namespace EmployeeAPI.Services.Implementacion
{
    public class DepartamentoService : IDepartamentoService
    {
        private DbempleadoContext dbContext;
        public DepartamentoService(DbempleadoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Departamento>> GetList()
        {
            try
            {
                List<Departamento> departamentos = new List<Departamento>();
                departamentos = await dbContext.Departamentos.ToListAsync();
                return departamentos;
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
        }
    }
}
