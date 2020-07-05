package com.zxyao.problems;

import com.zxyao.TreeNode;

/**
 * 二叉树最小深度
 */
public class Problem111 {
    public int minDepth(TreeNode root) {
        if(root == null) return 0;
        dfs(root,1);

        return min;
    }

    int min = Integer.MAX_VALUE;
    public void dfs(TreeNode node, int curLevel){
        if(node == null) return;

        if(node.left == null && node.right == null){
            min = curLevel< min?curLevel:min;
        }

        dfs(node.left,curLevel+1);
        dfs(node.right,curLevel+1);
    }
}


