using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public GameManager Manager;
    public Sprite[] PanicImages;

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(Manager.currentPanicLevel < 20)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[0];    
        }else if(Manager.currentPanicLevel < 40)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[1];
        }else if(Manager.currentPanicLevel < 70)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[2];
        }
        else if(Manager.currentPanicLevel < 100)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[3];
        }
    }

   

}
