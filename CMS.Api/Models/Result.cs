using CMS.Api.Models.Enums;

namespace CMS.Api.Models;

public class Result
{
    public object Data { get; set; }
    public Status Status { get; set; }
    public string Message { get; set; }
}

