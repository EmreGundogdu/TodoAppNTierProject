using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Bussiness.Interfaces;
using TodoAppNTier.DataAccess.UnitOfWork;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Bussiness.Services
{
    public class WorkManager : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(WorkCreateDto workCreateDto)
        {
            await _unitOfWork.GetRepository<Work>().Create(new()
            {
                IsCompleted = workCreateDto.IsCompleted,
                Definition = workCreateDto.Definition
            });
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAll();
            var workList = new List<WorkListDto>();
            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(object id)
        {
            var work = await _unitOfWork.GetRepository<Work>().GetById(id);
            return new()
            {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted
            };
        }

        public async Task Rempve(object id)
        {
            var deletedWork = await _unitOfWork.GetRepository<Work>().GetById(id);
            _unitOfWork.GetRepository<Work>().Remove(deletedWork);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDto workUpdateDto)
        {
            _unitOfWork.GetRepository<Work>().Update(new()
            {
                Definition = workUpdateDto.Definition,
                Id = workUpdateDto.Id,
                IsCompleted = workUpdateDto.IsCompleted
            });
            await _unitOfWork.SaveChanges();
        }
    }
}
