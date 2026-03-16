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
            BaseURL = "https://opensource-demo.orangehrmlive.com/web/index.php",
        };
    }
}