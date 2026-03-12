using System;
using Microsoft.Playwright;

namespace Pages;

public class LoginPage : BasePage
{
  public LoginPage(IPage page) : base(page) { }

  private ILocator UsernameInput => Page.GetByPlaceholder("Username");
  private ILocator PasswordInput => Page.GetByPlaceholder("Password");
  private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
  private ILocator Alert => Page.GetByRole(AriaRole.Alert);
}
