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
    public ILocator NoRecordsFoundMessage => _noRecordsFoundMessage;

    private readonly ILocator _pimTitle;
    private readonly ILocator _employeeListTitle;
    private readonly ILocator _searchDropdownButton;
    private readonly ILocator _employeeNameInput;
    private readonly ILocator _employeeIdInput;
    private readonly ILocator _searchEmployeeButton;
    private readonly ILocator _resetFormButton;
    private readonly ILocator _addEmployeeButton;
    private readonly ILocator _employeeList;
    private readonly ILocator _employeeListCard;
    private readonly ILocator _confirmUserDeleteDialog;
    private readonly ILocator _confirmUserDeleteButton;
    private readonly ILocator _noRecordsFoundMessage;

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
                                    .Locator("button.oxd-icon-button");

        _employeeNameInput = Page.Locator("div.oxd-grid-item")
                                 .Filter(new() { HasText = "Employee Name" })
                                 .GetByPlaceholder("Type for hints...");

        _employeeIdInput = Page.Locator("div.oxd-input-group", new()
        { HasText = "Employee Id" }).GetByRole(AriaRole.Textbox);

        _searchEmployeeButton = Page.Locator("div.oxd-form-actions")
        .GetByRole(AriaRole.Button, new() { Name = "Search" });

        _resetFormButton = Page.Locator("div.oxd-form-actions")
        .GetByRole(AriaRole.Button, new() { Name = "Reset" });

        _addEmployeeButton = Page.GetByRole(AriaRole.Button)
        .Locator("i.bi-plus");

        _employeeList = Page.Locator("div.orangehrm-employee-list");

        _employeeListCard = Page.Locator("div.oxd-table-card");

        _confirmUserDeleteDialog = Page.Locator("div.orangehrm-dialog-popup");

        _confirmUserDeleteButton = _confirmUserDeleteDialog.GetByRole(AriaRole.Button)
                                  .Filter(new() { Has = Page.Locator("i.bi-trash") });

        _noRecordsFoundMessage = Page.GetByText("No Records Found");
    }

    // Interaction Methods
    public async Task ClickSearchDropdownButtonAsync()
    {
        var isCollapsed = await _searchDropdownButton.Locator("i.bi-caret-up-fill").IsVisibleAsync();

        if (isCollapsed is true)
        {
            await _searchDropdownButton.ClickAsync();
        }
    }

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

    public ILocator GetEmployeeCardByUsername(string username)
        => _employeeListCard.Filter(new() { HasText = username });

    public ILocator GetEmployeeCardById(string id)
        => _employeeListCard.Filter(new() { HasText = id });

    public async Task ClickDeleteUserButtonAsync(string username)
    {
        var employeeCard = GetEmployeeCardByUsername(username);
        await employeeCard.Locator("i.bi-trash").ClickAsync();
    }

    public async Task ClickEditUserButtonAsync(string username)
    {
        var employeeCard = GetEmployeeCardByUsername(username);
        await employeeCard.Locator("i.bi-pencil-fill").ClickAsync();
    }

    public async Task ClickConfirmUserDeleteButtonAsync()
        => await _confirmUserDeleteButton.ClickAsync();
}
