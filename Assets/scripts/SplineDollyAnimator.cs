using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineSplineDolly))]
public class SplineDollyAnimator : MonoBehaviour
{
    [Min(0.01f)] public float duration = 5f;
    public bool loop = false;
    public bool pingPong = false;
    [Range(0f, 1f)] public float startPosition = 0f;
    bool isPlaying = false;

    CinemachineSplineDolly dolly;
    float progress;
    int direction = 1;

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

    void Update()
    {
        if(!isPlaying) return;
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
            progress = Mathf.Clamp01(progress);
        }

        dolly.CameraPosition = progress;
    }

    public void PlayFromStart()
    {
        progress = 0f;
        isPlaying = true;
    }


}
