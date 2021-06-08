using Architecture;
using Architecture.Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class NodeRepository : RepositoryBase<Node, ApplicationDataMongoContext>, INodeRepository
    {
        public NodeRepository(ApplicationDataMongoContext dbContext) : base(dbContext)
        {
        }
    }
}
