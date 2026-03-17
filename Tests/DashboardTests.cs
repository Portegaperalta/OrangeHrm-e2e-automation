using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

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
}
