using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private EFDbContext _context;
        public AddressController(EFDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<Address> GetAll()
        {
            var list = _context.Address.Take(10).ToList();


            return list;
        }

    }
}