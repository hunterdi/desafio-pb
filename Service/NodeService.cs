using Architecture;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NodeService : ServiceBase<Node>, INodeService
    {
        private Node _root { get; set; }

        public NodeService(IRepositoryBase<Node> repository) : base(repository)
        {
        }

        public override async Task<Node> CreateAsync(Node node)
        {
            Node response = null;
            var result = await _repository.GetAllAsync();

            if (result.Any())
            {
                _root = result.FirstOrDefault();
            }
            else
            {
                response = await _repository.CreateAsync(node);
                return response;
            }

            await PutAsync(node.Value);

            response = FindInRootWithValue(node.Value);

            await _repository.CreateAsync(response);

            var prevNode = FindPrevNodeWithValue(node.Value);

            if (prevNode.Left != null)
            {
                var left = await _repository.GetByIdAsync(prevNode.ID);
                left.LeftID = response.ID;
                await _repository.UpdateAsync(left.ID, left);
            }

            if (prevNode.Right != null)
            {
                var right = await _repository.GetByIdAsync(prevNode.ID);
                right.RightID = response.ID;
                await _repository.UpdateAsync(right.ID, right);
            }

            return response;
        }

        public Node FindWithValue(int value)
        {
            var result = this._repository.GetAll().FirstOrDefault(e => e.Value == value);

            return result;
        }

        private Node FindInRootWithValue(int value)
        {
            return Get(this._root, value);
        }

        private Node FindPrevNodeWithValue(int value)
        {
            return GetPrev(_root, value);
        }

        private Node GetPrev(Node node, int value)
        {
            if (node == null) return null;
            int cmp = value.CompareTo(node.Value);
            if (cmp < 0 && node.Left.Value != value) return GetPrev(node.Left, value);
            else if (cmp > 0 && node.Right.Value != value) return GetPrev(node.Right, value);
            else return node;
        }

        private Node Get(Node node, int value)
        {
            if (node == null) return null;
            int cmp = value.CompareTo(node.Value);
            if (cmp < 0) return Get(node.Left, value);
            else if (cmp > 0) return Get(node.Right, value);
            else return node;
        }

        private async Task PutAsync(int value)
        {
            await PutAsync(_root, value);
        }

        private async Task PutAsync(Node node, int value)
        {
            if (node != null)
            {
                if (value < node.Value)
                {
                    if (node.LeftID.HasValue)
                    {
                        var left = await _repository.GetByIdAsync(node.LeftID.Value);
                        await PutAsync(left, value);
                        node.Left = left;
                    }
                    else
                    {
                        node.Left = new Node(value);
                    }
                }
                else if (value > node.Value)
                {
                    if (node.RightID.HasValue)
                    {
                        var right = await _repository.GetByIdAsync(node.RightID.Value);
                        await PutAsync(right, value);
                        node.Right = right;
                    }
                    else
                    {
                        node.Right = new Node(value);
                    }
                }
            }
        }
    }
}
