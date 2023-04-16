using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class DragNDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Tilemap tileMap;
    [SerializeField] GameObject BlockPrefab;
    [SerializeField] TileBase tile_;
    Image image;
    [SerializeField] Color colorOnHover;
    Color initialColor;
    //Vector3 initialPosition;
    RectTransform rectTransform;
    Vector2 initialPosition;
    Canvas canvas;
    [SerializeField] string blockName;

    void Start()
    {
        //initialPosition = transform.position;
        image = gameObject.GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (image == null) return;
        image.sprite = BlockPrefab.GetComponent<SpriteRenderer>().sprite;
        image.color = BlockPrefab.GetComponent<SpriteRenderer>().color;
        initialColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = colorOnHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = initialColor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = initialPosition;

        Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TileBase tile = tileMap.GetTile(tileMap.LocalToCell(new Vector3(i.x, i.y)));
        if (tile == null) return;
        string a = tile.ToString();
        string[] word = a.Split(" ");
        Debug.Log($"/{word[0]}/");

        if (word[0] == blockName)
        {
            GameObject block = Instantiate(BlockPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);

            block.transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(block.transform.position.x, block.transform.position.y, 0)));
            //Vector3 pition = tileMap.LocalToCell(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0));
            //Vector3 Psition = tileMap.GetCellCenterWorld(new Vector3Int((int)pition.x, (int)pition.y, (int)pition.z));
            //tileMap.SetTile(new Vector3Int((int)Psition.x, (int)Psition.y, 0), tile_);
            //block.GetComponent<SpriteRenderer>().color = new Color(colorOnHover.r, colorOnHover.g, colorOnHover.b, 1f);
        }
    }
}
