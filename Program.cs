using System;

// Клас продукту
class Airplane
{
    public string Engine { get; set; }
    public string Wings { get; set; }
    public string Interior { get; set; }

    public override string ToString()
    {
        return $"Літак з двигуном: {Engine}, крилами: {Wings}, інтер'єром: {Interior}";
    }
}

// Абстрактний будівельник
abstract class AirplaneBuilder
{
    protected Airplane airplane;

    public void CreateNewAirplane()
    {
        airplane = new Airplane();
    }

    public Airplane GetAirplane()
    {
        return airplane;
    }

    public abstract void SetEngine();
    public abstract void SetWings();
    public abstract void SetInterior();
}

// Конкретний будівельник – Пасажирський літак
class PassengerAirplaneBuilder : AirplaneBuilder
{
    public override void SetEngine()
    {
        airplane.Engine = "Двигун Rolls-Royce";
    }

    public override void SetWings()
    {
        airplane.Wings = "Довгі крила для економії палива";
    }

    public override void SetInterior()
    {
        airplane.Interior = "Комфортний салон для 180 пасажирів";
    }
}

// Конкретний будівельник – Військовий літак
class FighterAirplaneBuilder : AirplaneBuilder
{
    public override void SetEngine()
    {
        airplane.Engine = "Реактивний двигун GE F110";
    }

    public override void SetWings()
    {
        airplane.Wings = "Короткі маневрові крила";
    }

    public override void SetInterior()
    {
        airplane.Interior = "Кабіна одного пілота з HUD-дисплеєм";
    }
}

// Директор, який керує процесом створення літака
class AirplaneDesigner
{
    private AirplaneBuilder builder;

    public void SetBuilder(AirplaneBuilder b)
    {
        builder = b;
    }

    public Airplane GetAirplane()
    {
        return builder.GetAirplane();
    }

    public void ConstructAirplane()
    {
        builder.CreateNewAirplane();
        builder.SetEngine();
        builder.SetWings();
        builder.SetInterior();
    }
}

// Демонстрація
class Program
{
    static void Main(string[] args)
    {
        AirplaneDesigner designer = new AirplaneDesigner();

        // Побудова пасажирського літака
        AirplaneBuilder passengerBuilder = new PassengerAirplaneBuilder();
        designer.SetBuilder(passengerBuilder);
        designer.ConstructAirplane();
        Airplane passenger = designer.GetAirplane();
        Console.WriteLine(passenger);

        // Побудова військового літака
        AirplaneBuilder fighterBuilder = new FighterAirplaneBuilder();
        designer.SetBuilder(fighterBuilder);
        designer.ConstructAirplane();
        Airplane fighter = designer.GetAirplane();
        Console.WriteLine(fighter);

        Console.ReadKey();
    }
}
