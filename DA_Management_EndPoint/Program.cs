using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services;
using DA_Management_EndPoint.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)))); // Use appropriate MySQL version


// Configure Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
builder.Services.AddScoped<IBlockRepository, BlockRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ICatechistRepository, CatechistRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

// Configure Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAcademicYearService, AcademicYearService>();
builder.Services.AddScoped<IBlockService, BlockService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ICatechistService, CatechistService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IScoreService, ScoreService>();

var app = builder.Build();

// API Endpoints for Students
app.MapGet("/students", async (IStudentService studentService) =>
    await studentService.GetAllStudentsAsync());

app.MapGet("/students/{id:int}", async (int id, IStudentService studentService) =>
    await studentService.GetStudentByIdAsync(id) is Student student
        ? Results.Ok(student)
        : Results.NotFound());

app.MapPost("/students", async (Student student, IStudentService studentService) =>
{
    await studentService.AddStudentAsync(student);
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPut("/students/{id:int}", async (int id, Student updatedStudent, IStudentService studentService) =>
{
    var student = await studentService.GetStudentByIdAsync(id);
    if (student == null) return Results.NotFound();

    updatedStudent.Id = id;
    await studentService.UpdateStudentAsync(updatedStudent);
    return Results.Ok(updatedStudent);
});

app.MapDelete("/students/{id:int}", async (int id, IStudentService studentService) =>
{
    var student = await studentService.GetStudentByIdAsync(id);
    if (student == null) return Results.NotFound();

    await studentService.DeleteStudentAsync(id);
    return Results.NoContent();
});

app.MapGet("/students/academic-year/{academicYearId:int}", async (int academicYearId, IStudentService studentService) =>
    await studentService.GetStudentsByAcademicYearAsync(academicYearId));

app.MapGet("/students/academic-year/{academicYearId:int}/block/{blockId:int}", async (int academicYearId, int blockId, IStudentService studentService) =>
    await studentService.GetStudentsByAcademicYearAndBlockAsync(academicYearId, blockId));

app.MapGet("/students/academic-year/{academicYearId:int}/block/{blockId:int}/class/{classId:int}", async (int academicYearId, int blockId, int classId, IStudentService studentService) =>
    await studentService.GetStudentsByAcademicYearBlockAndClassAsync(academicYearId, blockId, classId));


// API Endpoints for AcademicYears
app.MapGet("/academicYears", async (IAcademicYearService academicYearService) =>
    await academicYearService.GetAllAcademicYearsAsync());

app.MapGet("/academicYears/{id:int}", async (int id, IAcademicYearService academicYearService) =>
    await academicYearService.GetAcademicYearByIdAsync(id) is AcademicYear academicYear
        ? Results.Ok(academicYear)
        : Results.NotFound());

app.MapPost("/academicYears", async (AcademicYear academicYear, IAcademicYearService academicYearService) =>
{
    await academicYearService.AddAcademicYearAsync(academicYear);
    return Results.Created($"/academicYears/{academicYear.Id}", academicYear);
});

app.MapPut("/academicYears/{id:int}", async (int id, AcademicYear updatedAcademicYear, IAcademicYearService academicYearService) =>
{
    var academicYear = await academicYearService.GetAcademicYearByIdAsync(id);
    if (academicYear == null) return Results.NotFound();

    updatedAcademicYear.Id = id;
    await academicYearService.UpdateAcademicYearAsync(updatedAcademicYear);
    return Results.Ok(updatedAcademicYear);
});

app.MapDelete("/academicYears/{id:int}", async (int id, IAcademicYearService academicYearService) =>
{
    var academicYear = await academicYearService.GetAcademicYearByIdAsync(id);
    if (academicYear == null) return Results.NotFound();

    await academicYearService.DeleteAcademicYearAsync(id);
    return Results.NoContent();
});

// API Endpoints for Blocks
app.MapGet("/blocks", async (IBlockService blockService) =>
    await blockService.GetAllBlocksAsync());

app.MapGet("/blocks/{id:int}", async (int id, IBlockService blockService) =>
    await blockService.GetBlockByIdAsync(id) is Block block
        ? Results.Ok(block)
        : Results.NotFound());

app.MapPost("/blocks", async (Block block, IBlockService blockService) =>
{
    await blockService.AddBlockAsync(block);
    return Results.Created($"/blocks/{block.Id}", block);
});

app.MapPut("/blocks/{id:int}", async (int id, Block updatedBlock, IBlockService blockService) =>
{
    var block = await blockService.GetBlockByIdAsync(id);
    if (block == null) return Results.NotFound();

    updatedBlock.Id = id;
    await blockService.UpdateBlockAsync(updatedBlock);
    return Results.Ok(updatedBlock);
});

app.MapDelete("/blocks/{id:int}", async (int id, IBlockService blockService) =>
{
    var block = await blockService.GetBlockByIdAsync(id);
    if (block == null) return Results.NotFound();

    await blockService.DeleteBlockAsync(id);
    return Results.NoContent();
});

// API Endpoints for Classes
app.MapGet("/classes", async (IClassService classService) =>
    await classService.GetAllClassesAsync());

app.MapGet("/classes/{id:int}", async (int id, IClassService classService) =>
    await classService.GetClassByIdAsync(id) is Class @class
        ? Results.Ok(@class)
        : Results.NotFound());

app.MapPost("/classes", async (Class @class, IClassService classService) =>
{
    await classService.AddClassAsync(@class);
    return Results.Created($"/classes/{@class.Id}", @class);
});

app.MapPut("/classes/{id:int}", async (int id, Class updatedClass, IClassService classService) =>
{
    var @class = await classService.GetClassByIdAsync(id);
    if (@class == null) return Results.NotFound();

    updatedClass.Id = id;
    await classService.UpdateClassAsync(updatedClass);
    return Results.Ok(updatedClass);
});

app.MapDelete("/classes/{id:int}", async (int id, IClassService classService) =>
{
    var @class = await classService.GetClassByIdAsync(id);
    if (@class == null) return Results.NotFound();

    await classService.DeleteClassAsync(id);
    return Results.NoContent();
});

// API Endpoints for Catechists
app.MapGet("/catechists", async (ICatechistService catechistService) =>
    await catechistService.GetAllCatechistsAsync());

app.MapGet("/catechists/{id:int}", async (int id, ICatechistService catechistService) =>
    await catechistService.GetCatechistByIdAsync(id) is Catechist catechist
        ? Results.Ok(catechist)
        : Results.NotFound());

app.MapPost("/catechists", async (Catechist catechist, ICatechistService catechistService) =>
{
    await catechistService.AddCatechistAsync(catechist);
    return Results.Created($"/catechists/{catechist.Id}", catechist);
});

app.MapPut("/catechists/{id:int}", async (int id, Catechist updatedCatechist, ICatechistService catechistService) =>
{
    var catechist = await catechistService.GetCatechistByIdAsync(id);
    if (catechist == null) return Results.NotFound();

    updatedCatechist.Id = id;
    await catechistService.UpdateCatechistAsync(updatedCatechist);
    return Results.Ok(updatedCatechist);
});

app.MapDelete("/catechists/{id:int}", async (int id, ICatechistService catechistService) =>
{
    var catechist = await catechistService.GetCatechistByIdAsync(id);
    if (catechist == null) return Results.NotFound();

    await catechistService.DeleteCatechistAsync(id);
    return Results.NoContent();
});

// API Endpoints for Attendances
app.MapGet("/attendances", async (IAttendanceService attendanceService) =>
    await attendanceService.GetAllAttendancesAsync());

app.MapGet("/attendances/{id:int}", async (int id, IAttendanceService attendanceService) =>
    await attendanceService.GetAttendanceByIdAsync(id) is Attendance attendance
        ? Results.Ok(attendance)
        : Results.NotFound());

app.MapPost("/attendances", async (Attendance attendance, IAttendanceService attendanceService) =>
{
    await attendanceService.AddAttendanceAsync(attendance);
    return Results.Created($"/attendances/{attendance.Id}", attendance);
});

app.MapPut("/attendances/{id:int}", async (int id, Attendance updatedAttendance, IAttendanceService attendanceService) =>
{
    var attendance = await attendanceService.GetAttendanceByIdAsync(id);
    if (attendance == null) return Results.NotFound();

    updatedAttendance.Id = id;
    await attendanceService.UpdateAttendanceAsync(updatedAttendance);
    return Results.Ok(updatedAttendance);
});

app.MapDelete("/attendances/{id:int}", async (int id, IAttendanceService attendanceService) =>
{
    var attendance = await attendanceService.GetAttendanceByIdAsync(id);
    if (attendance == null) return Results.NotFound();

    await attendanceService.DeleteAttendanceAsync(id);
    return Results.NoContent();
});

app.MapPost("/attendances", async (Attendance attendance, IAttendanceService attendanceService) =>
{
    await attendanceService.AddAttendanceAsync(attendance);
    return Results.Created($"/attendances/{attendance.Id}", attendance);
});

app.MapPost("/attendances/bulk", async (IEnumerable<Attendance> attendances, IAttendanceService attendanceService) =>
{
    await attendanceService.AddAttendancesRangeAsync(attendances);
    return Results.Created("/attendances/bulk", attendances);
});


// API Endpoints for Scores
app.MapGet("/scores", async (IScoreService scoreService) =>
    await scoreService.GetAllScoresAsync());

app.MapGet("/scores/{id:int}", async (int id, IScoreService scoreService) =>
    await scoreService.GetScoreByIdAsync(id) is Score score
        ? Results.Ok(score)
        : Results.NotFound());

app.MapPost("/scores", async (Score score, IScoreService scoreService) =>
{
    await scoreService.AddScoreAsync(score);
    return Results.Created($"/scores/{score.Id}", score);
});

app.MapPut("/scores/{id:int}", async (int id, Score updatedScore, IScoreService scoreService) =>
{
    var score = await scoreService.GetScoreByIdAsync(id);
    if (score == null) return Results.NotFound();

    updatedScore.Id = id;
    await scoreService.UpdateScoreAsync(updatedScore);
    return Results.Ok(updatedScore);
});

app.MapDelete("/scores/{id:int}", async (int id, IScoreService scoreService) =>
{
    var score = await scoreService.GetScoreByIdAsync(id);
    if (score == null) return Results.NotFound();

    await scoreService.DeleteScoreAsync(id);
    return Results.NoContent();
});

app.MapPost("/scores", async (Score score, IScoreService scoreService) =>
{
    await scoreService.AddScoreAsync(score);
    return Results.Created($"/scores/{score.Id}", score);
});

app.MapPost("/scores/bulk", async (IEnumerable<Score> scores, IScoreService scoreService) =>
{
    await scoreService.AddScoresAsync(scores);
    return Results.Created("/scores/bulk", scores);
});

app.MapGet("/scores/student/{studentId:int}/year/{academicYearId:int}", async (int studentId, int academicYearId, IScoreService scoreService) =>
    await scoreService.GetScoresByStudentAsync(studentId, academicYearId));


app.Run();