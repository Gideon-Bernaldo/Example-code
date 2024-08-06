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
            if(!sit) startPos = transformPlayer.position; // ���������� ��������� ������� ������, ���� �� �� � �����

            {
                sit = !sit; // ������ ������ �����
                EventsOfWorld.OnSatDown(sit); // �������� ������ ������
                transformPlayer.rotation = Quaternion.identity;
                transformPlayer.position = sit ? transformSit.position : startPos; // ������ ������� ������ {transformPlayer} � ����������� �� ��������� {sit}
            }            
        }
    }

    /// <summary>
    /// �������� ������� ��������� �� ������
    /// </summary>
    /// <returns></returns>
    public void CheckDistance() => sqrDistance = SqrDistance(transformPlayer, transformTower);

}
