using System.Security.AccessControl;
using System.Linq;

List<int> num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var env = num.Where(x => x % 2 == 0);

num.Add(10);

System.Console.WriteLine(string.Join(",", env));

Console.ReadLine();
