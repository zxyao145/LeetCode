package com.zxyao.problems;

import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class Problem169 {
    public int majorityElement(int[] nums) {
        Map<Integer,Integer> counter = new HashMap<>();
        int majorityLength = nums.length / 2;
        for (int num : nums) {
            if(counter.containsKey(num)){
                int oldCount = counter.get(num)+1;
                if(oldCount > majorityLength){
                    return num;
                }
                counter.put(num, oldCount);
            }else{
                counter.put(num,1);
            }
        }
        Map.Entry<Integer, Integer> entry = counter.entrySet().iterator().next();

        return entry.getKey();
    }
}
