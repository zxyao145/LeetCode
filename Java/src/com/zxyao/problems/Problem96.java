package com.zxyao.problems;

/**
 * 不同的二叉搜索树
 */
public class Problem96 {

    public static void mainFunc(){
        Problem96 p = new Problem96();

        System.out.println(p.numTrees(3));
    }

    public int numTrees(int n) {
        if(n == 0 || n == 1) return 1;
        int[] dp = new int[n+1];
        dp[0]=1;
        dp[1]=1;
        //计算dp[i]，n==i的解法
        for (int i = 2; i < dp.length; i++) {
            //将以i为终点，j为中点，将其划分成两部分
            for (int j = 1; j <= i; ++j) {
                dp[i] += dp[j - 1] * dp[i - j];
            }
        }
        return dp[n];
    }

}
