### Summary

In this project I explored two different ways to drive a Cinemachine virtual camera in Unity 6, wiring both behind UGUI buttons rather than auto-playing them on Play Mode.

- Stack: Unity 6, Cinemachine 3.1.6 (CM3 API), Timeline 1.8.11, uGUI 2.0.0, and the Splines package (pulled in transitively via Cinemachine).
- Set up a single `CinemachineCamera` GameObject driven two different ways: one path through a Timeline (`PlayableDirector` bound to `CinematicDirectorTimeline.playable`, animating the camera via an Animation Track), and another path through a custom script (`SplineDollyAnimator`) that animates `CinemachineSplineDolly.CameraPosition` along a `SplineContainer`.
- Authored a `SplineContainer` with a curved path for the Spline Dolly to follow.
- Wrote `SplineDollyAnimator.cs` — a MonoBehaviour using a coroutine (`StartCoroutine` + `yield return null`) to advance camera position frame-by-frame from a button click, with support for one-shot, loop, and ping-pong playback modes.
- Wrote `CameraButtonRouter.cs` — a coordinator MonoBehaviour that wires UGUI `Button.onClick.AddListener` handlers in C# (in `Awake()`) instead of configuring listeners via the Inspector, and cleans them up in `OnDestroy()` with `RemoveListener`.
- Prevented auto-play on entering Play Mode: Timeline by setting `PlayableDirector.playOnAwake = false` in the Inspector (serialized as `m_InitialState: 0`), script camera by only launching its coroutine when its button is clicked.
- Triggered Timeline replay from a button click using `playableDirector.time = 0; playableDirector.Play();` so each press restarts the cinematic from frame 0.
- Used the `StartCoroutine`/`StopCoroutine` pattern with a cached `Coroutine` handle so repeated button presses cancel the in-flight animation before launching a fresh one.

### citation

**Cinemachine 3**
- CinemachineCamera — https://docs.unity3d.com/Packages/com.unity.cinemachine@3.1/api/Unity.Cinemachine.CinemachineCamera.html
- CinemachineSplineDolly — https://docs.unity3d.com/Packages/com.unity.cinemachine@3.1/api/Unity.Cinemachine.CinemachineSplineDolly.html
- CinemachineBrain — https://docs.unity3d.com/Packages/com.unity.cinemachine@3.1/api/Unity.Cinemachine.CinemachineBrain.html
- Upgrading from Cinemachine 2 — https://docs.unity3d.com/Packages/com.unity.cinemachine@3.1/manual/CinemachineUpgradeFrom2.html

**Timeline / Playables**
- PlayableDirector — https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.html
- PlayableDirector.playOnAwake — https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-playOnAwake.html
- PlayableDirector.time — https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector-time.html
- PlayableDirector.Play — https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Play.html
- PlayableDirector.Stop — https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.Stop.html
- Timeline package — https://docs.unity3d.com/Packages/com.unity.timeline@1.8/manual/index.html

**Splines**
- SplineContainer — https://docs.unity3d.com/Packages/com.unity.splines@2.7/api/UnityEngine.Splines.SplineContainer.html
- Splines package — https://docs.unity3d.com/Packages/com.unity.splines@2.7/manual/index.html

**UGUI (Buttons & UnityEvents)**
- UI.Button — https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Button.html
- UnityEvent — https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
- UnityEvent.AddListener — https://docs.unity3d.com/ScriptReference/Events.UnityEvent.AddListener.html
- UnityEvent.RemoveListener — https://docs.unity3d.com/ScriptReference/Events.UnityEvent.RemoveListener.html
- UnityAction — https://docs.unity3d.com/ScriptReference/Events.UnityAction.html

**MonoBehaviour lifecycle**
- MonoBehaviour — https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
- MonoBehaviour.Awake — https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
- MonoBehaviour.OnEnable — https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnEnable.html
- MonoBehaviour.OnDestroy — https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDestroy.html
- Order of execution for event functions — https://docs.unity3d.com/Manual/execution-order.html

**Coroutines**
- Coroutine — https://docs.unity3d.com/ScriptReference/Coroutine.html
- MonoBehaviour.StartCoroutine — https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
- MonoBehaviour.StopCoroutine — https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopCoroutine.html
- Coroutines manual — https://docs.unity3d.com/Manual/Coroutines.html

**Inspector attributes**
- SerializeField — https://docs.unity3d.com/ScriptReference/SerializeField.html
- RequireComponent — https://docs.unity3d.com/ScriptReference/RequireComponent.html
- RangeAttribute — https://docs.unity3d.com/ScriptReference/RangeAttribute.html
- MinAttribute — https://docs.unity3d.com/ScriptReference/MinAttribute.html
