package com.zxyao.problems;

/**
 * 使用最小花费爬楼梯
 */
public class Problem746 {

    public static void mainFunc() {
        Problem746 p = new Problem746();
        int[] cost = new int[]{
                0, 1, 2, 2
        };
        System.out.println(p.minCostClimbingStairs(cost));
    }

    public int minCostClimbingStairs(int[] cost) {
        int n = cost.length;
        int[] result = new int[n];
        result[0]= cost[0];
        result[1] = cost[1];
        for (int i = 2; i < n; i++) {
            int min = Math.min((cost[i] + result[i-1]),cost[i] + result[i-2]);
            result[i]=  min;
        }

        return Math.min(result[n - 2], result[n - 1]);
    }
}
