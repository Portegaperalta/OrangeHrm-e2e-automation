using System;
using Microsoft.Playwright;

namespace Pages;

public class LeaveListPage : BasePage
{
  public string Url = "/web/index.php/leave/viewLeaveList";

  public ILocator LeaveListDropdownButton => _leaveListDropdownButton;
  public ILocator EmployeeNameInput => _employeeNameInput;
  public ILocator SearchEmployeeButton => _searchEmployeeButton;
  public ILocator ResetFormButton => _resetFormButton;

  private readonly ILocator _leaveListDropdownButton;
  private readonly ILocator _employeeNameInput;
  private readonly ILocator _searchEmployeeButton;
  private readonly ILocator _resetFormButton;

  public LeaveListPage(IPage page) : base(page)
  {
    _leaveListDropdownButton = Page.Locator("div.oxd-table-filter-header")
                                   .GetByRole(AriaRole.Button);

    _employeeNameInput = Page.Locator("div.oxd-input-group", new() { HasText = "Employee Name" })
                             .GetByRole(AriaRole.Textbox);

    _searchEmployeeButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new() { Name = "Search" });

    _resetFormButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new() { Name = "Reset" });
  }

  // Interaction Methods
  public async Task ClickLeaveListDropdownButtonAsync()
      => await _leaveListDropdownButton.ClickAsync();

  public async Task InsertEmployeeNameAsync(string name)
      => await _employeeNameInput.FillAsync(name);

  public async Task ClickSearchEmployeeButtonAsync()
      => await _searchEmployeeButton.ClickAsync();

  public async Task ClickResetFormButtonAsync()
      => await _resetFormButton.ClickAsync();

  public async Task NavigateToAsync()
      => await Page.GotoAsync(Url);
}