using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils
{
	public static class Extension
	{
		public static int Count<String>(this string self)
		{
			// В задание именно найти количество символов в строке, думаю оно либо неправильно сформулировано 
			// в методичке, либо я его не так понял
			return self.Length;
		}
	}
}
