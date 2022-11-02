using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCursor : MonoBehaviour
{
    [SerializeField] Texture2D _initialTexture;
    [SerializeField] Texture2D _hoverTexture;
    public void Start()
    {
        SetCursorTexture(_initialTexture);
    }

    public void SetCursorTexture(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }


}
