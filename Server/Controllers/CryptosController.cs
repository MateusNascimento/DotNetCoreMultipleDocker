using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptosController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Crypto>> Get()
        {
            List<Crypto> cryptoList = new List<Crypto>();
            
            cryptoList.Add(new Crypto { Symbol = "BTC", Name = "Bitcoin" });
            cryptoList.Add(new Crypto { Symbol = "ETH", Name = "Ethereum" });
            cryptoList.Add(new Crypto { Symbol = "XRP", Name = "Ripple" });

            return cryptoList;
        }
    }
}
