# 🛒 SimpleECommerceAPI

A secure and clean .NET Web API for a simple e-commerce backend, including products, user authentication, and order management. Built with C# and ASP.NET Core.

---

## ✨ Features

- 🔐 JWT Authentication (Register & Login)
- 👤 Role-based access (Admin / User)
- 📦 Product CRUD (Protected)
- 🛒 Checkout API with Order History
- 🔐 Swagger UI with JWT token support
- 💾 Entity Framework Core + SQL Server

---

## 📂 Project Structure
SimpleECommerceAPI/
│
├── Controllers/
│ ├── AuthController.cs
│ ├── ProductController.cs
│ └── CartController.cs
│
├── Data/
│ └── AppDbContext.cs
│
├── Models/
│ ├── Product.cs
│ ├── User.cs
│ ├── Order.cs
│ └── OrderItem.cs
│
├── DTOs/
│ ├── RegisterDto.cs
│ └── LoginDto.cs
│
├── Program.cs
└── appsettings.json

---

## 🚀 How to Run the Project

1. **Clone the repo**
   ```bash
   git clone https://github.com/Elham7899/SimpleECommerceAPI.git
   cd SimpleECommerceAPI

2. Set up the database
Configure connection string in appsettings.json
Run migrations (if added) or let EF create tables

3. Run the app
Open in Visual Studio
Press F5 or run dotnet run

4. Test in Swagger
Visit: https://localhost:{port}/swagger

## 🛠 Tech Stack
C# / ASP.NET Core 8

Entity Framework Core

SQL Server / SQLite

JWT Authentication

Swagger UI

BCrypt password hashing

📄 License
MIT — free to use, modify, and share.

## 👤 Author
Elham7899
GitHub: github.com/Elham7899

If you like this project, give it a ⭐ on GitHub!

