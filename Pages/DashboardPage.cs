using System;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace Pages;

public class DashboardPage : BasePage
{
    private readonly ILocator _dashboardTitle;
    private readonly ILocator _userDropwdownMenuButton;
    private readonly ILocator _aboutLink;
    private readonly ILocator _supportLink;
    private readonly ILocator _changePasswordLink;
    private readonly ILocator _logoutLink;
    private readonly ILocator _sidePanel;
    private readonly ILocator _helpButton;
    private readonly ILocator _timeAtWorkWidget;
    private readonly ILocator _punchInButton;
    private readonly ILocator _myActionsWidget;
    private readonly ILocator _quickLaunchWidget;
    private readonly ILocator _quickLaunchCard;
    private readonly ILocator _buzzPostsWidget;
    private readonly ILocator _buzzPostCard;
    private readonly ILocator _employeesOnLeaveWidget;
    private readonly ILocator _employeesOnLeaveWidgetConfigurationButton;
    private readonly ILocator _employeesOnLeaveWidgetConfigurationDialog;
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

        _userDropwdownMenuButton = Page.Locator("ul.oxd-dropdown-menu");

        _aboutLink = _userDropwdownMenuButton.Locator(".oxd-userdropdown-link")
                                             .Filter(new() { HasText = "About" });

        _supportLink = _userDropwdownMenuButton.Locator(".oxd-userdropdown-link")
                                               .Filter(new() { HasText = "Support" });

        _changePasswordLink = _userDropwdownMenuButton.Locator(".oxd-userdropdown-link")
                                                      .Filter(new() { HasText = "Change Password" });

        _logoutLink = _userDropwdownMenuButton.Locator(".oxd-userdropdown-link")
                                              .Filter(new() { HasText = "Logout" });

        _sidePanel = Page.GetByRole(AriaRole.Navigation, new() { Name = "Sidepanel" });

        _helpButton = Page.GetByRole(AriaRole.Button)
                          .GetByTitle(new Regex("help", RegexOptions.IgnoreCase));

        _timeAtWorkWidget = Page.Locator(".orangehrm-dashboard-widget")
                                .Filter(new() { HasText = "Time at Work" });

        _punchInButton = _timeAtWorkWidget.GetByRole(AriaRole.Button);

        _myActionsWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "My Actions" });

        _quickLaunchWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Quick Launch" });

        _quickLaunchCard = _quickLaunchWidget.Locator(".orangehrm-quick-launch-card");

        _buzzPostsWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Buzz Latest Posts" });

        _buzzPostCard = _buzzPostsWidget.Locator(".orangehrm-buzz-widget-card");

        _employeesOnLeaveWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employees on Leave Today" });

        _employeesOnLeaveWidgetConfigurationButton = _employeesOnLeaveWidget.Locator(".bi-gear-fill");

        _employeesOnLeaveWidgetConfigurationDialog = Page.Locator(".orangehrm-dialog-modal")
                                                         .Filter(new() { HasText = "Configurations" });

        _employeeDistributionBySubWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employee Distribution by Sub Unit" });

        _employeeDistributionByLocationWidget = Page.Locator(".orangehrm-dashboard-widget")
                               .Filter(new() { HasText = "Employee Distribution by Location" });
    }

    // Verification methods
    public async Task<bool> IsDashboardTitleVisible()
        => await _dashboardTitle.IsVisibleAsync();
    public async Task<bool> IsUserDropdownMenuButtonVisible()
        => await _userDropwdownMenuButton.IsVisibleAsync();

    public async Task<bool> IsSidePanelVisible()
        => await _sidePanel.IsVisibleAsync();

    public async Task<bool> IsTimeAtWorkWidgetVisible()
        => await _timeAtWorkWidget.IsVisibleAsync();

    public async Task<bool> IsMyActionsWidgetVisible()
        => await _myActionsWidget.IsVisibleAsync();

    public async Task<bool> IsQuickLaunchWidgetVisible()
        => await _quickLaunchWidget.IsVisibleAsync();

    public async Task<bool> IsBuzzPostWidgetVisible()
        => await _buzzPostsWidget.IsVisibleAsync();

    public async Task<bool> IsEmployeesOnLeaveWidgetVisible()
        => await _employeesOnLeaveWidget.IsVisibleAsync();

    public async Task<bool> IsEmployeeDistributionBySubUnitWidgetVisible()
        => await _employeeDistributionBySubWidget.IsVisibleAsync();

    public async Task<bool> IsEmployeeDistributionByLocationWidgetVisible()
        => await _employeeDistributionByLocationWidget.IsVisibleAsync();
}