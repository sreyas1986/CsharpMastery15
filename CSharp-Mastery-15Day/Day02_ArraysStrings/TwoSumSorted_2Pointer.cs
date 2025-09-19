using System;
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int left=0;
        int right=nums.length-1;
        while (left<right)
        {
            sum=nums[left]+nums[right]
            if(sum==target){
                return new int[]{left,right};
            }
            else if (sum <target)
            {
                left++;
            }
            else{
                right++;
            }
        }
        return new int[0];
    }

  }