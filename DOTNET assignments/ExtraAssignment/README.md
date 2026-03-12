# HolisticHealth Microservices Project

This project consists of three microservices designed to help users track their health and wellness. 

## Architecture Overview

1.  **IdentityService**: 
    - **Database**: MongoDB
    - **Responsibilities**: User registration, login, and JWT token generation.
    - **Tech Stack**: ASP.NET Core Web API, MongoDB.Driver, JWT Bearer Authentication.

2.  **HealthTrackerService**:
    - **Database**: SQL Server (EF Core)
    - **Responsibilities**: Tracking physical activities, daily meals, and mental wellness (mood).
    - **Tech Stack**: ASP.NET Core Web API, Entity Framework Core (SQL Server), JWT Bearer Authentication.

3.  **GoalService**:
    - **Database**: In-Memory (for now)
    - **Responsibilities**: Setting and tracking long-term health goals (weight, distance, steps) and providing motivation.
    - **Tech Stack**: ASP.NET Core Web API, JWT Bearer Authentication.

## Endpoints (14 Total)

### IdentityService
- `POST /api/auth/register`: Register a new user.
- `POST /api/auth/login`: Authenticate and receive a JWT token.

### HealthTrackerService (*Requires JWT*)
- `GET /api/activity`: Retrieve all activities.
- `GET /api/activity/{id}`: Get activity details.
- `POST /api/activity`: Log a new activity.
- `GET /api/diet`: Get logged meals.
- `POST /api/diet`: Log a new meal.
- `GET /api/wellness/mood`: Get mood history.
- `POST /api/wellness/mood`: Log current mood.
- `GET /api/wellness/summary`: Holistic daily summary.

### GoalService (*Requires JWT*)
- `GET /api/goals`: List all user goals.
- `POST /api/goals`: Create a new personal goal.
- `PUT /api/goals/{id}/progress`: Update progress towards a specific goal.
- `GET /api/motivation/quote`: Get an inspirational health quote.

## Setup Instructions

### Prerequisites
- .NET 9 SDK
- MongoDB running locally at `mongodb://localhost:27017`
- SQL Server LocalDB

### Running the Services (Automated Swagger Launch)
To have Swagger open automatically for all services:
1. Open this folder in **VS Code**.
2. Press `Ctrl+Shift+D` to open the **Run and Debug** view.
3. Select **"Launch All Microservices"** from the dropdown at the top.
4. Press `F5`.

This will build and run all 3 services, and your browser will automatically open 3 tabs with their respective Swagger UIs.
