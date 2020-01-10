using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlternativeEnding : MonoBehaviour
{
    public void AnimationEnd()
    {
        SceneManager.LoadScene(1);
    }
}
