using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedReesult<T>(IGenericRepository<T> repo,ISpecifications<T> spec,int PageIndex,int PageSize) where T : BaseEntity
        {
            var list =await repo.ListAsyc(spec);
            var count =await repo.CountAsync(spec);
            var result = new Pagination<T>(PageSize,PageIndex,count,list);
           return Ok(result);
        }
    }
}