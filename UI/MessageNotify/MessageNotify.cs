using aldetkov.Components.SpriteCollection;
using aldetkov.EventSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.MessageNotify
{
    public interface IMessageNotifyShow : IGlobalSubscriber
    {
        public void Notify(NotifyType notifyType, string text);
    }

    public class MessageNotify : MonoBehaviour, IMessageNotifyShow
    {
        [SerializeField] private Animator anim;
        [SerializeField] private Image back;
        [SerializeField] private TMP_Text textField;
        [SerializeField] private SpriteCollectionSimple spritesBack;
        [SerializeField] private AudioSource sound;
        private void Start()
        {
            EventManager.Subscribe(this);
        }

        private void OnDestroy()
        {
            EventManager.Unsubscribe(this);
        }

        public void Notify(NotifyType notifyType, string text)
        {
            textField.text = text;
            back.sprite = spritesBack.GetSprite((int) notifyType);
            anim.SetTrigger("Show");
            sound.Play();
        }
    }

    public enum NotifyType
    {
        Simple = 0,
        Warning = 1,
        Error = 2,
        Bonus = 3,
    }
}