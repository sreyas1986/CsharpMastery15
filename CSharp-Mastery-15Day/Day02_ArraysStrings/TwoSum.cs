// TwoSum.cs
// Two Sum problem solution
using System;
using System.Collections.Generic;
public class TwoSolution {
    public int[] TwoSum(int[] nums, int target) {
   Dictionary<int,int> result= new Dictionary<int,int>();

  for(int i=0;i<nums.Length;i++){
   int compliment = target-nums[i];
   if(result.ContainsKey(compliment)){
    return new int[] {result[compliment],i};
   }
   result[nums[i]]=i;

  }
  return new int[0];

    }
     public int[] TwoSum_Easyoption(int[] nums, int target) {
        int[] output= new int[2];
        for(int i=0;i<nums.Length-1;i++){

            for(int j=i+1;j<nums.Length;j++){
                if(nums[i]+nums[j]==target){

                        output[0]=i;
                        output[1]=j;
                        break;
                }
            }
            if(output[1]>0){
                break;

            }
            
        }
        return output;
    }
}