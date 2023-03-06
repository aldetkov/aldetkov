using System.Collections;
using UnityEngine;

namespace aldetkov.Components.Other
{
    public class AutoDisable : MonoBehaviour
    {
        [SerializeField] private float time = 0.5f;

        private void OnEnable()
        {
            StartCoroutine(DelayDisable());
        }
    
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator DelayDisable()
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }
    }
}
