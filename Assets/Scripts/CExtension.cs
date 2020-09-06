using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.CommonFunctions
{
    public static class CExtension
    {
        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T) Enum.Parse(typeof(T), value, true);
            }
            catch (Exception e)
            {
                throw new Exception("Item not found");
            }
        }

        public static string GetNowIsoDate(this DateTime nowTime)
        {
            return nowTime.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
        }

        public static void FitContentSize(this RectTransform content)
        {
            float entityHight = (content.GetChild(0) as RectTransform).sizeDelta.y;
            int count = content.transform.childCount;
            Vector2 size = content.sizeDelta;
            size.y = count * entityHight;
            content.sizeDelta = size;
        }

        public static void SetPivot(this RectTransform rectTransform, Vector2 pivot)
        {
            if (rectTransform == null) return;

            Vector2 size = rectTransform.rect.size;
            Vector2 deltaPivot = rectTransform.pivot - pivot;
            Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y);
            rectTransform.pivot = pivot;
            rectTransform.localPosition -= deltaPosition;
        }


        public static void SetText(this Text objText, string value)
        {
            objText.text = value;
        }

        public static void SetTimeText(this Text text, String preFix, int time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            text.text = preFix + string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }


        public static void C_SetTimeout(this MonoBehaviour _behaviour, float delay, Action task)
        {
            _behaviour.StartCoroutine(DoTask(task, delay));
        }

        private static IEnumerator DoTask(Action task, float delay)
        {
            yield return new WaitForSeconds(delay);
            task?.Invoke();
        }

        public static void C_AddListener(this EventTrigger trigger, EventTriggerType eventType,
            System.Action<PointerEventData> listener)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventType;
            entry.callback.AddListener(data => listener.Invoke((PointerEventData) data));
            trigger.triggers.Add(entry);
        }
    }
}