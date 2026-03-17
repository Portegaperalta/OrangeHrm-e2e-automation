using Microsoft.Playwright.Xunit;
using Microsoft.Playwright;
using Pages;

namespace Tests;

public class AuthTests : PageTest
{
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            BaseURL = "https://opensource-demo.orangehrmlive.com",
        };
    }

    [Fact]
    public async Task Login_RedirectsToDashboard_WhenCredentialsAreValid()
    {
        // Arrange
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        var username = "Admin";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
    }

    [Fact]
    public async Task
    Login_DisplaysInvalidCredentialsAlert_WhenPasswordIsInvalid()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "Admin";
        var password = "#wrongPassword999";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.InvalidCredentialsAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysInvalidCredentialsAlert_WhenUsernameIsInvalid()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "invaliduserName";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.InvalidCredentialsAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysRequiredAlert_WhenUsernameIsEmpty()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.RequiredAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysRequiredAlert_WhenPasswordIsEmpty()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "Admin";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.RequiredAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysRequiredAlert_WhenBothFieldsAreEmpty()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.RequiredAlert).ToHaveCountAsync(2);
    }

    [Fact]
    public async Task
    Login_DisplaysRequiredAlert_WhenUsernameIsWhiteSpace()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "   ";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.RequiredAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysRequiredAlert_WhenPasswordIsWhiteSpace()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "Admin";
        var password = "   ";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.RequiredAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysInvalidCredentialsAlert_WhenUsernameIsSqlInjection()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "OR '1'='1";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.InvalidCredentialsAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Login_DisplaysInvalidCredentialsAlert_WhenUsernameIsXssPayload()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var username = "<script>alert('xss')</script>";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
        await Expect(loginPage.InvalidCredentialsAlert).ToBeVisibleAsync();
    }

    [Fact]
    public async Task
    Logout_RedirectsToLoginPage()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        var username = "Admin";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        await dashboardPage.ClickUserDropdownMenuButtonAsync();
        await dashboardPage.ClickLogoutLinkAsync();

        // Assert
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
    }

    [Fact]
    public async Task
    UserStaysOnLoginPage_WhenHasLoggedOut_AndClicksBrowserBackButton()
    {
        // Arrange  
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        var username = "Admin";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.ClickLoginButtonAsync();

        await dashboardPage.ClickUserDropdownMenuButtonAsync();
        await dashboardPage.ClickLogoutLinkAsync();

        // Assert
        await Page.GoBackAsync();
        await Expect(Page).ToHaveURLAsync(loginPage.Url);
    }

    [Fact]
    public async Task Login_RedirectsToDashboard_WhenUserPressEnter()
    {
        // Arrange
        var loginPage = new LoginPage(Page);
        var dashboardPage = new DashboardPage(Page);

        var username = "Admin";
        var password = "admin123";

        // Act
        await loginPage.NavigateToAsync();
        await loginPage.InsertUserNameAsync(username);
        await loginPage.InsertPasswordAsync(password);
        await loginPage.UsernameInput.PressAsync("Enter");

        // Assert
        await Expect(Page).ToHaveURLAsync(dashboardPage.Url);
    }
}