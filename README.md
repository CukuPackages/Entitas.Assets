## Entitas.Generator.dll to generate code using via Roslyn

## Entitas LifeCycle
Includes a Life Cycle Controller for the Entitas Loop and a prefab version to add on the first scene.

## Installation
1. Open Git Bash / Terminal at the project root
2. Add submodule
   ```
   git submodule add https://github.com/CukuPackages/Entitas.Assets.git Assets/Entitas
   ```

## Add Features
1. Create partial LifeCycle script
2. Implement InitializeFeatures() with project features
3. Implement ResetContexts() to reset project contexts
4. Example:
   ```
   using Entitas.Unity;

   public partial class LifeCycle
   {
       public void InitializeFeatures()
       {
           Contexts.Initialize();
   
           var inputContext = InputContext.Instance;
           inputContext.CreateContextObserver();
   
           features = new Features(inputContext);
       }
   
       private void ResetContexts()
       {
           InputContext.Instance.Reset();
       }
   }
   ```
