namespace Практ_6
{
    public class Car
    {
        public string owner;
        public string mark;
        public int year;

        public Car()
        {
            owner = "";
            mark = "";
            year = 0;
        }

        public Car(string owner, string mark, int year)
        {
            this.owner = owner;
            this.mark = mark;
            this.year = year;
        }
    }
}
