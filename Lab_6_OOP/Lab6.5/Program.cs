using System;
using System.Collections.Generic;

abstract class Food
{
    public abstract int HappinessPoints { get; }
}

class FoodFactory
{
    public Food ProduceFood(string foodName)
    {
        foodName = foodName.ToLower();
        switch (foodName)
        {
            case "cram":
                return new Cram();
            case "lembas":
                return new Lembas();
            case "apple":
                return new Apple();
            case "melon":
                return new Melon();
            case "honeycake":
                return new HoneyCake();
            case "mushrooms":
                return new Mushrooms();
            case "everything else":
                return new Everything ();
            default:
                return new OtherFood();
        }
    }
}

class Cram : Food
{
    public override int HappinessPoints => 2;
}

class Lembas : Food
{
    public override int HappinessPoints => 3;
}

class Apple : Food
{
    public override int HappinessPoints => 1;
}

class Melon : Food
{
    public override int HappinessPoints => 1;
}

class HoneyCake : Food
{
    public override int HappinessPoints => 5;
}

class OtherFood : Food
{
    public override int HappinessPoints => -1;
}

class Mushrooms : Food
{
    public override int HappinessPoints => -10;
}

class Everything : Food
{
    public override int HappinessPoints => -1;
}

abstract class Mood
{
    public abstract string MoodName { get; }
}

class MoodFactory
{
    public Mood ProduceMood(int happinessPoints)
    {
        if (happinessPoints < -5)
            return new AngryMood();
        else if (happinessPoints < 0)
            return new SadMood();
        else if (happinessPoints <= 15)
            return new HappyMood();
        else
            return new JavaScriptMood();
    }
}

class AngryMood : Mood
{
    public override string MoodName => "Злий";
}

class SadMood : Mood
{
    public override string MoodName => "Сумний";
}

class HappyMood : Mood
{
    public override string MoodName => "Щасливий";
}

class JavaScriptMood : Mood
{
    public override string MoodName => "JavaScript";
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть список їжі Гендальфа, розділений пробілом:(cram lembas apple melon honeycake mushrooms everything)");
        string input = Console.ReadLine();
        string[] foods = input.Split(' ');

        FoodFactory foodFactory = new FoodFactory();
        MoodFactory moodFactory = new MoodFactory();
        int totalHappinessPoints = 0;

        foreach (string foodName in foods)
        {
            Food food = foodFactory.ProduceFood(foodName);
            totalHappinessPoints += food.HappinessPoints;
        }

        Mood mood = moodFactory.ProduceMood(totalHappinessPoints);

        Console.WriteLine($"Загальна кількість балів щастя: {totalHappinessPoints}");
        Console.WriteLine($"Настрій Гендальфа: {mood.MoodName}");
    }
}
