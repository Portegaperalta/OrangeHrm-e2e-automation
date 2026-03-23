using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Pages;

namespace Tests;

public class PimTests : PageTest
{
      public override BrowserNewContextOptions ContextOptions()
      {
            return new BrowserNewContextOptions
            {
                  BaseURL = "https://opensource-demo.orangehrmlive.com",
            };
      }

      [Fact]
      public async Task
      AddEmployee_CreatesEmployee_WhenRequiredMinimumFieldsAreFilled()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimEmployeePersonalDetailsPage = new PimEmployeePersonalDetailsPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "OrangeHrm";
            var employeeLastName = "TestUser";
            var employeeFullName = $"{employeeFirstName} {employeeLastName}";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);
            await sidebar.ClickPimLinkAsync();

            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);

            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            // Assert
            await Expect(pimEmployeePersonalDetailsPage.EmployeeNameTitle)
                  .ToHaveTextAsync(employeeFullName, new() { Timeout = 10000 });

            await Expect(pimEmployeePersonalDetailsPage.EmployeeFirstNameInput)
                  .ToHaveValueAsync(employeeFirstName);

            await Expect(pimEmployeePersonalDetailsPage.EmployeeLastNameInput)
                  .ToHaveValueAsync(employeeLastName);
      }

      [Fact]
      public async Task AddEmployee_CreatesEmployee_WhenAllFieldsAreFilled()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimEmployeePersonalDetailsPage = new PimEmployeePersonalDetailsPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "Orange";
            var employeeMiddleName = "Hrm";
            var employeeLastName = "TestUser";
            var employeeFullName = $"{employeeFirstName} {employeeLastName}";
            var employeeUsername = "OrangeHrmTestUsername";
            var employeePassword = "orangeHrm123";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);

            await sidebar.ClickPimLinkAsync();
            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);

            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeMiddleNameAsync(employeeMiddleName);
            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);

            await pimAddEmployeePage.ToggleLoginDetailsAsync();
            await pimAddEmployeePage.InsertEmployeeUsernameAsync(employeeUsername);
            await pimAddEmployeePage.InsertEmployeePasswordAsync(employeePassword);
            await pimAddEmployeePage.ConfirmEmployeePasswordAsync(employeePassword);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            // Assert
            await Expect(pimEmployeePersonalDetailsPage.EmployeeNameTitle)
                  .ToHaveTextAsync(employeeFullName, new() { Timeout = 10000 });

            await Expect(pimEmployeePersonalDetailsPage.EmployeeFirstNameInput)
                  .ToHaveValueAsync(employeeFirstName);

            await Expect(pimEmployeePersonalDetailsPage.EmployeeMiddleNameInput)
                  .ToHaveValueAsync(employeeMiddleName);

            await Expect(pimEmployeePersonalDetailsPage.EmployeeLastNameInput)
                  .ToHaveValueAsync(employeeLastName);
      }

      [Fact]
      public async Task
      AddEmployee_ShowsDuplicatedIdWarning_WhenCreatingUserWithDuplicateId()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "Orange";
            var employeeMiddleName = "Hrm";
            var existingId = "0259";

            //Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);

            await sidebar.ClickPimLinkAsync();
            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);

            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeMiddleNameAsync(employeeMiddleName);
            await pimAddEmployeePage.ClearEmployeeIdInputAsnyc();
            await pimAddEmployeePage.InsertEmployeeIdAsync(existingId);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            //Assert
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);
            await Expect(pimAddEmployeePage.DuplicatedEmployeeIdWarning).ToBeVisibleAsync();
      }

      [Theory]
      [InlineData(null)]
      [InlineData("   ")]
      public async Task
            AddEmployee_ShowsRequiredWarning_WhenFirstNameIsNullOrEmpty(string? firstName)
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeLastName = "TestOnly";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);

            await sidebar.ClickPimLinkAsync();
            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);

            if (firstName != null)
                  await pimAddEmployeePage.InsertEmployeeFirstNameAsync(firstName);

            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            //Assert
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);
            await Expect(pimAddEmployeePage.RequiredFieldWarning).ToBeVisibleAsync();
      }

      [Fact]
      public async Task
      AddEmployee_CreatesEmployee_WhenNameHasSpecialCharacters()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimEmployeePersonalDetailsPage = new PimEmployeePersonalDetailsPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "O'Brian-García";
            var employeeLastName = "St. James";
            var employeeFullName = $"{employeeFirstName} {employeeLastName}";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);
            await sidebar.ClickPimLinkAsync();

            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);

            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            // Assert
            await Expect(pimEmployeePersonalDetailsPage.EmployeeNameTitle)
                  .ToHaveTextAsync(employeeFullName, new() { Timeout = 10000 });

            await Expect(pimEmployeePersonalDetailsPage.EmployeeFirstNameInput)
                  .ToHaveValueAsync(employeeFirstName);

            await Expect(pimEmployeePersonalDetailsPage.EmployeeLastNameInput)
                  .ToHaveValueAsync(employeeLastName);
      }

      [Fact]
      public async Task SearchEmployee_FindsEmployee_ByFullName()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "OrangeHrm";
            var employeeLastName = "TestUser";
            var employeeFullName = $"{employeeFirstName} {employeeLastName}";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);
            await sidebar.ClickPimLinkAsync();

            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            await sidebar.ClickPimLinkAsync();
            await pimEmployeesListPage.ClickSearchDropdownButtonAsync();
            await pimEmployeesListPage.InsertEmployeeNameAsync(employeeFullName);
            await pimEmployeesListPage.ClickSearchEmployeeButtonAsync();
            var employeeCard = pimEmployeesListPage.GetEmployeeCardByUsername(employeeFullName);

            //Assert
            await Expect(employeeCard).ToBeVisibleAsync();
      }

      [Fact]
      public async Task SearchEmployee_FindsEmployee_ById()
      {
            // Arrange
            var loginPage = new LoginPage(Page);
            var sidebar = new Sidebar(Page);
            var pimEmployeesListPage = new PimEmployeeListPage(Page);
            var pimAddEmployeePage = new PimAddEmployeePage(Page);

            var loginUsername = "Admin";
            var loginPassword = "admin123";
            var employeeFirstName = "OrangeHrm";
            var employeeLastName = "TestUser";

            // Act
            await loginPage.NavigateToAsync();
            await loginPage.LoginAsync(loginUsername, loginPassword);
            await sidebar.ClickPimLinkAsync();

            await pimEmployeesListPage.ClickAddEmployeeButtonAsync();
            await pimAddEmployeePage.InsertEmployeeFirstNameAsync(employeeFirstName);
            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            var employeeId = await pimAddEmployeePage.EmployeeIdInput.InputValueAsync();
            await pimAddEmployeePage.ClickSaveButtonAsync();

            await sidebar.ClickPimLinkAsync();
            await pimEmployeesListPage.ClickSearchDropdownButtonAsync();
            await pimEmployeesListPage.InsertEmployeeIdAsync(employeeId);
            await pimEmployeesListPage.ClickSearchEmployeeButtonAsync();
            var employeeCard = pimEmployeesListPage.GetEmployeeCardById(employeeId);

            //Assert
            await Expect(employeeCard).ToBeVisibleAsync();
      }
}
