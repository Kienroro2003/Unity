using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Text rows;
    public Text columns;
    public GameObject boxPrefab;
    public GameObject panel;

    public void buttonOK()
    {
        RectTransform rectTransform = panel.GetComponent<RectTransform>();
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        RectTransform boxTransform = boxPrefab.GetComponent<RectTransform>();
        float withBox = boxTransform.rect.width;
        float heightBox = boxTransform.rect.height;
        float rootTop = height / 2 ;
        float rootLeft = width / 2;
        Debug.Log("Width: " + withBox + ", height: " + heightBox);
        Debug.Log("Width parent: " + width + ", height parent: " + height);
        int intRows = int.Parse(rows.text);
        int intColumns = int.Parse(columns.text);
        float spaceRow = (height - heightBox * intRows) / (intRows - 1);
        float spaceColumn = (width - withBox * intColumns) / (intColumns - 1);
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        };
        for(int i = 0; i < intRows; i++)
        {
            for(int j = 0; j < intColumns; j++)
            {
                GameObject game = Instantiate(boxPrefab);
                game.SetActive(true);
                game.GetComponent<Image>().enabled = true;
                Debug.Log(rootTop - heightBox / 2 - spaceRow * i);
                game.transform.position = new Vector3(-rootLeft + withBox / 2 + spaceColumn * j, rootTop - heightBox / 2 - spaceRow * i, 0);
                game.transform.SetParent(panel.transform, false);
            }
        }
    }

    void OnRectTransformDimensionsChange()
    {
        Debug.Log("Run change windown");
        buttonOK();
    }

}
