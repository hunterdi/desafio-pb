using Architecture;
using Architecture.Extensions;
using Domain;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BSTTests
    {
        [Fact]
        public async Task Must_insert_at_root_of_empty_tree()
        {
            var node = new Node(10);
            node.ID = Guid.NewGuid();

            Mock<IRepositoryBase<Node>> repository = new Mock<IRepositoryBase<Node>>();

            repository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Node>());

            repository.Setup(x => x.CreateAsync(It.IsAny<Node>()))
                .ReturnsAsync(node);

            repository.Setup(x => x.GetAll()).Returns((new List<Node> { node }).AsQueryable());

            var service = new NodeService(repository.Object);
            await service.CreateAsync(node);

            var nodeInserted = service.FindWithValue(10);

            Assert.Equal<int>(10, nodeInserted.Value);
            Assert.Null(nodeInserted.LeftID);
            Assert.Null(nodeInserted.RightID);
        }

        [Fact]
        public void Is_Palindrome()
        {
            Assert.False("Teste".IsPalindrome());
            Assert.True("Deleveled".IsPalindrome());
            Assert.True("Delev#$%eled".IsPalindrome());
        }
    }
}
