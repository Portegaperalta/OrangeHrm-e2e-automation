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
    await loginPage.LoginAsync(username, password);

    // Assert
    await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
    await Expect(dashboardPage.DashboardTitle).ToBeVisibleAsync();
    await Expect(dashboardPage.DashboardTitle).ToHaveTextAsync("Dashboard");
    await Expect(sidebar.SidebarContainer).ToBeVisibleAsync();
  }

  [Fact]
  public async Task SidebarNavigationItems_AreVisible()
  {
    // Arrange
    var loginPage = new LoginPage(Page);
    var dashboardPage = new DashboardPage(Page);
    var sidebar = new Sidebar(Page);

    var username = "Admin";
    var password = "admin123";

    // Act
    await loginPage.NavigateToAsync();
    await loginPage.LoginAsync(username, password);

    // Assert
    await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
    await Expect(sidebar.AdminLink).ToBeVisibleAsync();
    await Expect(sidebar.PimLink).ToBeVisibleAsync();
    await Expect(sidebar.RecruitmentLink).ToBeVisibleAsync();
  }

  [Fact]
  public async Task SidebarNavigationItems_NavigateToCorrectModule()
  {
    // Arrange
    var loginPage = new LoginPage(Page);
    var dashboardPage = new DashboardPage(Page);
    var pimEmployeePage = new PimEmployeeListPage(Page);
    var adminUsersPage = new AdminViewUsersPage(Page);
    var recruitmentPage = new RecruitmentCandidatesPage(Page);
    var sidebar = new Sidebar(Page);

    var username = "Admin";
    var password = "admin123";

    // Act + Assert
    await loginPage.NavigateToAsync();
    await loginPage.LoginAsync(username, password);

    await Expect(Page).ToHaveURLAsync(dashboardPage.Url);

    await sidebar.ClickPimLinkAsync();
    await Expect(Page).ToHaveURLAsync(pimEmployeePage.Url);
    await Expect(pimEmployeePage.PimTitle).ToBeVisibleAsync();
    await Page.GoBackAsync();

    await sidebar.ClickAdminLinkAsync();
    await Expect(Page).ToHaveURLAsync(adminUsersPage.Url);
    await Expect(adminUsersPage.AdminTitle).ToBeVisibleAsync();
    await Page.GoBackAsync();

    await sidebar.RecruitmentLink.ClickAsync();
    await Expect(Page).ToHaveURLAsync(recruitmentPage.Url);
    await Expect(recruitmentPage.CandidatesTitle).ToBeVisibleAsync();
    await Page.GoBackAsync();
  }
}
