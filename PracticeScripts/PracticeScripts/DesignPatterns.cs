using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PracticeScripts
{
    internal class DesignPatterns
    {
    }
    #region SOLID Principles
    /*
        S - Single Responsibility Principle (SRP) – A class should have only one reason to be changed.(every class, or similar structure, in your code should have only one job to do. Everything in that class should be related to a single purpose.)
        O - Open-Closed Principle (OCP) – A class should be open to extension but closed to modification
        L -Liskov Substitution Principle (LSP) – You should be able to replace a class with a subclass without the calling code knowing about the change(you should be able to use any derived class instead of a parent class and have it behave in the same manner without modification)
        I - Interface Segregation Principle (ISP) – Many specific interfaces are better than a single, all-encompassing interface(clients should not be forced to implement interfaces they don't use)
        D - Dependency Inversion Principle (DIP) – Code should depend upon abstractions, not concrete implementations(High-level modules/classes implement business rules or logic in a system (application). Low-level modules/classes deal with more detailed operations)
    */
    #endregion

    #region Category of Design Patterns
    /*
        Creational patterns: Initialization and configuration of objects
        
        Structure pattern: Separate the implementation interface. They deal with how classes and objects are grouped, to form larger structures.
        
        Behavior pattern: More than describing objects or classes, they describe the communication between them.
    */
    #endregion

    #region Test Driven Development(TDD)
    /*TDD is a software development approach where tests are written before the actual code.It follows the Red-Green-Refactor cycle:

        Red: Write a failing test
        Green: Write minimal code to pass the test
        Refactor: Improve code while keeping tests passing

    Benefits of TDD:
            ->Better code design and maintainability
            ->Fewer bugs and regressions
            ->Living documentation
            ->Faster debugging
            ->Encourages modular, testable code
            ->Increases developer confidence

    */
    #endregion

    #region TDD Process & Practices
    /*
     How do you start with TDD on a new feature?

    Answer:
        Understand requirements and define test cases
        Write the simplest failing test
        Implement minimal code to pass
        Refactor
        Repeat until feature complete

    What makes a good test?
        Fast: Runs quickly
        Isolated: No dependencies on other tests
        Repeatable: Same results every time
        Self-validating: Clearly passes or fails
        Timely: Written at the right time (before code for TDD)
     * 
     * */
    #endregion

    #region Domain-Driven Design(DDD)
    /*
     DDD is an approach to software development that focuses on:

        ->Core domain and domain logic
        ->Ubiquitous Language shared by developers and domain experts
        ->Complex domain models that reflect business reality
        ->Strategic design patterns (Bounded Contexts, Context Maps)
        ->Tactical design patterns (Entities, Value Objects, Aggregates, etc.)

    What is the Ubiquitous Language? A common language shared by developers and domain experts that:
        Is used in code, documentation, and conversations
        Reduces translation errors between technical and business teams
        Evolves with the domain understanding
        Is precise and consistent across the project

    Explain Bounded Contexts
    Bounded Contexts define:
        Explicit boundaries where a particular domain model applies
        Context-specific meanings for terms (e.g., "Product" means different things in Sales vs. Inventory contexts)
        Owned domain models with clear responsibilities
        Integration points between contexts via Context Mapping

    What are the main benefits of DDD?
        Better alignment between software and business needs
        Improved communication between technical and business teams
        More maintainable and evolvable codebase
        Clear boundaries that reduce complexity
        Focus on core business value
     * */
    #endregion

    #region CRUD
    /*
     What does CRUD stand for?
        Create - Add new records            | POST
        Read - Retrieve or view records     | GET
        Update - Modify existing records    | PUT/PATCH
        Delete - Remove records             | DELETE 

        PUT: Complete resource replacement (idempotent)
        PATCH: Partial resource update (not necessarily idempotent)

    key components of a CRUD application
        Data Model - Entity classes
        Data Access Layer - Repository pattern
        Business Logic Layer - Service classes
        API Layer - Controllers
        Database - Persistent storage

     */

    #endregion

    #region CQRS (Command Query Responsibility Segregation)
    /*
    Separates read and write operations into different models
        Commands change state (writes) - should return only success/failure
        Queries return data (reads) - should not change state
        Enables optimization of each side independently 

    What are the main benefits of CQRS?
        Scalability: Read and write scales independently
        Optimization: Different data models for reads vs writes
        Simplified queries: Read models can be denormalized
        Security: Different permissions for commands vs queries
        Maintainability: Separation of concerns

    When should you use CQRS?
        Read and write workloads have different requirements
        You need high performance on reads or writes
        Complex domain with different data representations
        Team can handle the additional complexity
        Using Event Sourcing (they often go together)

    When should you avoid CQRS?
        The system is simple CRUD-based
        Team lacks experience with the pattern
        Overhead outweighs benefits
        Consistency requirements are very strict
        Project is small or short-lived

    basic CQRS architecture
    [Command Side]           [Query Side]
    ╔═════════════╗         ╔════════════╗
    ║   Command   ║         ║   Query    ║
    ║   Handler   ║         ║   Handler  ║
    ╚═════════════╝         ╚════════════╝
           │                       │
           ▼                       ▼
    ╔═════════════╗         ╔════════════╗
    ║ Write Model ║         ║ Read Model ║
    ║ (Domain)    ║         ║ (DTOs)     ║
    ╚═════════════╝         ╚════════════╝
           │                       │
           ▼                       ▼
    ╔═════════════╗         ╔════════════╗
    ║ Write       ║         ║ Read       ║
    ║ Database    ║         ║ Database   ║
    ╚═════════════╝         ╚════════════╝

     */
    #endregion

    #region Hexagonal
    /*
     Hexagonal Architecture (also called Ports and Adapters) is:
        An architectural pattern that isolates the core business logic from external concerns
        Uses ports (interfaces) for communication and adapters (implementations) for external systems
        Makes the application framework-agnostic and highly testable
        The core domain is at the center, surrounded by adapters 

    main benefits
        Testability: Core logic can be tested without external dependencies
        Maintainability: Changes to external systems don't affect core logic
        Flexibility: Easy to swap implementations (database, UI, external services)
        Framework independence: Core doesn't depend on specific frameworks
        Clear separation of concerns

    Ports and Adapters?
        Ports: Interfaces that define how the application communicates with the outside world
            Primary/Driving Ports: For input (API calls, user interactions)
            Secondary/Driven Ports: For output (databases, external services)

        Adapters: Implementations that connect ports to external systems
            Primary Adapters: Controllers, CLI handlers, HTTP handlers
            Secondary Adapters: Database repositories, external service clients

                +-----------------+
                | Primary Adapters|
                | (Controllers,   |
                |  CLI Handlers)  |
                +-----------------+
                        ▲ │
                        │ ▼
    +----------------+  Ports  +----------------+
    |                |←───────→|                |
    | Application    |         | Secondary      |
    | Core           |         | Adapters       |
    | (Use Cases,    |←───────→| (Repositories, |
    | Domain Models) |  Ports  | External APIs) |
    |                |         |                |
    +----------------+         +----------------+

    */
    #endregion

    #region Onion Architecture
    /*
        A layered architecture with domain at the center
        Dependencies point inward - inner layers don't depend on outer layers
        External concerns (UI, database, infrastructure) are pushed to the outside
        High testability and maintainability through separation of concerns 

     +-------------------+
     |   Domain Layer    |  ← Core business entities, rules
     +-------------------+
     | Application Layer |  ← Use cases, application services  
     +-------------------+
     | Infrastructure    |  ← External concerns: DB, APIs, UI
     +-------------------+

        Dependencies point inward only:
            Domain Layer has no dependencies
            Application Layer depends on Domain
            Infrastructure Layer depends on Application and Domain
            No outer layer should be referenced by inner layers

        Domain Layer
            Entities - Core business objects with identity
            Value Objects - Immutable objects without identity
            Domain Events - Things that happened in the domain
            Repository Interfaces - Contracts for persistence (no implementations)
            Domain Services - Domain-specific operations

        Application Layer
            Use Cases / Application Services - Coordinate domain objects
            DTOs (Data Transfer Objects) - For input/output
            Interface Adapters - Implement repository interfaces
            Cross-cutting concerns (validation, authorization)

        Infrastructure Layer
            Repository Implementations - DB, file system, external APIs
            UI Components - Web controllers, CLI handlers
            Framework-specific code - ASP.NET, Entity Framework
            External Services - Email, messaging, caching

         src/
        ├── Domain/                    # Domain Layer
        │   ├── Entities/
        │   │   └── User.cs
        │   ├── ValueObjects/
        │   │   └── Email.cs
        │   ├── Interfaces/
        │   │   └── IUserRepository.cs
        │   └── Events/
        │       └── UserCreatedEvent.cs
        ├── Application/               # Application Layer  
        │   ├── UseCases/
        │   │   └── CreateUserUseCase.cs
        │   ├── DTOs/
        │   │   └── CreateUserDto.cs
        │   └── Services/
        │       └── IEmailService.cs
        └── Infrastructure/           # Infrastructure Layer
        ├── Persistence/
        │   └── UserRepository.cs
        ├── Web/
        │   └── UsersController.cs
        └── External/
        └── SmtpEmailService.cs
     */
    #endregion

    #region Singleton
    /*
        Ensures a class has only one instance throughout the application
        Provides a global access point to that instance
        Controls object creation to prevent multiple instantiations
        Is a creational design pattern 

    main use cases for Singleton
        Logging systems - single point for log writing
        Configuration management - global config access
        Database connections - connection pooling
        Caching mechanisms - shared cache store
        Hardware access - printer spoolers, device managers

    advantages of Singleton
        Controlled access to single instance
        Reduced memory usage - avoid multiple instances
        Global state management - shared resource access
        Lazy initialization - create only when needed

     */
    // Registration
    //services.AddSingleton<IMyService, MyService>();
    //services.AddSingleton<MyService>(); // As self

    // The container ensures only one instance exists
    // Thread-safe initialization
    // Proper disposal if implemented IDisposable

    // Implementation
    public class MyService :  IDisposable //, IMyService
    {
        public MyService() { } // Called once

        public void Dispose() { } // Called when app stops
    }

    #endregion

    #region Factory
    /*
    Provides an interface for creating objects without specifying their concrete classes
    Decouples object creation from object usage
    Centralizes creation logic in one place
    Promotes loose coupling and high cohesion 

    Types of Factory patterns
        Simple Factory: A single method that creates objects based on input parameters
        Factory Method: Defines an interface for creating an object, but lets subclasses decide which class to instantiate
        Abstract Factory: Provides an interface for creating families of related or dependent objects without specifying their concrete classes

    Factory pattern solve
        Tight coupling between client and concrete classes
        Complex object creation logic scattered throughout code
        Difficulty in extending with new product types
        Violation of Open/Closed Principle when adding new products
     */
    // Product interface
    public interface IVehicle
    {
        void Drive();
    }

    // Concrete products
    public class Car : IVehicle
    {
        public void Drive() => Console.WriteLine("Driving a car");
    }

    public class Bike : IVehicle
    {
        public void Drive() => Console.WriteLine("Riding a bike");
    }

    // Simple Factory
    public class VehicleFactory
    {
        public IVehicle CreateVehicle(string type)
        {
            return type.ToLower() switch
            {
                "car" => new Car(),
                "bike" => new Bike(),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }

    // Usage
    //var factory = new VehicleFactory();
    //IVehicle vehicle = factory.CreateVehicle("car");
    //vehicle.Drive();

    #endregion

    #region Microservices
    /*
        Small, autonomous services that work together
        Each service owns its own data and domain logic
        Services communicate via lightweight protocols (HTTP/REST, gRPC, messaging)
        Independently deployable and scalable
        Organized around business capabilities

    key characteristics?
        Single responsibility - each service does one thing well
        Decentralized governance - teams choose their own tools
        Failure isolation - one service failure doesn't bring down entire system
        Independent deployment - deploy services without coordinating with others
        Smart endpoints, dumb pipes - business logic in services, simple communication

    */
    #endregion

    //Repository with unit of work pattern
    
}
