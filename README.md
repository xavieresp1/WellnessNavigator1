# README for WellnessNavigator1 GitHub Repository
## Prerequisites
Before you begin, ensure you have the following installed and configured to your system:
- Git
- Visual Studio
- SQL Server Management Studio

## Installation Steps

### Step 1: Cloning the Repository
1. Open your terminal or command prompt.
2. Navigate to the directory where you want to clone the repository.
3. Run the following command:
   ```
   git clone https://github.com/xavieresp1/WellnessNavigator1
   ```
### Step 2: Opening the Project in Visual Studio
1. Launch Visual Studio.
2. Select `File` -> `Open` -> `Project/Solution`.
3. Navigate to the directory where you cloned the repository.
4. Select the `WellnessNavigator1.sln` file and click `Open`.

### Step 3: Configuring the MySQL Database Connection
1. In the Solution Explorer, find the `appsettings.json` file.
2. Open the file and locate the MySQL database server connection string section.
3. Replace the existing connection string with your MySQL database server connection string.
4. Save the changes.

## Running the Application
After completing the installation and configuration, you can run the application directly from Visual Studio by pressing `F5` or clicking on the `Run` button.

## Database Setup
The Migrations folder of the project should handle most of the database setup. All you need to do is replace the connection string in the appsettings.json folder with the connection string provided by the SQL Server Management Studio after you've initialized a database server. Once you've connected the database server with the project, navigate to the package manager console and run the command "Update-Database", provided by the Entity-Framework Core package library. This should create the Database tables necessary for the project.
