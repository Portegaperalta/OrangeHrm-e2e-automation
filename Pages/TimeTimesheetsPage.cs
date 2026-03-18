using System;
using Microsoft.Playwright;

namespace Pages;

public class TimeTimesheetsPage : BasePage
{
  public string Url = "/web/index.php/time/viewEmployeeTimesheet";
  public ILocator SelectEmployeeInput => _selectEmployeeInput;
  public ILocator SearchEmployeeButton => _searchEmployeeButton;
  public ILocator TimeSheetsPendingList => _timeSheetsPendingList;

  private readonly ILocator _selectEmployeeInput;
  private readonly ILocator _searchEmployeeButton;
  private readonly ILocator _timeSheetsPendingList;

  public TimeTimesheetsPage(IPage page) : base(page)
  {
    _selectEmployeeInput = Page.Locator("div.orangehrm-card-container")
                               .Filter(new() { HasText = "Select Employee" })
                               .GetByRole(AriaRole.Textbox);

    _searchEmployeeButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new() { Name = "View" });

    _timeSheetsPendingList = Page.Locator("div.orangehrm-paper-container")
                                 .Locator("div.oxd-table-body");
  }

  public async Task InsertEmployeeNameAsync(string name)
      => await _selectEmployeeInput.FillAsync(name);

  public async Task ClickSearchEmployeeButtonAsync()
      => await _searchEmployeeButton.ClickAsync();
}
