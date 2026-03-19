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
}
