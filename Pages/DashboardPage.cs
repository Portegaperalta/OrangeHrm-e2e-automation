using System;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace Pages;

public class DashboardPage : BasePage
{
    public string Url = "/web/index.php/dashboard/index";
    public ILocator DashboardTitle => _dashboardTitle;
    public ILocator UserDropwdownMenuButton => _userDropwdownMenuButton;
    public ILocator LogoutLink => _logoutLink;
    public ILocator TimeAtWorkWidget => _timeAtWorkWidget;
    public ILocator MyActionsWidget => _myActionsWidget;
    public ILocator QuickLaunchWidget => _quickLaunchWidget;
    public ILocator BuzzPostsWidget => _buzzPostsWidget;
    public ILocator EmployeesOnLeaveWidget => _employeesOnLeaveWidget;
    public ILocator EmployeeDistributionBySubWidget => _employeeDistributionBySubWidget;
    public ILocator EmployeeDistributionByLocationWidget => _employeeDistributionByLocationWidget;

    private readonly ILocator _dashboardTitle;
    private readonly ILocator _userDropwdownMenuButton;
    private readonly ILocator _logoutLink;
    private readonly ILocator _timeAtWorkWidget;
    private readonly ILocator _myActionsWidget;
    private readonly ILocator _quickLaunchWidget;
    private readonly ILocator _buzzPostsWidget;
    private readonly ILocator _employeesOnLeaveWidget;
    private readonly ILocator _employeeDistributionBySubWidget;
    private readonly ILocator _employeeDistributionByLocationWidget;

    public DashboardPage(IPage page) : base(page)
    {
        _dashboardTitle = Page.GetByRole(AriaRole.Heading, new()
        {
            Name = "Dashboard",
            Level = 6
        });

        _userDropwdownMenuButton = Page.Locator("li.oxd-userdropdown");

        _userDropwdownMenuButton = Page.Locator("i.oxd-userdropdown-icon");

        _logoutLink = Page.Locator(".oxd-userdropdown-link")
                          .Filter(new() { HasText = "Logout" });

        _timeAtWorkWidget = Page.Locator(".orangehrm-dashboard-widget")
                                .Filter(new() { HasText = "Time at Work" });

        _myActionsWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "My Actions" });

        _quickLaunchWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Quick Launch" });

        _buzzPostsWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Buzz Latest Posts" });

        _employeesOnLeaveWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employees on Leave Today" });

        _employeeDistributionBySubWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employee Distribution by Sub Unit" });

        _employeeDistributionByLocationWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employee Distribution by Location" });
    }

    // Interaction Methods
    public async Task ClickUserDropdownMenuButtonAsync()
        => await _userDropwdownMenuButton.ClickAsync();

    public async Task ClickLogoutLinkAsync()
        => await _logoutLink.ClickAsync();

    public async Task NavigateToAsync()
        => await Page.GotoAsync(Url);
}