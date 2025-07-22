# InnoClinic

**InnoClinic** is a web-based medical system developed for clinic with multiple branches. It is accessed via a web interface and exposes functionality through a structured HTTP API. The system covers all core processes of a healthcare facility — such as user registration, appointment scheduling, medical records management, service catalog organization, and internal administration. It is structured to support clear role separation and ensure smooth interaction between patients and clinic staff. The goal is to streamline daily operations, reduce manual workload, and maintain accurate medical data through a unified digital platform.

---

## Tech Stack

- **Backend Language**: C# (.NET 8)
- **Backend Framework**: ASP.NET Core Web API
- **Frontend Framework**: React (planned)
- **Architecture**: Domain-Driven Design (DDD), Clean Architecture, Onion Architecture
- **Data Access**: Entity Framework Core (Code First)
- **Database**: SQL Server (Dockerized)
- **Validation**: FluentValidation
- **Messaging**: RabbitMQ with MassTransit (for centralized logging)
- **CQRS / Mediator Pattern**: MediatR
- **Logging**: Asynchronous event-based logging via RabbitMQ to a dedicated logging microservice
- **Authentication & Authorization**: JWT (planned), role-based access control
- **Containers & Orchestration**: Docker, Docker Compose

---

## Microservices

| Name                 | Responsibility                                                                                     |
|----------------------|-----------------------------------------------------------------------------------------------------|
| `PatientControl`     | Handles patient-related data, including creation and management of patient profiles and medical records. |
| `StaffControl`       | Manages staff profiles and role assignment; defines access to features based on user roles.        |
| `AccountControl`     | Responsible for creating and managing user accounts and general account-related operations.        |
| `AppointmentsControl`| Manages creation, modification, and cancellation of appointments.                                   |
| `LogControl`         | Aggregates and stores structured logs from all services for centralized diagnostics.                |
| `Contracts`          | Shared library used for communication between microservices.                                       |


---

## Getting Started

### Requirements

- .NET 8 SDK
- Docker & Docker Compose
- RabbitMQ (included via `docker-compose.yml`)

### Run the system

```bash
git clone https://github.com/arina29lv/InnoClinic.git
cd InnoClinic
docker-compose up --build
```  

---

## Author

**Arina Liubas**
Software Engineer at Innowice  
© 2025

--- 

## License

This project is proprietary and **does not have an open-source license**.  
Usage, copying, or distribution without explicit permission from the author is not allowed.