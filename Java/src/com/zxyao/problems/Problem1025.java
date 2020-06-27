package com.zxyao.problems;

/**
 * 1025. 除数博弈
 */
public class Problem1025 {
    public static void mainFunc() {
        Problem1025 p = new Problem1025();
        System.out.println(p.divisorGame(3));
    }

    public boolean divisorGame(int N) {
        if (N == 1) return false;
        char[] dp = new char[N + 1];
        dp[2] = 't';

        for (int i = 3; i < N + 1; i++) {
            for (int j = 1; j < i; j++) {
                if (i % j == 0 && dp[i-j] != 't') {
                    dp[i] = 't';
                    break;
                }
            }
        }
        return dp[N] == 't';
    }
}
