using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace aldetkov.SceneUtils
{
    public class SceneAsyncLoader : MonoBehaviour
    {
        public static SceneAsyncLoader instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (instance == this) instance = null;
        }

        public IEnumerator SceneLoad(int index, float delay)
        {
            yield return new WaitForSeconds(delay);
            yield return SceneManager.LoadSceneAsync(index);
        }

        public void SceneLoad(SceneList sceneType, float delay)
        {
            StartCoroutine(SceneLoad((int) sceneType, delay));
        }
    }
    
    public enum SceneList
    {
        Login = 0,
        Game = 1,
    }
}