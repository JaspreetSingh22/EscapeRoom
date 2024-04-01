using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadLock : MonoBehaviour
{
   [SerializeField] string code;
    string key = null;
    public Text typedText;

   public void OnclickNo(string ButtonNo)
    {
        key = key + ButtonNo;
        typedText.text = key;
    }
    public void OnclickYes()
    { 
        if(key != null)
        {
            if (key == code)
            {
                typedText.color = Color.green;
                typedText.text = "CORRECT";
            }
            else
            {
                typedText.color = Color.red;
                typedText.text = "Wrong";
                StartCoroutine("startTimer");
            }
        }
    }
    public void OnClickClear()
    {
        typedText.text = "";
        typedText.color = Color.black;
        key = null;
        
    }
    IEnumerator startTimer()
    {
        yield return new WaitForSeconds(2f);
        typedText.text = "";
        typedText.color = Color.black;
        key = null;
    }
}
