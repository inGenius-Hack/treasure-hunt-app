using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;
namespace Ingenius.UI
{
    public class SetLvlState : MonoBehaviour
    {
        public UI_System ui;
        public int level;
        
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Set state");
            setState();
             
           
        }
        // Update is called once per frame
        void Update()
        {

        }
        public void setState()
        {
            int current_lvl = ui.level;
            Debug.Log("ui level:"+ui.level);

            if (level <= current_lvl)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}