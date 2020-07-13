package com.zxyao.problems;

import java.util.Stack;

public class Problem32 {



    public int longestValidParentheses(String s) {
        if(s == null || s == "") return 0;
        int sLen = s.length();
        Stack<Integer> stack = new Stack<>();
        stack.push(-1);
        int maxans = 0;
        for (int i = 0; i < sLen; i++) {
            char ch = s.charAt(i);
            if(ch == '('){
                stack.push(i);
            }else{
                stack.pop();
                if(stack.isEmpty()){
                    stack.push(i);
                }else{
                    int popVar = stack.peek();
                    maxans = Math.max(maxans, i - popVar);
                }
            }
        }
        return maxans;
    }
}
