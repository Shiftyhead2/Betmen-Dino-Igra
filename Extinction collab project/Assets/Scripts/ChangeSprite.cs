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
        if(Manager.currentPanicLevel < 250)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[0];
            Manager.GetComponent<AudioSource>().pitch = 1f;
        }else if(Manager.currentPanicLevel < 450)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[1];
            Manager.GetComponent<AudioSource>().pitch = 0.9f;
        }
        else if(Manager.currentPanicLevel < 550)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[2];
            Manager.GetComponent<AudioSource>().pitch = 0.7f;
        }
        else if(Manager.currentPanicLevel < 750)
        {
            this.gameObject.GetComponent<Image>().sprite = PanicImages[3];
            Manager.GetComponent<AudioSource>().pitch = 0.5f;
        }
        else if(Manager.currentPanicLevel < 1000)
        {
            Manager.GetComponent<AudioSource>().pitch = 0.3f;
        }
    }

   

}
