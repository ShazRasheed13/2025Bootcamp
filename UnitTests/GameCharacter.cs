using Examples.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class GameCharacterTest
    {
        private readonly GameCharacter _otherCharacter = new GameCharacter("Gandalf", 80);
        private readonly GameCharacter _warrior = GameCharacter.NewWarrior("Conan");

        
        [Fact]
        public void TakeDamage()
        {
            var damagedWarrior = _warrior.TakeDamage(30);
            Assert.Equal(100, _warrior.Health());
            Assert.Equal(70, damagedWarrior.Health());
        }

        [Fact]
        public void GainHealth()
        {
            var gainedCharacter = _otherCharacter.Heal(20);
            Assert.Equal(100, gainedCharacter.Health());
        }


        [Fact]
        public void WarriorHasBetterHealth()
        {
            Assert.True(_warrior.IsBetterThan(_otherCharacter));
        }

        [Fact]
        public void ValidateParameters()
        {
            Assert.Throws<ArgumentException>(() => new GameCharacter("", 100));
            Assert.Throws<ArgumentException>(() => new GameCharacter("Hero", -10));
            Assert.Throws<ArgumentException>(() => _warrior.TakeDamage(-10));
        }

    }
}
