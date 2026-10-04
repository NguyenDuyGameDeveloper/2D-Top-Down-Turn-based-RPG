using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offSetColor;

    public override void Initialize(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        sr.color = isOffset ? offSetColor : baseColor;
    }
}
