using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        [Test]
        public void FightWithWeakness()
        {
            Character tortipousse = new Character(100, 50, 30, 20, TYPE.GRASS, TYPE.FIRE);
            Character chimpanfeu = new Character(100, 70, 10, 30, TYPE.FIRE, TYPE.WATER);
            Fight f = new Fight(tortipousse, chimpanfeu);
            Punch p = new Punch();
            FireBall fb = new FireBall();
            f.ExecuteTurn(p, fb);

            Assert.That(tortipousse.CurrentHealth, Is.EqualTo(30));//hp 100 => 30
            Assert.That(tortipousse.IsAlive, Is.EqualTo(true));

            Assert.That(chimpanfeu.CurrentHealth, Is.EqualTo(40)); //hp 100 => 40
            Assert.That(chimpanfeu.IsAlive, Is.EqualTo(true));
        }

        [Test]
        public void FightWithCrit()
        {
            Character tortipousse = new Character(100, 50, 30, 20, TYPE.GRASS, TYPE.FIRE);
            Character chimpanfeu = new Character(100, 70, 10, 30, TYPE.FIRE, TYPE.WATER);
            Fight f = new Fight(tortipousse, chimpanfeu);
            Punch p = new Punch();
            FireBall fb = new FireBall();
            f.ExecuteTurn(p, fb);
            
            Assert.That(tortipousse.CurrentHealth, Is.EqualTo(30));
            Assert.That(tortipousse.IsAlive, Is.EqualTo(true));
            if(tortipousse.CriticShot())
            {
                Assert.That(chimpanfeu.CurrentHealth, Is.EqualTo(0));
                Assert.That(chimpanfeu.IsAlive, Is.EqualTo(false));
            }
            else
            {
                Assert.That(chimpanfeu.CurrentHealth, Is.EqualTo(40)); //hp 100 => 40
                Assert.That(chimpanfeu.IsAlive, Is.EqualTo(true));
            }
           
        }

      
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer les TU sur le reste et de les implémenter

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type

    }
}
