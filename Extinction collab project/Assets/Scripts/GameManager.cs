using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int currentPanicLevel;
    public float nextSituationTimer;
    float FoxNewsTime = 5f;
    float SituationTimer;
    int maxPanicLevel = 1000;
    int PanicIncrease;
    bool AnsweringSituation = false;
    public Situations[] ListOfSituations;
    private Situations currentSituation;
    bool GameOver = false;
    bool WatchingFoxNews = false;
    int WatchedFoxNews;
    int Days = 0;
    float DaysCountTimer = 0f;

    //UI
    [Header("UI")]
    public Text QuestionText;
    public Button[] AnswerButton;
    public Image PhoneImage;
    public Animator PhoneAnimation;
    public Image FoxNews;
    public Image Background;
    public Animator ForeGroundAnimation;
    public Text DaysText;

    [Header("Audio")]
    public AudioClip PhoneRing;
    

    private void Start()
    {
        QuestionText.gameObject.SetActive(false);
        for(int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.SetActive(false);
        }
        SituationTimer = nextSituationTimer;
        DaysText.text = "Days: " + Days;
    }

    private void Update()
    {
        if(currentPanicLevel >= maxPanicLevel && GameOver == false)
        {
            //Game Over
            SceneManager.LoadScene(1);
            
        }else if(WatchedFoxNews == 4 && GameOver == false)
        {
            GameOver = true;
            Background.gameObject.SetActive(false);
            PhoneImage.gameObject.SetActive(false);
            FoxNews.gameObject.SetActive(false);
            ForeGroundAnimation.SetTrigger("Play");
        }

        if(SituationTimer <= 0f)
        {
            if(AnsweringSituation == false)
            {
                PhoneImage.gameObject.GetComponent<AudioSource>().clip = PhoneRing;
                PhoneImage.gameObject.GetComponent<AudioSource>().Play();
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
            FoxNews.gameObject.GetComponent<Animator>().SetBool("Close", false);
            FoxNewsTime -= Time.deltaTime;
            DaysCountTimer += Time.deltaTime;
            if(DaysCountTimer >= 2f)
            {
                Days++;
                DaysText.text = "Days: " + Days;
                if (currentPanicLevel >= 50)
                {
                    currentPanicLevel -= 50;
                }
                DaysCountTimer = 0f;
            }
            if(FoxNewsTime <= 0f)
            {
                FoxNews.gameObject.GetComponent<Animator>().SetBool("Close", true);
                FoxNewsTime = 5f;
                WatchingFoxNews = false;
            }
        }
    }

    public void GoodChoice()
    {
        PanicIncrease = 10 * currentSituation.Seriousness;
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
        DaysText.text = "Days: " + Days;
        
    }

    public void BadChoice()
    {
        PanicIncrease = 10 * currentSituation.Seriousness;
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
        DaysText.text = "Days: " + Days;

    }

    public void NoChoice()
    {
        PanicIncrease = 30* currentSituation.Seriousness;
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
        DaysText.text = "Days: " + Days;
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
        FoxNews.gameObject.GetComponent<Animator>().SetTrigger("Watching");
        PhoneAnimation.SetBool("Done", true);
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
