public class LifeCycleController : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] string[] Scenes;
    [UnityEngine.SerializeField] UnityEngine.Events.UnityEvent OnScenesInitialized;

    private LifeCycle lifeCycle;

    /// <summary>
    /// Construct <see cref="LifeCycle"/>.
    /// </summary>
    private void Awake() => lifeCycle = new LifeCycle();

    /// <summary>
    /// Initialize <see cref="LifeCycle"/>.
    /// </summary>
    private async void OnEnable()
    {
        await lifeCycle.Initialize(Scenes);
        OnScenesInitialized?.Invoke();
    }

    /// <summary>
    /// Update <see cref="LifeCycle"/>.
    /// </summary>
    private void Update() => lifeCycle.Execute();

    /// <summary>
    /// Cleanup <see cref="LifeCycle"/>.
    /// </summary>
    private void LateUpdate() => lifeCycle.Cleanup();

    /// <summary>
    /// Tear down <see cref="LifeCycle"/>.
    /// </summary>
    private void OnDisable() => lifeCycle.TearDown();

    /// <summary>
    /// Tear down <see cref="LifeCycle"/>.
    /// </summary>
    private void OnDestroy() => lifeCycle.TearDown();

    /// <summary>
    /// Tear down <see cref="LifeCycle"/>.
    /// </summary>
    private void OnApplicationQuit() => lifeCycle.TearDown();
}
