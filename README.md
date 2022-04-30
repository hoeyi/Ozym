# Njord Finance #
Njord Finance, a banking and investing management application, built using ASP .NET Core, EF Core, 
and Blazor.

* [Getting Started](#getting-started)
* [Commit Message Guidelines](#commit-message-guidelines)

## Getting Started ##

### Build Scripts ###

| Script | Usage |
|:--- |:--- |
| **MigrateNjordFinanceModel** | Updates the destintation database set in the startup project connection string using the `FinanceDbContext`.
| **MigrateNjordIdentityModel** | Updates the destination database set in the startup project connection string using the `IdentityDbContext`.

## Commit Message Guidelines ##

The structure of these guidelines are based on the [Angular convetion](
https://github.com/angular/angular/blob/22b96b9/CONTRIBUTING.md#commit) and 
[Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0-beta.2/).

Commit messages should follow the format:
```
<type>[optional scope]: <description>
[optional body]
[optional footer]
```

### Type ###
Must be one of the following:

* **build**: Changes that affect the build system or external dependencies
* **design**: Changes to CSS rules or code changes to support UI behavior
* **docs**: Documentation only changes
* **feat**: A new feature
* **fix**: A bug fix
* **perf**: A code change that improves performance
* **refactor**: A code change that neither fixes a bug nor adds a feature
* **revert**: Reverts commit `<hash>`.
* **style**: Changes that do not affect the meaning of the code 
(white-space, formatting, missing semi-colons, etc)
* **test**: Adding missing tests or correcting existing tests

### Scope ###
The scope is the domain affected. Choose one of the following:
* **Blazor**: Blazor view, view logic, or components.
* **DAL**: Data model or data service layer.
* **Logic**: Business logic or related model.
* **API-{Name}**: API support where {Name} is the API project (e.g., NjordFinance, or a vendor).

Example: 
```
feat(DAL): add service for using market data API

fix(Blazor): fix unhandled null reference error
```

### Subject ###
The subject contains a succinct description of the change:

* Use the imperative, present tense
* Don't capitalize the first letter
* Don't include punctuation

### Body ###
The body contains the detail of why the change was made:
* Use the imperative, present tense
* Include the motivation for the change with contrast to prior behavior

### Footer ###
The footer contains information on breaking changes. Start with the phrase 
`BREAKING CHANGE:`. Also use this space to reference closing GitHub issues. 

Example:
```
BREAKING CHANGE: Ends support for [NAME] API

Resolves #42 (where #42 is the GitHub issue no.)
```
