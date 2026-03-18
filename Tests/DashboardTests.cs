using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;
using Pages;

namespace Tests;

public class DashboardTests : PageTest
{
  public override BrowserNewContextOptions ContextOptions()
  {
    return new BrowserNewContextOptions
    {
      BaseURL = "https://opensource-demo.orangehrmlive.com",
    };
  }

  [Fact]
  public async Task Dashboard_LoadsAfterLogin()
  {
    // Arrange
    var loginPage = new LoginPage(Page);
    var dashboardPage = new DashboardPage(Page);
    var sidebar = new Sidebar(Page);

    var username = "Admin";
    var password = "admin123";

    // Act
    await loginPage.NavigateToAsync();
    await loginPage.InsertUserNameAsync(username);
    await loginPage.InsertPasswordAsync(password);
    await loginPage.ClickLoginButtonAsync();

    // Assert
    await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
    await Expect(dashboardPage.DashboardTitle).ToBeVisibleAsync();
    await Expect(dashboardPage.DashboardTitle).ToHaveTextAsync("Dashboard");
    await Expect(sidebar.SidebarContainer).ToBeVisibleAsync();
  }
}
