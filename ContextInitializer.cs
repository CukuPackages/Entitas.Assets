using UnityEditor;

public class ContextInitializer
{
    [InitializeOnLoad]
    public static class EditorInitializer
    {
        static EditorInitializer() => Contexts.Initialize();
    }
}
