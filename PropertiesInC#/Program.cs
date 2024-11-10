using System;

namespace Coding.Exercise
{
    public class Order
    {
        public string Item { get; }

        private DateTime _date;
        public DateTime Date
        { 
            get { return _date;}
            set
            {
                if (value.Year == DateTime.Now.Year)
                {
                    _date = value;
                }
            }
        }

        public Order(string item, DateTime date)
        {
            Item = item;
            Date = date;
        }

        public static void Main()
        {
            // Order order1 = new Order("laptop", DateTime.Now);

            DateTime date = new DateTime(2023, 4, 15);
            Order order1 = new Order("laptop", date);

            Console.WriteLine(order1.Item);
            Console.WriteLine(order1.Date);
        }
    }
}