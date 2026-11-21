
# Student Course API - Module 5 Assignment 5

## About My Project

For this assignment, I continued working on the Student Course API I made for my previous assignment using C# and ASP.NET Core.

I kept the five college classes I originally used because I wanted to work with course information that was familiar to me instead of making everything up.

My API still lets users see all the courses, look up a course by its ID, add a new course, update an existing course, and delete a course.

The new part of this assignment was adding a way to filter courses using LINQ. I decided to let users search by the number of credits instead of searching by a course ID.

I also kept the webpage I made with HTML, CSS, and JavaScript. It uses `fetch()` to get the course information from my API and display it in a table.

## What You Need

- .NET 10 SDK
- Visual Studio Code
- A web browser

## How to Run It

1. Open the `Module5_Assign5` folder in VS Code.
2. Open the terminal inside that folder.
3. Enter this command:

   ```cmd
   dotnet run
   ```

4. Wait for the application to start.
5. Open the localhost address shown in the terminal.

When I tested my project, it ran at `http://localhost:5052`.

The port number might be different on another computer.

My API uses in-memory storage, so any courses I add, update, or delete will reset when I stop and restart the application.

## API Routes

| Method | Route | What It Does |
|---|---|---|
| GET | `/api/courses` | Shows all courses |
| GET | `/api/courses/{id}` | Finds one course by its ID |
| GET | `/api/courses/search?credits=3` | Filters courses by credits using LINQ |
| POST | `/api/courses` | Adds a new course |
| PUT | `/api/courses/{id}` | Updates an existing course |
| DELETE | `/api/courses/{id}` | Deletes a course |

## New Feature: Filtering Courses With LINQ

The biggest change I made for this assignment was adding a GET endpoint that lets someone filter courses based on how many credits they have.

I used LINQ's `Where()` method to find courses that match the credit number entered and `ToList()` to return those courses.

For example, I tested this address:

`http://localhost:5052/api/courses/search?credits=3`

It returned all five of my original courses because they are all worth three credits.

I also added validation so someone cannot search using a credit number outside the range of 1 through 6.

If an invalid number is entered, the API returns a `400 Bad Request` response.

## Example of Course Information

For testing, I made up an additional course and used Professor Hayes as the instructor.

This is the JSON information I used to add that course:

```json
{
  "code": "CMPS350",
  "title": "Software Engineering",
  "credits": 3,
  "instructor": "Professor Hayes"
}
```

## How I Tested My API

I tested the GET endpoints in my browser and used the VS Code terminal to test POST, PUT, and DELETE.

I also tested the new LINQ filter and checked that my API returns the correct error messages when something goes wrong.

### Get All Courses

I entered this address in my browser:

`http://localhost:5052/api/courses`

It showed all five courses.

### Get One Course by ID

I entered:

`http://localhost:5052/api/courses/1`

It returned my CMPS360 course.

### Filter Courses by Credits

I entered:

`http://localhost:5052/api/courses/search?credits=3`

It returned the five courses that have three credits.

### Test a Course That Does Not Exist

I entered:

`http://localhost:5052/api/courses/999`

The API returned `404 Not Found` because that course does not exist.

### Add a New Course (POST)

I used this command in my VS Code terminal:

```cmd
curl.exe -i -X POST http://localhost:5052/api/courses -H "Content-Type: application/json" -d "{\"code\":\"CMPS350\",\"title\":\"Software Engineering\",\"credits\":3,\"instructor\":\"Professor Hayes\"}"
```

The API returned `201 Created` and added the new course with ID 6.

### Update a Course (PUT)

Next, I changed the course title to Advanced Software Engineering.

```cmd
curl.exe -i -X PUT http://localhost:5052/api/courses/6 -H "Content-Type: application/json" -d "{\"code\":\"CMPS350\",\"title\":\"Advanced Software Engineering\",\"credits\":3,\"instructor\":\"Professor Hayes\"}"
```

The API returned `200 OK` and showed the updated course information.

### Delete a Course (DELETE)

After updating the test course, I deleted it using this command:

```cmd
curl.exe -i -X DELETE http://localhost:5052/api/courses/6
```

The API returned `200 OK` and confirmed that course 6 was deleted.

### Test Invalid Information (400 Bad Request)

I also tried adding a course with nine credits, even though my API only allows one through six.

```cmd
curl.exe -i -X POST http://localhost:5052/api/courses -H "Content-Type: application/json" -d "{\"code\":\"CMPS350\",\"title\":\"Software Engineering\",\"credits\":9,\"instructor\":\"Professor Hayes\"}"
```

The API returned `400 Bad Request`, which showed me that my validation was working.

## Checking for Errors

I added validation to make sure each course has a code, title, instructor, and a credit amount between 1 and 6.

If someone tries to add or update a course with missing information or invalid credits, the API returns `400 Bad Request`.

The credits filter also returns `400 Bad Request` if someone searches using an invalid credit amount.

If someone tries to find, update, or delete a course that does not exist, the API returns `404 Not Found`.

## Screenshots

I saved eight screenshots showing the different parts of my API working.

1. `Credits_Filter.png` - Filtering courses by credits using LINQ
2. `GET_All_Courses.png` - Showing all five courses
3. `GET_By_ID.png` - Looking up one course
4. `GET_404_Not_Found.png` - Testing a course ID that does not exist
5. `POST_201_Created.png` - Adding a new course
6. `PUT_200_OK.png` - Updating the test course
7. `DELETE_200_OK.png` - Deleting the test course
8. `POST_400_Bad_Request.png` - Testing invalid course credits

All of my screenshots are saved in the `screenshots` folder.

## What I Learned

This assignment helped me work through better understanding how to add new features to an API without having to start the whole project over again and to just be able to add information into it. 

I got more practice using GET, POST, PUT, and DELETE, and I learned how LINQ can make it easier to find specific information in a list. This was a lot of fun to do, since the last time I used these were in POSTMAN, so doing it here was different but fun. 

I also got more comfortable testing my API and checking the response codes to make sure everything was working the way it should.
