using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblems
{
    public partial class Problems
    {
        public bool IsBst(TreeNode root)
        {
            // clarification question on this
            if (root == null) return true;

            return this.IsBST(int.MinValue, int.MaxValue, root);

        }

        private bool IsBST(int min, int max, TreeNode root)
        {
            if (root == null) return true;

            // Actual test for BST
            if( root.Data< min || root.Data > max)
            {
                return false;
            }

            if(!this.IsBST(min, root.Data, root.Left))
            {
                return false;
            }

            if(!this.IsBST(root.Data,max, root.Right))
            {
                return false;
            }

            return true;
        }
    }
}
