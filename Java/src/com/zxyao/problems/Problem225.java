package com.zxyao.problems;

import java.util.LinkedList;
import java.util.Queue;

/**
 * 225. 用队列实现栈
 */
public class Problem225 {
    public static void mainFunc(){
        Problem225 p = new Problem225();
        MyStack obj = new MyStack();
        obj.push(2);
        obj.push(1);
        int param_2 = obj.pop();
        int param_3 = obj.top();
        boolean param_4 = obj.empty();
//        System.out.println(p.reverseList(head));
    }
}

class MyStack {
    Queue<Integer> a;
    Queue<Integer> b;
    /** Initialize your data structure here. */
    public MyStack() {
        a = new LinkedList<>();
        b = new LinkedList<>();
    }

    /** Push element x onto stack. */
    public void push(int x) {
        if(a.isEmpty()){
            b.add(x);
        }else{
            a.add(x);
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int pop() {
        if(a.isEmpty()){
            while (b.size()>1){
                a.add(b.remove());
            }
            if(b.size() == 1){
                return b.remove();
            }
        }
        else{
            while (a.size()>1){
                b.add(a.remove());
            }
            if(a.size() == 1){
                return a.remove();
            }
        }
        throw new IndexOutOfBoundsException();
    }

    /** Get the top element. */
    public int top() {
        if(a.isEmpty()){
            while (b.size()>1){
                a.add(b.remove());
            }
            if(b.size() == 1){
                int val = b.remove();
                a.add(val);
                return val;
            }
        }
        else{
            while (a.size()>1){
                b.add(a.remove());
            }
            if(a.size() == 1){
                int val = a.remove();
                b.add(val);
                return val;
            }
        }
        throw new IndexOutOfBoundsException();
    }

    /** Returns whether the stack is empty. */
    public boolean empty() {
        return a.isEmpty() && b.isEmpty();
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.push(x);
 * int param_2 = obj.pop();
 * int param_3 = obj.top();
 * boolean param_4 = obj.empty();
 */
