namespace Services
{
    public class CalculatorService : IService
    {
        public int Sum(int a, int b)
        {
            return a+b;
        }
    }
}
