using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadLevel : MonoBehaviour
{
    public int level_index = 0;
    public float duration, duration2;
    public Levels[] levels; //настройки для каждого уровня
    public GameObject allCells;
    public Vector3 orignal_scale, start_bounce_scale;
    void Start()
    {
        LoadLv(level_index);
        Bounce();
    }

    public void Bounce()
    {
        for (int i = 0; i < allCells.transform.childCount; i++)
        {
            Transform obj = allCells.transform.GetChild(i);
            obj.transform.localScale = start_bounce_scale;
            var Seq = DOTween.Sequence();
            Seq.AppendInterval(0.1f);
            Seq.Append(obj.transform.DOScale(new Vector3(orignal_scale.x + 0.15f, orignal_scale.y + 0.15f, orignal_scale.z), duration));
            Seq.Append(obj.transform.DOScale(new Vector3(orignal_scale.x - 0.1f, orignal_scale.y - 0.1f, orignal_scale.z), duration2));
            //Seq.AppendInterval(0.1f);
            Seq.Append(obj.transform.DOScale(new Vector3(orignal_scale.x + 0.1f, orignal_scale.y + 0.1f, orignal_scale.z), duration2));
            //Seq.AppendInterval(0.1f);
            Seq.Append(obj.transform.DOScale(orignal_scale, duration2));
        }
    }

    public void LoadLv(int level_index)
    {
        if (allCells.transform.childCount > 0)
            this.GetComponent<SpawnCells>().ClearLevel();
            this.GetComponent<SpawnCells>().Spawn(
                levels[level_index].grid_column,
                levels[level_index].grid_row,
                levels[level_index].start_position.x,
                levels[level_index].start_position.y,
                levels[level_index].step_to_x,
                levels[level_index].step_to_y);
    }
}
