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

    //Act
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
          .ToHaveTextAsync($"{employeeFirstName} {employeeLastName}",
          new() { Timeout = 10000 });

    await Expect(pimEmployeePersonalDetailsPage.EmployeeFirstNameInput)
          .ToHaveValueAsync(employeeFirstName);

    await Expect(pimEmployeePersonalDetailsPage.EmployeeLastNameInput)
          .ToHaveValueAsync(employeeLastName);
  }
}
