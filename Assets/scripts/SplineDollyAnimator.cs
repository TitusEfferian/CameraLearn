using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineSplineDolly))]
public class SplineDollyAnimator : MonoBehaviour
{
    [Min(0.01f)] public float duration = 5f;
    public bool loop = false;
    public bool pingPong = false;
    [Range(0f, 1f)] public float startPosition = 0f;

    CinemachineSplineDolly dolly;
    float progress;
    int direction = 1;
    Coroutine playing;

    void Awake()
    {
        dolly = GetComponent<CinemachineSplineDolly>();
    }

    void OnEnable()
    {
        progress = Mathf.Clamp01(startPosition);
        direction = 1;
        dolly.CameraPosition = progress;
    }

    public void PlayFromStart()
    {
        if (playing != null) StopCoroutine(playing);
        playing = StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine()
    {
        progress = Mathf.Clamp01(startPosition);
        direction = 1;
        dolly.CameraPosition = progress;

        while (true)
        {
            yield return null;
            progress += direction * (Time.deltaTime / duration);

            if (pingPong)
            {
                if (progress >= 1f) { progress = 1f; direction = -1; }
                else if (progress <= 0f) { progress = 0f; direction = 1; }
            }
            else if (loop)
            {
                if (progress > 1f) progress -= 1f;
                if (progress < 0f) progress += 1f;
            }
            else
            {
                if (progress >= 1f)
                {
                    progress = 1f;
                    dolly.CameraPosition = progress;
                    playing = null;
                    yield break;
                }
            }

            dolly.CameraPosition = progress;
        }
    }
}
