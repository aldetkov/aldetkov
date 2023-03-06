using System;

namespace aldetkov.SceneUtils
{
    public static class SceneTypeUtils
    {
        public static string GetSceneName(this SceneType sceneType)
        {
            return sceneType switch
            {
                SceneType.Login => "Login",
                SceneType.Lobby => "Lobby",
                SceneType.Game => "Game",
                SceneType.None => "None",
                _ => throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null)
            };
        }
        
        public static SceneType GetSceneType(string sceneName)
        {
            foreach (var sceneType in Enum.GetValues(typeof(SceneType)))
            {
                if (((SceneType) sceneType).GetSceneName() == sceneName) return (SceneType) sceneType;
            }

            return SceneType.None;
        }
    }
}