/TodoListAPI
│
├── /Application (Class Library)
│   ├── /DTOs  
│    │   └── TaskDTO.cs
│    │   └── TaskCreateDTO.cs
│    │   └── TaskUpdateDTO.cs
│    ├── /Mappers
│    │   └── TaskMapper.cs
│    ├── /Services
│    │   └── TaskAppService.cs
│    ├── /Interfaces
│    │   └── ITaskAppService.cs
│
├── /Domain (Class Library)
│    ├── /Models  
│    │   └── Task.cs
│    │   └── TaskStatus.cs
│    ├── /Repositories
│    │   └── ITaskRepository.cs
│    ├── /Services
│    │   └── TaskService.cs
│
├── /Infrastructure (Class Library)
│    ├── /Data
│    │   └── ApplicationDbContext.cs
│    ├── /Repositories
│    │   └── TaskRepository.cs
│
├── /WebApi (Web API Project)
│    ├── /Controllers
│    │   └── TaskController.cs
│    ├── /DTOs
│    │   └── TaskDTO.cs
│    │   └── TaskCreateDTO.cs
│    │   └── TaskUpdateDTO.cs
│    ├── /Mappers
│    │   └── TaskMapper.cs
│
├── /Shared (Class Library)
│    ├── /Exceptions
│    │   └── TaskNotFoundException.cs
│    ├── /Validators
│    │   └── TaskValidator.cs
│
├── /Tests (Class Library)
│    ├── /ApplicationTests (Unit Tests)
│    │   └── TaskServiceTests.cs
│    ├── /DomainTests (Unit Tests)
│    │   └── TaskTests.cs
│    ├── /InfrastructureTests (Unit Tests)
│    │   └── TaskRepositoryTests.cs
│    ├── /WebApiTests (Integration Tests)
│    │   └── TaskControllerTests.cs
│
├── /appsettings.json           
├── /Program.cs                 
└── /TodoListAPI.csproj         