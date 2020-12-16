using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// leetCode每日一题
    /// </summary>
    class leetCodeOneDay
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            var checks = new HashSet<int>();
            foreach (int n in nums)
            {
                if (checks.Add(n) == false)
                {
                    return true;
                }
            }
            return false;
            //if (nums.Length > 0)
            //{
            //    if (nums.GroupBy(n => n).Count() == nums.Length)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 字母异位词分组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach(string s in strs)
            {
                string str = string.Join("",s.ToCharArray().OrderBy(n => n).ToList());
                if (dic.ContainsKey(str))
                {
                    dic[str].Add(s);
                }
                else
                {
                    dic.Add(str,new List<string>() { s});
                    
                }
            }
            var dd = dic.Values;
            IList<IList<string>> ss = new List<IList<string>>();
            foreach(var l in dic)
            {
                List<string> ls = new List<string>();
                foreach(var em in l.Value)
                {
                    ls.Add(em);
                }
                ss.Add(ls);
            }
            return ss;
            //new ArrayList(dic.Values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int MonotoneIncreasingDigits(int N)
        {
            //Stack<int>
            List<int> intList = new List<int>();
            while (N > 0)
            {
                intList.Insert(0, N%10);
                N = N / 10;
            }
            int [] aaa=re(intList.ToArray(), 0);
            int tmpNum = 0;
            foreach(int a in aaa)
            {
                tmpNum = tmpNum * 10 + a;
            }
            
            return tmpNum;
        }
        public int[] re(int[] nums,int n)
        {
            if (n == nums.Length)
            {
                return nums;
            }
            else
            {
                if (n == 0)
                {
                    //if (nums[n] == 1)
                    //{
                    //    nums[n] = 0;
                    //}
                    re(nums, n + 1);
                }
                else
                {
                    if (nums[n - 1] <= nums[n] || nums[n - 1] == 0)
                    {
                        if (nums[n] == 0)
                        {
                            nums[n] = 9;
                        }
                        re(nums, n + 1);
                    }
                    else
                    {
                        //if(nums[n - 1] - 1 <= 0)
                        //{
                        //    nums[n - 1] = 9;
                        //}
                        //else
                        //{
                            nums[n - 1] = nums[n - 1] - 1;
                        //}
                        
                        re(nums, n-1);
                        nums[n] = 9;
                    }
                }
            }
            return nums;
        }
    }
}
