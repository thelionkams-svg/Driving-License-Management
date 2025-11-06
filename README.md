# 🚦 DVLD: Driving & Vehicle License Management System

**Project 1: Comprehensive Driving License Issuance and Administration System**

This project is a robust application designed to manage the entire lifecycle of driver licensing and vehicle administration. The system's primary goal is to ensure compliance with all necessary conditions for road safety and regulatory requirements.

## 🛠️ Technology and Structure

This solution focuses on demonstrating foundational software engineering skills and applying OOP principles:

* **Primary Language:** C#
* **Framework:** .NET Framework (for the application environment)
* **Database:** SQL Server (Applied T-SQL for data management and integrity)
* **Structure:** Structured using **Object-Oriented Programming (OOP)** principles to ensure code modularity and maintainability, separating the UI from the Business Logic.

## ✨ Core Services and Features (Business Logic)

The core **C# Application Logic** handles all business rules, ensuring data integrity and correct processing of requests:

| Service | Description | Logic & Validation |
| :--- | :--- | :--- |
| **New License Issuance** | Manages the initial application for a driving license, checking eligibility against **Minimum Age Requirements** based on the license class. | Validates that the applicant does not already possess the requested class license. |
| **License Renewal** | Processes the renewal of expired licenses. | Requires the applicant to pass a renewed Vision Test (Eye Exam). |
| **Replace Lost/Damaged** | Issues a replacement for a lost or damaged license. | Critical validation: Checks that the license is **not** currently detained. |
| **International License** | Issuance of an International Driving Permit. | Logic ensures the local Class 3 license is valid and active before issuance. |

### 💻 Administration and Data Management Functions

* **People Management:** Full CRUD operations (Create, Read, Update, Delete) for all individuals, strictly enforcing the unique National ID as a key identifier.
* **User & Permissions Management:** Administration of system users, including defining access permissions and account suspension features.
* **License Class Management:** Control over fixed system parameters such as minimum age, validity length, and fees for each license class.
* **Testing Sequence Management:** Enforcing the sequential pass requirement: Vision Test → Theory Test → Practical Test.
* **Audit Logging:** Tracking and recording the details of the specific system User who performed any action.
