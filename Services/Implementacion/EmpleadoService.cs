using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Contrato;

namespace EmployeeAPI.Services.Implementacion
{
    public class EmpleadoService: IEmpleadoService
    {
        private DbempleadoContext dbContext;

        public EmpleadoService(DbempleadoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Empleado>> GetList()
        {
            try
            {
                List<Empleado> empleados = new List<Empleado>();
                empleados = await dbContext.Empleados.Include(dpt=>dpt.IdDepartamentoNavigation).ToListAsync();
                return empleados;
            }
            catch (Exception _Ex)
            {

                throw _Ex;
            }
        }
        public async Task<Empleado> Get(int IdEmpleado)
        {
            try
            {
                Empleado? empleado = new Empleado();
                empleado = await dbContext.Empleados.Include(dpt=>dpt.IdDepartamentoNavigation)
                    .Where(e=>e.IdEmpleado == IdEmpleado).FirstOrDefaultAsync();
                return empleado;
            }
            catch (Exception _Ex)
            {

                throw _Ex;
            }
        }

        public async Task<Empleado> Add(Empleado modelo)
        {
            try
            {
                dbContext.Empleados.Add(modelo);
                await dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception _Ex)
            {

                throw _Ex;
            }
        }
        public async Task<bool> Update(Empleado modelo)
        {
            try
            {
                dbContext.Empleados.Update(modelo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception _Ex)
            {

                throw _Ex;
            }
        }
        public async Task<bool> Delete(Empleado modelo)
        {
            try
            {
                dbContext.Empleados.Remove(modelo);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception _Ex)
            {
                throw _Ex;
            }
        }
    }
}
