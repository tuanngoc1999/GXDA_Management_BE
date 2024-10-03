using System;
using AutoMapper;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        protected readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper) : base(repository)
        {
            _studentRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(int classId, int userId)
        {
            return await _studentRepository.GetStudentsByClassIdAsync(classId, userId);
        }

        public async Task AddAsync(CreateStudentDto st, int userId)
        {
            var entity = new Student
            {
                HolyName = st.HolyName,
                FirstName = st.FirstName,
                LastName = st.LastName,
                BirthDate = st.BirthDate,
                Address = st.Address,
                Dad = st.Dad,
                Mom = st.Mom,
                Note = st.Note,
                Status = 1,
                ClassId = st.ClassId,
                SacramentBaptism = st.SacramentBaptism,
                SacramentFirstConfession = st.SacramentFirstConfession,
                SacramentConfirmation = st.SacramentConfirmation,
                AddedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = userId,
                UpdatedBy = userId
            };
            await _repository.AddAsync(entity);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByBlockIdAsync(int blockId, int userId)
        {
            return await _studentRepository.GetStudentsByBlockIdAsync(blockId, userId);
        }

        public async Task<StudentDto?> GetWaitingForApprove(int userId)
        {

            var dto = await _studentRepository.GetWaitingForApprove(userId);
            if (dto != null)
            {
                var entity = _mapper.Map<Student>(dto);
                entity.Status = 0;
                entity.UpdatedDate = DateTime.UtcNow;
                entity.UpdatedBy = userId;
                await _studentRepository.UpdateAsync(entity);
            }
            return dto;
        }


        public async Task Regist(CreateStudentDto st)
        {
            var student = new Student
            {
                HolyName = st.HolyName,
                FirstName = st.FirstName,
                LastName = st.LastName,
                BirthDate = st.BirthDate,
                Address = st.Address,
                Dad = st.Dad,
                Mom = st.Mom,
                Note = st.Note,
                Status = -1,
                ClassId = st.ClassId,
                SacramentBaptism = st.SacramentBaptism,
                SacramentFirstConfession = st.SacramentFirstConfession,
                SacramentConfirmation = st.SacramentConfirmation,
                AddedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task ApproveRegistration(Student student, int userId)
        {
            student.UpdatedBy = userId;
            student.UpdatedDate = DateTime.UtcNow;
            student.Status = 1;
            await _studentRepository.UpdateAsync(student);
        }

        public Task<List<StudentAttendanceDto>> GetAttendancesByClassIdAsync(int classId, int userId, int month = 0)
        {
            return _studentRepository.GetAttendancesByClassIdAsync(classId, userId, month);
        }

        public Task<List<StudentScoreDto>> GetScoresByClassIdAsync(int classId, int userId, string term = "")
        {
            return _studentRepository.GetScoresByClassIdAsync(classId, userId, term);
        }

        public async Task ImportRange(List<CreateStudentDto> students, int userId)
        {
            List<Student> datas = new List<Student>();
            foreach (CreateStudentDto st in students)
            {
                var item = new Student
                {
                    HolyName = st.HolyName,
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    BirthDate = st.BirthDate,
                    Address = st.Address,
                    Dad = st.Dad,
                    Mom = st.Mom,
                    Note = st.Note,
                    Status = 1,
                    ClassId = st.ClassId,
                    SacramentBaptism = st.SacramentBaptism,
                    SacramentFirstConfession = st.SacramentFirstConfession,
                    SacramentConfirmation = st.SacramentConfirmation,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CreatedBy = userId,
                    UpdatedBy = userId
                };
                datas.Add(item);
            }
            await _studentRepository.ImportRange(datas, userId);
        }

        public async Task UpdateAsync(int id, CreateStudentDto st, int userId)
        {
            await _studentRepository.UpdateAsync(id, st, userId);
        }
    }
}

