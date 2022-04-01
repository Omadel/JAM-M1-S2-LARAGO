using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LaraGoLike
{
    [AddComponentMenu("UI/Better Button")]
    public class BetterButton : Button, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {
        public System.Action OnHover { get; set; }
        public System.Action OnPress { get; set; }
        public System.Action OnClick{ get; set; }

        protected override void Start()
        {
            onClick.AddListener(() => OnClick?.Invoke());
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            OnHover?.Invoke();
        }
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            OnPress?.Invoke();
        }
    }
}
