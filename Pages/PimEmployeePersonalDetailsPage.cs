using Microsoft.Playwright;

namespace Pages;

public class PimEmployeePersonalDetailsPage : BasePage
{
  public string Url = "/web/index.php/pim/viewPersonalDetails/empNumber/";

  public ILocator EmployeeNameTitle => _employeeNameTitle;
  public ILocator EmployeePersonalDetailsLink => _employeePersonalDetailsLink;
  public ILocator EmployeeFirstNameInput => _employeeFirstNameInput;
  public ILocator EmployeeMiddleNameInput => _employeeMiddleNameInput;
  public ILocator EmployeeLastNameInput => _employeeLastNameInput;
  public ILocator EmployeeIdInput => _employeeIdNameInput;
  public ILocator EmployeeGenderMaleCheckbox => _employeeGenderMaleCheckbox;
  public ILocator EmployeeGenderFemaleCheckbox => _employeeGenderFemaleCheckbox;
  public ILocator SaveEmployeeDetailsButton => _saveEmployeeDetailsButton;

  private readonly ILocator _employeeNameTitle;
  private readonly ILocator _employeePersonalDetailsLink;
  private readonly ILocator _employeeFirstNameInput;
  private readonly ILocator _employeeMiddleNameInput;
  private readonly ILocator _employeeLastNameInput;
  private readonly ILocator _employeeIdNameInput;
  private readonly ILocator _employeeGenderMaleCheckbox;
  private readonly ILocator _employeeGenderFemaleCheckbox;
  private readonly ILocator _saveEmployeeDetailsButton;

  public PimEmployeePersonalDetailsPage(IPage page) : base(page)
  {
    _employeeNameTitle = Page.Locator("div.orangehrm-edit-employee-imagesection")
                             .GetByRole(AriaRole.Heading, new() { Level = 6, });

    _employeePersonalDetailsLink = Page.Locator("a.orangehrm-tabs-wrapper")
                                       .Filter(new() { HasText = "Personal Details" });

    _employeeFirstNameInput = Page.GetByRole(AriaRole.Textbox, new()
    { Name = "firstName" });

    _employeeMiddleNameInput = Page.GetByRole(AriaRole.Textbox, new()
    { Name = "middleName" });

    _employeeLastNameInput = Page.GetByRole(AriaRole.Textbox, new()
    { Name = "lastName" });

    _employeeIdNameInput = Page.Locator("div.oxd-input-group")
                               .Filter(new() { HasText = "Employee Id" })
                               .GetByRole(AriaRole.Textbox);

    _employeeGenderMaleCheckbox = Page.Locator("div.oxd-radio-wrapper")
                                      .Filter(new() { HasText = "Male" })
                                      .GetByRole(AriaRole.Radio);

    _employeeGenderFemaleCheckbox = Page.Locator("div.oxd-radio-wrapper")
                                      .Filter(new() { HasText = "Female" })
                                      .GetByRole(AriaRole.Radio);

    _saveEmployeeDetailsButton = Page.GetByRole(AriaRole.Button)
                                     .Filter(new() { HasText = "Save", })
                                     .First;
  }

  public async Task ClickEmployeePersonalDetailsLinkAsync()
      => await _employeePersonalDetailsLink.ClickAsync();

  public async Task FillEmployeeFirstNameAsync(string firstName)
      => await _employeeFirstNameInput.FillAsync(firstName);

  public async Task FillEmployeeMiddleNameAsync(string middleName)
      => await _employeeMiddleNameInput.FillAsync(middleName);

  public async Task FillEmployeeLastNameAsync(string lastName)
      => await _employeeLastNameInput.FillAsync(lastName);

  public async Task FillEmployeeIdAsync(string employeeId)
      => await _employeeIdNameInput.FillAsync(employeeId);

  public async Task SelectGenderMaleAsync()
      => await _employeeGenderMaleCheckbox.SetCheckedAsync(true);

  public async Task SelectGenderFemaleAsync()
      => await _employeeGenderFemaleCheckbox.SetCheckedAsync(true);

  public async Task ClickSaveEmployeeDetailsButtonAsync()
      => await _saveEmployeeDetailsButton.ClickAsync();

  public async Task NavigateToAsync(string empNumber)
      => await Page.GotoAsync(Url + empNumber);
}