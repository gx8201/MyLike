using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch swatch = new Stopwatch();    //创建Stopwatch 实例
            int[] nums = { 1, 1, 2, 2, 3, 5, 4 };
            leetCodeOneDay oneDay = new leetCodeOneDay();
            //char[] s = "234512".ToCharArray().OrderBy(n=>n).ToArray();
            //oneDay.GroupAnagrams(new string[]{ "eat", "tea", "tan", "ate", "nat", "bat"});
            ////Console.WriteLine(oneDay.ContainsDuplicate());
            //Console.WriteLine(nums.GroupBy(n=>n).Count());
            oneDay.MonotoneIncreasingDigits(100);
            Console.Write("时间-"+DateTime.Now+"-");
            Console.WriteLine("程序退出");
            Console.ReadLine();
        }


        /// <summary>
        /// dota参议院     未完成
        /// </summary>
        /// <param name="senate"></param>
        /// <returns></returns>
        public static string PredictPartyVictory(string senate)
        {
            char[] strA = senate.ToCharArray();
            long r = 0;
            long d = 0;
            int tmpIndex = -1;
            if (strA.Length == 0)
            {
                return "";
            }
            if (strA.Length == 1)
            {
                if (strA[0] == 'R')
                {
                    return "Radiant";
                }
                else
                {
                    return "Dire";
                }
            }
            while (true)
            {
                //foreach (char t in strA)
                for (int i = 0; i < strA.Length; i++)
                {
                    if (!strA[i].Equals('o'))
                    {
                        if (strA[i].Equals('R'))
                        {
                            if (r >= 0)
                            {
                                r++;
                                d--;
                                tmpIndex = strA.ToString().IndexOf('D');
                                if (tmpIndex > -1)
                                {
                                    strA[tmpIndex] = 'o';
                                }
                            }
                            else
                            {
                                r++;
                            }

                        }
                        else
                        {
                            if (d >= 0)
                            {
                                d++;
                                r--;
                                tmpIndex = strA.ToString().IndexOf('R');
                                if (tmpIndex > -1)
                                {
                                    strA[tmpIndex] = 'o';
                                }
                            }
                            else
                            {
                                d++;
                            }
                        }
                    }
                }
                if (r <= 0 || d <= 0)
                {
                    break;
                }
            }
            if (r > d)
            {
                return "Radiant";
            }
            else
            {
                return "Dire";
            }
        }
        /// <summary>
        /// 柠檬水找零
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public static bool LemonadeChange(int[] bills)
        {
            int n5 = 0, n10 = 0;
            foreach (int a in bills)
            {
                if (a == 5)
                {
                    n5++;
                }
                else if (a == 10)
                {
                    n5--;
                    n10++;
                }
                else
                {
                    if (n10 >= 1)
                    {
                        n10--;
                        n5--;
                    }
                    else
                    {
                        n5 -= 3;
                    }
                }
                if (n5 < 0 || n10 < 0)
                {
                    return false;
                }
            }
            return true;
        }

        //public static void Main(String[] args)
        //{
        //    var iArray = new List<int> { 1, 5, 3, 6, 10, 55, 55, 100, 9, 2, 87, 12, 34, 75, 33, 47 };
        //    var newArray = ShellSort(iArray);
        //    Console.WriteLine(string.Join(",", newArray));
        //}

        //public static void preOrder(TreeNode tree)
        //{
        //    if (tree == null)
        //        return;
        //    System.out.printf(tree.val + "");
        //    preOrder(tree.left);
        //    preOrder(tree.right);
        //}
        //public static void preOrder(TreeNode tree)
        //{
        //    if (tree == null)
        //        return;
        //    Stack<TreeNode> q1 = new Stack<>();
        //    q1.push(tree);//压栈
        //    while (!q1.empty())
        //    {
        //        TreeNode t1 = q1.pop();//出栈
        //        System.out.println(t1.val);
        //        if (t1.right != null)
        //        {
        //            q1.push(t1.right);
        //        }
        //        if (t1.left != null)
        //        {
        //            q1.push(t1.left);
        //        }
        //    }
        //}

        public int trap(int[] height)
        {
            int left = 0, right = height.Length - 1, water = 0, bucketHeight = 0;
            while (left < right)
            {
                //取height[left]和height[right]的最小值
                int minHeight = Math.Min(height[left], height[right]);
                //如果最小值minHeight大于桶的高度bucketHeight，要更新桶的高度到minHeight
                bucketHeight = bucketHeight < minHeight ? minHeight : bucketHeight;
                water += height[left] >= height[right] ? (bucketHeight - height[right--]) : (bucketHeight - height[left++]);
            }
            return water;
        }

        /// <summary>
        /// 背包获取最大价值
        /// </summary>
        public static void GetMaxValue()
        {
            int maxW = 4;
            int[] w = { 1, 3, 4 };   // 体积数组
            int[] values = { 100, 200, 250 };
            int[,] dp = new int[w.Length + 1, maxW + 1];
            for (int i = 1; i <= w.Length; i++)
            {
                for (int j = 1; j <= maxW; j++)
                {
                    if (j >= w[i - 1])
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - w[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            Console.WriteLine("输出最大价值" + dp[w.Length, maxW]);
        }

        /// <summary>
        /// 一维数组中取不相邻的数的和的最大值
        /// </summary>
        /// <param name="number"></param>
        /// <param name="i"></param>
        public static int robHelper(int[] numbers,int i )
        {
            if (numbers.Length == 0) return 0;
            else if (numbers.Length == 1) return numbers[0];
            else if (numbers.Length == 2) return Math.Max(numbers[0], numbers[1]);
            if (i < 0)
                return 0;
                
            int last = robHelper(numbers, i - 1);   // 取上一个值时候的最大值
            int _last = robHelper(numbers, i - 2);  // 取当前值的时候的最大值
            int _lastSum = _last + numbers[i];
            return Math.Max(last, _lastSum);
        }




        public static List<String> generateParenthesis(int n)
        {
            List<String> res = new List<String>();
            generate(res, "", 0, 0, n);

            return res;
        }
        //count1统计“(”的个数，count2统计“)”的个数
        public static void generate(List<String> res, String ans, int count1, int count2, int n)
        {

            if (count1 > n || count2 > n) return;

            if (count1 == n && count2 == n) res.Add(ans);


            if (count1 >= count2)
            {
                String ans1 = new String(ans);
                generate(res, ans + "(", count1 + 1, count2, n);
                generate(res, ans1 + ")", count1, count2 + 1, n);

            }
        }

        /// <summary>
        /// 校验括号对称性
        /// </summary>
        public static bool isValid(string validStr)
        {
            Stack<Char> stack = new Stack<char>(validStr.Length);
            foreach (char c in validStr.ToCharArray())
            {
                if (c.Equals('['))
                {
                    stack.Push(']');
                }
                else if (c.Equals('{'))
                {
                    stack.Push('}');
                }
                else if (c.Equals('('))
                {
                    stack.Push(')');
                }
                else if (stack.Count == 0 || !stack.Pop().Equals(c))
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }

        /// <summary>
        /// 判断一个 9x9 的数独是否有效。只需要根据以下规则，验证已经填入的数字是否有效即可。
        /// 数字 1-9 在每一行只能出现一次。
        /// 数字 1-9 在每一列只能出现一次。
        /// 数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。
        //{
        //        board[0]=new char[]{ '5', '3', '.', '.', '7', '.', '.', '.', '.' };
        //    board[1]=new char[]{ '6', '.', '.', '1', '9', '5', '.', '.', '.' };
        //board[2]=new char[]{ '.', '.', '8', '.', '.', '.', '.', '6', '.' };
        //             board[3]=new char[]{ '8', '.', '.', '.', '6', '.', '.', '.', '3' };
        //             board[4]=new char[]{ '4', '.', '.', '8', '.', '3', '.', '.', '1' };
        //             board[5]=new char[]{ '7', '.', '.', '.', '2', '.', '.', '.', '6' };
        //             board[6]=new char[]{ '.', '6', '.', '.', '.', '.', '2', '8', '.' };
        //             board[7]=new char[]{ '.', '.', '.', '4', '1', '9', '.', '.', '5' };
        //             board[8]=new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9' };
        //IsValidSudoku(board);
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValidSudoku(char[][] board)
        {
            if (board == null || board.Length == 0)
            {
                Console.WriteLine(false);
            }
            Dictionary<char, int>[] row = new Dictionary<char, int>[9];//行
            Dictionary<char, int>[] col = new Dictionary<char, int>[9];//列
            Dictionary<char, int>[] box = new Dictionary<char, int>[9];//宫
                                                                       //初始化哈希表
            for (int i = 0; i < 9; i++)
            {
                row[i] = new Dictionary<char, int>();
                col[i] = new Dictionary<char, int>();
                box[i] = new Dictionary<char, int>();
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //当前没有字符 抬走 下一个
                    if (board[i][j].Equals('.'))
                    {
                        continue;
                    }
                    //计算宫的索引
                    int k = i / 3 * 3 + j / 3;
                    //当前元素对应的行集合,列集合,宫集合,都不重复
                    if (!row[i].ContainsKey(board[i][j]) && !col[j].ContainsKey(board[i][j]) && !box[k].ContainsKey(board[i][j]))
                    {
                        row[i].Add(board[i][j], i);
                        col[j].Add(board[i][j], j);
                        box[k].Add(board[i][j], k);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], i);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var anoNum = target - nums[i];
                if (dic.ContainsKey(anoNum))
                {
                    if (dic[anoNum] != i) return new int[] { i, dic[anoNum] };
                }
            }
            return new int[2];
        }

        /// <summary>
        /// 给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。int[] digits = { 8, 9 };
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] plusOne(int[] digits)
        {
            if (digits.Length == 0)
            {
                return new int[0];
            }
            int digitsL = digits.Length;
            int k = 0;  // 进阶位表示
            // 数组排序
            for (int i = digitsL - 1; i >= 0; i--)
            {
                if (i == digitsL - 1 && (digits[i] = digits[i] + 1 + k) > 9)
                {
                    k = 0;
                    digits[i] = 0;
                    ++k;
                }
                else if ((digits[i] = digits[i] + k) > 9)
                {
                    k = 0;
                    digits[i] = 0;
                    ++k;
                }
                else
                {
                    k = 0;
                    return digits;
                }
            }
            if (k > 0)
            {
                digits = new int[digitsL + 1];
                digits[0] = k;

            }
            return digits;
        }

        /// <summary>
        /// 输出两个数组的交集
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 || nums2.Length == 0)
            {
                return new int[0];
            }
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0;
            List<int> vs = new List<int>();
            while (true)
            {
                if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    j++;
                }
                else
                {
                    vs.Add(nums1[i]);
                    i++;
                    j++;
                }
                if (i == nums1.Length || j == nums2.Length)
                {
                    return vs.ToArray();
                }
            }
        }

        /// <summary>
        /// 存在重复值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static Boolean ContainsDuplicate(int[] nums)
        {
            //int count = nums.ToList().GroupBy(n => n).Where(n => n.Count() > 1).Count();
            //if (count>0)
            //{
            //   return true;
            //}else{
            //  return false;
            //}
            HashSet<int> map = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (map.TryGetValue(nums[i], out int target))
                {
                    return true;
                }
                else
                {
                    map.Add(nums[i]);
                }
            }
            return false;
        }

        /// <summary>
        /// 数组偏移      或多次平移
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] rotate(int[] nums, int k)
        {
            //// 数组偏移(轮转)
            //int[] nums = { 1, 2, 3, 4, 5, 6, 7 };   //输入
            //int k = 2;
            int temp, tt;       // 中间变量
            k %= (nums.Length);
            int oindex, index = 0;
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums;
            }

            for (int i = 0; i < k; i++)
            {
                // 变量值获取 替换量值
                // 替换下标记录 赋值
                oindex = index;
                temp = nums[index + k];
                nums[index + k] = nums[index];
                index += k;
                // 内层移位循环
                while (true)
                {
                    if (index + k >= nums.Length)
                    {
                        if (oindex == (index + k - nums.Length))  // 判断循环到的下标是否等于初始下标
                        {
                            // 取下标以及中间量
                            nums[index + k - nums.Length] = temp;
                            index = oindex += 1;
                            //temp = tt = nums[index];
                            break;
                        }
                        else
                        {
                            tt = nums[index + k - nums.Length];
                            // 变量替换
                            nums[index + k - nums.Length] = temp;
                            index += (k - nums.Length);
                            // 循环一轮次数记录
                            i++;
                        }
                    }
                    else
                    {
                        // 中间变量获取被替换位置变量
                        tt = nums[index + k];
                        // 变量替换
                        nums[index + k] = temp;
                        // 下标变更
                        index += k;
                    }
                    // 变更量获取
                    temp = tt;
                }
            }
            return nums;
        }


        //买卖股票的最佳时机 II
        /// <summary>
        /// 给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。
        /// 设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。
        /// </summary>
        /// <param name="prices"></param>
        public static void MaxProfit(int[] prices)
        {
            int sum = 0;
            int[] nums = { 7, 1, 5, 3, 6, 4 };
            nums = prices;
            //int j = 0;
            //外循环遍历数组
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //当前值小于下一个
                if (nums[i] < nums[i + 1])
                {
                    //最大长度 终止循环
                    if ((i + 1) >= nums.Length)
                    {
                        sum += nums[i + 1] - nums[i];
                        break;
                    }
                    //内循环遍历剩余数据
                    int k = i + 1;
                    // 判断 next 的下一个是是否大于 next 继而向下
                    for (; k < nums.Length - 1; k++)
                    {
                        if (nums[k] > nums[k + 1])
                        {
                            sum += nums[k] - nums[i];
                            i = k;
                            break;
                        }
                    }
                    //循环至最大值 都没有大于next值的选择卖出
                    if (k == nums.Length - 1)
                    {
                        sum += nums[i + 1] - nums[i];
                    }
                }
            }
            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("结果输出:↓↓↓↓↓↓↓↓↓↓↓↓↓↓");
            Console.WriteLine(sum);

        }
    }
}
