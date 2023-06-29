
//21.
double[] A = new double[3];
double[] B = new double[3];
A[0] = Convert.ToDouble(Console.ReadLine());
A[1] = Convert.ToDouble(Console.ReadLine());
A[2] = Convert.ToDouble(Console.ReadLine());
B[0] = Convert.ToDouble(Console.ReadLine());
B[1] = Convert.ToDouble(Console.ReadLine());
A[2] = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"{Math.Round(Math.Sqrt(Math.Pow(A[1] - B[1], 2) + Math.Pow(A[0] - B[0], 2) + Math.Pow(A[2] - B[2], 2)), 2)}");
