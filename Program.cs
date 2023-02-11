using System;

namespace Paradigms
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region Task 1

			Procedural.Task1(30.0, 5.0);

			var point = Point2D.FromPolarInDegrees(30.0, 5.0);
			Console.WriteLine(point);

			Console.WriteLine(
				Polar2D
					.Create((30.0).ToRadians(), 5.0)
					.ToCartesian2D()
					.GetDescription()
			);

			#endregion

			#region Task 2

			Procedural.Task2(1.0, 3.0, 30.0, 5.0);

			var radarPoint = new Point2D(1.0, 3.0);
			var radarDetection = Point2D.FromPolarInDegrees(30.0, 5.0);
			var objectPoint = radarPoint + radarDetection;
			Console.WriteLine(objectPoint);

			Console.WriteLine(
				Cartesian2D
					.Create(1.0, 3.0)
					.Shift(
						Polar2D
							.Create((30.0).ToRadians(), 5.0)
							.ToCartesian2D())
					.GetDescription()
			);

			#endregion
		}
	}
}
