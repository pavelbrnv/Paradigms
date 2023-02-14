using System;

namespace Paradigms
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region Task 1
			
			(double x, double y) = Procedural.ConvertFromPolarToCartesian(30.0, 5.0);
			Procedural.Print(x, y);

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

			(x, y) = Procedural.GetDetectedPoint(1.0, 3.0, 30.0, 5.0);
			Procedural.Print(x, y);

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

			var detectedAnglesAndDistances = new[,]
			{
				{ 30.0, 5.0 },
				{ 32.0, 5.1 },
				{ 31.3, 4.9 },
				{ 32.2, 5.4 }
			};
			double[,] detectedPointsXY = Procedural.GetDetectedPoints(1.0, 3.0, detectedAnglesAndDistances);
			(double averageX, double averageY) = Procedural.GetAveragePoint(detectedPointsXY);
			double deviation = Procedural.GetStandardDeviation(detectedPointsXY, averageX, averageY);
			Console.WriteLine($"Deviation - {deviation}");

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

			Console.WriteLine("Deviation - {0}",
				Cartesian2D
					.CreateMany(
						Polar2D.Create((30.0).ToRadians(), 5.0).ToCartesian2D(),
						Polar2D.Create((32.0).ToRadians(), 5.1).ToCartesian2D(),
						Polar2D.Create((31.3).ToRadians(), 4.9).ToCartesian2D(),
						Polar2D.Create((32.2).ToRadians(), 5.4).ToCartesian2D())
					.ShiftMany(Cartesian2D.Create(1.0, 3.0))
					.GetStandardDeviationFromAverage()
			);

			#endregion
		}
	}
}
