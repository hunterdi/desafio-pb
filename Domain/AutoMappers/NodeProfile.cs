using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class NodeProfile: Profile
    {
        public NodeProfile()
        {
            CreateMap<NodeInsertDTO, Node>();
        }
    }
}
