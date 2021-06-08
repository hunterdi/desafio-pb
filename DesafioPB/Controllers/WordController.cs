using Architecture.Extensions;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPB.Controllers
{
    [EnableCors]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : Controller
    {
        [HttpPost("is-palindrome")]
        public IActionResult IsPalindrome([FromBody] WordCheckIsPalindrome word)
        {
            return Ok(word.Text.IsPalindrome());
        }
    }
}
