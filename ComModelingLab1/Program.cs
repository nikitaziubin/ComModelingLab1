
using System.Runtime.InteropServices;

internal class Program
{
	public static double[] LaguerreX(int n)
	{
		if (n == 1)
		{
			return new double[1] { 1 };
		}
		else if (n == 2)
		{
			return new double[2] { 0.59, 3.41 };
		}
		else if (n == 3)
		{
			return new double[3] { 0.42, 2.29, 6.29 };
		}
		else if ((n == 4))
		{
			return new double[4] { 0.33, 1.75, 4.54, 9.4 };
		}
		return new double[0];
	}
	public static List<double> Ck(double[] Xk)
	{
		//double[] Ck = new double[3];
		List<double> Ck = new List<double>();
		int i = 0;
		foreach (var x in Xk)
		{
			if (Xk.Length == 2)
			{
				Ck.Add(4 / (x * Math.Pow(2 * x - 4, 2)));
			}
			else if (Xk.Length == 3)
			{
				Ck.Add(36 / (x * Math.Pow((-3 * Math.Pow(x, 2) + 18 * x - 18), 2)));
			}
			else if (Xk.Length == 4)
			{
				Ck.Add(576 / (x * Math.Pow(4 * Math.Pow(x, 3) - 48 * Math.Pow(x, 2) + 144 * x - 96, 2)));
			}
			i++;
		}
		return Ck;
	}

	public static double Fact(double n)
	{
		if (n == 0)
			return 1;
		else
			return n * Fact(n - 1);
	}

	public static double MAXFun(int n)
	{
		if (n == 2)
		{
			return 24;
		}
		else if (n == 3)
		{
			return 720;
		}
		else if (n == 4)
		{
			return 5040000;
		}
		return 0;
	}
	#region
	public static double CalculateF(double t)
	{
		return 1 / (1 - Math.Log(t));
	}
	public static double CalculateI(int n, double[] Ns)
	{
		double h;
		h = 1.0 / n;
		double sum1 = 0;
		double sum2 = 0;
		double Fxn = CalculateF(1);

		for (int i = 1; i <= n / 2; ++i)
		{
			sum1 = sum1 + CalculateF(Ns[2 * i - 1]);
		}
		if (n == 2)
		{
			sum2 = 0;
		}
		else
		{
			for (int i = 1; i <= n / 2 - 1; ++i)
			{
				sum2 = sum2 + CalculateF(Ns[2 * i]);
			}
		}
		double a = 1.0 / 3;
		return a * h * (4 * sum1 + 2 * sum2 + Fxn);
	}

	public static double IncreaseE(double I2, double I1, double p)
	{
		return (Math.Pow(2, p) * I2 - I1) / (Math.Pow(2, p) - 1);
	}
	#endregion
	private static void Main(string[] args)
	{
		int j = 0;
		for (int n = 2; n < 5; n++)
		{
			double a = Fact(2 * n);
			double x = MAXFun(n) * Fact(n) * Fact(n) / a;
			if (x < 0.0001)
			{
				j = n; break;
			}
		}

		double[] Xk = LaguerreX(4);
		List<double> Ck = Program.Ck(Xk);
		double sum = 0;
		int i = 0;
		foreach (double x in Ck)
		{
			sum = sum + (x * (1 / (Xk[i] + 1)));
			i++;
		}
		Console.WriteLine(sum + " " + j);

		double[] one2 = new double[3] { 0, 0.5, 1 };
		double[] one4 = new double[5] { 0, 0.25, 0.5, 0.75, 1 };
		double[] one8 = new double[9] { 0, 0.125, 0.25, 0.375, 0.5, 0.625, 0.75, 0.875, 1 };
		double[] one16 = new double[17] { 0, 0.0625, 0.125, 0.1875, 0.25, 0.3125, 0.375, 0.4375, 0.5, 0.5625, 0.625, 0.6875, 0.75, 0.8125, 0.875, 0.9375, 1 };

		double I2 = CalculateI(2, one2);
		double I4 = CalculateI(4, one4);
		double I8 = CalculateI(8, one8);
		double I16 = CalculateI(16, one16);

		double I21 = IncreaseE(I4, I2, 2);
		double I41 = IncreaseE(I8, I4, 2);
		double I81 = IncreaseE(I16, I8, 2);

		double I42 = IncreaseE(I41, I21, 4);
		double I82 = IncreaseE(I81, I41, 4);

		double I83 = IncreaseE(I82, I42, 6);

		Console.WriteLine($"{I2}    ");
		Console.WriteLine($"{I4}    {I21}");
		Console.WriteLine($"{I8}    {I41}    {I42}");
		Console.WriteLine($"{I16}     {I81}    {I82}     {I83}");

	}
}