using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixKeeper.Events;

public class PlayerStatusUI : MonoBehaviour
{
    public Slider healthPointSlider;

    private void Awake() => EventsOfWorld.setCorrectHealth += NormalizeSlider;

    private void OnDestroy() => EventsOfWorld.setCorrectHealth -= NormalizeSlider;

    IEnumerator SlowAction(int v, int maxV)
    {
        healthPointSlider.maxValue = maxV;
        float timer = 0;
        const float duration = 1f;

        while (timer < 1)
        {
            healthPointSlider.value = Mathf.Lerp(healthPointSlider.value, v, timer * timer);

            timer += Time.deltaTime / duration;

            yield return null;
        }
    }

    void NormalizeSlider(int health, int maxHealth) => StartCoroutine(SlowAction(health, maxHealth));
}
