using Architecture;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface INodeService: IServiceBase<Node>
    {
        Node FindWithValue(int value);
    }
}
