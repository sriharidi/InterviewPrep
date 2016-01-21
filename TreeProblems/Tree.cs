using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblems
{
    public class Tree
    {
        private TreeNode root;

        public Tree(TreeNode root)
        {
            this.root = root;
        }

        public void BstInsert(int val)
        {
            this.InternalBstInsert(val, root);
        }

        private TreeNode InternalBstInsert(int val, TreeNode root)
        {
            if(root == null)
            {
                return new TreeNode(val);
            }

            if(val < root.Data)
            {
                root.Left = this.InternalBstInsert(val, root.Left);
            }
            else
            {
                root.Right = this.InternalBstInsert(val, root.Right);
            }

            return root;
        }

        public void InorderTraversal()
        {
        }

        public void PreorderTraversal()
        {
        }

        public void PostorderTraversal()
        {
        }

        public void Print()
        {
            if( this.root == null)
            {
                Console.WriteLine("Empty tree");
            }

            Console.WriteLine("@@@@@@@@TREE@@@@@@@@@@@");
            TreeNode tr = this.root;

            List<TreeNode> currentList = new List<TreeNode>();
            currentList.Add(this.root);

            //formatting
            // int tabCount = 10;
            while(currentList.Count>0)
            {
                List<TreeNode> nextList = new List<TreeNode>();

                // for (int i = 0; i < tabCount; ++i) { Console.Write("\t"); } tabCount--;

                for (int i = 0; i < currentList.Count; ++i )
                {
                    Console.Write("{0:D2}\t", currentList[i]);
                    if (currentList[i].Left != null)
                        nextList.Add(currentList[i].Left);
                    if (currentList[i].Right != null)
                        nextList.Add(currentList[i].Right);
                }

                currentList = nextList;
            }

            Console.WriteLine("########TREE###########");
        }

        private void InternalPrint(TreeNode r)
        {

        }
    }
}
