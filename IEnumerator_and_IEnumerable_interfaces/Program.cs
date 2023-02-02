using System;

namespace IEnumerator_and_IEnumerable_interfaces
{
    class MyCar : IEnumerable, IEnumerator
    {
        //Fields of MyCar class
        MyCar[] MyCars;
        int number_of_cars = 0;
        int current_position = 0;
        int position = -1;

        //Properties of MyCar class
        string brand { get; set; }
        int horsepower { get; set; }
        double fuel_consumption { get; set; }

        //MyCar class constructor
        public MyCar(int number_of_cars)
        {
            if (number_of_cars <= 0) return;
            MyCars = new MyCar[number_of_cars];
        }

        //A method that represents the Add method in the ArrayList class
        public void Add(string brand, int horsepower, double fuel_consumption)
        {
            if (horsepower <= 0 || fuel_consumption <= 0) return;
            this.MyCars[current_position] = new MyCar(1);
            this.MyCars[current_position].brand = brand;
            this.MyCars[current_position].horsepower = horsepower;
            this.MyCars[current_position].fuel_consumption = fuel_consumption;
            current_position++;
        }

        //Outputs a string with the characteristics of the car
        public string Car_characters() 
        {
            return "Brand of the car: " + brand + " Horsepower: " + horsepower.ToString() + " Fuel consumption: " + fuel_consumption.ToString();
        }

        //The GetEnumerator method returns the counter that iterates through the collection (in the foreach loop)
        public IEnumerator GetEnumerator() 
        {
            foreach (MyCar car in MyCars)
                yield return (IEnumerator)car;
        }

        //Property Current returns the value of the element at a certain index
        public object Current 
        {
            get
            {
                if (position >= 0 && position < number_of_cars)
                    return MyCars[position];
                else
                    return null;
            }

        }

        //MoveNext method checks if the next item in the list exists
        public bool MoveNext() 
        {
            position++;
            return (position < number_of_cars);
        }

        //The Reset method sets the counter to its initial position (before the first element)
        public void Reset()
        {
            position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCar cars = new MyCar(5);

            cars.Add("Lamborgini", 798, 14.2);
            cars.Add("Ferrari", 689, 16.9);
            cars.Add("Mercedes", 450, 15.7);
            cars.Add("Aston Martin", 370, 14.6);
            cars.Add("Passat B3", 1234, 8.4);

            foreach (MyCar c in cars)
            {
                if (c != null)
                    Console.WriteLine(c.Car_characters());
            }
        }
    }

}
