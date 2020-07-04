package com.zxyao.problems;

import com.zxyao.TreeNode;

public class Problem235 {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        while(root!= null){
            if(root.val < p.val && root.val <q.val){
                root = root.right;
            }else  if(root.val > p.val && root.val> q.val){
                root = root.left;
            }else{
                return root;
            }
        }
        return root;
    }
}
