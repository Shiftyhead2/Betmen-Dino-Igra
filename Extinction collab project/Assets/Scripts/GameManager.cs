using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentPanicLevel;
    public float nextSituationTimer;
    float FoxNewsTime = 2f;
    float SituationTimer;
    int maxPanicLevel = 100;
    int PanicIncrease;
    bool AnsweringSituation = false;
    public Situations[] ListOfSituations;
    private Situations currentSituation;
    bool GameOver = false;
    bool WatchingFoxNews = false;
    int WatchedFoxNews;
    int Days = 0;

    //UI
    public Text QuestionText;
    public Button[] AnswerButton;
    public Button RestartButton;
    public Image PhoneImage;
    public Animator PhoneAnimation;
    public Image FoxNews;
    public Image Background;
    public Animator ForeGroundAnimation;
    public Text DaysText;

    private void Start()
    {
        QuestionText.gameObject.SetActive(false);
        FoxNews.gameObject.SetActive(false);
        for(int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        SituationTimer = nextSituationTimer;
    }

    private void Update()
    {
        if(currentPanicLevel >= 100 && GameOver == false)
        {
            //Game Over
            SceneManager.LoadScene(1);
            
        }else if(WatchedFoxNews == 4 && GameOver == false)
        {
            GameOver = true;
            Background.gameObject.SetActive(false);
            PhoneImage.gameObject.SetActive(false);
            ForeGroundAnimation.SetTrigger("Play");
        }

        

        if(SituationTimer <= 0f)
        {
            if(AnsweringSituation == false)
            {

                PhoneAnimation.SetTrigger("OpenPhone");
                GenerateSituation();
                AnsweringSituation = true;
                
            }
            
            
        }

        

        if (AnsweringSituation == false && GameOver == false && WatchingFoxNews == false)
        {
            SituationTimer -= Time.deltaTime;
        }

        if(WatchingFoxNews == true && GameOver == false)
        {
            FoxNews.gameObject.SetActive(true);
            FoxNewsTime -= Time.deltaTime;
            if(FoxNewsTime <= 0f)
            {
                FoxNews.gameObject.SetActive(false);
                FoxNewsTime = 2f;
                WatchingFoxNews = false;

            }
        }

        DaysText.text = "Days: " + Days;


    }

    public void GoodChoice()
    {
        PanicIncrease = 5;
        currentPanicLevel += PanicIncrease;
        AnsweringSituation = false;
        SituationTimer = nextSituationTimer;
        QuestionText.gameObject.SetActive(false);
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        PhoneAnimation.SetBool("Done", true);
        Days++;
    }

    public void BadChoice()
    {
        PanicIncrease = 10;
        currentPanicLevel += PanicIncrease;
        AnsweringSituation = false;
        SituationTimer = nextSituationTimer;
        QuestionText.gameObject.SetActive(false);
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        PhoneAnimation.SetBool("Done", true);
        Days++;

    }

    public void NoChoice()
    {
        PanicIncrease = 30;
        currentPanicLevel += PanicIncrease;
        AnsweringSituation = false;
        SituationTimer = nextSituationTimer;
        QuestionText.gameObject.SetActive(false);
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        PhoneAnimation.SetBool("Done", true);
        Days++;
    }

    public void WatchFoxNews()
    {
        AnsweringSituation = false;
        SituationTimer = nextSituationTimer;
        QuestionText.gameObject.SetActive(false);
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        WatchedFoxNews++;
        WatchingFoxNews = true;
        PhoneAnimation.SetBool("Done", true);
        Days++;
    }


   public void GenerateSituation()
    {
        PhoneAnimation.SetBool("Done", false);
        currentSituation = ListOfSituations[Random.Range(0, ListOfSituations.Length)];
        QuestionText.text = currentSituation.SituationText;
        QuestionText.gameObject.SetActive(true);
        for (int i = 0; i < currentSituation.SituationAnswers.Length; i++)
        {
            AnswerButton[i].GetComponentInChildren<Text>().text = currentSituation.SituationAnswers[i];
            AnswerButton[i].gameObject.SetActive(true);
        }
    }

    

    
    
}
