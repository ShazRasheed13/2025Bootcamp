using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Game
{
    public class GameCharacter
    {
        private readonly string _name;
        private readonly int _health;
        private const int MaxHealth = 100;
        private const int MinHealth = 0;

        public GameCharacter(string name, int health)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Character must have a name");
            if (health < MinHealth || health > MaxHealth)
                throw new ArgumentException($"Health must be between {MinHealth} and {MaxHealth}");

            _name = name;
            _health = health;
        }

        public static GameCharacter NewWarrior(string name) =>
            new GameCharacter(name, MaxHealth);

        public GameCharacter TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentException("Damage must be positive");
            int newHealth = Math.Max(MinHealth, _health - damage);
            return new GameCharacter(_name, newHealth);
        }


        public GameCharacter Heal(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Healing amount must be positive");
            int newHealth = Math.Min(MaxHealth, _health + amount);
            return new GameCharacter(_name, newHealth);
        }

        public int Health() => _health;


        public bool IsBetterThan(GameCharacter other) =>
            this.Health() > other.Health();
    }
}
