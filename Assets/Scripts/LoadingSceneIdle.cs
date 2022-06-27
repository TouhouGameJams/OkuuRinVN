using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class LoadingSceneIdle : MonoBehaviour
{
    public SpriteRenderer spriteRend;

    [SerializeField]
    private SpriteLibrary spriteLibrary = default;

    [SerializeField]
    private SpriteResolver targetResolver = default;

    [SerializeField]
    private string targetCategory = default;

    private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

    private bool isForward;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = gameObject.transform.GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(ExpressionSwap());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwapSprite(string expressionName)
    {
        targetResolver.SetCategoryAndLabel(targetCategory, expressionName);
    }

    public IEnumerator ExpressionSwap()
    {
        SwapSprite("Neutral");
        yield return new WaitForSeconds(1f);
        SwapSprite("Happy");
        yield return new WaitForSeconds(1f);
        StartCoroutine(ExpressionSwap());
    }
}
