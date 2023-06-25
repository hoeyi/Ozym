## Commit Message Guidelines ##

Commit message guidelines are meant to mirror the style prescribed in [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/). Changes to the types and scope have been made.

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
* **docs**: Changes to documentation or code comments
* **feat**: A new feature / ehancement
* **fix**: A bug fix
* **perf**: A code change that improves performance
* **refactor**: A code change that neither fixes a bug nor adds a feature
* **revert**: Reverts commit `<hash>`.
* **style**: Changes that do not affect the meaning of the code 
(white-space, formatting, missing semi-colons, etc)
* **test**: Adding missing tests or correcting existing tests

### Scope ###
The scope is the domain affected. Choose one of the following:
* **Blazor**: Blazor pages or components.
* **Controller**: Web controllers.
* **DAL**: Model repository services and data-transfer objects.
* **EntityModel**: Entity classes and/or ORM.
* **EntityMigration**: Entity data migrations
* **Logic**: Business logic.
* **API-{Name}**: API support where {Name} is the API project (e.g., NjordinSight, or a vendor).

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
