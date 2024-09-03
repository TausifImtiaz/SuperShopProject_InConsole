# SuperShop Console Application

## Overview

The **SuperShop Console Application** is a .NET Framework-based console application designed to manage a virtual shop. It utilizes the repository pattern to handle CRUD operations efficiently and stores data in XML files. This project demonstrates how to implement a repository pattern in a console environment for data management and persistence.

## Features

- **Repository Pattern:** Implements the repository pattern for data access, ensuring a clean separation of concerns and easier maintenance.
- **CRUD Operations:** Supports Create, Read, Update, and Delete operations on shop data.
- **XML Data Storage:** Uses XML files for data storage, providing a lightweight and easily accessible format.
- **Console Interface:** Provides a command-line interface for interacting with the application.

## Technologies Used

- .NET Framework
- C#
- XML for Data Storage
- Console Application

## Project Structure

- **Repositories:** Contains classes implementing the repository pattern for data access.
- **Models:** Defines the data structures used in the application.
- **Data Storage:** XML files used for persisting data.
- **Console Application:** Main application logic and user interface via the console.

## Getting Started

### Prerequisites

- .NET Framework (version compatible with your project)
- Visual Studio 2019 or later

### Cloning the Repository

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/TausifImtiaz/SuperShopProject_InConsole.git
   ```

### Installation

1. **Open the Solution:**
   Open the `.sln` file in Visual Studio or your preferred IDE.

2. **Restore NuGet Packages:**
   Ensure all required NuGet packages are restored by building the solution or using the NuGet Package Manager.

3. **Inspect XML Files:**
   - Locate the XML files in the `DataStorage` folder.
   - Review or modify the XML files if necessary to fit your data requirements.

### Running the Application

1. **Build and Run:**
   Press `F5` or use the command line to run the application:
   ```bash
   dotnet run
   ```

2. **Using the Application:**
   - Follow the on-screen prompts to interact with the application.
   - Perform CRUD operations by entering commands as instructed by the console interface.

## Usage

1. **CRUD Operations:**
   - **Create:** Add new items to the shop inventory.
   - **Read:** View existing items and their details.
   - **Update:** Modify item details as needed.
   - **Delete:** Remove items from the inventory.

2. **Data Management:**
   - The data is stored in XML files located in the `DataStorage` folder.
   - Changes made through the console application are reflected in these XML files.

## Contributing

Contributions are welcome! To contribute:
- Fork the repository.
- Create a feature branch.
- Commit your changes.
- Push to the branch.
- Open a pull request with a description of your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- .NET Framework documentation
- Repository pattern resources
- XML data storage references

## Contact

For any questions or support, please contact [Tausif Imtiaz](mailto:tausifimtiaz@gmail.com).
