namespace Api.Helpers;

public record QueryRecord(
    string? Symbol = null,
    string? CompanyName = null,
    string? SortBy = null,
    bool IsDecsending = false,
    int PageNumber = 1,
    int PageSize = 20
);