namespace Calculator
{
    public class MyMath
    {
        public static float add(float x, float y)
        {
            return x + y;
        }

        public static float sub(float x, float y)
        {
            return x - y;
        }

        public static float mul(float x, float y)
        {
            return x * y;
        }

        public static float div(float x, float y)
        {
            try
            {
                return x / y;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}
