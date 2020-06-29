package com.zxyao.problems;

import java.util.Stack;

/**
 * 232. 用栈实现队列
 */
public class Problem232 {
    public static void mainFunc(){
        MyQueue queue = new MyQueue();

        queue.push(1);
        queue.push(2);
        System.out.println(queue.peek());  // 返回 1
        System.out.println(queue.pop());   // 返回 1
        queue.empty(); // 返回 false

    }

}
class MyQueue {

    Stack<Integer> outStack;
    Stack<Integer> inStack;
    /** Initialize your data structure here. */
    public MyQueue() {
        outStack = new Stack<>();
        inStack = new Stack<>();
    }

    /** Push element x to the back of queue. */
    public void push(int x) {
        inStack.push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int pop() {
        if(outStack.isEmpty()){
            while (!inStack.isEmpty()){
                outStack.push(inStack.pop());
            }
        }
        if(!outStack.isEmpty()){
            return outStack.pop();
        }

        throw new IndexOutOfBoundsException();
    }

    /** Get the front element. */
    public int peek() {
        if(outStack.isEmpty()){
            while (!inStack.isEmpty()){
                outStack.push(inStack.pop());
            }
        }
        if(!outStack.isEmpty()){
            return outStack.peek();
        }

        throw new IndexOutOfBoundsException();
    }

    /** Returns whether the queue is empty. */
    public boolean empty() {
        return outStack.isEmpty() && inStack.isEmpty();
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.push(x);
 * int param_2 = obj.pop();
 * int param_3 = obj.peek();
 * boolean param_4 = obj.empty();
 */