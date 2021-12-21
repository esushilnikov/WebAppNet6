using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

public class WebAppBaseController : Controller
{
    public UserAccount UserAccount
    {
        get
        {
            return HttpContext.Items["UserAccount"] as UserAccount; 
        }
    }
}