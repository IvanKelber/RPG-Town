using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CellSize : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(1,10)]
    public int numRows;
    [Range(1,10)]
    public int numCols;

    [Range(0,1)]
    public float spacingPercentageX;

    [Range(0,1)]
    public float spacingPercentageY;

    [Range(0,1)]
    public float paddingPercentageX;
    [Range(0,1)]
    public float paddingPercentageY;

    public float minSizeX;
    public float minSizeY;

    private RectTransform rectTransform;
    private GridLayoutGroup layout;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        layout = GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        float parentHeight = rectTransform.rect.height;
        float parentWidth = rectTransform.rect.width;

        float paddingX = parentWidth * paddingPercentageX;
        float paddingY = parentWidth * paddingPercentageY;

        float adjustedHeight = parentHeight - 2 * paddingY;
        float adjustedWidth = parentWidth - 2 * paddingX;


        float spacingX = parentWidth * spacingPercentageX;
        float spacingY = parentHeight * spacingPercentageY;

    

        Vector2 cellSize = new Vector2(Mathf.Clamp((adjustedWidth/numCols) - spacingX, minSizeX, adjustedWidth), 
                                       Mathf.Clamp((adjustedHeight/numRows) - spacingY, minSizeY, adjustedHeight));

        layout.spacing = new Vector2(spacingX, spacingY);

        layout.cellSize = cellSize;


    }
}
