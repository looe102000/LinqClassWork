using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqClassWork
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CWOne();
            CWTwo();
            CWThree();
            CWFour();
            CWFive();
            CWSix();

            Console.ReadLine();
        }

        private static void CWSix()
        {
            Console.WriteLine("TakeWhile SkipWhile 練習");
            Console.WriteLine();
            int[] data = { 4, 3, 2, 4, 8 };

            foreach (var item in data.TakeWhile((a, index) => a > 1 && a < 5))
            {
                Console.WriteLine("TakeWhile");
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("SkipWhile 練習");
            Console.WriteLine();

            foreach (var item in data.SkipWhile((a, index) => a > 1 && a < 5 && index < 2))
            {
                Console.WriteLine("SkipWhile");
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void CWFive()
        {
            Person2[] data1 = {
            new Person2() { ID = 1, Name = "code6421", Age = 10 },
            new Person2() { ID = 2, Name = "mary", Age = 11 },
            new Person2() { ID = 3, Name = "mark", Age = 12 } };

            Console.WriteLine("Linq 取得 a 出現的次數 方法1");

            var countA = data1.Select(a => a.Name.ToArray().Where(s => s == 'a').Count()).Sum();
            Console.WriteLine(countA);
            Console.WriteLine();

            Console.WriteLine("Linq 取得 a 出現的次數 方法2");
            //you want know how many 'a' in the collection
            var countB = (from s in data1
                          let name = s.Name
                          where name.Contains('a')
                          select (from c in name where c == 'a' select c).Count()).Sum();

            Console.WriteLine(countB);

            Console.WriteLine();
        }

        private static void CWFour()
        {
            //使用 linq 查出 含有 b 的元素
            Console.WriteLine("使用 linq 查出 含有 b 的元素 ");

            string[] data2 = { "aa", "t", "cccccdd", "cb", "db", "tb" };
            var result3 = from s1 in data2 where s1.Contains("b") select s1;
            foreach (var item in result3)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //string 陣列找出符合的元素
            Console.WriteLine("string 陣列找出符合的元素");

            string[] infilter = { "bbbbb", "ccccc" };

            var result4 = from s1 in data2 where infilter.Contains(s1) select s1;
            foreach (var item in result4)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        private static void CWThree()
        {
            int[] data = { 1, 3, 5, 7, 9 };
            //IEnumerator 迭代子 ；底下實作內容與 for each 效果差不多

            Console.WriteLine("IEnumerator 迭代子 ；底下實作內容與 for each 效果差不多 ");
            IEnumerator iterator = data.GetEnumerator();

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.ToString());
            }
            Console.WriteLine();
        }

        private static void CWTwo()
        {
            //Linq 取得 Windows 資料夾中 .exe 檔案

            Console.WriteLine("Windows 資料夾中 .exe 檔案");
            var result1 = from s1 in Directory.GetFiles(@"C:\\Windows")
                          where s1.EndsWith(".exe")
                          select s1;

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Windows 資料夾中 drivers.ini");

            var result2 = from s1 in Directory.GetFiles(@"C:\\Windows", "*.ini")
                          let content = File.ReadAllText(s1)
                          where content.Contains("drivers")
                          select s1;

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void CWOne()
        {
            int[] data = { 1, 3, 5, 7, 9 };

            //原始版本

            Console.WriteLine("原始版本");
            foreach (var item in Filter(data, (s) => s > 5))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Console.ReadLine();

            //Linq 版

            Console.WriteLine("Linq 版");
            var result = from s1 in data where s1 > 5 select s1;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        //原始版本
        private static List<T> Filter<T>(T[] source, Func<T, Boolean> func)
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (func(item))
                    result.Add(item);
            }
            return result;
        }
    }

    internal class Person2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}