using Core.AbstractManager;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IGenericManager<AboutUs,AboutDTO> _genericManager;
        
    }
}
