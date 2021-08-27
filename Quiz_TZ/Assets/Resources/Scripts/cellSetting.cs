using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cellSetting : MonoBehaviour
{
    public string letter;
    public int id;
    public Vector3 normal_scale, event_scale;
    private GameObject obj;

    private void Start()
    {
        obj = this.gameObject;
    }

    private void OnMouseEnter()
    {
        if (IsClicking())
        obj.transform.DOScale(event_scale, 0.2f);
    }

    private void OnMouseExit()
    {
        if (IsClicking())
        obj.transform.DOScale(normal_scale, 0.2f);
    }

    private bool IsClicking()
    {
        return GetComponent<ClickToCell>().cotroller.GetComponent<GameManager>().clicking;
    }

}
