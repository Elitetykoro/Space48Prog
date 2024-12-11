using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using TMPro;
using Unity.VisualScripting;


public class Items : MonoBehaviour
{
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;
    [SerializeField] private UnityEngine.UI.Image itemImageHolder;
    [SerializeField] private Shooting shooting;
    [SerializeField] private ShipMovement shipMovement;
    [SerializeField] private Text text;

    private void Update()
    {
        CycleItems();
        UseItem();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    void UseItem()
    {

        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

            if (items[activeItemIndex] == Color.blue)
            {
                StartCoroutine(text.ShowMessage(" +  Move Speed",3f));
                shipMovement.moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(text.ShowMessage(" + Fire Rate", 3f));
                shooting.cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                StartCoroutine(text.ShowMessage(" + Rotation Speed", 3f));
                shipMovement.rotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
}
