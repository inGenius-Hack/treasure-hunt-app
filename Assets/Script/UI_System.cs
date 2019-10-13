using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ingenius.UI
{
    public class UI_System : MonoBehaviour
    {


        #region Variables
        [Header("Player Data")]
        public int level = 1;
        public string teamName;
        public string password;
        public GameObject tf_overlay;

        [Header("Main Properties")]
        public UI_Screen m_StartScreen;
        public SimpleScrollSnap simpleScrollSnap;

        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();
        public UnityEvent refresh = new UnityEvent();

        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration;
        public float m_FadeOutDuration;


        public Component[] screens = new Component[0];

        private UI_Screen currentScreen;
        public UI_Screen CurrentScreen { get { return currentScreen; } }


        private UI_Screen previousScreen;
        public UI_Screen PreviousScreen { get { return previousScreen; ; } }
        #endregion





        #region Main Methods
        void Start()
        {
          //  ResetPlayer();
            Debug.Log("ui");
            LoadPlayer();
            refresh.Invoke();
            simpleScrollSnap = GetComponentInChildren<SimpleScrollSnap>();
            Screen.fullScreen = false;
            screens = GetComponentsInChildren<UI_Screen>(true);
            if (m_StartScreen)
            {
                SwitchScreens(m_StartScreen);
            }
            if (m_Fader)
            {
                m_Fader.gameObject.SetActive(true);
            }
            //FadeOut();
            FadeIn();

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (CurrentScreen == screens[1])
                {
#if UNITY_ANDROID
                    Debug.Log("Nope");
                    AndroidJavaObject activity =
                       new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                       .GetStatic<AndroidJavaObject>("currentActivity");
                    activity.Call<bool>("moveTaskToBack", true);
#endif
                }
                else if (CurrentScreen == screens[3])
                {
                    GoToPreviousScreen();
                }
                else if (CurrentScreen == screens[5])
                {
                    SwitchScreens(screens[4] as UI_Screen);
                }
                else if (CurrentScreen == screens[4])
                {
                    SwitchScreens(screens[1] as UI_Screen);
                }
            }
        }
        #endregion




        #region Helper Methods

        public void SwitchScreens(UI_Screen screen)
        {
            if (screen)
            {
                if (currentScreen)
                {
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
                }
                currentScreen = screen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();
            }

            if (onSwitchedScreen != null)
            {
                onSwitchedScreen.Invoke();
            }
        }
        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreens(previousScreen);
            }
        }
        public void FadeIn()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
            }
        }
        public void FadeOut()
        {
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(1f, m_FadeOutDuration, false);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }
        public void LoadPlayer()
        {
            PlayerData data = SaveSytem.LoadPlayer();
            level = data.level;
            //  teamName = data.teamName;
            //  password = data.password;
        }
        public void SavePlayer()
        {
            SaveSytem.SavePlayer(this);
        }
        public void ResetPlayer()
        {
            level = 1;
            SavePlayer();
        }
        public int getSelectedLevel()
        {
            return simpleScrollSnap.CurrentPanel;
        }
        public int getCurrentlevel()
        {
            PlayerData data = SaveSytem.LoadPlayer();
            return data.level;
        }
        public void ValidateAnswer(GameObject img_lock)
        {

            bool Answer = true;
            //TODO 
            Debug.Log(getSelectedLevel());
            if (getSelectedLevel() == level)
            {
                if (Answer)
                {
                    level += 1;
                    SavePlayer();
                    img_lock.SetActive(false);
                }
                else
                {
                    img_lock.SetActive(true);
                }
            }
            else
            {
                if (getSelectedLevel() < level)
                {
                    //Loads Question
                }
            }
        }
        public void play()
        {
            int index = getSelectedLevel();
            if (index+1 <= level)
            {

                SwitchScreens(screens[5] as UI_Screen);
            }

        }
        public void DiplayAnswerOverlay()
        {
            tf_overlay.SetActive(true);
        }

        public void Logout()
        {
            level = 1;
            SavePlayer();
            SwitchScreens(screens[0] as UI_Screen);
            refresh.Invoke();
            simpleScrollSnap.GoToPanel(0);

        }

        #endregion
    }
}

    
