using System;
using Microsoft.Playwright;

namespace Pages;

public class DashboardPage : BasePage
{
  private readonly ILocator _dashboardTitle;
  private readonly ILocator _userDropwdownMenuButton;
  private readonly ILocator _sidePanel;
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

    _sidePanel = Page.GetByRole(AriaRole.Navigation, new() { Name = "Sidepanel" });

    _timeAtWorkWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Time at Work" });

    _myActionsWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "My Actions" });

    _quickLaunchWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Quick Launch" });

    _buzzPostsWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Buzz Latest Posts" });

    _employeesOnLeaveWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Employees on Leave Today" });

    _employeeDistributionBySubWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Employee Distribution by Sub Unit" });

    _employeeDistributionByLocationWidget = Page.GetByRole(AriaRole.Paragraph, new() { Name = "Employee Distribution by Location" });
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