## 🚗 CarBook – Enterprise Car Rental & Management System

CarBook is a comprehensive, **full‑stack vehicle rental and reservation platform** built on a highly scalable **Onion Architecture**. The project is designed as an **enterprise‑level solution** that manages complex car rental workflows, real‑time data tracking, and a large set of business entities using modern software design patterns.

---

## 🏗 Architecture & Design Patterns

The project is engineered with a strong focus on **Clean Code** and **Separation of Concerns**.

### **Onion Architecture**

The solution is organized into four distinct layers:

* **Core**

  * **Domain**: Central business entities and core rules
  * **Application**: DTOs, CQRS Handlers, Validators, Interfaces
* **Infrastructure**

  * **Persistence**: EF Core DbContext, repositories, migrations, Fluent API
  * **SignalR**: Real‑time hubs and statistics logic
* **Presentation**

  * **WebAPI**: RESTful API with 94+ endpoints
* **Frontend**

  * **WebUI**: ASP.NET Core 8.0 MVC application consuming the API via `IHttpClientFactory`

### **Core Design Patterns & Technologies**

* **CQRS with MediatR**: Full separation of Command (Write) and Query (Read) operations
* **Repository Pattern**: Generic and abstracted data access layer
* **JWT Authentication**: Secure, claim‑based authentication
* **Role‑Based Authorization**: Admin, Author, and User roles

---

## 🌟 Key Features & Core Modules

### 🏎️ Vehicle & Fleet Management

* **Brand & Category Management**: Dynamic vehicle classification
* **Car Features & Descriptions**: Technical specifications and rich content
* **Dynamic Pricing Models**:

  * Daily, weekly, and monthly pricing
  * Managed via `CarPricing` and `Pricing` entities
* **Car‑Feature Mapping**: Many‑to‑many relationship management

---

### 🔄 Advanced Reservation & Rental Pipeline

* **Dynamic Reservation System**:

  * Pick‑up & drop‑off locations
  * Date & time selection
* **Admin Approval Engine**:

  * Reservations are reviewed by admins
  * Approved reservations are migrated to the `Rental` table
---

### 📊 Real‑Time Analytics & Statistics (SignalR)

* **Live Admin Dashboard** with real‑time updates:

  * Total brands
  * Most expensive & cheapest cars
  * Daily rental averages
  * Fleet statistics
* No page refresh required (WebSocket‑based updates)

---

### 🛠️ Dynamic Content Management (Admin Controlled)

All frontend content is managed dynamically through the **Admin Panel**.

* **Company Profile Management**:

  * About (Hakkımızda)
  * Services (Hizmetler)
* **Communication Hub**:

  * Contact (İletişim) messages
  * Addresses & locations
* **Global UI Management**:

  * Dynamic banners
  * Footer addresses
  * Social media links
* **Social Proof**:

  * Testimonials (Referanslar)

---

### ✍️ Interaction Ecosystem

* **Blog & Author Management**:

  * Authors manage blogs, categories, and tags (TagCloud)
* **User Engagement**:

  * Blog comments
  * Car reviews

---

## 📂 Project Structure

```text
CarBook
├── Core
│   ├── CarBook.Application   # CQRS Handlers, DTOs, Validators, Interfaces
│   └── CarBook.Domain        # 25+ Entities (Car, Reservation, Blog, Brand, etc.)
├── Infrastructure
│   ├── CarBook.Persistence  # DbContext, Repositories, Migrations, Fluent API
│   └── CarBook.SignalR      # Real‑time Hubs & Statistics Logic
├── Presentation
│   └── CarBook.WebApi       # Controllers & JWT Configuration
└── Frontends
    └── CarBook.WebUI        # MVC Areas, ViewComponents, PartialViews, SignalR Clients
```

---

## 🛠 Tech Stack

| Category     | Technology                                                |
| ------------ | --------------------------------------------------------- |
| Framework    | .NET 8.0 (Web API & MVC)                                  |
| Architecture | Onion Architecture, CQRS, MediatR                         |
| Database     | MS SQL Server, EF Core 8.0 (Code First)                   |
| Security     | JWT, Role‑Based Authorization                             |
| Real‑Time    | SignalR (WebSockets)                                      |
| Tools        | IHttpClientFactory, FluentValidation, Swagger             |
| UI/UX        | Bootstrap 5, AJAX, jQuery, SweetAlert                     |

