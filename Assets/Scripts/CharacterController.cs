using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using Yarn.Unity;

public class CharacterController : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    [YarnCommand("Expression")]
    public void SwapSprite(string expressionName)
    {

        targetResolver.SetCategoryAndLabel(targetCategory, expressionName);
    }

    [YarnCommand("Flip")]
    private void Flip()
    {
        if (gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX == false)
        {
            gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = false;

        }
    }

    [YarnCommand("Spin")]
    private IEnumerator Spin(float repeat)
    {
        float val = 0;
        while (val < repeat)
        {
            Flip();
            yield return new WaitForSeconds(0.25f);
            Flip();
            yield return new WaitForSeconds(0.25f);
            val++;
        }
    }

    [YarnCommand("Hop")]
    private IEnumerator HopUpAndDown(float repeat)
    {
        float val = 0;
        while (val < repeat)
        {
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            val++;
        }
    }

    private IEnumerator Hop(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    [YarnCommand("WalkTowards")]
    private IEnumerator WalkTowards(float moveAmount, string direction, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Dictionary<string, Vector3> afterPosition = new Dictionary<string, Vector3>
        {
            {"Left", new Vector3(startPosition.x - moveAmount,transform.position.y,startPosition.z) },
            {"Right", new Vector3(startPosition.x + moveAmount,transform.position.y,startPosition.z)},
            {"Up", new Vector3(transform.position.x,startPosition.y - moveAmount,startPosition.z) },
            {"Down",new Vector3(transform.position.x,startPosition.y - moveAmount,startPosition.z) },

        };
        if (!afterPosition.ContainsKey(direction)) yield return null;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, afterPosition[direction], time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float time = 0;
        Color startValue = new Color(spriteRend.color.r, spriteRend.color.b, spriteRend.color.g, 0);
        Color endValue = new Color(spriteRend.color.r, spriteRend.color.b, spriteRend.color.g, 1);

        spriteRend.color = startValue;

        while (time < 1f)
        {
            spriteRend.color = Color.Lerp(startValue, endValue, time / 1f);
            time += Time.deltaTime;
            yield return null;

        }
        spriteRend.color = endValue;
    }

    public IEnumerator FadeOut()
    {
        float time = 0;
        Color startValue = new Color(spriteRend.color.r, spriteRend.color.b, spriteRend.color.g, 1);
        Color endValue = new Color(spriteRend.color.r, spriteRend.color.b, spriteRend.color.g, 0);

        spriteRend.color = startValue;

        while (time < 1f)
        {
            spriteRend.color = Color.Lerp(startValue, endValue, time / 1f);
            time += Time.deltaTime;
            yield return null;

        }
        spriteRend.color = endValue;
    }
}
