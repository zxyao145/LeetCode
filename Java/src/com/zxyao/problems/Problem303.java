package com.zxyao.problems;

import sun.rmi.runtime.Log;

public class Problem303 {
    public static void mainFunc() {
        int[] nums = new int[] {-2, 0, 3, -5, 2, -1};


        Problem303 p = new Problem303(nums);
        System.out.println(p.sumRange(0, 2));
        System.out.println(p.sumRange(2, 5));
        System.out.println(p.sumRange(0, 5));
    }


    private int[] _sums ;

    public Problem303(int[] nums) {
        if(nums == null|| nums.length == 0){
            return;
        }

        int numsLen = nums.length;
        _sums =  new int[numsLen];
        _sums[0]= nums[0];

        for (int i = 1; i < numsLen; i++) {
            _sums[i] = _sums[i-1] + nums[i];
        }
    }

    public int sumRange(int i, int j) {
        if(i>0){
            return _sums[j]-_sums[i-1];
        }else{
            return _sums[j];
        }
    }
}
