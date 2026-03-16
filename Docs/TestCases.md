# Test Cases: OrangeHRM E2E Automation

**Coverage:** Authentication, PIM, Admin User Management, Recruitment, Leave Management, Time & Attendance

## TC-AUTH — Authentication

---

### TC-AUTH-001: Valid Admin Login
* **Priority**: P0 – Critical
* **Type**: Happy Path
* **Preconditions**:  1) App is accessible 2) Credentials `Admin / admin123` exist.
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `Admin`
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** User is redirected to `/web/index.php/dashboard/index`. 

---

### TC-AUTH-002: Login with Wrong Password
* **Priority**: P0 – Critical
* **Type**: Negative
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `Admin`
3. Enter password: `#wrongPassword999`
4. Click **Login**

**Expected Result:** Error message `"Invalid credentials"` is displayed. User stays on login page.

---

### TC-AUTH-003: Login with Wrong Username
* **Priority**: P0 – Critical
* **Type**: Negative
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `invaliduserName`
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** Error message `"Invalid credentials"` is displayed. User stays on login page.

---

### TC-AUTH-004: Login with empty username
* **Priority**: P1 – High
* **Type**: Negative
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Leave **Username** input field empty
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** Error message `"Required"` is displayed. Form is not submitted.

--- 

### TC-AUTH-005: Login with empty password
* **Priority**: P1 – High
* **Type**: Negative
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `Admin`
3. Leave **Password** input field empty
4. Click **Login**

**Expected Result:** Error message `"Required"` is displayed. Form is not submitted.

---

### TC-AUTH-006: Login with both fields empty
* **Priority**: P1 – High
* **Type**: Negative
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Leave **Username** input field empty
3. Leave **Password** input field empty
4. Click **Login**

**Expected Result:** Error message `"Required"` is displayed in both fields. Form is not submitted.

---

### TC-AUTH-007: Login with white space username
* **Priority**: P1 – High
* **Type**: Edge case
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `   ` 
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** Error message `"Required"` is displayed in username field. Form is not submitted.

---

### TC-AUTH-008: Login with white space password
* **Priority**: P1 – High
* **Type**: Edge case
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `Admin` 
3. Enter password: `   `
4. Click **Login**

**Expected Result:** Error message `"Required"` is displayed in password field. Form is not submitted.

---

### TC-AUTH-009: Login with SQL injection in username
* **Priority**: P1 – High
* **Type**: Edge case / Security
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `' OR '1'='1` 
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** Error message `"Invalid credentials"` is displayed in password field. User stays on login page.

---

### TC-AUTH-010: Login with XSS Payload in Username
* **Priority**: P1 – High
* **Type**: Edge case / Security
* **Preconditions**:  1) App is accessible
* **Steps:**
1. Navigate to `https://opensource-demo.orangehrmlive.com/web/index.php/auth/login`
2. Enter username: `'<script>alert('xss')</script>` 
3. Enter password: `admin123`
4. Click **Login**

**Expected Result:** Error message `"Invalid credentials"` is displayed in password field. User stays on login page.
