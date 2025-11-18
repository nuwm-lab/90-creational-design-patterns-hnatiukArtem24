using System;

namespace AirplaneBuilderPattern
{
    // Продукт
    public class Airplane
    {
        public string Engine { get; set; }
        public string Wings { get; set; }
        public string Interior { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("----- Літак створено -----");
            Console.WriteLine($"Двигун: {Engine}");
            Console.WriteLine($"Крила: {Wings}");
            Console.WriteLine($"Інтер'єр: {Interior}");
            Console.WriteLine();
        }
    }

    // Інтерфейс будівельника
    public interface IAirplaneBuilder
    {
        void SetEngine();
        void SetWings();
        void SetInterior();
        Airplane GetResult();
    }

    // Конкретний будівельник — пасажирський літак
    public class PassengerAirplaneBuilder : IAirplaneBuilder
    {
        private Airplane airplane = new Airplane();

        public void SetEngine()
        {
            airplane.Engine = "Двигун Rolls-Royce Trent 1000";
        }

        public void SetWings()
        {
            airplane.Wings = "Крила зі збільшеним розмахом";
        }

        public void SetInterior()
        {
            airplane.Interior = "Інтер'єр: 220 пасажирських місць";
        }

        public Airplane GetResult()
        {
            return airplane;
        }
    }

    // Конкретний будівельник — вантажний літак
    public class CargoAirplaneBuilder : IAirplaneBuilder
    {
        private Airplane airplane = new Airplane();

        public void SetEngine()
        {
            airplane.Engine = "Двигун GE90-115B (найпотужніший у світі)";
        }

        public void SetWings()
        {
            airplane.Wings = "Посилені крила для важких навантажень";
        }

        public void SetInterior()
        {
            airplane.Interior = "Інтер'єр: вантажний відсік на 70 тонн";
        }

        public Airplane GetResult()
        {
            return airplane;
        }
    }

    // Директор
    public class AirplaneDirector
    {
        public void Construct(IAirplaneBuilder builder)
        {
            builder.SetEngine();
            builder.SetWings();
            builder.SetInterior();
        }
    }

    // Тестова програма
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть тип літака:");
            Console.WriteLine("1 — Пасажирський");
            Console.WriteLine("2 — Вантажний");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            IAirplaneBuilder builder;

            if (choice == 1)
                builder = new PassengerAirplaneBuilder();
            else
                builder = new CargoAirplaneBuilder();

            AirplaneDirector director = new AirplaneDirector();
            director.Construct(builder);

            Airplane airplane = builder.GetResult();
            airplane.ShowInfo();

            Console.ReadKey();
        }
    }
}