---

## 📸 Screenshots
* Login Page
  * <img width="1894" height="914" alt="1" src="https://github.com/user-attachments/assets/fcf8f811-e9b4-4417-81df-a7d01a5b62b4" />
* Main Page
  * <img width="1896" height="912" alt="2" src="https://github.com/user-attachments/assets/6ee15984-810b-4f0d-884a-861c431e2c4d" />
* My Reservation Page
  * <img width="1894" height="911" alt="3" src="https://github.com/user-attachments/assets/5c76b43b-ab0a-44e8-8331-83e7a957cf03" />
* My Rental Page
  * <img width="1890" height="913" alt="4" src="https://github.com/user-attachments/assets/ea8c47b3-f7ad-45a1-a218-92b15a41ff54" />
* About Page
  * <img width="1858" height="914" alt="5" src="https://github.com/user-attachments/assets/0d805a47-e2f9-4b19-9a41-616b91447513" />
* Service Page
  * <img width="1893" height="909" alt="6" src="https://github.com/user-attachments/assets/ed925ef5-7d74-4706-8943-f298216dc100" />
* Car Pricing Page
  * <img width="1889" height="906" alt="7" src="https://github.com/user-attachments/assets/4fda7ecf-b148-430f-8aeb-b612ce02ad6b" />
* Cars Page
  *   <img width="1895" height="910" alt="8" src="https://github.com/user-attachments/assets/cf764413-f9f3-4ad6-8027-1f7fd0f51ded" />
*   Car Detail Page
  *   <img width="1891" height="909" alt="9" src="https://github.com/user-attachments/assets/c9532ce7-de26-49f2-b1d3-d9fb83db6f1b" />
*   Blog Page
  *   <img width="1892" height="914" alt="10" src="https://github.com/user-attachments/assets/935c78d5-4b38-42ab-8300-3f17165f81d2" />
*   My Blogs Page for the Author
  *   <img width="1891" height="906" alt="11" src="https://github.com/user-attachments/assets/cbacbb40-e352-470e-8a38-04bafe73df2f" />
*   Update Blog Page for Author
  *   <img width="1892" height="912" alt="12" src="https://github.com/user-attachments/assets/78cdae50-4b96-4bb5-8eac-19e5e5782af8" />
*   Admin Dashboard Panel
  *   <img width="1898" height="912" alt="13" src="https://github.com/user-attachments/assets/cc168590-4bb0-4425-ba20-cdddadb6744a" />
*   Admin Statistics Panel (Real Time)
  *   <img width="1902" height="905" alt="14" src="https://github.com/user-attachments/assets/4c376538-c664-46e6-a426-ad4fc2202bba" />
*   Admin Car Panel
  *   <img width="1891" height="904" alt="15" src="https://github.com/user-attachments/assets/ef6005c2-e04f-4438-8b87-0dbeeaea7d23" />
*   Admin Car Price Panel
  *   <img width="1908" height="910" alt="16" src="https://github.com/user-attachments/assets/1b33a619-1b35-4d16-b1a0-491de4c864eb" />
*   Admin Reservation Panel
  *   <img width="1897" height="910" alt="17" src="https://github.com/user-attachments/assets/c3c3258f-73f3-41a8-b31f-8f80f4f60c20" />
*   Admin Blog Panel
  *   <img width="1914" height="915" alt="18" src="https://github.com/user-attachments/assets/936c49a4-f517-468a-a1d0-ad9268fc6e1b" />

---

## ⚙️ Setup & Installation

### **Clone the Repository**

```bash
git clone https://github.com/alpaykuzu/CarBook
```

### **Database Configuration**

* Update the connection string in:

  ```
  CarBook.Persistence/Context/CarBookContext.cs
  ```

### **Apply Migrations**

```powershell
Update-Database
```

### **Run the Project**

1. Start **CarBook.WebApi**
2. Then start **CarBook.WebUI**

---

## 📝 Roadmap & Future Enhancements

* ✅ Redis caching for high‑frequency pricing queries
* ✅ Global exception handling for standardized API responses
* ✅ Unit testing with **xUnit** for Application layer handlers

---

Developed with a strong focus on **enterprise standards**, **scalability**, and **performance** 🚀
