# ManetesArtistes - Windows Forms Application

The **ManetesArtistes** Windows Forms application is designed to manage data, statistics, and provide administrative functions for the **ManetesArtistes** Android app. This tool allows educators and administrators to track children's progress, analyze game statistics, and make data-driven decisions to enhance the learning experience.

## Features

- **Data Management**: Manage and organize data from the Android application, including drawing and gameplay records.
- **Statistics and Reports**: View detailed statistics and generate reports based on children's performance in the Simon Says and coloring modes.
- **Admin and Educator Modes**:
  - **Admin Mode**: View logs, manage user data, and control overall application features.
  - **Educator Mode**: Download students creations, organize centers and classes, assign students to groups with customizable stickers, and access educational insights to track progress and plan activities.

## Getting Started

### Prerequisites

- Windows 10 or later
- .NET Framework 4.8 or later
- Visual Studio (recommended for development)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ManetesArtistes/windows-forms.git
   ```

2. **Open the project in Visual Studio**

3. **Build and Run**
   - Open the solution file (`.sln`) in Visual Studio.
   - Before running the application, ensure the .env file is properly configured. Use the .env.example file provided in the project as a reference, as it contains the essential environment variables required for the application to function correctly.
   - Build the project and run the application.

## Usage

- **Admin Mode**: Log in with administrative credentials to configure application settings, manage data, and set up user permissions.
- **Educator Mode**: Log in with educator credentials to track children's progress, view statistics, and generate insights based on the data collected from the Android app.

## Roadmap

- **Enhanced Reporting**: Add more detailed reports and customizable charts for better insights.
- **User Roles**: Add different user roles with varying levels of access and permissions.
- **Integration with FTP Services:**: Enable data synchronization with FTP servers for easier backup and access, ensuring compliance with the non-cloud requirement. Note that configuring the .env file is essential for setting up FTP connections. Use the .env.example file provided in the project as a reference, as it contains the necessary environment variables required for proper functionality.

## Contributing

We welcome contributions from the community. Please follow the steps below to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

If you have any questions or suggestions, feel free to contact us at **148581386+rwxce@users.noreply.github.com**.
