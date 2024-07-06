using EmployeeAPI.Models;
namespace EmployeeAPI.Services.Contrato
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetList();
    }
}
