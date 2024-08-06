using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixKeeper;

namespace PixKeeper.Indicator
{
    /// <summary>
    /// Объект является живым
    /// </summary>
    interface IAlive
    {
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    /// <summary>
    /// Сущность получает урон
    /// </summary>
    interface IGetDamage : IDead
    {
        /// <summary>
        /// Получаем урон
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage);
    }

    /// <summary>
    /// Сущность может ударить
    /// </summary>
    interface IHit
    {
        public int Damage { get; set; }
        /// <summary>
        /// Бьем
        /// </summary>
        /// <param name="damage"></param>
        public void Hit(int damage, Entity entity);
    }

    /// <summary>
    /// Сущность может умерерть
    /// </summary>
    interface IDead
    {
        /// <summary>
        /// Смерть
        /// </summary>
        void Dead();
    }

    /// <summary>
    /// Объект может обновлять уровни
    /// </summary>
    interface ILevelUpdate
    {
        public int Level { get; set; }
        public int Exp {  get; set; }

        public void LevelUpdate();
        public void AddScore(int exp);
    }

    interface ICheckDistance
    {
        public void CheckDistance();
    }

    interface ICanSitDown {
        public bool Sit { get; }

        public void SatDown();
    }
}
