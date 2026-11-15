# Student Course API

## About My Project

For this assignment, I created a Student Course API using C# and ASP.NET Core. I decided to use five of my actual college classes instead of making up courses for the project.

The API lets users view all the courses, look up a specific course, add a new course, update a course, or delete one.

I also made a simple webpage using HTML, CSS, and JavaScript. The webpage uses `fetch()` to get the course information from my API and display it in a table.

## What You Need

- .NET 10 SDK
- Visual Studio Code
- A web browser

## How to Run It

1. Open the `StudentCourseApi` folder in VS Code.
2. Open the terminal.
3. Enter this command:

   ```cmd
   dotnet run
   ```

4. Wait for the application to start.
5. Open the localhost address shown in the terminal to see the webpage.

I used in-memory storage for this project, so any courses that are added, updated, or deleted will reset when the application restarts.

## API Routes

| Method | Route | What It Does |
|---|---|---|
| GET | `/api/courses` | Shows all courses |
| GET | `/api/courses/{id}` | Finds one course using its ID |
| POST | `/api/courses` | Adds a new course |
| PUT | `/api/courses/{id}` | Updates a course |
| DELETE | `/api/courses/{id}` | Deletes a course |

## Example of Course Information

This is an example of the JSON information that can be sent to the API to add a course:

```json
{
  "code": "CMPS350",
  "title": "Software Engineering",
  "credits": 3,
  "instructor": "Professor Taylor"
}
```

## How I Tested My API

I used my browser to test the GET routes and the VS Code terminal to test POST, PUT, and DELETE.

My application ran at `http://localhost:5052` when I tested it. The port number might be different on another computer.

**Get all courses:**

```text
http://localhost:5052/api/courses
```

**Get one course:**

```text
http://localhost:5052/api/courses/1
```

**Try an ID that doesn't exist (404):**

```text
http://localhost:5052/api/courses/99
```

**Add a new course (201 Created):**

```cmd
curl.exe -i -X POST http://localhost:5052/api/courses -H "Content-Type: application/json" -d "{\"code\":\"CMPS350\",\"title\":\"Software Engineering\",\"credits\":3,\"instructor\":\"Professor Taylor\"}"
```

**Try adding a course with invalid credits (400 Bad Request):**

```cmd
curl.exe -i -X POST http://localhost:5052/api/courses -H "Content-Type: application/json" -d "{\"code\":\"CMPS999\",\"title\":\"Test Course\",\"credits\":9,\"instructor\":\"Professor Taylor\"}"
```

**Update a course (200 OK):**

```cmd
curl.exe -i -X PUT http://localhost:5052/api/courses/5 -H "Content-Type: application/json" -d "{\"code\":\"MBA582\",\"title\":\"Advanced Database Management\",\"credits\":3,\"instructor\":\"Professor Diogo Oliveira\"}"
```

**Delete a course (200 OK):**

```cmd
curl.exe -i -X DELETE http://localhost:5052/api/courses/5
```

## Checking for Errors

I added validation so that a course needs a code, title, instructor, and a credit amount between 1 and 6.

If someone tries to add or update a course with missing information or invalid credits, the API returns **400 Bad Request**.

If someone tries to find, update, or delete a course that doesn't exist, the API returns **404 Not Found**.

## Screenshots

I took eight screenshots to show that the different parts of my project work.

1. `GET_All_Courses.png` — All five courses
2. `GET_Course_By_ID.png` — Looking up one course
3. `GET_Course_404.png` — Trying an