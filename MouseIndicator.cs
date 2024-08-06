using UnityEngine;
using PixKeeper.Events;

public class MouseIndicator : MonoBehaviour
{
    public ParticleSystem ParticleYes, ParticleNo;

    private void Awake() => EventsOfMouse.goalAccessStatus += SetMouseEffect;

    private void OnDestroy() => EventsOfMouse.goalAccessStatus -= SetMouseEffect;

    void SetMouseEffect(Vector3 pos, bool status)
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = pos;

            if (status) ParticleYes.Play();
            else ParticleNo.Play();
        }
    }
}
