using CMS.Api.Models;
using CMS.Api.Models.Enums;
using CMS.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers;

public class BaseController : ControllerBase
{
    public ActionResult CustomOk(object data, string message = "")
    {
        return Ok(new Result()
        {
            Message = message,
            Data = data,
            Status = Status.Success
        });
    }

    public ActionResult CustomError(object data = null, string message = "")
    {
        return BadRequest(new Result()
        {
            Message = message,
            Data = data,
            Status = Status.Failed
        });
    }
}