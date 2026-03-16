using System;
using Microsoft.Playwright;

namespace Pages;

public class LoginPage : BasePage
{
    public string Url = "/web/index.php/auth/login";
    public readonly ILocator _usernameInput;
    private readonly ILocator _passwordInput;
    private readonly ILocator _loginButton;
    private readonly ILocator _invalidCredentialAlert;
    private readonly ILocator _requiredAlert;

    public LoginPage(IPage page) : base(page)
    {
        _usernameInput = Page.GetByRole(AriaRole.Textbox, new() { Name = "Username" });

        _passwordInput = Page.GetByRole(AriaRole.Textbox, new() { Name = "Password" });

        _loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });

        _invalidCredentialAlert = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Invalid credentials" });

        _requiredAlert = Page.Locator(".oxd-input-field-error-message")
                             .Filter(new() { HasText = "Required" });
    }

    // Interaction methods

    public async Task InsertUserNameAsync(string username) => await _usernameInput.FillAsync(username);

    public async Task InsertPasswordAsync(string password) => await _passwordInput.FillAsync(password);

    public async Task ClickLoginButtonAsync() => await _loginButton.ClickAsync();

    public async Task NavigateToAsync()
    {
        await Page.GotoAsync(Url);
    }
}
