using Architecture;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPB.Controllers
{
    public class NodeController : BaseControllerCrud<Node, Node, NodeInsertDTO, Node>
    {
        private readonly INodeService nodeService; 

        public NodeController(INodeService service, IMapper mapper, ILogger<BaseController<Node, Node>> logger) : base(service, mapper, logger)
        {
            nodeService = service;
        }

        [HttpGet("find-witch-value/{value}")]
        public IActionResult FindwithValue([FromRoute] int value)
        {
            var response = nodeService.FindWithValue(value);

            return Ok(response);
        }
    }
}
