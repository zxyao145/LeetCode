package com.zxyao.problems;

import com.zxyao.TreeNode;

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
