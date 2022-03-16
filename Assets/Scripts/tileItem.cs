using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileItem : MonoBehaviour
{
    /*
     * 0 => left
     * 1 => up
     * 2 => right
     * 3 => down
     */
    private TileO tile;
    //Testing Purposes
    [SerializeField]
    private Text nuTxt;
    [SerializeField]
    private GameObject[] bordersGo;

    private bool isEscape;

    private void Awake()
    {
        //Testing Purposes
        nuTxt.text = GetComponent<RectTransform>().GetSiblingIndex().ToString("00");
        tile = new TileO();
    }

    public void SetData(TileO tile, bool isEscape = false)
    {
        this.tile = tile;
        for (int i = 0; i < tile.borders.Length; i++)
            bordersGo[i].SetActive(tile.borders[i] == 1);
        this.isEscape = isEscape;
    }

    public bool getIsEscape() { return isEscape; }
    public int[] GetBorders() { return tile.borders; }
    public TileO getTile() { return tile; }

}