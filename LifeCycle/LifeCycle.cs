using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using static Cuku.Assets.Assets;

public partial class LifeCycle
{
    Entitas.Systems features;

    bool isTearingDown = false;

    List<AsyncOperationHandle> loadedScenes = new List<AsyncOperationHandle>();

    public LifeCycle() => InitializeFeatures();

    public async void Initialize(string[] scenes)
    {
        isTearingDown = false;
        // Reactivate Reactive Systems in case of a LifeCycle restart
        features.ActivateReactiveSystems();
        features.Initialize();

        foreach (var scene in scenes)
            loadedScenes.Add(await scene.LoadScene());
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

        foreach (var scene in loadedScenes)
            scene.UnloadScene();
        loadedScenes.Clear();
    }
}
