package com.zxyao.problems;

/**
 * 1139, 最大的以 1 为边界的正方形
 */
public class Problem1139 {
    public static void mainFunc(){
        Problem1139 p = new Problem1139();
        int[][] grid = {{0,0,0,1}};

        System.out.println(p.largest1BorderedSquare(grid));
    }

    public int largest1BorderedSquare(int[][] grid) {
        int lenGrid = grid.length + 1;
        int innerLen = grid[0].length + 1;

        //i,j,0:左面有几个连续的1
        //i,j,1:上面有几个连续的1
        int[][][] dp = new int[lenGrid][innerLen][2];
        int res = 0;
        //行
        for (int i = 1; i < lenGrid; i++) {
            //列
            for (int j = 1; j < innerLen; j++) {
                int minEdge = 0;
                if(grid[i-1][j-1] == 1){
                    dp[i][j][0] = dp[i][j-1][0]+1;
                    dp[i][j][1] = dp[i-1][j][1]+1;

                    minEdge = Math.min(dp[i][j][0],dp[i][j][1]);

                    while(minEdge > 0){
                        //判断左下角上方和右上角左方1的个数能不能构成正方形
                        if(dp[i][j - minEdge][1]  > minEdge &&  dp[i - minEdge][j][0] > minEdge)
                            break;
                        minEdge--;    //若不能就取次小的边长
                    }
                    //minEdge+自己本身为边长
                    res = Math.max(res, minEdge + 1);
                }
            }
        }
        return res*res;
    }
}
