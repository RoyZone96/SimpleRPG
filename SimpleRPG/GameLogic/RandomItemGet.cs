using ItemList;
using ClassList;
using System;

namespace GameLogic
{
    public class RandomItemGet
    {
        private static Random random = new Random();

        private static readonly List<(Func<IItem> factory, int weight)> items = new()
        {
            (() => new Potion(), 50),
            (() => new HighPotion(), 20),
            (() => new Ether(), 15),
            (() => new HighEther(), 10),
            (() => new PhoenixFeather(), 5)
        };    
        
        public static IItem GetRandomItem()
        {
            int totalWeight = items.Sum(item => item.weight);
            int roll = random.Next(0, totalWeight);
            int cumulativeWeight = 0;

            foreach (var (factory, weight) in items)
            {
                cumulativeWeight += weight;
                if (roll < cumulativeWeight)
                {
                    return factory();
                }
            }

            throw new Exception("Failed to get a random item.");
        
        }
}   }