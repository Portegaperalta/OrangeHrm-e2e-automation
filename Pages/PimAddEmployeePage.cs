using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace Pages;

public class PimAddEmployeePage : BasePage
{
    public string Url = "/web/index.php/pim/addEmployee";

    public ILocator AddEmployeeTitle => _addEmployeeTitle;
    public ILocator EmployeeFirstNameInput => _employeeFirstNameInput;
    public ILocator EmployeeMiddleNameInput => _employeeMiddleNameInput;
    public ILocator EmployeeLastNameInput => _employeeLastNameInput;
    public ILocator EmployeeIdInput => _employeeIdInput;
    public ILocator ToggleLoginDetailsButton => _toggleLoginDetailsButton;
    public ILocator EmployeeUsernameInput => _employeeUsernameInput;
    public ILocator EmployeePasswordInput => _employeePasswordInput;
    public ILocator ConfirmEmployeePasswordInput => _confirmEmployeePasswordInput;
    public ILocator RequiredFieldWarning => _requiredFieldWarning;
    public ILocator DuplicatedEmployeeIdWarning => _duplicatedEmployeeIdWarning;
    public ILocator PasswordsDoNotMatchWarning => _passwordsDoNotMatchWarning;
    public ILocator CancelFormButton => _cancelFormButton;
    public ILocator SaveEmployeeButton => _saveEmployeeButton;

    private readonly ILocator _addEmployeeTitle;
    private readonly ILocator _employeeFirstNameInput;
    private readonly ILocator _employeeMiddleNameInput;
    private readonly ILocator _employeeLastNameInput;
    private readonly ILocator _employeeIdInput;
    private readonly ILocator _toggleLoginDetailsButton;
    private readonly ILocator _employeeUsernameInput;
    private readonly ILocator _employeePasswordInput;
    private readonly ILocator _confirmEmployeePasswordInput;
    private readonly ILocator _requiredFieldWarning;
    private readonly ILocator _duplicatedEmployeeIdWarning;
    private readonly ILocator _passwordsDoNotMatchWarning;
    private readonly ILocator _cancelFormButton;
    private readonly ILocator _saveEmployeeButton;

    public PimAddEmployeePage(IPage page) : base(page)
    {
        _addEmployeeTitle = Page.Locator("a.oxd-topbar-body-nav-tab-item")
                                .Filter(new() { HasText = "Add Employee" });

        _employeeFirstNameInput = Page.GetByPlaceholder("First Name");

        _employeeMiddleNameInput = Page.GetByPlaceholder("Middle Name");

        _employeeLastNameInput = Page.GetByPlaceholder("Last Name");

        _employeeIdInput = Page.GetByLabel("Employee Id");

        _toggleLoginDetailsButton = Page.Locator("div.oxd-switch-wrapper");

        _employeeUsernameInput = Page.Locator("div.oxd-input-group")
                                     .Filter(new() { HasText = "Username" })
                                     .GetByRole(AriaRole.Textbox);

        _employeePasswordInput = Page.Locator("div.oxd-input-group")
                                     .Filter(new() { HasTextRegex = new Regex("^Password$") })
                                     .GetByRole(AriaRole.Textbox);

        _confirmEmployeePasswordInput = Page.Locator("div.oxd-input-group")
                                     .Filter(new() { HasText = "Confirm Password" })
                                     .GetByRole(AriaRole.Textbox);

        _requiredFieldWarning = Page.Locator("span.oxd-input-field-error-message")
                                    .Filter(new() { HasText = "Required" });

        _duplicatedEmployeeIdWarning = Page.Locator("span.oxd-input-field-error-message")
                                    .Filter(new() { HasText = "Employee Id already exists" });

        _passwordsDoNotMatchWarning = Page.Locator("span.oxd-input-field-error-message")
                                    .Filter(new() { HasText = "Passwords do not match" });

        _cancelFormButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button)
                                .Filter(new() { HasText = "Cancel" });

        _saveEmployeeButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button)
                                .Filter(new() { HasText = "Save" });
    }

    public async Task InsertEmployeeFirstNameAsync(string firstName)
        => await _employeeFirstNameInput.FillAsync(firstName);

    public async Task InsertEmployeeMiddleNameAsync(string middleName)
        => await _employeeMiddleNameInput.FillAsync(middleName);

    public async Task InsertEmployeeLastNameAsync(string lastName)
        => await _employeeLastNameInput.FillAsync(lastName);

    public async Task ToggleLoginDetailsAsync()
        => await _toggleLoginDetailsButton.ClickAsync();

    public async Task InsertEmployeeUsernameAsync(string username)
        => await _employeeUsernameInput.FillAsync(username);

    public async Task InsertEmployeePasswordAsync(string password)
        => await _employeePasswordInput.FillAsync(password);

    public async Task ConfirmEmployeePasswordAsync(string password)
        => await _confirmEmployeePasswordInput.FillAsync(password);

    public async Task ClickSaveButtonAsync() =>
        await _saveEmployeeButton.ClickAsync();

    public async Task ClickCancelButtonAsync()
        => await _cancelFormButton.ClickAsync();

    public async Task NavigateToAsync()
        => await Page.GotoAsync(Url);
}
