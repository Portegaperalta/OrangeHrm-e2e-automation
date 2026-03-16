using Microsoft.Playwright.Xunit;
using Microsoft.Playwright;
using Pages;
using FluentAssertions;

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
}