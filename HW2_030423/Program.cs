using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW2_030423
{
	internal class Program
	{
		static void Main()
		{
			IStrategy SimpleNavigator = new TaxiStrategy();

			(double time, double price) res = SimpleNavigator.Calculate((1, 8), (32, - 2));

			Console.WriteLine(
				$"Time = {res.time}\n" +
				$"Price = {res.price}");

			Console.ReadKey(true);
		}

		public interface IStrategy
		{
			//	(x, y) - кортеж
			(double time, double price) Calculate((double x, double y) start, (double x, double y) finish);
		}

		public class BicycleStrategy : IStrategy
		{
			public (double time, double price) Calculate((double x, double y) start, (double x, double y) finish)
			{
				(double time, double price) res;

				double S = (start.x + start.y) - (finish.x + finish.y);	// Путь
				if (S < 0) S = -S;

				res.time = S * 3;	// время
				res.price = 0;		// цена

				return res;
			}
		}

		public class BusStrategy : IStrategy
		{
			public (double time, double price) Calculate((double x, double y) start, (double x, double y) finish)
			{
				(double time, double price) res;

				double S = (start.x + start.y) - (finish.x + finish.y);
				if(S < 0) S = -S;

				res.time = S * 2;
				res.price = 20;

				return res;
			}
		}

		public class TaxiStrategy : IStrategy
		{
			public (double time, double price) Calculate((double x, double y) start, (double x, double y) finish)
			{
				(double time, double price) res;

				double S = (start.x + start.y) - (finish.x + finish.y);
				if (S < 0) S = -S;

				res.time = S;
				res.price = S * 2;

				return res;
			}
		}
	}
}
