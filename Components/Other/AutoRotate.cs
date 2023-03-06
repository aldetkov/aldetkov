using UnityEngine;

namespace aldetkov.Components.Other
{
    public class AutoRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 speedRotate;

        private void Update()
        {
            transform.Rotate(speedRotate * Time.deltaTime);
        }
    }
}
