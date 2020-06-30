package com.zxyao.problems;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

/**
 * 242.有效的字母异位词
 */
public class Problem242 {
    public static void mainFunc(){
        Problem242 p = new Problem242();
        String s = "anagram";
        String t = "nagaram";
        System.out.println(p.isAnagram(s,t));
    }
    public boolean isAnagram(String s, String t) {
        if(s.length() != t.length()) return false;

        HashMap<Character, Integer> sMap = new HashMap<>();

        char[] sChars =  s.toCharArray();
        for (char ch : sChars) {
            sMap.put(ch,sMap.get(ch) == null?1:sMap.get(ch)+1);
        }

        char[] tChars =  t.toCharArray();
        for (char ch : tChars) {
            Integer val = sMap.get(ch);
            if(val == null){
                return false;
            }
            sMap.put(ch,val-1);

        }

        for( Map.Entry e : sMap.entrySet()){
            if(!e.getValue().equals(Integer.valueOf(0))){
                return false;
            }
        }
        return true;
    }

}
