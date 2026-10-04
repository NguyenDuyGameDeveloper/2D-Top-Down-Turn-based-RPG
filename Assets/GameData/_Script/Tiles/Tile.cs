using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject highlight;

    [Header("Components")]
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseEnter() => highlight.SetActive(true);
    private void OnMouseExit() => highlight.SetActive(false);
    public abstract void Initialize(int x, int y);
}
