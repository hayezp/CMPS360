
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Display the HTML webpage from the wwwroot folder.
app.UseDefaultFiles();
app.UseStaticFiles();

// Five courses stored in memory.
var courses = new List<Course>
{
    new Course(1, "CMPS360", "Survey of Programming Languages", 3, "Professor Jeff Seaman"),
    new Course(2, "CMPS460", "Mobile Application Development", 3, "Professor Jeff Seaman"),
    new Course(3, "CMPS462", "Data Mining", 3, "Professor Mark Voortman"),
    new Course(4, "CMPS480", "Senior Project", 3, "Professor Mark Voortman"),
    new Course(5, "MBA582", "Database Management and Application", 3, "Professor Diogo Oliveira")
};

// GET - Display all courses.
app.MapGet("/api/courses", () => Results.Ok(courses));


 // GET - Filter courses by number of credits using LINQ.
app.MapGet("/api/courses/search", (int credits) =>
{
    if (credits < 1 || credits > 6)
    {
        return Results.BadRequest("Credits must be between 1 and 6.");
    }

    var results = courses
        .Where(c => c.Credits == credits)
        .ToList();

    return Results.Ok(results);
});


// GET - Find a course by its ID.
app.MapGet("/api/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    return course is not null
        ? Results.Ok(course)
        : Results.NotFound();
});

// POST - Add a new course.
app.MapPost("/api/courses", (Course newCourse) =>
{
    if (string.IsNullOrWhiteSpace(newCourse.Code) ||
        string.IsNullOrWhiteSpace(newCourse.Title) ||
        string.IsNullOrWhiteSpace(newCourse.Instructor) ||
        newCourse.Credits < 1 || newCourse.Credits > 6)
    {
        return Results.BadRequest(
            "Please provide a code, title, instructor, and credits between 1 and 6.");
    }

    int newId = courses.Count == 0
        ? 1
        : courses.Max(c => c.Id) + 1;

    var course = newCourse with { Id = newId };
    courses.Add(course);

    return Results.Created($"/api/courses/{newId}", course);
});

// PUT - Update an existing course.
app.MapPut("/api/courses/{id:int}", (int id, Course updatedCourse) =>
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
        return Results.BadRequest(
            "Please provide a code, title, instructor, and credits between 1 and 6.");
    }

    var course = updatedCourse with { Id = id };
    courses[courses.IndexOf(existingCourse)] = course;

    return Results.Ok(course);
});

// DELETE - Remove a course.
app.MapDelete("/api/courses/{id:int}", (int id) =>
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

// Course model with five required properties.
record Course(
    int Id,
    string Code,
    string Title,
    int Credits,
    string Instructor
);
