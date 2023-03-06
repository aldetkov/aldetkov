using System;
using System.Collections;
using UnityEngine;

namespace aldetkov.UI.Other
{
    public class TimingUtils
    {
        public static IEnumerator ActionDelay(float sec, Action action)
        {
            yield return new WaitForSeconds(sec);
            action?.Invoke();
        }
        
        public static IEnumerator ActionRepeat(float sec, Action action, int count = 999999)
        {
            while (count > 0)
            {
                count--;
                yield return new WaitForSeconds(sec);
                action.Invoke();
            }
        }
    }
}