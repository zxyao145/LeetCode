package com.zxyao.problems;

import com.zxyao.TreeNode;

public class Problem104 {

    public int maxDepth(TreeNode root) {
        if(root == null) return 0;
        max = 1;
        dfs(root,1);
        return max;
    }

    int max = Integer.MIN_VALUE;
    public void dfs(TreeNode node, int curLevel){
        if(node == null) return;

        if(node.left == null && node.right == null){
            max = curLevel> max?curLevel:max;
        }

        dfs(node.left,curLevel+1);
        dfs(node.right,curLevel+1);
    }


}
