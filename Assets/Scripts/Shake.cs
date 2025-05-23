using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 0.5f; // Длительность тряски
    public float magnitude = 0.2f; // Сила тряски

    public void CamShake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = 1f * magnitude;
            float y = 1f * magnitude;
            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}

