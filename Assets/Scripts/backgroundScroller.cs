using System.Numerics;
using UnityEngine;

public class backgroundScroller : MonoBehaviour
{

    [SerializeField] UnityEngine.Vector2 moveSpeed;

    UnityEngine.Vector2 offset;
    Material material;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        
        offset += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;

    }


}
