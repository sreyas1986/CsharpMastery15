// LongestSubstring.cs
// Longest Substring Without Repeating Characters
// This is a Sliding window pattern
using System;
using System.Collections.Generic;
public class LenSolution {
    public int LengthOfLongestSubstring(string s) 
    {

     Dictionary<char,int> lastSeen = new Dictionary<char,int>();
     int maxLength=0; // stores the length of the longest subarray;
     int start=0;//start index
     //Loop through each character in the string using index i
        for(int i=0; i<s.Length;i++)
        {
            // If the character was seen before and is inside the current window
            if(lastSeen.ContainsKey(s[i])&& lastSeen[s[i]] > start){
                // Move the start of the window to one position after the last occurrence
                // This effectively "slides" the window forward past the duplicate
              //  start=lastSeen[i]+1;
            }

            // Update the last seen index of the current character
                lastSeen[s[i]] = i;
            // Calculate the current window size and update maxLength if it's larger
         //   maxLength = Math.Max(maxLength, i - start + 1);

        }
        return 0;
    }


    }