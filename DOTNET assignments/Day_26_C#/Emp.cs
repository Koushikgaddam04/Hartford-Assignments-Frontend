namespace Day_26_C_
{
    internal class Emp : IComparable<Emp>
    {
        public Emp(int v1, string v2, string v3, int v4)
        {
            Id = v1;
            Name = v2;
            Department = v3;
            Salary = v4;
        }

        public int Id { get; }
        public string Name { get; }
        public string Department { get; }
        public int Salary { get; }

        public int CompareTo(Emp? other)
        {
            if (other == null) return 1;
            return this.Salary.CompareTo(other.Salary);
        }
    }
}