using Unity.Cinemachine;
using UnityEngine;

public class SplineDollyAnimator : MonoBehaviour
{

    public float duration = 5f;
    public bool loop = false;
    public bool pingPong = false;
    public float startPosition = 0f;

    CinemachineSplineDolly dolly;
    float t;
    int direction = 1;

    void Awake()
    {
        dolly = GetComponent<CinemachineSplineDolly>();

    }

    void OnEnable()
    {
        t = Mathf.Clamp01(startPosition);
        direction = 1;
        dolly.CameraPosition = t;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t+=direction * (Time.deltaTime/duration);
        if(pingPong)
        {
            if(t>=1f)
            {
                t=1f;
                direction = 1;
            }
            else if(loop)
            {
                if(t>1f)
                {
                    t -=1;
                }
                if(t<0f)
                {
                    t+=1f;
                }
            } else
            {
                t = Mathf.Clamp01(t);
            }
        }
        dolly.CameraPosition = t;
    }
}
