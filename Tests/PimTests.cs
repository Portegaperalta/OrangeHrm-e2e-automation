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

      [Fact]
      public async Task AddEmployee_ShowsRequiredWarning_WhenFirstNameIsEmpty()
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

            await pimAddEmployeePage.InsertEmployeeLastNameAsync(employeeLastName);
            await pimAddEmployeePage.ClickSaveButtonAsync();

            //Assert
            await Expect(Page).ToHaveURLAsync(pimAddEmployeePage.Url);
            await Expect(pimAddEmployeePage.RequiredFieldWarning).ToBeVisibleAsync();
      }
}
