using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xylia.Preview.Common.Extension
{
	public static class MyRandom
	{
		private static Random[] m_RandomStream;

		/// <summary>
		/// 公共随机数流
		/// </summary>
		public static Random[] RandomStream
		{
			get
			{
				if (m_RandomStream is null)
				{
					var temp = new List<Random>();
					for (int i = 0; i < 100; i++)
						temp.Add(new Random());

					m_RandomStream = temp.ToArray();
				}


				return m_RandomStream;
			}
		}
	}
}
