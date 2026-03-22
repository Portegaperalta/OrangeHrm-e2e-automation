# OrangeHRM E2E PIM / Employee Management Test Cases

### TC-PIM-001: Add Employee with Minimum Required Fields
* **Priority**: P0 – Critical
* **Status**: Passed 🟢
* **Type**: Happy Path
* **Preconditions**:
  - Admin is logged in.
  - No employee with the test name already exists.
  
* **Steps:**
1. Navigate to **PIM > Add Employee**
2. Enter First Name: `OrangeHrm`
3. Enter Last Name: `TestUser`
4. Note the auto-generated Employee ID
5. Click **Save**

**Expected Result:** Employee profile page opens. Submitted employee details are shown. 

---

### TC-PIM-002: Add Employee with All Fields and Login Details
* **Priority**: P1 – High
* **Status**: Passed 🟢
* **Type**: Happy Path
* **Preconditions**:
  - Admin is logged in.
  - No employee with the test name already exists.
  
* **Steps:**
1. Navigate to **PIM > Add Employee**
2. Enter First Name, Middle Name, Last Name
3. Set a unique Employee ID
4. Toggle **Create Login Details**
5. Set Status: `Enabled`
6. Enter Username: `OrangeHrmTestUsername` and password `orangeHrm123`
7. Click **Save**

**Expected Result:** Employee is created successfully and login details saved. 
New user appears in **Admin > User Management** with the given username.

---

### TC-PIM-003: Add Employee with Duplicate Employee ID
* **Priority**: P1 – High
* **Status**: Passed 🟢
* **Type**: Negative / Edge Case
* **Preconditions**:
  - Admin is logged in.
  - An employee with a known Employee ID exists.
  
* **Steps:**
1. Navigate to **PIM > Add Employee**
2. Enter any First and Last Name
3. Clear the auto-generated ID and enter an existing employee's ID
4. Click **Save**

**Expected Result:** Inline warning `"Employee Id already exists"` is shown. No new employee record is created.

---

### TC-PIM-004: Add Employee with Empty First Name
* **Priority**: P1 – High
* **Status**: Passed 🟢
* **Type**: Negative / Validation
* **Preconditions**:
  - Admin is logged in an on the Add employee page.
  
* **Steps:**
1. Leave the **First Name** field blank
2. Enter Last Name: `TestOnly`
3. Click **Save**

**Expected Result:** Inline warning `"Required"` appears under the First Name field. Employee is not created.

---

### TC-PIM-005: Add Employee with Whitespace-Only Name
* **Priority**: P1 – High
* **Status**: Passed 🟢
* **Type**: Edge Case
* **Preconditions**:
  - Admin is logged in an on the Add employee page.
  
* **Steps:**
1. Enter First Name: `   ` 
2. Enter Last Name: `   ` 
3. Click **Save**

**Expected Result:** Inline warning `"Required"` appears under the first and last name fields. Employee is not created.

---

### TC-PIM-006: Add Employee with Special Characters in Name
* **Priority**: P2 – Medium
* **Status**: Passed 🟢
* **Type**: Edge Case / Boundary
* **Preconditions**:
  - Admin is logged in an on the Add employee page.
  
* **Steps:**
1. Enter First Name: `O'Brian-García`
2. Enter Last Name: `St. James`
3. Click **Save**

**Expected Result:** Employee is saved successfully. Name with special characters is stored and displayed correctly.

---

### TC-PIM-007: Search Employee by Full Name
* **Priority**: P0 – Critical
* **Status**: Not Run
* **Type**: Happy Path
* **Preconditions**:
  - Admin is logged in an on the Add employee page.
  - At least one employee with a known name exists.
  
* **Steps:**
1. Enter First Name: `OrangeHrm`
2. Enter Last Name: `TestUser`
3. Click **Save**
4. Navigate to **PIM > Employee List**
5. Enter the known employee's first and last name in the search fields
6. Click **Search**

**Expected Result:** The matching employee appears in the results

---

### TC-PIM-008: Search Employee by Employee ID
* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Happy Path
* **Preconditions**:
  - Admin is logged in an on the Add employee page.
  - At least one employee with a known a known ID exists.
  
* **Steps:**
1. Enter First Name: `OrangeHrm`
2. Enter Last Name: `TestUser`
3. Click **Save**
4. Note Emplyee auto-generated ID
5. Navigate to **PIM > Employee List**
6. Enter the known ID in the **Employee Id** field
7. Click **Search**

**Expected Result:** Exactly one result is returned matching that Employee ID.

---

### TC-PIM-009: Search Returns No Results when Credentials Don't Exist
* **Priority**: P1 – High
* **Status**: Not Run
* **Type**: Negative
* **Preconditions**:
  - Admin is logged in an on the Employee List Page.
  
* **Steps:**
1. Enter a name that does not exist: `##DOESNOTEXIST!`
2. Click **Search**

**Expected Result:** The results table shows `"No Records Found"`. Row count is 0.

---

### TC-PIM-010: Edit Employee Personal Information
* **Priority**: P0 – Critical
* **Status**: Not Run
* **Type**: Happy Path
* **Preconditions**:
  - Admin is logged in an on the Employee List Page.
  - An employee record exists
  
* **Steps:**
1. Enter First Name: `OrangeHrm`
2. Enter Last Name: `TestUser`
3. Click **Save**
4. Navigate to **PIM > Employee List**
5. Search for the target employee and click the pen icon (edit profile button).
6. Change the **Nationality** to a new value
7. Click **Save**

**Expected Result:** Success toast appears. Refreshing the page confirms the new Nationality value is persisted.
