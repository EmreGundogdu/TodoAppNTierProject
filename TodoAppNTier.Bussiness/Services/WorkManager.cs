using AutoMapper;
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
        private readonly IMapper _mapper;

        public WorkManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(WorkCreateDto workCreateDto)
        {
            await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(workCreateDto));
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAll();

            return _mapper.Map<List<WorkListDto>>(await _unitOfWork.GetRepository<Work>().GetAll());
        }

        public async Task<WorkListDto> GetById(int id)
        {
            return _mapper.Map<WorkListDto>(await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id));

        }

        public async Task Remove(int id)
        {
            _unitOfWork.GetRepository<Work>().Remove(id);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDto workUpdateDto)
        {
            _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto));
            await _unitOfWork.SaveChanges();
        }
    }
}
