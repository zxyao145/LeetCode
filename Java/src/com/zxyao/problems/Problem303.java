package com.zxyao.problems;

import sun.rmi.runtime.Log;

public class Problem303 {
    public static void mainFunc() {
        int[] nums = new int[] {-4,-5};

        Problem303 p = new Problem303(nums);
        System.out.println(p.sumRange(0, 0));
        System.out.println(p.sumRange(1,1));
        System.out.println(p.sumRange(0,1));
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
