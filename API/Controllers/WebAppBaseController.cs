using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

public class WebAppBaseController : Controller
{
    protected UserAccount? UserState => HttpContext.Items["UserState"] as UserAccount;
}