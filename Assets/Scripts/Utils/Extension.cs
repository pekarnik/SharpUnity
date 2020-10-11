using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils
{
	public static class Extension
	{
		public static int Count(this string self)
		{
			// В задание именно найти количество символов в строке, думаю оно либо неправильно сформулировано 
			// в методичке, либо я его не так понял
			return self.Length;
		}
		public static Dictionary<T,int> ElCount0<T>(this List<T> list)
		{
			//a+b часть
			Dictionary<T, int> res= new Dictionary<T, int>();
			list.Sort();
			int ind = 0;
			res.Add(list[ind], 1);
			for(var i = 1;i<list.Count;i++)
			{
				if(list[ind].Equals(list[i]))
				{
					res[list[ind]]++;
				}
				else
				{
					res.Add(list[i], 1);
					ind = i;
				}
			}
			//c часть
			var uniqList = list.Distinct();
			List<int> resList = new List<int>();
			foreach(T t in uniqList)
			{
				resList.Add(list.Count(s => s.Equals(t)));
			}
			return res;
		}
	}
}
