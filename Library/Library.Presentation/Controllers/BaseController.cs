using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
// ۱. ساخت کلاس پایه
public abstract class BaseController : ApiController
{
    protected readonly ILogger _logger;

    protected BaseController(ILogger logger)
    {
        _logger = logger;
    }
}
