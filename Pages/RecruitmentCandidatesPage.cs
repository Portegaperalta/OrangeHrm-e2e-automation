using System;
using Microsoft.Playwright;

namespace Pages;

public class RecruitmentCandidatesPage : BasePage
{
    public string Url = "/web/index.php/recruitment/viewCandidates";

    public ILocator CandidatesTitle => _candidatesTitle;
    public ILocator AddCandidateButton => _addCandidateButton;
    public ILocator SearchCandidateButton => _searchCandidateButton;
    public ILocator ResetFilterButton => _resetFilterButton;
    public ILocator CandidatesTable => _candidatesTable;
    public ILocator ToggleSearchButton => _toggleSearchButton;
    public ILocator CandidateNameInput => _candidateNameInput;
    public ILocator JobTitleInput => _jobTitleInput;
    public ILocator HiringManagerInput => _hiringManagerInput;
    public ILocator StatusDropdown => _statusDropdown;

    private readonly ILocator _candidatesTitle;
    private readonly ILocator _toggleSearchButton;
    private readonly ILocator _candidateNameInput;
    private readonly ILocator _jobTitleInput;
    private readonly ILocator _hiringManagerInput;
    private readonly ILocator _statusDropdown;
    private readonly ILocator _searchCandidateButton;
    private readonly ILocator _resetFilterButton;
    private readonly ILocator _addCandidateButton;
    private readonly ILocator _candidatesTable;

    public RecruitmentCandidatesPage(IPage page) : base(page)
    {
        _candidatesTitle = Page.GetByRole(AriaRole.Link, new()
        {
            Name = "Candidates"
        });


        _toggleSearchButton = Page.Locator("div.oxd-table-filter-header-options")
                                  .GetByRole(AriaRole.Button);

        _candidateNameInput = Page.Locator("div.oxd-input-group")
                                .Filter(new() { HasText = "Candidate Name" })
                                .GetByRole(AriaRole.Textbox);

        _jobTitleInput = Page.Locator("div.oxd-input-group")
                            .Filter(new() { HasText = "Job Title" })
                            .GetByRole(AriaRole.Textbox);

        _hiringManagerInput = Page.Locator("div.oxd-input-group")
                                 .Filter(new() { HasText = "Hiring Manager" })
                                 .GetByRole(AriaRole.Textbox);

        _statusDropdown = Page.Locator("div.oxd-input-group")
                             .Filter(new() { HasText = "Status" })
                             .GetByRole(AriaRole.Combobox);

        _searchCandidateButton = Page.Locator("div.oxd-form-actions")
                                    .GetByRole(AriaRole.Button, new()
                                    { Name = "Search" });

        _resetFilterButton = Page.Locator("div.oxd-form-actions")
                                 .GetByRole(AriaRole.Button, new()
                                 { Name = "Reset" });

        _addCandidateButton = Page.GetByRole(AriaRole.Button).Locator("i.bi-plus");

        _candidatesTable = Page.GetByRole(AriaRole.Table).Locator("div.oxd-table");
    }

    // Interaction Methods
    public async Task ClickToggleSearchButtonAsync()
        => await _toggleSearchButton.ClickAsync();

    public async Task InsertCandidateNameAsync(string name)
        => await _candidateNameInput.FillAsync(name);

    public async Task ClickAddCandidateButtonAsync()
        => await _addCandidateButton.ClickAsync();

    public async Task ClickSearchCandidateButtonAsync()
        => await _searchCandidateButton.ClickAsync();

    public async Task ClickResetFilterButtonAsync()
        => await _resetFilterButton.ClickAsync();

    public async Task NavigateToAsync()
        => await Page.GotoAsync(Url);
}