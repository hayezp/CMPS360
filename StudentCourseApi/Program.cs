var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

var courses = new List<Course>
{
    new Course(1, "CMPS360", "Survey of Programming Languages", 3, "Professor Jeff Seaman"),
    new Course(2, "CMPS460", "Mobile Application Development", 3, "Professor Jeff Seaman"),
    new Course(3, "CMPS462", "Data Mining", 3, "Professor Mark Voortman"),
    new Course(4, "CMPS480", "Senior Project", 3, "Professor Mark Voortman"),
    new Course(5, "MBA582", "Database Management and Application", 3, "Professor Diogo Oliveira")
};

app.MapGet("/api/courses", () => courses);
app.MapGet("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    return course is not null
        ? Results.Ok(course)
        : Results.NotFound();
});

app.MapPost("/api/courses", (Course newCourse) =>
{
    if (string.IsNullOrWhiteSpace(newCourse.Code) ||
        string.IsNullOrWhiteSpace(newCourse.Title) ||
        string.IsNullOrWhiteSpace(newCourse.Instructor) ||
        newCourse.Credits < 1 || newCourse.Credits > 6)
    {
        return Results.BadRequest("Please provide a code, title, instructor, and credits between 1 and 6.");
    }

    int newId = courses.Max(c => c.Id) + 1;

    var course = newCourse with { Id = newId };
    courses.Add(course);

    return Results.Created($"/api/courses/{newId}", course);
});

app.MapPut("/api/courses/{id}", (int id, Course updatedCourse) =>
{
    var existingCourse = courses.FirstOrDefault(c => c.Id == id);

    if (existingCourse is null)
    {
        return Results.NotFound();
    }

    if (string.IsNullOrWhiteSpace(updatedCourse.Code) ||
        string.IsNullOrWhiteSpace(updatedCourse.Title) ||
        string.IsNullOrWhiteSpace(updatedCourse.Instructor) ||
        updatedCourse.Credits < 1 || updatedCourse.Credits > 6)
    {
        return Results.BadRequest("Please provide a code, title, instructor, and credits between 1 and 6.");
    }

    var course = updatedCourse with { Id = id };

    courses[courses.IndexOf(existingCourse)] = course;

    return Results.Ok(course);
});

app.MapDelete("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course is null)
    {
        return Results.NotFound();
    }

    courses.Remove(course);

    return Results.Ok($"Course {id} was deleted successfully.");
});

app.Run();

record Course(
    int Id,
    string Code,
    string Title,
    int Credits,
    string Instructor
);