package com.zxyao.problems;

/**
 * 爬楼梯
 */
public class Problem70 {
    public static void mainFunc() {

        Problem70 p = new Problem70();
        System.out.println(p.climbStairs(4));

    }

    public int climbStairs(int n) {
        if (n == 0) return 1;
        if (n == 1) return 1;
        if (n == 2) return 2;
        int max = n+1;
        int last2=1;
        int last1=2;
        int result = last1 + last2;
        for (int i = 3; i < max; i++) {
            result = last1+last2;
            last2 = last1;
            last1 = result;
        }
        return result;
    }
}
