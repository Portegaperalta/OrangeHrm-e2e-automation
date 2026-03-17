using Microsoft.Playwright;

namespace Pages;

public class AdminViewUsersPage : BasePage
{
    public string Url = "/web/index.php/admin/viewSystemUsers";

    public ILocator AdminTitle => _adminTitle;
    public ILocator UserManagementTitle => _userManagementTitle;
    public ILocator ToggleUserFilterButton => _toggleUserFilterButton;
    public ILocator AddUserButton => _addUserButton;
    public ILocator SearchUserButton => _searchUserButton;
    public ILocator ResetFilterButton => _resetFilterButton;
    public ILocator UsersTable => _usersTable;

    private readonly ILocator _adminTitle;
    private readonly ILocator _userManagementTitle;
    private readonly ILocator _toggleUserFilterButton;
    private readonly ILocator _usernameInput;
    private readonly ILocator _addUserButton;
    private readonly ILocator _searchUserButton;
    private readonly ILocator _resetFilterButton;
    private readonly ILocator _usersTable;

    public AdminViewUsersPage(IPage page) : base(page)
    {
        _adminTitle = Page.GetByRole(AriaRole.Heading, new()
        {
            Level = 6,
            Name = "Admin"
        });

        _userManagementTitle = Page.GetByRole(AriaRole.Heading, new()
        {
            Level = 6,
            Name = "User Management"
        });

        _toggleUserFilterButton = Page.Locator("div.oxd-table-filter-header-options");

        _usernameInput = Page.Locator("div.oxd-input-group")
                             .Filter(new() { HasText = "Username" })
                             .GetByRole(AriaRole.Textbox);

        _addUserButton = Page.GetByRole(AriaRole.Button).Locator("i.bi-plus");

        _usersTable = Page.GetByRole(AriaRole.Table).Locator("div.oxd-table");

        _searchUserButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new()
                                { Name = "Search" });

        _resetFilterButton = Page.Locator("div.oxd-form-actions")
                                .GetByRole(AriaRole.Button, new()
                                { Name = "Reset" });
    }

    // Interaction Methods
    public async Task ClickToggleSearchButton()
        => await _toggleUserFilterButton.ClickAsync();

    public async Task InsertUsername(string username)
        => await _usernameInput.FillAsync(username);

    public async Task ClickAddUserButtonAsync()
        => await _addUserButton.ClickAsync();

    public async Task ClickSearchUserButtonAsync()
        => await _searchUserButton.ClickAsync();

    public async Task ClickResetFilterButton()
        => await _resetFilterButton.ClickAsync();

    public async Task NavigateToAsync()
        => await Page.GotoAsync(Url);
}
