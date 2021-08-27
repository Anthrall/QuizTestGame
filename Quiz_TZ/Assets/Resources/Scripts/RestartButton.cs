using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector3 normal;
    public Image loading;
    public Text text;
    public GameObject controller;
    public void Start()
    {
        normal = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(normal.x - 0.1f, normal.y - 0.1f, normal.z), 0.2f);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(normal.x + 0.2f, normal.y + 0.2f, normal.z), 0.2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(normal.x + 0.2f, normal.y + 0.2f, normal.z), 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(normal, 0.2f);
    }

    public void DoRestart()
    {

        controller.GetComponent<SpawnCells>().ClearLevel();
        this.gameObject.SetActive(false);
        text.enabled = false;
        Invoke("SceneRestart", 3f);
        
    }

    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
