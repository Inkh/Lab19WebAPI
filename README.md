# To Dos API

This is a simple web API that allows users to store to dos and put them into a list.

## Getting Started

Clone down the project from github, open the .sln file with Visual Studio, then run the application.

Alternatively, a deployed site is also available for API calls:

https://tdapi.azurewebsites.net/

- /api/todo 
    - GET: Returns all the To Dos in JSON format.
    - POST: Takes in a valid ToDo object to store in DB.

- /api/todo/:id
    - GET: Returns the ToDo matching with the input ID.
    - PUT: Updates a specific todo.
    - DELETE: Deletes a specific todo.

- /api/todolists
    - GET: Returns all the To do lists in JSON format.
    - POST: Takes in a valid ToDoList object to store in DB.

- /api/todolists/:id
    - GET: Returns the ToDoList matching with the input ID.
    - PUT: Updates a specific todolist.
    - DELETE: Deletes a specific todolist.