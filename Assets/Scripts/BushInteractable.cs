using UnityEngine;

public class BushInteractable : MonoBehaviour
{
    [SerializeField] private Sprite searchedSprite;
    [SerializeField] private GameObject hiddenItem; // child

    private SpriteRenderer sr;
    private Collider2D col;

    private bool isSearched = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        if (hiddenItem != null)
            hiddenItem.SetActive(false);
    }

    public void Search()
    {
        if (isSearched)
            return;

        isSearched = true;
        gameObject.tag = "Untagged";

        Debug.Log("Przeszukano krzak");

        // zmiana sprite
        if (searchedSprite != null)
            sr.sprite = searchedSprite;

        // wy³¹cz collider (ju¿ nie mo¿na ponownie u¿yæ)
        if (col != null)
            col.enabled = false;

        // odpal item jeœli istnieje
        if (hiddenItem != null)
        {
            hiddenItem.SetActive(true);
            hiddenItem.transform.SetParent(null); // wypada z krzaka

            // opcjonalnie lekko odsuñ
            hiddenItem.transform.position += new Vector3(0.2f, 0.2f, 0);
        }
    }
}