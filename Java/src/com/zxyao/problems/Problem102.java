package com.zxyao.problems;

import com.zxyao.TreeNode;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class Problem102 {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> result = new ArrayList<>();
        if(root == null){
            return result;
        }

        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        while (!queue .isEmpty()){
            int size = queue.size();

            List<Integer> curLevel = new ArrayList<>();

            for (int i = 0; i < size; i++) {
                TreeNode cur = queue.poll();
                curLevel.add(cur.val);
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            result.add(curLevel);
        }

        return result;
    }
}
