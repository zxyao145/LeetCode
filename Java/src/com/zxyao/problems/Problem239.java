package com.zxyao.problems;

import java.util.*;

/**
 * 239. 滑动窗口最大值
 */
public class Problem239 {
    public static void mainFunc(){
        Problem239 p = new Problem239();
        int[] nums = {1,3,-1,-3,5,3,6,7};
        int k = 3;
        System.out.println(Arrays.toString(p.maxSlidingWindow(nums,k)));
    }

    public int[] maxSlidingWindow(int[] nums, int k) {
        //#region 以空间换时间
        // 执行用时：2 ms, 在所有 Java 提交中击败了98.88%的用户
        // 内存消耗：50.9 MB, 在所有 Java 提交中击败了6.67%的用户
        if(nums == null || nums.length==0){
            return new int[0];
        }

        int curMax = Integer.MIN_VALUE;

        int maxI = nums.length - k + 1;
        //如果窗口宽度k比数组的个数还要大，直接找出最大的数字，并返回
        if(nums.length<k){
            for (int num : nums) {
                if(curMax<num){
                    curMax = num;
                }
            }
            return new int[]{ curMax };
        }

        //结果数组
        int[] result = new int[maxI];
        result[0] = curMax;

        // curMaxIndex一定要定义的小于0，便于在第一次（i=0）时计算这个窗口的最大值
        int curMaxIndex=-1;

        //遍历窗口的左端开始索引，
        // 因此i是和result中下一个数的索引是对应的
        for (int i = 0; i < maxI; i++) {
            //如果i>curMaxIndex，
            // 表明在i=i-1时，i就是整个窗口的最大元素，需要重新计算最大元素
            if(i > curMaxIndex){
                curMax = Integer.MIN_VALUE;
                for (int j = 0; j < k; j++) {
                    if(curMax<nums[j+i]){
                        curMaxIndex = j+i;
                        curMax = nums[curMaxIndex];
                    }
                }
            }else{
                //判断新加进来的元素是否比最大元素大，
                //是就更新最大元素的信息
                if(nums[i+k-1]>curMax){
                    curMaxIndex = i+k-1;
                    curMax = nums[curMaxIndex];
                }
            }
            //将最大元素放大结果数组中
            result[i] = curMax;
        }

        return result;
        // #endregion

        // #region 使用Deque
        // 执行用时：18 ms, 在所有 Java 提交中击败了39.36%的用户
        // 内存消耗：54.1 MB, 在所有 Java 提交中击败了6.67%的用户
//        int outer = nums.length - k + 1;
//        int[] result = new int[outer];
//        Deque<Integer> window = new LinkedList<>();
//        for (int i = 0; i < nums.length; i++) {
//            int curNum = nums[i];
//
//            if (i >= k && i - k + 1 > window.peek()) {
//                window.removeFirst();
//            }
//
//            while (!window.isEmpty() && nums[window.peekLast()] < curNum){
//                window.removeLast();
//            }
//
//            window.add(i);
//            if(i-k+1>-1){
//                result[i-k+1] = nums[window.peek()];
//            }
//        }
//
//        return result;
        //#endregion
    }
}
