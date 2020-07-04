package com.zxyao.problems;

import javax.transaction.TransactionRequiredException;

public class Problem98 {

    private Integer lastVal;

    public boolean isValidBST(TreeNode root) {
        if(root == null) {
            return true;
        }
        boolean left = isValidBST(root.left);
        if(!left) return false;
        if(lastVal != null){
            if(lastVal.intValue() >= root.val){
                return false;
            }
        }
        lastVal = root.val;


        return isValidBST(root.right);
    }
}

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;

    TreeNode(int x) {
        val = x;
    }
}