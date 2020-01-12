using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Situation",menuName = "Situation",order = 51)]
public class Situations : ScriptableObject
{
    public string SituationText;
    public string[] SituationAnswers;
    public int Seriousness;
}
