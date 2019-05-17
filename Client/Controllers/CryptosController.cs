using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Client.Interfaces;
using System.Runtime.Serialization.Json;

namespace Client.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class CryptosController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        // GET api/cryptos
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var streamTask = client.GetStreamAsync("http://server/api/cryptos");
            var jsonSerializar = new DataContractJsonSerializer(typeof(List<Cryptos>));
            List<Cryptos> cryptoList = jsonSerializar.ReadObject(await streamTask) as List<Cryptos>;

            string resp = "Available currency:";

            foreach (var crypto in cryptoList)
            {
                resp += crypto.name + " (" + crypto.symbol + "),";
            }

            return resp;
        }
    }
}
