using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class AttendanceService : Service<Attendance>, IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ICatechistProfileRepository _catechistProfileRepository;
        public AttendanceService(IAttendanceRepository repository, ICatechistProfileRepository catechistProfileRepository) : base(repository)
        {
            _attendanceRepository = repository;
            _catechistProfileRepository = catechistProfileRepository;
        }

        public async Task AddAttendancesAsync(int classId, List<CreateAttendanceDto> createAttendanceDtos, int userId)
        {
            //TODO check role
            if (await _catechistProfileRepository.IsAllow(userId, "")) throw new InvalidOperationException();

            var attendances = new List<Attendance>();

            foreach (var att in createAttendanceDtos)
            {

                var attendance = new Attendance
                {
                    ClassId = classId,
                    StudentId = att.StudentId,
                    Date = att.Date,
                    Status = att.Status,
                    CreatedBy = userId,
                    UpdatedBy = userId
                };

                attendances.Add(attendance);
            }

            await _attendanceRepository.AddAttendancesAsync(attendances);
        }
        public async Task UpdateAttendancesAsync(int classId, List<CreateAttendanceDto> attendanceDtos, int userId)
        {
            var attendances = new List<Attendance>();

            foreach (var att in attendanceDtos)
            {
                var existedAttendance = await _attendanceRepository.GetFirstOrDefaultByConditionAsync(x => x.StudentId == att.StudentId && x.ClassId == classId && x.Date == att.Date);
                if (existedAttendance == null) throw new InvalidOperationException("Attendance does not exist.");
                var attendance = new Attendance
                {
                    Id = existedAttendance.Id,
                    ClassId = classId,
                    StudentId = att.StudentId,
                    Date = att.Date,
                    Status = att.Status,
                    CreatedBy = userId,
                    UpdatedBy = userId
                };

                attendances.Add(attendance);
            }

            await _attendanceRepository.UpdateAttendancesAsync(attendances);
        }

    }
}
