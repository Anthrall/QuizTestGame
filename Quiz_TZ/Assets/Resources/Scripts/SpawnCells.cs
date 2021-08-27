using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCells : MonoBehaviour
{
    
    public CellsData cellsdata; //блоки данные с цифрами и буквами
    
    public GameObject celltoCreate, allCells;
    public int typecells;
    private List<int> uses_cells_in_level;

    public void Spawn(int gridcols, int gridrows, float start_x, float start_y, float step_x, float step_y)
    {
        typecells = UnityEngine.Random.Range(0, cellsdata.type.Length); //выбор пака данных случайным образом
        Debug.Log("Type data now is " + cellsdata.type[typecells].name);

        int id = 0;
        int cells = gridrows * gridcols; //количество ячеек
        int count = cellsdata.type[typecells].data.Length; //общее количество букв/цифр
        int index = 0;
        int index_cell = 0;
        uses_cells_in_level = new List<int>();
        GetComponent<GameManager>().uses_letter = new List<string>();
        GetComponent<GameManager>().uses_number = new List<string>();


        LoadList(uses_cells_in_level, cellsdata, typecells);

        Vector3 startPos = new Vector3(start_x, start_y, 0);
        for (int i = 0; i < gridcols; i++)
        {
            for (int j = 0; j < gridrows; j++)
            {
                Vector3 nowPos = new Vector3(startPos.x + (j * step_x), startPos.y + (i * step_y), startPos.z);
                GameObject newCell = Instantiate(
                    celltoCreate,
                    nowPos,
                    Quaternion.identity) as GameObject;

                newCell.transform.SetParent(allCells.transform);
                newCell.GetComponent<cellSetting>().id = id;
                id++;
                //index = UnityEngine.Random.Range(0, count); //случайный выбор буквы или цифры
                index = UnityEngine.Random.Range(0, uses_cells_in_level.Count);
                index_cell = uses_cells_in_level[index];
                newCell.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = cellsdata.type[typecells].data[index_cell].sprite;
                newCell.transform.GetChild(1).GetComponent<Transform>().localScale = new Vector3(cellsdata.type[typecells].scale_x, cellsdata.type[typecells].scale_y, 0);
                Color tmp = cellsdata.type[typecells].data[index_cell].backgroundcolor;
                tmp.a = 100f;
                newCell.transform.GetComponent<SpriteRenderer>().color = tmp;
                newCell.GetComponent<cellSetting>().letter = cellsdata.type[typecells].data[index_cell].letter;
                newCell.GetComponent<ClickToCell>().cotroller = this.gameObject;
                newCell.GetComponent<ClickToCell>().Letter = newCell.transform.GetChild(1).gameObject;

                uses_cells_in_level.Remove(index_cell);
                if (typecells == 0)
                {
                    GetComponent<GameManager>().uses_letter.Add(cellsdata.type[typecells].data[index_cell].letter);
                }
                else
                    GetComponent<GameManager>().uses_number.Add(cellsdata.type[typecells].data[index_cell].letter);

            }
        }
        GetComponent<GameManager>().StartLevel(typecells, GetComponent<LoadLevel>().level_index);
    }

    public void LoadList(List<int> list, CellsData data, int type)
    {
        for (int i = 0; i < data.type[type].data.Length; i++)
        {
            list.Add(i);
        }
    }

    public void ClearLevel()
    {
        for (int i = allCells.transform.childCount-1; i >=0; i--)
        {
            Transform child = allCells.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }
}
