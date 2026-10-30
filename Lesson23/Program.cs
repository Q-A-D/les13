using Microsoft.EntityFrameworkCore;
using Lesson23.Data;
using Lesson23.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CollegeDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;"));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ============ STUDENTS ============
app.MapGet("/students", async (CollegeDbContext db) => await db.Students.ToListAsync());

app.MapGet("/students/{id}", async (int id, CollegeDbContext db) =>
{
    var s = await db.Students.FindAsync(id);
    return s is not null ? Results.Ok(s) : Results.NotFound();
});

app.MapPost("/students", async (Student student, CollegeDbContext db) =>
{
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPut("/students/{id}", async (int id, Student updated, CollegeDbContext db) =>
{
    var s = await db.Students.FindAsync(id);
    if (s is null) return Results.NotFound();
    s.FirstName = updated.FirstName;
    s.LastName = updated.LastName;
    s.Age = updated.Age;
    s.GroupId = updated.GroupId;
    await db.SaveChangesAsync();
    return Results.Ok(s);
});

app.MapDelete("/students/{id}", async (int id, CollegeDbContext db) =>
{
    var s = await db.Students.FindAsync(id);
    if (s is null) return Results.NotFound();
    db.Students.Remove(s);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ============ GROUPS ============
app.MapGet("/groups", async (CollegeDbContext db) => await db.Groups.ToListAsync());

app.MapGet("/groups/{id}", async (int id, CollegeDbContext db) =>
{
    var g = await db.Groups.FindAsync(id);
    return g is not null ? Results.Ok(g) : Results.NotFound();
});

app.MapPost("/groups", async (Group group, CollegeDbContext db) =>
{
    db.Groups.Add(group);
    await db.SaveChangesAsync();
    return Results.Created($"/groups/{group.Id}", group);
});

app.MapPut("/groups/{id}", async (int id, Group updated, CollegeDbContext db) =>
{
    var g = await db.Groups.FindAsync(id);
    if (g is null) return Results.NotFound();
    g.Name = updated.Name;
    await db.SaveChangesAsync();
    return Results.Ok(g);
});

app.MapDelete("/groups/{id}", async (int id, CollegeDbContext db) =>
{
    var g = await db.Groups.FindAsync(id);
    if (g is null) return Results.NotFound();
    db.Groups.Remove(g);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ============ SUBJECTS ============
app.MapGet("/subjects", async (CollegeDbContext db) => await db.Subjects.ToListAsync());

app.MapPost("/subjects", async (Subject subject, CollegeDbContext db) =>
{
    db.Subjects.Add(subject);
    await db.SaveChangesAsync();
    return Results.Created($"/subjects/{subject.Id}", subject);
});

app.MapPut("/subjects/{id}", async (int id, Subject updated, CollegeDbContext db) =>
{
    var s = await db.Subjects.FindAsync(id);
    if (s is null) return Results.NotFound();
    s.Name = updated.Name;
    await db.SaveChangesAsync();
    return Results.Ok(s);
});

app.MapDelete("/subjects/{id}", async (int id, CollegeDbContext db) =>
{
    var s = await db.Subjects.FindAsync(id);
    if (s is null) return Results.NotFound();
    db.Subjects.Remove(s);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ============ TEACHERS ============
app.MapGet("/teachers", async (CollegeDbContext db) => await db.Teachers.ToListAsync());

app.MapPost("/teachers", async (Teacher teacher, CollegeDbContext db) =>
{
    db.Teachers.Add(teacher);
    await db.SaveChangesAsync();
    return Results.Created($"/teachers/{teacher.Id}", teacher);
});

app.MapPut("/teachers/{id}", async (int id, Teacher updated, CollegeDbContext db) =>
{
    var t = await db.Teachers.FindAsync(id);
    if (t is null) return Results.NotFound();
    t.Name = updated.Name;
    await db.SaveChangesAsync();
    return Results.Ok(t);
});

app.MapDelete("/teachers/{id}", async (int id, CollegeDbContext db) =>
{
    var t = await db.Teachers.FindAsync(id);
    if (t is null) return Results.NotFound();
    db.Teachers.Remove(t);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// ============ GRADES ============
app.MapGet("/grades", async (CollegeDbContext db) => await db.Grades.ToListAsync());

app.MapPost("/grades", async (Grade grade, CollegeDbContext db) =>
{
    db.Grades.Add(grade);
    await db.SaveChangesAsync();
    return Results.Created($"/grades/{grade.Id}", grade);
});

app.MapPut("/grades/{id}", async (int id, Grade updated, CollegeDbContext db) =>
{
    var g = await db.Grades.FindAsync(id);
    if (g is null) return Results.NotFound();
    g.StudentId = updated.StudentId;
    g.SubjectId = updated.SubjectId;
    g.GradeValue = updated.GradeValue;
    await db.SaveChangesAsync();
    return Results.Ok(g);
});

app.MapDelete("/grades/{id}", async (int id, CollegeDbContext db) =>
{
    var g = await db.Grades.FindAsync(id);
    if (g is null) return Results.NotFound();
    db.Grades.Remove(g);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();