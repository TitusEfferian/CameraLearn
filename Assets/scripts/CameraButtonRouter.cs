using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CameraButtonRouter : MonoBehaviour
{
    [SerializeField] Button timelineButton;
    [SerializeField] Button splineButton;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] SplineDollyAnimator splineDollyAnimator;

    void OnTimeLineClicked()
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
        timelineButton.onClick.AddListener(OnTimeLineClicked);
        splineButton.onClick.AddListener(OnSplineClicked);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
