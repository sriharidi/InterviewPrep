using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblems
{
    internal class MaxBstResult
    {
        public bool IsBST;
        public int TotalNodes;
        public int LeftVal;
        public int RightVal;
    }

    public partial class Problems
    {
        /// <summary>
        /// Find max BXT in a given tree
        /// </summary>
        /// <returns>Sixe of the tree(total nodes)</returns>
        public int GetMaxBstInGivenTree(TreeNode root)
        {

            return this.InternalGetMaxBstInGivenTree(root).TotalNodes;
        }

        private  MaxBstResult InternalGetMaxBstInGivenTree(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }

            MaxBstResult lResult = this.InternalGetMaxBstInGivenTree(root.Left);
            MaxBstResult rResult = this.InternalGetMaxBstInGivenTree(root.Right);

            // Need to handle 4 conditions on the pre order traversal..
            if( lResult == null && rResult == null)
            {
                return new MaxBstResult{IsBST=true,TotalNodes=1,LeftVal=root.Data, RightVal=root.Data};
            }
            else if ( lResult != null && rResult != null)
            {
                if(
                    lResult.LeftVal <= root.Data 
                    && rResult.RightVal>= root.Data
                    && lResult.IsBST
                    && rResult.IsBST)
                {
                    return new MaxBstResult { IsBST = true, TotalNodes = lResult.TotalNodes + rResult.TotalNodes + 1, LeftVal = lResult.LeftVal, RightVal = rResult.RightVal };
                }
                else
                {
                    return new MaxBstResult{IsBST=false, TotalNodes= Math.Max(lResult.TotalNodes, rResult.TotalNodes), LeftVal =0, RightVal=0};
                }
            }
            else if (lResult==null)
            {
                if( rResult.IsBST
                    && root.Data <= rResult.LeftVal)
                {
                    return new MaxBstResult{IsBST=true,TotalNodes=rResult.TotalNodes+1, LeftVal=root.Data,RightVal=rResult.RightVal};
                }
                else
                {
                    return new MaxBstResult{IsBST=false,TotalNodes=rResult.TotalNodes, LeftVal=0, RightVal=0};
                }
            }
            else
            {
                if (lResult.IsBST
                    && root.Data >= lResult.RightVal)
                {
                    return new MaxBstResult { IsBST = true, TotalNodes = lResult.TotalNodes + 1, LeftVal = lResult.LeftVal, RightVal = root.Data};
                }
                else
                {
                    return new MaxBstResult { IsBST = false, TotalNodes = lResult.TotalNodes, LeftVal = 0, RightVal = 0 };
                }
            }
        }
    }
}
