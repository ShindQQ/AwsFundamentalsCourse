namespace Customers.Api.Contracts.Messages;

public class CustomerCreated
{
    public Guid Id { get; init; }

    public string GitHubUsername { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }
}

public class CustomerUpdated
{
    public Guid Id { get; init; }

    public string GitHubUsername { get; init; } = default!;

    public string FullName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }
}

public class CustomerDeleted
{
    public Guid Id { get; init; }
}