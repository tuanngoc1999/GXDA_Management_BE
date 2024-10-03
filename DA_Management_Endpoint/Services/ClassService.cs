using System;
using AutoMapper;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class ClassService : Service<Class>, IClassService
    {
        private new readonly IClassRepository _repository;
        private readonly IAcademicYearRepository _academicYearRepository;

        protected readonly IMapper _mapper;

        public ClassService(IClassRepository repository, IAcademicYearRepository academicYearRepository,
            IMapper mapper) : base(repository)
        {
            _repository = repository;
            _academicYearRepository = academicYearRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassListDto>> GetClassesDetail(int? blockId)
        {
            return await _repository.GetClassesDetail(blockId);
        }

        public async Task<IEnumerable<ClassDto>> GetClassesByCatechistId(int catechistId)
        {
            return await _repository.GetClassesByCatechistId(catechistId);
        }


        public async Task AddAsync(CreateClassDto dto, int userId)
        {
            var entity = _mapper.Map<Class>(dto);
            var cls = await _repository.GetFirstOrDefaultByConditionAsync(x => x.BlockId == entity.BlockId && x.Name == entity.Name);
            if (cls != null) throw new InvalidOperationException("Class already exists.");
            entity.UpdatedBy = userId;
            var academicYear = await _academicYearRepository.GetFirstOrDefaultByConditionAsync(x => x.Status!.Value);
            entity.CreatedBy = userId;
            entity.AcademicYearId = academicYear!.Id;

            if (dto.Catechists.Any())
            {
                var clsCatechists = new List<ClassCatechist>();
                foreach(int id in dto.Catechists)
                {
                    var isMain = true;
                    var item = new ClassCatechist
                    {
                        CatechistId = id,
                        IsMainCatechist = isMain
                    };
                    isMain = false;
                    clsCatechists.Add(item);
                }
                entity.ClassCatechists = clsCatechists;
            }


            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(CreateClassDto dto, int userId)
        {
            var entity = _mapper.Map<Class>(dto);
            var cls = await _repository.GetFirstOrDefaultByConditionAsync(x => x.BlockId == entity.BlockId && x.Name == entity.Name);
            if (cls == null)
            {
                throw new InvalidOperationException("Class not exists.");
            }
            else if (cls.Id != entity.Id)
            {
                throw new InvalidOperationException("Class already exists.");
            }
            cls.UpdatedBy = userId;
            cls.Name = entity.Name;

            if (dto.Catechists.Any())
            {
                var clsCatechists = new List<ClassCatechist>();
                foreach (int id in dto.Catechists)
                {
                    var isMain = true;

                    var item = new ClassCatechist
                    {
                        CatechistId = id,
                        IsMainCatechist = isMain
                    };
                    isMain = false;
                    clsCatechists.Add(item);
                }
                cls.ClassCatechists = clsCatechists;
            }

            await _repository.UpdateClass(cls);

        }
    }

}

