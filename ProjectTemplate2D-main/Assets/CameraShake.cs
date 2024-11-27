using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-0.5f, 0.5f) * magnitude;
            float offsetY = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null; // Attend la fin de la frame
        }

        transform.localPosition = originalPosition;
    }
}
