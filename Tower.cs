using PixKeeper.Indicator;
using PixKeeper;
using UnityEngine;
using PixKeeper.Events;

public class Tower : Entity, ICheckDistance, ICanSitDown
{
    bool sit = false;
    public bool Sit { get; }

    [Header("Distance settings")]
    float sqrDistance;
    public float maxDistanse;
    
    Transform transformSit;
    Transform transformPlayer, transformTower;

    Player player;

    void Start()
    {
        isWorking = true;

        player = FindAnyObjectByType<Player>();
        
        transformPlayer = player.transform;
        transformTower = transform;

        for(int i = 0; i < transformTower.childCount; i++)
        {
            if (transformTower.GetChild(i).CompareTag("Sit"))
            {
                transformSit = transformTower.GetChild(i);
                break;
            }
        }
    }

    public Tower() { }

    void LateUpdate()
    {

        SatDown();

        if (Sit)
        {
            
        }
        else
        {
            CheckDistance();
        }
    }

    Vector3 startPos = Vector3.zero;

    public void SatDown()
    {
        if (Input.GetKeyDown(KeyCode.E) && CheckDistanceSqr(sqrDistance, maxDistanse))
        {            
            if(!sit) startPos = transformPlayer.position; // запоминаем начальную позицию игрока, если он не в башне

            {
                sit = !sit; // меняем статус башни
                EventsOfWorld.OnSatDown(sit); // сообщаем статус игрока
                transformPlayer.rotation = Quaternion.identity;
                transformPlayer.position = sit ? transformSit.position : startPos; // меняем позицию игрока {transformPlayer} в зависимости от состояния {sit}
            }            
        }
    }

    /// <summary>
    /// Передаем квадрат дистанции до игрока
    /// </summary>
    /// <returns></returns>
    public void CheckDistance() => sqrDistance = SqrDistance(transformPlayer, transformTower);

}
