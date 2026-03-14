using System;
using Microsoft.Playwright;

namespace Pages;

public class DashboardPage : BasePage
{
  private readonly ILocator _dashboardTitle;
  private readonly ILocator _userDropwdownMenuButton;
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

    _userDropwdownMenuButton = Page.Locator(".oxd-userdropdown");

    _timeAtWorkWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Time at Work" })
                            .Locator("p");

    _myActionsWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "My Actions" })
                            .Locator("p");

    _quickLaunchWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Quick Launch" })
                            .Locator("p");

    _buzzPostsWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Buzz Latest Posts" })
                            .Locator("p");

    _employeesOnLeaveWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Employees on Leave Today" })
                            .Locator("p");

    _employeeDistributionBySubWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Employee Distribution by Sub Unit" })
                            .Locator("p");

    _employeeDistributionByLocationWidget = Page.Locator(".orangehrm-dashboard-widget-name")
                            .Filter(new LocatorFilterOptions { HasText = "Employee Distribution by Location" })
                            .Locator("p");
  }
}
