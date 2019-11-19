﻿using System.Collections.Generic;
using Markdown.Tokens;

namespace Markdown.SyntaxTrees
{
    public class SyntaxTreeNode
    {
        public Token Token { get; }
        private readonly List<SyntaxTreeNode> children;

        public bool IsClosed { get; set; }

        public SyntaxTreeNode(Token token)
        {
            Token = token;
            children = new List<SyntaxTreeNode>();
        }

        public void AddChild(SyntaxTreeNode child)
        {
            children.Add(child);
        }

        public IReadOnlyList<SyntaxTreeNode> GetChildren()
        {
            return children;
        }
    }
}