using AutoMapper;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        protected readonly IMapper _mapper;
        protected readonly ICatechistProfileRepository _catechistProfileRepository;


        public StudentRepository(AppDbContext context, IMapper mapper, ICatechistProfileRepository catechistProfileRepository) : base(context)
        {
            _mapper = mapper;
            _catechistProfileRepository = catechistProfileRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(int classId, int userId)
        {
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "VIEW_STUDENTS_BY_CLASS"))) throw new InvalidOperationException();
                var data = await _context.Students
                                     .AsNoTracking()
                                     .Where(s => s.ClassId == classId)
                                     .ToListAsync();
                var dto = _mapper.Map<List<StudentDto>>(data);
                return dto;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByBlockIdAsync(int blockId, int userId)
        {
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "VIEW_STUDENTS_BY_BLOCK"))) throw new InvalidOperationException();
                var data = await _context.Students
                                 .AsNoTracking()
                                 .Join(_context.Classes,
                                       student => student.ClassId,
                                       classObj => classObj.Id,
                                       (student, classObj) => new { student, classObj })
                                 .Where(joinResult => joinResult.classObj.BlockId == blockId)
                                 .Select(joinResult => joinResult.student)
                                 .ToListAsync();
                var dto = _mapper.Map<List<StudentDto>>(data);
                return dto;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentDto?> GetWaitingForApprove(int userId)
        {

            /*Status
            -1: New added
            0: Approval rocessing
            1: Valid
            2: Invalid
            */
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "STUDENT_MANAGEMENT_CLASS_ASSIGN"))) throw new InvalidOperationException();
                var validDate = DateTime.UtcNow.AddMinutes(10);
                var data = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Status < 1 && (x.UpdatedBy == null || x.UpdatedDate < validDate));
                var dto = _mapper.Map<StudentDto>(data);
                return dto;
            } catch (Exception ex)
            {
                throw ex;
            }
                
        }

        public async Task<List<StudentAttendanceDto>> GetAttendancesByClassIdAsync(int classId, int userId, int month = 0)
        {
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "VIEW_STUDENTS_BY_CLASS"))) throw new InvalidOperationException();

                var data = await _context.Students
                                .Include(x => x.Attendances)
                                    .ThenInclude(a => a.UpdatedByCatechist)
                                .Include(x => x.Attendances)
                                    .ThenInclude(a => a.CreatedByCatechist)
                                .Include(x => x.Class)
                                .Where(a => a.ClassId == classId)
                                .ToListAsync();


                var attendanceDto = data.Select(s => new StudentAttendanceDto
                {
                    Student = new CoreDto
                    {
                        Id = s.Id,
                        Name = s.HolyName + ' ' + s.FirstName + ' ' + s.LastName
                    },
                    Attendances = s.Attendances.Where(a => month > 0 ||
                                        (a.Date.Split("/")[1] == month.ToString())).Select(a => new AttendanceDto
                                        {
                                            Id = a.Id,
                                            Date = a.Date,
                                            Status = a.Status,
                                            CreatedByCatechist = new CoreDto
                                            {
                                                Id = a.CreatedByCatechist!.Id,
                                                Name = a.CreatedByCatechist.HolyName + ' ' + a.CreatedByCatechist.FirstName + ' ' + a.CreatedByCatechist.LastName
                                            },
                                            UpdatedByCatechist = new CoreDto
                                            {
                                                Id = a.UpdatedByCatechist!.Id,
                                                Name = a.UpdatedByCatechist.HolyName + ' ' + a.UpdatedByCatechist.FirstName + ' ' + a.UpdatedByCatechist.LastName
                                            }
                                        }).ToList()
                }).ToList();

                return attendanceDto;
            } catch (Exception ex)
            {
                throw ex;
            }
                
        }

        public async Task<List<StudentScoreDto>> GetScoresByClassIdAsync(int classId, int userId, string term = "")
        {
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "VIEW_STUDENTS_BY_CLASS"))) throw new InvalidOperationException();

                var data = await _context.Students
                                .Include(x => x.Scores)
                                    .ThenInclude(a => a.UpdatedByCatechist)
                                .Include(x => x.Scores)
                                    .ThenInclude(a => a.CreatedByCatechist)
                                .Include(x => x.Class)
                                .Where(a => a.ClassId == classId)
                                .ToListAsync();


                var attendanceDto = data.Select(s => new StudentScoreDto
                {
                    Student = new CoreDto
                    {
                        Id = s.Id,
                        Name = s.HolyName + ' ' + s.FirstName + ' ' + s.LastName
                    },
                    Scores = s.Scores.Where(a => term == "all" ||
                                        (a.Term == term)).Select(a => new ScoreDto
                                        {
                                            Id = a.Id,
                                            CatechismMark = a.CatechismMark.ToString(),
                                            PrayerMark = a.PrayerMark.ToString(),
                                            Term = a.Term,
                                            Note = a.Note,
                                            CreatedByCatechist = new CoreDto
                                            {
                                                Id = a.CreatedByCatechist!.Id,
                                                Name = a.CreatedByCatechist.HolyName + ' ' + a.CreatedByCatechist.FirstName + ' ' + a.CreatedByCatechist.LastName
                                            },
                                            UpdatedByCatechist = new CoreDto
                                            {
                                                Id = a.UpdatedByCatechist!.Id,
                                                Name = a.UpdatedByCatechist.HolyName + ' ' + a.UpdatedByCatechist.FirstName + ' ' + a.UpdatedByCatechist.LastName
                                            }
                                        }).ToList()
                }).ToList();

                return attendanceDto;
            } catch (Exception ex)
            {
                throw ex;
            }

                
        }

        public async Task ImportRange(List<Student> students, int userId)
        {
            try
            {
                if (!(await _catechistProfileRepository.IsAllow(userId, "STUDENT_MANAGEMENT_ADD"))) throw new InvalidOperationException();
                await _context.Students.AddRangeAsync(students);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateAsync(int id, CreateStudentDto students, int userId)
        {
            var existedItem = await _context.Students.FindAsync(id);
            if (existedItem == null) throw new Exception();

            existedItem.HolyName = students.HolyName;
            existedItem.FirstName = students.FirstName;
            existedItem.LastName = students.LastName;
            existedItem.BirthDate = students.BirthDate;
            existedItem.Address = students.Address;
            existedItem.Dad = students.Dad;
            existedItem.Mom = students.Mom;
            existedItem.Note = students.Note;
            existedItem.ClassId = students.ClassId;
            existedItem.SacramentBaptism = students.SacramentBaptism;
            existedItem.SacramentFirstConfession = students.SacramentFirstConfession;
            existedItem.SacramentConfirmation = students.SacramentConfirmation;
            existedItem.UpdatedDate = DateTime.UtcNow;
            existedItem.UpdatedBy = userId;

            _context.Students.Update(existedItem);
            await _context.SaveChangesAsync();

        }
    }

}

