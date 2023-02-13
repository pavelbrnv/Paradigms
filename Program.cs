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

			#region Task 3

			radarPoint = new Point2D(1.0, 3.0);
			var detections = new Point2D[]
			{
				Point2D.FromPolarInDegrees(30.0, 5.0),
				Point2D.FromPolarInDegrees(32.0, 5.1),
				Point2D.FromPolarInDegrees(31.3, 4.9),
				Point2D.FromPolarInDegrees(32.2, 5.4)
			};
			var detectedPoints = new Point2D[]
			{
				radarPoint + detections[0],
				radarPoint + detections[1],
				radarPoint + detections[2],
				radarPoint + detections[3]
			};
			var detectedAveragePoint = MathUtils.GetAverage(detectedPoints);
			var detectedDeviation = MathUtils.GetStandardDeviation(detectedPoints, detectedAveragePoint);
			Console.WriteLine($"Deviation - {detectedDeviation}");

			#endregion
		}
	}
}
