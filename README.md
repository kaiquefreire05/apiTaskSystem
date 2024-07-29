# Task System API

`Developed by:` Kaíque Freire dos Santos

This project is an API for managing tasks, developed using Entity Framework and C#.

## Features

* `Task Management:` Create, read, update, and delete tasks.
* `User Authentication:` Secure user login and registration.
* `Task Assignment:` Assign tasks to different users.
* `Status Tracking:` Track the status of tasks (e.g., pending, in progress, completed).

## Technologies

* .NET Core
* Entity Framework Core
* SQL Server
* JWT for authentication

## Getting Started
### Prerequisites 

- [.NET Core SDK](https://dotnet.microsoft.com/pt-br/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation

1. Clone the repository:
   
```
git clone https://github.com/kaiquefreire05/apiTaskSystem.git
```
2. Navigate to the project directory:
   
```
cd apiTaskSystem
```
3. Restore dependencies:

```
dotnet restore
```
4. Update the connection string in `appsettings.json`:

```
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server connection string"
}
```
5. Apply migrations:

```
dotnet ef database update
```
6. Run the application:

```
dotnet run
```

## Usage

### Endpoints

#### Account

* POST /api/account

#### Cep

* GET api/Cep

#### Task

* GET api/Task
* POST api/Task
* DELETE api/Task
* GET api/Task/{id}
* PUT api/Task/{id}

#### User

* GET api/User
* POST api/User
* GET api/User/{id}
* PUT api/User/{id}
* DELETE api/User

## Example Requests

### Create Task

```
POST /api/tasks
Content-Type: application/json
Authorization: Bearer {token}

{
  "id": 0,
  "name": "string",
  "desc": "string",
  "status": 0,
  "userId": 0,
  "user": {
    "id": 0,
    "name": "string",
    "email": "string"
  }
}
```

### Get All Tasks

```
GET /api/tasks
Authorization: Bearer {token}
```

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
