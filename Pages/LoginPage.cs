using System;
using Microsoft.Playwright;

namespace Pages;

public class LoginPage : BasePage
{

  private readonly ILocator _usernameInput;
  private readonly ILocator _passwordInput;
  private readonly ILocator _loginButton;
  private readonly ILocator _invalidCredentialAlert;

  public LoginPage(IPage page) : base(page)
  {
    _usernameInput = Page.GetByPlaceholder("Username");
    _passwordInput = Page.GetByPlaceholder("Password");
    _loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    _invalidCredentialAlert = Page.GetByText("Invalid credentials");
  }

  public async Task InsertUserName(string username) => await _usernameInput.FillAsync(username);

  public async Task InsertPassword(string password) => await _passwordInput.FillAsync(password);

  public async Task ClickLoginButton() => await _loginButton.ClickAsync();
}
