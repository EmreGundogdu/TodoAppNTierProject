using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Bussiness.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto workCreateDto);
        Task<WorkListDto> GetById(int id);
        Task Rempve(object id);
        Task Update(WorkUpdateDto workUpdateDto);

    }
}
