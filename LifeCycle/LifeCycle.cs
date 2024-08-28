public partial class LifeCycle
{
    Entitas.Systems features;

    bool isTearingDown = false;

    public LifeCycle() => InitializeFeatures();

    public void Initialize()
    {
        isTearingDown = false;
        // Reactivate Reactive Systems in case of a LifeCycle restart
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
        ResetContexts();
    }
}
