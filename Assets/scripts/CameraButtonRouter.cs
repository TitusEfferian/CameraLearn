using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CameraButtonRouter : MonoBehaviour
{
    [SerializeField] Button timelineButton;
    [SerializeField] Button splineButton;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] SplineDollyAnimator splineDollyAnimator;

    void OnTimelineClicked()
    {
        playableDirector.time = 0;
        playableDirector.Play();

    }

    void OnSplineClicked()
    {
        splineDollyAnimator.PlayFromStart();
    }
    void Awake()
    {
        timelineButton.onClick.AddListener(OnTimelineClicked);
        splineButton.onClick.AddListener(OnSplineClicked);
    }

    void OnDestroy()
    {
        if (timelineButton != null) timelineButton.onClick.RemoveListener(OnTimelineClicked);
        if (splineButton != null) splineButton.onClick.RemoveListener(OnSplineClicked);
    }
}
