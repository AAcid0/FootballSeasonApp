# 2025 Football Season Management System

A modern web solution developed in response to the **.NET Developer Technical Test** for SIIMED SAS. This project implements a clean architecture using **ASP.NET Core** and **Blazor**, replacing traditional SQL Server persistence with **SQLite** to enhance portability and facilitate local deployment.

## 📋 Project Description

The application manages the sports ecosystem for the 2025 season, handling teams and football players under strict business rules. Unlike a traditional desktop application, this solution offers a reactive web interface that allows for real-time data manipulation and advanced statistical report generation.

## 🛠 Tech Stack

* **Framework:** .NET 8 / ASP.NET Core
* **Frontend:** Blazor (Razor Components)
* **Database:** SQLite (Local file `Temporada2025.db`)
* **ORM:** Entity Framework Core
* **Styles:** Bootstrap / Isolated CSS

## ✅ Key Features

### 1. Team Management
Club administration with integrated business logic validations:
* **Unique Code:** Uniqueness validation for alphabetic codes of exactly 3 characters (e.g., BAR, AME).
* **Categorization:** System restricted to categories A, B, and C.
* **Financial & Historical Data:** Control over the budget and foundation year.

### 2. Player Management
Complete registration of the player roster linked to their respective teams:
* Demographic and sports data (Age, Nationality, Position).
* **Performance Control:** Record of goals scored and injury status for the current season.

### 3. Reports and Data Analytics
An advanced query module was implemented, featuring:

* **Text Analysis:** An algorithm that processes player names to calculate the frequency of the letter "a" and the word count per name.
* **Historical Filters:** Report of teams founded in the first half of the 20th century (1900-1950).
* **Elite Scorers:** Ranking of players with more than 10 goals belonging exclusively to **Category A** teams, ordered by efficacy (descending).
* **Injury Audit:** Filtered list of injured **Goalkeepers** playing in **Category C** teams.

## 🚀 Execution Instructions (Local)

Since the project uses SQLite, no external database server installation is required.

1.  **Clone the repository:**
    ```bash
    git clone <REPOSITORY_URL>
    ```

2.  **Restore dependencies and database:**
    The application uses *Entity Framework Core* with *SQLite*. Upon the first run, migrations should apply automatically. If not, you can force the update:
    ```bash
    dotnet ef database update
    ```

3.  **Run the application:**
    ```bash
    dotnet run
    ```

4.  Open your browser at the indicated address (usually `https://localhost:xxxx`).

---
**Note:** The database will be generated locally as a `.db` file inside the project folder.