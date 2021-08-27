using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClickToCell : MonoBehaviour
{
    public GameObject cotroller;
    public GameObject Letter;
    public ParticleSystem stars;
    

    void OnMouseDown()
    {
        if (IsClicking())
        {
            if (this.gameObject.GetComponent<cellSetting>().letter == cotroller.gameObject.GetComponent<GameManager>().goal_letter)
            {
                cotroller.gameObject.GetComponent<GameManager>().goal.text = "CORRECT";
                Winner();
                Invoke("NextLevel", 3f);
                //Debug.Log("Succes");
            }
            else
            {
                Loser();
                //Debug.Log("Wrong");
            }
        }
        
    }
    public void NextLevel()
    {
        int level = cotroller.gameObject.GetComponent<LoadLevel>().level_index;
        int count = cotroller.gameObject.GetComponent<LoadLevel>().levels.Length;
        if (level != count-1)
            cotroller.gameObject.GetComponent<LoadLevel>().LoadLv(++cotroller.gameObject.GetComponent<LoadLevel>().level_index);
        else
        {
            Stopclick();
            cotroller.gameObject.GetComponent<GameManager>().goal.text = "Good job! Want again?";
            cotroller.gameObject.GetComponent<GameManager>().FadeInPanel();
            
        }
    }

    private void Loser()
    {
        Letter.transform.DOShakePosition(0.4f, new Vector3(0.3f,0.3f,0f), 10, 90, false, false).SetEase(Ease.InBounce);
    }

    private void Winner()
    {
        stars.Play();
        Vector3 normal_size = Letter.transform.localScale;
        var Seq = DOTween.Sequence();
        //Seq.AppendInterval(0.1f);
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x + 0.05f, normal_size.y + 0.05f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x - 0.1f, normal_size.y - 0.1f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(normal_size, 0.2f));
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x + 0.05f, normal_size.y + 0.05f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x - 0.1f, normal_size.y - 0.1f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(normal_size, 0.2f));
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x + 0.05f, normal_size.y + 0.05f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(new Vector3(normal_size.x - 0.1f, normal_size.y - 0.1f, normal_size.z), 0.3f));
        Seq.Append(Letter.transform.DOScale(normal_size, 0.2f));
    }

    private bool IsClicking()
    {
        return cotroller.GetComponent<GameManager>().clicking;
    }

    private void Stopclick()
    {
        cotroller.GetComponent<GameManager>().clicking = false;
    }
}
