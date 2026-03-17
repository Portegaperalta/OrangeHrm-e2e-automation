# OrangeHRM E2E Dashboard Test Cases

### TC-DASH-001: Dashboard loads after login
* **Priority**: P0 – Critical
* **Status**: Not Run
* **Type**: Happy Path
* **Preconditions**: Valid Admin credentials are available.
* **Steps:**
1. Log in with Credentials `Admin / admin123`

**Expected Result:** Dashboard page loads without errors. The page title is `"Dashboard"` The sidebar and top navigation bar are fully rendered.

---

### TC-DASH-002: All Sidebar Navigation Items Are Visible

* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Functional
* **Preconditions**: 1) Admin is logged in 2) Dashboard is loaded
* **Steps:**
1. Observe the left sidebar

**Expected Result:** The following items are visible and enabled:
Admin, PIM, Leave, Time, Recruitment, My Info, Performance, Dashboard, Directory, Maintenance, Buzz.

---

### TC-DASH-003: Sidebar Item Navigates to Correct Module

* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Functional
* **Preconditions**: 1) Admin is logged in 2) Dashboard is loaded
**Steps:**
1. Click **PIM** in the sidebar and verify URL and page heading
2. Navigate back to Dashboard
3. Repeat for **Admin**, **Recruitment**, **Time**, **Leave**.
4. Navigate back to Dashboard

**Expected Result:**
Each sidebar item navigates to its correct module page, URLs match expected routes and page headings are correct.

---

### TC-DASH-004: Dashboard Widgets Are Displayed

* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Functional
* **Preconditions**: 1) Admin is logged in 2) Dashboard is loaded
  
**Steps:**
1. Navigate to the Dashboard
2. Observe the widget area

**Expected Result:**
At least the following widgets are visible: 
**Time at Work**, **My Actions**, **Quick Launch**, **Buzz Latest Posts**, **Employees On Leave**, **Employee Distribution by Sub Unit**, 
**Employee Distribution by Location**

### TC-DASH-005: Quick Launch — Assign Leave

* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Functional
* **Preconditions**: 1) Admin is logged in 2) Dashboard is loaded
  
**Steps:**
1. Locate the **Quick Launch** link inside the **Quick Launch** widget.
2. Click **Assign Leave**

**Expected Result:** User is navigated to the Assign Leave page under the Leave module.
