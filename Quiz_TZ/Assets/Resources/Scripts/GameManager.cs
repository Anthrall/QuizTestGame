using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int index;
    public bool clicking;
    public string goal_letter;
    public List<string> uses_letter;
    public List<string> uses_number;
    public List<string> letter_used;
    public List<string> number_used;
    public Text goal;
    public Image panel;
    public Image Restart_button;
    private Color tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = panel.color;
        tmp.a = 0f;
        panel.color = tmp;
        Restart_button.enabled = false;
        clicking = true;
        uses_letter = new List<string>();
        uses_number = new List<string>();
        letter_used = new List<string>();
        number_used = new List<string>();
    }

    public void StartLevel(int typebase, int numberlevel)
    {
        //type_base = typebase;
        //level = numberlevel;
        if (typebase == 0)
        {
            if (letter_used.Count != 0)
            {
                DeleteUsedLetter(letter_used, uses_letter);
            }
            index = UnityEngine.Random.Range(0, uses_letter.Count);
            goal_letter = uses_letter[index];
            letter_used.Add(goal_letter);
        }
        else
        {
            if (number_used.Count != 0)
            {
                DeleteUsedLetter(number_used, uses_number);
            }
            index = UnityEngine.Random.Range(0, uses_number.Count);
            goal_letter = uses_number[index];
            number_used.Add(goal_letter);
        }
        if (numberlevel == 0)
        {
            goal.text = "Find " + goal_letter;
            Color tmp = goal.color;
            tmp.a = 0f; goal.color = tmp;
            var Seq = DOTween.Sequence();
            Seq.AppendInterval(0.1f);
            Seq.Append(goal.DOFade(100f, 70f));
        }
        else
            goal.text = "Find " + goal_letter;
    }

    public void FadeInPanel()
    {
        panel.DOFade(100f, 70f);
        Restart_button.enabled = true;

    }


    private void DeleteUsedLetter(List<string> listFrom, List<string> listTo)
    {
        for (int i = 0; i < listFrom.Count; i++)
        {
            foreach (string letter in listTo)
            {
                if (letter == listFrom[i])
                {
                    listTo.Remove(letter);
                    break;
                }
            }
        }
    }
}
