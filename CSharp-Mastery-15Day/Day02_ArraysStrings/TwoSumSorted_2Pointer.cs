using System;
public class TwoSumSolution {
    public int[] TwoSum(int[] nums, int target) 
    {
        int left=0;
        int right=nums.Length-1;
        int sum=0;
        while (left<right)
        {
            sum=nums[left]+nums[right];
            if(sum==target){
                return new int[2]{left,right};
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