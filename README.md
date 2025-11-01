# UdemyNewMicroservice

A modern microservices-based application built with .NET 9, implementing various microservices for e-commerce functionality.

## Project Structure

The solution consists of the following microservices:

- **Catalog API**: Manages product catalog and categories
- **Basket API**: Handles shopping cart operations
- **Order API**: Processes and manages orders
  - Order.Domain: Contains domain entities and business logic
  - Order.Application: Application layer with business rules
  - Order.Persistence: Data persistence layer
- **Discount API**: Manages discount and promotion operations
- **File API**: Handles file upload and management operations
- **Shared Library**: Common utilities and shared components

## Technical Stack

- **.NET 9**
- **C# 13**
- **Entity Framework Core**
- **MediatR** for CQRS pattern
- **MassTransit** for message queuing
- **ASP.NET Core Web API**
- **API Versioning**

## Features

- Microservices Architecture
- CQRS Pattern Implementation
- REST API with versioning
- Global Exception Handling
- Identity and Authorization
- File Upload Capabilities
- Shopping Cart Management
- Order Processing
- Discount Management
- Product Catalog Management

## Getting Started

### Prerequisites

- .NET 9 SDK
- Your preferred IDE (Visual Studio 2022 or later recommended)
- Docker (optional for containerization)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/fatihdemirtc/UdemyNewMicroservice.git
```

2. Navigate to the solution directory:
```bash
cd UdemyNewMicroservice
```

3. Build the solution:
```bash
dotnet build
```

4. Run the microservices:
```bash
dotnet run --project ./UdemyNewMicroservice.Catalog.API
dotnet run --project ./UdemyNewMicroservice.Basket.API
dotnet run --project ./UdemyNewMicroservice.Order.Api
dotnet run --project ./UdemyNewMicroservice.Discount.API
dotnet run --project ./UdemyNewMicroservice.File.API
```

## API Documentation

Each microservice exposes its own API endpoints:

- Catalog API: `/api/v{version}/categories`, `/api/v{version}/products`
- Basket API: `/api/v{version}/basket`
- Order API: `/api/v{version}/orders`
- Discount API: `/api/v{version}/discounts`
- File API: `/api/v{version}/files`

## Security

The application implements authentication and authorization using Identity Service. API endpoints can be protected using the `.RequireAuthorization()` middleware.

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Built as part of Udemy course curriculum
- Using modern .NET microservices architecture
- Implementing industry best practices and patterns