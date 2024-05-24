using UnityEngine;
using System.Collections;


public class Shelf : MonoBehaviour
{
    public ItemType itemType;     // assign the item type for each shelf in the inspector
    public GameObject icon;     // attach the icon to each shelf to allow disabling
    public Sprite brokenSprite;


    public float shakeDuration = 1.2f;
    public float shakeMagnitude = 2.1f;

    public void DisableIcon()
    {
        icon.SetActive(false);
;    }

    public void BrokenSprite()
    {
        SpriteRenderer iconSpriteRenderer = GetComponent<SpriteRenderer>();
        iconSpriteRenderer.sprite = brokenSprite;

        StartCoroutine(Shake());
    }




    private IEnumerator Shake()     // SHAKE EFFECT! 
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
            float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    // It is called on player controller
    public ItemType GetItemType()
    {
        return itemType;
    }

}
