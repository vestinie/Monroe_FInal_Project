using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monroe_FInal_Project
{
    public class LeetCode_Problem_123
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;

            int[] left = new int[n];   // Max profit up to day i
            int[] right = new int[n];  // Max profit from day i to end

            // Fill left[]: max profit from 0 to i
            int minPrice = prices[0];
            for (int i = 1; i < n; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                left[i] = Math.Max(left[i - 1], prices[i] - minPrice);
            }

            // Fill right[]: max profit from i to n-1
            int maxPrice = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                right[i] = Math.Max(right[i + 1], maxPrice - prices[i]);
            }

            // Combine both transactions
            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, left[i] + right[i]);
            }

            return maxProfit;
        }
}