package com.zxyao.problems;

/**
 * 392. 判断子序列
 * 执行用时：5 ms, 在所有 Java 提交中击败了42.99%的用户
 * 内存消耗：38.3 MB, 在所有 Java 提交中击败了100.00%的用户
 */
public class Problem392 {
    public static void mainFunc() {
        Problem392 p = new Problem392();
        String s = "abc";
        String t = "ahbgdc";

        System.out.println(p.isSubsequence(s, t));
    }

    /**
     * 判断 s 是否为 t 的子序列
     *
     * @param s
     * @param t
     * @return
     */
    public boolean isSubsequence(String s, String t) {
        int sLen = s.length();
        int tLen = t.length();
        if (sLen == 0) {
            return true;
        }
        char[][] status = new char[sLen + 1][tLen + 1];

        //如果sLen == 0, 则s为任意 t 的子字符串
        for (int i = 0; i <= tLen; i++) {
            status[0][i] = 't';
        }
        //先遍历第一维度
        for (int j = 0; j < sLen; j++) {
            for (int i = 0; i < tLen; i++) {
                if (s.charAt(j) == t.charAt(i)) {
                    status[j + 1][i + 1] = status[j][i];
                } else {
                    status[j + 1][i + 1] = status[j + 1][i];
                }
            }
        }

        return status[sLen][tLen] == 't';
    }
}
