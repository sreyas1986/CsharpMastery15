//Given an array of integers and a number k, find the maximum sum of any contiguous subarray of size k.
//Sliding Window pattern
using System;
public class SubSolution{

    public static void Main6(){
        int[] arr = {2, 1, 5, 1, 3, 2};
        int k = 3;
        Console.WriteLine(MaxSumSubarray(arr,k));

    }
    private static int MaxSumSubarray(int[] arr,int k){
        int maxSum=0;
        int windowSum=0;
        for (int i = 0; i < k; i++)
        {
            windowSum+=arr[i];
        }
        for (int i = k; i < arr.Length; i++)
        {
            // FOr the 1st iteratoion 8+1-2 windowsum 2+1+5 arr[k]==arr[4] 1 then arr [i-k] arr[3-3] arr[0]=1
             windowSum = windowSum+arr[i]-arr[i-k];
             maxSum=Math.Max(windowSum,maxSum);
        }
        return maxSum;
    }
}