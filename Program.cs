using System;

namespace Paradigms
{
	public class Program
	{
		static void Main(string[] args)
		{
			Task1();
			Task2();
			Task3();
			Task4();
		}

		public static void Task1()
		{
			(double x, double y) = Procedural.ConvertFromPolarInDegreesToCartesian(30.0, 5.0);
			Procedural.Print(x, y);

			Point2D point = Point2D.FromPolarInDegrees(30.0, 5.0);
			Console.WriteLine(point);

			Console.WriteLine(
				Polar2D
					.Create((30.0).ToRadians(), 5.0)
					.ToCartesian2D()
					.GetDescription()
			);
		}

		public static void Task2()
		{
			(double detectionX, double detectionY) = Procedural.ConvertFromPolarInDegreesToCartesian(30.0, 5.0);
			(double x, double y) = Procedural.AddPoints(1.0, 3.0, detectionX, detectionY);
			Procedural.Print(x, y);

			Point2D radarPoint = new Point2D(1.0, 3.0);
			Point2D radarDetection = Point2D.FromPolarInDegrees(30.0, 5.0);
			Point2D objectPoint = radarPoint + radarDetection;
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
		}

		public static void Task3()
		{
			double[,] detectedAnglesAndDistances = new double[,]
			{
				{ 30.0, 5.0 },
				{ 32.0, 5.1 },
				{ 31.3, 4.9 },
				{ 32.2, 5.4 }
			};
			double[,] detectionsXY = Procedural.ConvertManyFromPolarInDegreesToCartesian(detectedAnglesAndDistances);
			double[,] detectedPointsXY = Procedural.GetShiftedPoints(detectionsXY, 1.0, 3.0);
			(double averageX, double averageY) = Procedural.GetAveragePoint(detectedPointsXY);
			double deviation = Procedural.GetStandardDeviation(detectedPointsXY, averageX, averageY);
			Console.WriteLine($"Deviation - {deviation}");

			Point2D radarPoint = new Point2D(1.0, 3.0);
			Point2D[] detections = new Point2D[]
			{
				Point2D.FromPolarInDegrees(30.0, 5.0),
				Point2D.FromPolarInDegrees(32.0, 5.1),
				Point2D.FromPolarInDegrees(31.3, 4.9),
				Point2D.FromPolarInDegrees(32.2, 5.4)
			};
			Point2D[] detectedPoints = Point2D.ShiftMany(detections, radarPoint);
			Point2D detectedAveragePoint = MathUtils.GetAverage(detectedPoints);
			double detectedDeviation = MathUtils.GetStandardDeviation(detectedPoints, detectedAveragePoint);
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
		}

		public static void Task4()
		{
			Point3D radarPoint = new Point3D(1.0, 3.0, 2.0);
			Point3D[] detections = new Point3D[]
			{
				Point3D.FromPolarInDegrees(30.0, 45.0, 5.0),
				Point3D.FromPolarInDegrees(32.0, 44.2, 5.1),
				Point3D.FromPolarInDegrees(31.3, 44.7, 4.9),
				Point3D.FromPolarInDegrees(32.2, 45.1, 5.4)
			};

			Points3DCalculator calculator = new Points3DCalculator();

			Point3D[] detectedPoints = calculator.ShiftMany(detections, radarPoint);
			Point3D detectedAveragePoint = calculator.GetAverage(detectedPoints);
			double detectedDeviation = calculator.GetStandardDeviation(detectedPoints, detectedAveragePoint);

			Console.WriteLine($"Deviation 3D - {detectedDeviation}");
		}
	}
}
