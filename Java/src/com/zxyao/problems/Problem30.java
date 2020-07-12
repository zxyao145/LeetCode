package com.zxyao.problems;

import java.lang.reflect.Array;
import java.util.*;

public class Problem30 {

    public static void mainFunc() {
        String s = "barfoothefoobarman";
        String[] words = {"foo", "bar"};

        Problem30 p = new Problem30();

        System.out.println(Arrays.toString(p.findSubstring(s,words).toArray()));
    }


    public List<Integer> findSubstring(String s, String[] words) {
        List<Integer> result = new ArrayList<>();
        if(s == null || s== ""){
            return result;
        }
        if(words == null || words.length == 0){
            return result;
        }
        Map<String,Integer> oWordsDict = new HashMap<>();
        for (String word : words) {
            if(oWordsDict.containsKey(word)){
                oWordsDict.put(word, oWordsDict.get(word) + 1);
            }else{
                oWordsDict.put(word,1);
            }
        }
        Map<String,Integer> wordsDict =  new HashMap<>(oWordsDict);

        int wordLength = words[0].length();
        int length = wordLength * words.length;
        int endIndex = s.length() - length + 1;
        for (int i = 0; i < endIndex; i++) {
            String temp = s.substring(i, i + length);
            for (int j = 0; j < length; j += wordLength) {
                String curWord = temp.substring(j, j+ wordLength);
                if(wordsDict.containsKey(curWord)){
                    wordsDict.put(curWord, wordsDict.get(curWord)-1);
                }
            }
            boolean isMatch = true;
            for (Map.Entry<String, Integer> stringIntegerEntry : wordsDict.entrySet()) {
                if(stringIntegerEntry.getValue() != 0) {
                    isMatch = false;
                }
                wordsDict.put(stringIntegerEntry.getKey(),oWordsDict.get(stringIntegerEntry.getKey()));
            }
            if(isMatch){
                result.add(i);
            }
        }

        return result;
    }
}
