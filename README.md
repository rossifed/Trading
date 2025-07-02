# Quantaventis Trading Platform

## Introduction
Quantaventis is a modular monolith trading system designed for the end-to-end trading process of systematic funds, based on EOD (End-Of-Day) price data. It connects to Bloomberg EMSX to route orders and retrieve trade executions. Built with Domain-Driven Design (DDD) principles, it serves as a real-world example of a full trading stack, from booking to execution, risk, and more.

While Quantaventis can be run in production, it requires significant configuration (database, user rights, Azure, Bloomberg, etc.), so it is primarily intended as an educational and reference project. The motivation behind Quantaventis is to provide the kind of example that would have been invaluable to the author in the past, and may help others facing similar challenges.

Target audience: developers, traders, and fund managers seeking a comprehensive, real-world example of a systematic trading system.

## Getting Started

### Prerequisites
- [.NET 8 SDK or above](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- (Optional) [Docker](https://www.docker.com/) for containerized deployment
- (Optional) Azure account and Bloomberg EMSX credentials for full integration

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/quantaventis.git
   cd quantaventis
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the solution (from Visual Studio or CLI):
   ```sh
   dotnet build TradingSolution.sln
   ```
4. Set up the database:
   - Use the provided `SqlScripts/Trading_Schema.sql` to create the required schema in your SQL Server instance.
5. Configure external connections:
   - Update configuration files for Azure Blob Storage, Bloomberg EMSX, etc., as needed for your environment.

### Running
- **From Visual Studio:** Open the solution and run the main web app project.
- **From CLI:**
  ```sh
  dotnet run --project WebApp/Quantaventis.Trading.WebApp
  ```
- **Docker:**
  ```sh
  docker-compose up
  ```
- **Azure:** Publish the app to Azure App Service as you would any ASP.NET Core app.

### API Reference
- The web app exposes a REST API with interactive documentation via Swagger (enabled by default).
- Once running, visit `/swagger` on your deployed instance to explore the API.

## Build and Test

- **Build:**
  ```sh
  dotnet build TradingSolution.sln
  ```
  (Or use Visual Studio's build command)

- **Test:**
  Some domain projects include unit tests. To run available tests:
  ```sh
  dotnet test
  ```
  Note: Test coverage is currently limited; most modules require specific configuration and data.

## Contribute

Contributions are welcome!
- Please open issues for bugs or feature requests.
- Fork the repository and submit a pull request.
- Follow the project's architectural principles: Modular Monolith, Domain-Driven Design (DDD), SOLID, and favor a functional approach where possible.
- For major changes, please open a discussion first to ensure alignment with the project's direction.

## License

This project is licensed under the MIT License.

You are free to use, modify, and distribute this code, but you must always keep the original copyright and attribution.

See the [LICENSE](LICENSE) file for details.

---

© 2024 Federico Rossi (Quantaventis)
