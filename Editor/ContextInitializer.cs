#if UNITY_EDITOR
using UnityEditor;

public class ContextInitializer
{
    [InitializeOnLoad]
    public static class EditorInitializer
    {
        static EditorInitializer() => Contexts.Initialize();
    }
}
#endif