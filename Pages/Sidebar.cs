using System;
using Microsoft.Playwright;

namespace Pages;

public class Sidebar : BasePage
{
  public string Url = "/web/index.php/dashboard/index";
  public ILocator AdminLink => _adminLink;
  public ILocator PimLink => _pimLink;
  public ILocator LeaveLink => _leaveLink;
  public ILocator TimeLink => _timeLink;
  public ILocator RecruitmentLink => _recruitmentLink;
  public ILocator MyInfoLink => _myInfoLink;
  public ILocator PerformanceLink => _performanceLink;
  public ILocator DashboardLink => _dashboardLink;
  public ILocator DirectoryLink => _directoryLink;
  public ILocator MaintenanceLink => _maintenanceLink;
  public ILocator ClaimLink => _claimLink;
  public ILocator BuzzLink => _buzzLink;

  private readonly ILocator _sidebarContainer;
  private readonly ILocator _adminLink;
  private readonly ILocator _pimLink;
  private readonly ILocator _leaveLink;
  private readonly ILocator _timeLink;
  private readonly ILocator _recruitmentLink;
  private readonly ILocator _myInfoLink;
  private readonly ILocator _performanceLink;
  private readonly ILocator _dashboardLink;
  private readonly ILocator _directoryLink;
  private readonly ILocator _maintenanceLink;
  private readonly ILocator _claimLink;
  private readonly ILocator _buzzLink;

  public Sidebar(IPage page) : base(page)
  {
    _sidebarContainer = Page.GetByRole(AriaRole.Navigation, new()
    {
      Name = "Sidepanel"
    });

    _adminLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Admin" });

    _pimLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "PIM" });

    _leaveLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Leave" });

    _timeLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Time" });

    _recruitmentLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Recruitment" });

    _myInfoLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "My Info" });

    _performanceLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Performance" });

    _dashboardLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Dashboard" });

    _directoryLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Directory" });

    _maintenanceLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Maintenance" });

    _claimLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Claim" });

    _buzzLink = _sidebarContainer.Locator("oxd-main-menu-item")
                                  .Filter(new() { HasText = "Buzz" });
  }

  // Interaction Methods
  public async Task ClickAdminLinkAsync()
      => await _adminLink.ClickAsync();

  public async Task ClickPimLinkAsync()
      => await _pimLink.ClickAsync();

  public async Task ClickLeaveLinkAsync()
      => await _leaveLink.ClickAsync();

  public async Task ClickTimeLinkAsync()
      => await _timeLink.ClickAsync();

  public async Task ClickRecruitmentLinkAsync()
      => await _recruitmentLink.ClickAsync();

  public async Task ClickMyInfoLinkAsync()
      => await _myInfoLink.ClickAsync();

  public async Task ClickPerformanceLinkAsync()
      => await _performanceLink.ClickAsync();

  public async Task ClickDashboardLinkAsync()
      => await _dashboardLink.ClickAsync();

  public async Task ClickDirectoryLinkAsync()
      => await _directoryLink.ClickAsync();

  public async Task ClickMaintenanceLinkAsync()
      => await _maintenanceLink.ClickAsync();

  public async Task ClickClaimLinkAsync()
      => await _claimLink.ClickAsync();

  public async Task ClickBuzzLinkAsync()
      => await _buzzLink.ClickAsync();

  public async Task NavigateToAsync()
      => await Page.GotoAsync(Url);
}
