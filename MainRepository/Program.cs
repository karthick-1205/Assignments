class ComplexNumber
{

    public ComplexNumber (int real, int imaginary)
    {
        mReal = real;
        mImaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2) => new (n1.mReal + n2.mReal, n1.mImaginary + n2.mImaginary);

    public override string ToString() => $"{mReal}+ i{mImaginary}";

    public static ComplexNumber operator -(ComplexNumber n1, ComplexNumber n2) => new (n1.mReal - n2.mReal, n1.mImaginary - n2.mImaginary);

    public int Norm => (int)Math.Sqrt(mReal * mReal + mImaginary * mImaginary);

    int mReal;
    int mImaginary;

    public static void Main(string[] args)
    {
        ComplexNumber c1 = new (100, 70);
        ComplexNumber c2 = new (23, 25);
        var add = c1 + c2;
        var sub = c1 - c2;
        Console.WriteLine("The addition of two complex numbers is " + add);
        Console.WriteLine("The subtraction of two complex numbers is " + sub);
        Console.WriteLine("The Norm of first complex number is " + add.Norm);
        Console.WriteLine("The Norm of second complex number is " + sub.Norm);
    }
}