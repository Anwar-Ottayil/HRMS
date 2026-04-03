# HRMS Module – Employee Attendance & Salary Calculation

**ASP.NET Core Web API – Clean Architecture**

---

## 1. Project Overview

The HRMS module is developed using **ASP.NET Core Web API** following **Clean Architecture principles**.
This system manages **employee details, attendance records, and monthly salary calculation** based on attendance.

The application is divided into multiple layers to ensure:

* Scalability
* Maintainability
* Separation of concerns
* Testability

---

## 2. Technology Stack

| Technology            | Usage                   |
| --------------------- | ----------------------- |
| ASP.NET Core Web API  | API Development         |
| Entity Framework Core | ORM                     |
| SQL Server            | Database                |
| Clean Architecture    | Project Structure       |
| Dependency Injection  | Service management      |
| Async/Await           | Asynchronous operations |

---

## 3. Clean Architecture Structure

The solution is divided into four layers:

```
HRMS Solution
│
├── HRMS.API
├── HRMS.Application
├── HRMS.Domain
└── HRMS.Infrastructure
```

### Layer Responsibilities

| Layer          | Responsibility                              |
| -------------- | ------------------------------------------- |
| Domain         | Entities and Enums                          |
| Application    | DTOs, Interfaces, Services (Business Logic) |
| Infrastructure | DbContext, Repositories, Database           |
| API            | Controllers and Endpoints                   |

### Dependency Flow

```
API → Application → Domain
           ↓
     Infrastructure → Domain
```

**Domain layer does not depend on any other layer.**

---

## 4. Modules Implemented

The system contains the following modules:

1. Employee Management
2. Attendance Management
3. Salary Calculation

---

## 5. Database Design

### Employee Table

| Column        | Type    |
| ------------- | ------- |
| Id            | int     |
| Name          | string  |
| MonthlySalary | decimal |

### Attendance Table

| Column     | Type       |
| ---------- | ---------- |
| Id         | int        |
| EmployeeId | int (FK)   |
| Date       | datetime   |
| Status     | int (Enum) |

### Relationship

```
Employee (1) → (Many) Attendance
```

---

## 6. Attendance Status Enum

| Value | Status   |
| ----- | -------- |
| 1     | Present  |
| 2     | Absent   |
| 3     | Half Day |

---

## 7. Salary Calculation Rules

Salary is calculated based on attendance for a given month.

### Rules

| Status   | Salary       |
| -------- | ------------ |
| Present  | Full Day Pay |
| Half Day | 50% Pay      |
| Absent   | No Pay       |

### Salary Formula

```
PerDaySalary = MonthlySalary / 30

TotalSalary =
(PresentDays × PerDaySalary) +
(HalfDays × PerDaySalary × 0.5)
```

---

## 8. API Endpoints

### 1. Create Employee

**POST** `/api/employees`

**Request Body**

```json
{
  "name": "Anwar",
  "monthlySalary": 35000
}
```

---

### 2. Record Attendance

**POST** `/api/attendance`

**Request Body**

```json
{
  "employeeId": 1,
  "date": "2026-03-01",
  "status": "Present"
}
```

---

### 3. Get Salary

**GET** `/api/salary?employeeId=1&month=2026-03`

| Parameter  | Description            |
| ---------- | ---------------------- |
| employeeId | Employee ID            |
| month      | Salary month (YYYY-MM) |

**Response**

```json
{
  "employeeId": 1,
  "month": "2026-03",
  "totalSalary": 27000
}
```

---

## 9. Project Flow

```
Client → Controller → Service → Repository → DbContext → Database
```

### Flow Explanation

1. Client sends API request
2. Controller receives request
3. Service handles business logic
4. Repository handles database operations
5. DbContext communicates with database
6. Response returned to client

---

## 10. Features Implemented

* Clean Architecture
* Repository Pattern
* Dependency Injection
* DTO Usage
* Async/Await
* Salary Calculation Logic
* Attendance Management
* Employee Management
* SQL Server Database
* Entity Framework Core Migration

---

## 11. How to Run the Project

1. Open solution in Visual Studio
2. Update connection string in **appsettings.json**
3. Run Migration:

```
Add-Migration InitialCreate
Update-Database
```

4. Run the project
5. Test APIs using **Postman** or **Swagger**

---

## 12. Sample Data

### Employee

| Id | Name  | Salary |
| -- | ----- | ------ |
| 1  | Anwar | 35000  |

### Attendance Example

| Date | Status  |
| ---- | ------- |
| 01   | Present |
| 02   | Present |
| 03   | HalfDay |
| 04   | Absent  |

---

## 13. Conclusion

This project demonstrates the implementation of a **real-world HRMS module** using **ASP.NET Core Web API with Clean Architecture**, including employee management, attendance tracking, and salary calculation based on attendance records.

### The architecture ensures:

* Separation of concerns
* Maintainability
* Scalability
* Testability

---

## 14. API Screenshots (Swagger)

### APIs to Capture Screenshots

| Module     | Method | Endpoint                               |
| ---------- | ------ | -------------------------------------- |
| Employee   | POST   | /api/employees                         |                     |
| Attendance | POST   | /api/attendance                        |         |
| Salary     | GET    | /api/salary?employeeId=1&month=2026-03 |

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/1152c080-0d5e-4c67-9ab0-57d160f287ad" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/41470606-4ad3-47f8-ac93-86e72c7c6e1c" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/b40fbd00-5bb9-49b9-9731-2020c3afe0f6" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/666d4d7d-2ae3-4efb-afb9-9030eba78895" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/0729e2f0-578c-43ec-a41e-33de4a618f1e" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/3c0c25f4-7a37-4883-931d-6827b91e7a36" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/99587c37-043a-40f5-a799-7927cff168b2" />



---

## 15. Sample Data SQL

### Sample Employee Data

```sql
INSERT INTO Employees (Name, MonthlySalary)
VALUES ('Anwar', 35000),
       ('Rahul', 45000),
       ('Sneha', 38000);
```

### Sample Attendance Data

```sql
INSERT INTO Attendances (EmployeeId, Date, Status)
VALUES 
(1, '2026-03-01', 1),
(1, '2026-03-02', 1),
(1, '2026-03-03', 3),
(1, '2026-03-04', 2),
(1, '2026-03-05', 1);
```

### Attendance Status

| Value | Status   |
| ----- | -------- |
| 1     | Present  |
| 2     | Absent   |
| 3     | Half Day |

---

## 16. Architecture Diagram

### Clean Architecture Diagram (Text Format)

```
                ┌───────────────┐
                │     API       │
                │ Controllers   │
                └───────┬───────┘
                        │
                        ▼
                ┌───────────────┐
                │ Application    │
                │ Services, DTOs │
                └───────┬───────┘
                        │
                        ▼
                ┌───────────────┐
                │   Domain       │
                │ Entities       │
                └───────┬───────┘
                        │
                        ▼
                ┌───────────────┐
                │ Infrastructure │
                │ DbContext, DB  │
                └───────────────┘
```

### Request Flow

```
Client → Controller → Service → Repository → DbContext → Database
                                              ↓
                                           SQL Server
```
