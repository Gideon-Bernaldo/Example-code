using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixKeeper;

namespace PixKeeper.Indicator
{
    /// <summary>
    /// ������ �������� �����
    /// </summary>
    interface IAlive
    {
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    /// <summary>
    /// �������� �������� ����
    /// </summary>
    interface IGetDamage : IDead
    {
        /// <summary>
        /// �������� ����
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage);
    }

    /// <summary>
    /// �������� ����� �������
    /// </summary>
    interface IHit
    {
        public int Damage { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="damage"></param>
        public void Hit(int damage, Entity entity);
    }

    /// <summary>
    /// �������� ����� ��������
    /// </summary>
    interface IDead
    {
        /// <summary>
        /// ������
        /// </summary>
        void Dead();
    }

    /// <summary>
    /// ������ ����� ��������� ������
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
