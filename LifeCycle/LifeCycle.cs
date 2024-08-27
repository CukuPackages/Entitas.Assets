using Entitas.Unity;

public class LifeCycle
{
    private readonly Entitas.Systems features;

    private bool isTearingDown = false;

    public LifeCycle()
    {
        Contexts.Initialize();
        var assetContext = WorldContext.Instance;
        assetContext.CreateContextObserver();

        features = new Features(assetContext);
    }

    public void Initialize()
    {
        isTearingDown = false;
        // Reactivate Reactive Systems in case of a LifyCycle restart
        features.ActivateReactiveSystems();
        features.Initialize();
    }

    public void Execute() => features.Execute();

    public void Cleanup() => features.Cleanup();

    public void TearDown()
    {
        if (isTearingDown) return;
        isTearingDown = true;
        features.TearDown();
        features.DeactivateReactiveSystems();
        // Reset contexts
        WorldContext.Instance.Reset();
    }
}
