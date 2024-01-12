using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        TYPE _weakType;
        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType, TYPE weakType)
        {
            
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            _weakType = weakType;
            CurrentHealth = _baseHealth;
            IsAlive = true;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType; }
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _baseHealth;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                return _baseAttack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                return _baseDefense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                return _baseSpeed;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive { get; private set; }

        public bool CriticShot()
        {
            Random rand = new Random();
            var r = rand.Next(1, 1000);
            if (r == 18)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (s == null)
            {
                throw new NotImplementedException();
            }
            
            int multiplicateur = 1;
            if (s.Type == _weakType ) 
            {
                multiplicateur = 2;
            }
            int oldHealth = CurrentHealth;
            CurrentHealth = CurrentHealth - (s.Power * multiplicateur - _baseDefense);
            
            if(CurrentHealth > oldHealth)
            {
                CurrentHealth = oldHealth;
            }
            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;  
                IsAlive = false;
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null) throw new ArgumentNullException();
            CurrentEquipment = newEquipment;
            _baseSpeed += CurrentEquipment.BonusSpeed;
            _baseHealth += CurrentEquipment.BonusHealth;
            _baseAttack += CurrentEquipment.BonusAttack;
            _baseDefense += CurrentEquipment.BonusDefense;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            _baseSpeed -= CurrentEquipment.BonusSpeed;
            _baseHealth -= CurrentEquipment.BonusHealth;
            _baseAttack -= CurrentEquipment.BonusAttack;
            _baseDefense -= CurrentEquipment.BonusDefense;
            CurrentEquipment = null;
        }

    }
}
