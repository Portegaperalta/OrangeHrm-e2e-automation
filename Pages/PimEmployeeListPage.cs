using System;
using Microsoft.Playwright;

namespace Pages;

public class PimEmployeeListPage : BasePage
{
    public string Url = "/web/index.php/pim/viewEmployeeList";

    public ILocator PimTitle => _pimTitle;
    public ILocator EmployeeListTitle => _employeeListTitle;
    public ILocator SearchDropdownButton => _searchDropdownButton;
    public ILocator EmployeeNameInput => _employeeNameInput;
    public ILocator EmployeeIdInput => _employeeIdInput;
    public ILocator SearchEmployeeButton => _searchEmployeeButton;
    public ILocator ResetFormButton => _resetFormButton;
    public ILocator AddEmployeeButton => _addEmployeeButton;
    public ILocator EmployeeList => _employeeList;

    private readonly ILocator _pimTitle;
    private readonly ILocator _employeeListTitle;
    private readonly ILocator _searchDropdownButton;
    private readonly ILocator _employeeNameInput;
    private readonly ILocator _employeeIdInput;
    private readonly ILocator _searchEmployeeButton;
    private readonly ILocator _resetFormButton;
    private readonly ILocator _addEmployeeButton;
    private readonly ILocator _employeeList;

    public PimEmployeeListPage(IPage page) : base(page)
    {
        _pimTitle = Page.GetByRole(AriaRole.Heading, new()
        {
            Level = 6,
            Name = "PIM"
        });

        _employeeListTitle = Page.Locator("a.oxd-topbar-body-nav-tab-item", new()
        {
            HasText = "Employee List"
        });

        _searchDropdownButton = Page.Locator("div.oxd-table-filter-header")
                                                 .GetByRole(AriaRole.Button);

        _employeeNameInput = Page.Locator("div.oxd-input-group", new()
        { HasText = "Employee Name" }).GetByRole(AriaRole.Textbox);

        _employeeIdInput = Page.Locator("div.oxd-input-group", new()
        { HasText = "Employee Id" }).GetByRole(AriaRole.Textbox);

        _searchEmployeeButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new() { Name = "Search" });

        _resetFormButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new() { Name = "Reset" });

        _addEmployeeButton = Page.GetByRole(AriaRole.Button)
                                 .Locator("i.bi-plus");

        _employeeList = Page.Locator("div.orangehrm-employee-list");
    }

    // Interaction Methods
    public async Task ClickSearchDropdownButtonAsync()
        => await _searchDropdownButton.ClickAsync();

    public async Task InsertEmployeeNameAsync(string name)
        => await _employeeNameInput.FillAsync(name);

    public async Task InsertEmployeeIdAsync(string id)
        => await _employeeIdInput.FillAsync(id);

    public async Task ClickSearchEmployeeButtonAsync()
        => await _searchEmployeeButton.ClickAsync();

    public async Task ClickResetFormButtonAsync()
        => await _resetFormButton.ClickAsync();

    public async Task ClickAddEmployeeButtonAsync()
        => await _addEmployeeButton.ClickAsync();

    public async Task NavigateToAsync()
        => await Page.GotoAsync(Url);
}
