using UnityEngine;
using PixKeeper.Indicator;
using PixKeeper;

public abstract class Entity : RuleOfWorld, IAlive, IGetDamage, IHit
{
    public bool isWorking;

    int health, maxHealth, dopMaxHealth;
    int armor;
    int damage;
    int level;
    int exp;

    float strong = 2.5f;
    const int healthPointsForStrength = 7;

    public float Strong { get => strong; set => strong = value; }
    public int Armor { get => armor; set => armor = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Level { get => level; set => level = value; }
    public int Exp { get => exp; set => exp = value; }
    public int Health
    {
        get => health;
        set
        {
            int totalValue = MaxHealth;

            if (value >= 0 && value <= totalValue)
            {
                health = value;
            }
            else if (value < 0)
            {
                health = 0;
            }
            else
            {
                health = totalValue;
            }
        }
    }
    public int MaxHealth => maxHealth = dopMaxHealth + HealthForStrength();

    public Entity() { }

    public Entity(int armor, int damage, float strong, int level, int dopMaxHealth)
    {
        this.Armor = armor;
        this.Damage = damage;
        this.Strong = strong;
        this.Level = level;
        this.dopMaxHealth = dopMaxHealth;
        Health = MaxHealth;
    }

    /// <summary>
    /// инициализация переменных в классе
    /// </summary>
    /// <param name="armor"></param>
    /// <param name="damage"></param>
    /// <param name="strong"></param>
    /// <param name="level"></param>
    /// <param name="dopMaxHealth"></param>
    public void InitializeEntity(int armor, int damage, float strong, int level, int dopMaxHealth)
    {
        this.Armor = armor;
        this.Damage = damage;
        this.Strong = strong;
        this.Level = level;
        this.dopMaxHealth = dopMaxHealth;
        Health = MaxHealth;
    }

    /// <summary>
    /// Метод, рассчитывающий здоровье от показателей силы, здоровья за единицу силы и уровень сущности
    /// </summary>
    /// <returns></returns>
    public int HealthForStrength() => Mathf.CeilToInt(strong * healthPointsForStrength * level);

    /// <summary>
    /// Увлечить показатели максимального здоровья (так же прибавляется и к health)
    /// </summary>
    /// <param name="value"></param>
    public void AddMaxHealth(int value)
    {
        if (value > 0)
        {
            dopMaxHealth += value;
            Health += value;
        }
    }

    /// <summary>
    /// Обновить максимальный запас здоровья от уровня
    /// </summary>
    /// <param name="level"></param>
    public void RefreshMaxHealthFromLvl(bool newLvl)
    {
        Strong = Level * 2.5f;
        if (newLvl) Health = MaxHealth;
    }

    public virtual void GetDamage(int damage)
    {
        if (damage <= 0 || !isWorking) return;
        Health -= damage;
    }

    public virtual void Hit(int damage, Entity entity) => entity.GetDamage(damage);

    public virtual void Dead() => Destroy(gameObject);
}
