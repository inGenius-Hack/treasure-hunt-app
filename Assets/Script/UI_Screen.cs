using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Ingenius.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UI_Screen : MonoBehaviour
    {


        #region Variables
        [Header("Main Properties")]
        public UI_System ui;
        public Selectable m_StartSelectable;

        [Header("Screen Events")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();
 
        
        private Animator animator;
        #endregion






        #region Main methods
        void Start()
        {
            animator = GetComponent<Animator>();
            if(m_StartSelectable)
            {
                EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
            }
            Debug.Log(gameObject.name);
        }

   
        #endregion






        #region Helper methods
        public virtual void StartScreen()
        {
            if (onScreenStart != null)
            {
                onScreenStart.Invoke();
            }
            HandleTrigger("show");
        }
        public virtual void CloseScreen()
        {
            if (onScreenClose != null)
            {
                onScreenClose.Invoke();
            }
            HandleTrigger("hide");

        }
        void HandleTrigger(string sTrigger)
        {
            if (animator)
            {
                animator.SetTrigger(sTrigger);
            }
        }
        #endregion
    }
}