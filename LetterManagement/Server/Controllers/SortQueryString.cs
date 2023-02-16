using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers;

public enum SortFields
{
    SentDate = 1,
    ReceivedDate = 2, 
    FinishedDate=3,
}

public enum SortDirections
{
    asc = 1, 
    desc = 2
}
public class SortQueryString
{
    [FromQuery]
    public SortFields SortBy { get; set; }
    [FromQuery]
    public SortDirections SortDirection { get; set; }
}