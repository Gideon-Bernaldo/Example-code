using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixKeeper.Events;
using PixKeeper.Indicator;
using PixKeeper;

public class Player : Entity, ILevelUpdate
{
    bool sit;

    public Player(int armor, int damage, float strong, int level, int dopMaxHealth) : base(armor, damage, strong, level, dopMaxHealth)
    {  
    }

    private void Start()
    {
        isWorking = true;
        InitializeEntity(4, 15, 1, 1, 100);
        Debug.Log($"{Health}/{MaxHealth}");
        CheckLevel<Transform>(Exp, Level);
    }

    public void Awake()
    {
        EventsOfWorld.satDown += SatDown;
    }

    public void OnDestroy()
    {
        EventsOfWorld.satDown -= SatDown;
    }



    public override void GetDamage(int damage)
    {
        Debug.Log($"Получен урон: {damage}");        

        base.GetDamage(damage);

        EventsOfWorld.OnSetCorrectHealth(Health, MaxHealth); // привязать к переменным
    }

    private void LateUpdate()
    {
        
    }

    public void LevelUpdate()
    {

        if (CheckLevel<bool>(Exp, Level))
        {
            Exp = CalculateDifference(Exp, CheckLevel<int>(Exp, Level));

            Level++;
            RefreshMaxHealthFromLvl(true);
            EventsOfWorld.OnPlayLevelUp(Level);
        }
    }

    public void AddScore(int exp)
    {
        Exp += exp;
        LevelUpdate();
    }

    public void SatDown(bool status) => sit = status;
}
