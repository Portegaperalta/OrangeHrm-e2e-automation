# Test Plan: Orange HRM E2E Automation

## 1. Overview

This Test Plan defines the end-to-end automation strategy for the OrangeHRM Human Resource Management (HRM) web app.
It establishes the scope, approach, resources, and tooling to validate that all critical user workflows function correctly.

## 2. Objectives

•	Ensure stability of authentication, HR core, leave management, and reporting flows.

•	Provide maintainable, individual and automated test suites.

•	Validate cross-browser compatibility across Chrome, Firefox, and Edge.


## 3. Test Scope:

### 3.1 In Scope: 

| Module | Flows to Automate | Priority |
|--------|-------------------|----------|
| Authentication | Login , logout | P0 – Critical |
| Dashboard | Widget visibility, navigation links| P1 – High |
| PIM / Employee Management | Add, edit, delete, search employee| P0 – Critical |
| Admin – User Management | Create, edit, delete user; assign roles; reset password | P0 – Critical |

### 3.2 Out of Scope: 
*   **Attendance, Reports, and Leave Management modules**.

*   **Mobile application testing**.

*   **API performance load testing**.

*   **Security penetration testing**.

*   **Database-level data integrity testing**.

# 4. Test Strategy
### This plan primary focus is to cover the E2E UI Tests layer.

### 4.1 Automation Approach
*   **Tech Stack:** C# (.NET 10), Playwright (HTTP Client), and xUnit (Test Runner).
*   **Assertions:** Utilizing Playwright built-in assertions / FluentAssertions for human-readable, expressive validation logic.
  
*   **Design Pattern:** Page Object Model (POM).

### 3.3 Tooling and Infrastructure

*   **Version Control:** Git/GitHub for source code management.
*   **CI/CD Pipeline:** **GitHub Actions** to execute the full suite on every `push` and `pull_request` to the main branch.
*   **Reporting:** Allure Report

## 5. Test Deliverables
*   **Automated Test Suite:** C# source code located in the `/Tests` directory.
*   **Test Cases:** List of test cases located int the `/Docs` directory.
*   **Execution Reports:** Auto-generated Allure reports located in the `/Reports` directory.
