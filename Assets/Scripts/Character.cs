using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [System.Serializable] // map of textures for facial expressions
    public class Expression
    {
        public string name;
        public Image sprite;
    }

    [SerializeField] List<Expression> expressions = new List<Expression>();

    private bool isForward;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.localScale.x == -1)
        {
            isForward = false;
        }
        else
        {
            isForward = true;
        }


        if (expressions.Count < 1)
        {
            Debug.LogError($"Character {name} has no available sprites.");
            return;
        }
        Debug.Log($"Character {name} created.");
        SetSprite(expressions[0].sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //[YarnCommand("Expression")]
    public void SetExpression(string expressionName)
    {
        // find the expression with the same name as we are looking for
        Expression expressionToUse = FindExpressionWithName(expressionName);
        if (expressionToUse == null)
        {
            Debug.LogError($"Character {name} has no Expression named {expressionName}.");
            return;
        }
        SetSprite(expressionToUse.sprite);
    }

    private Expression FindExpressionWithName(string expressionName)
    {
        var caseInsensitiveMode = System.StringComparison.InvariantCultureIgnoreCase;
        foreach (Expression expression in expressions)
        {
            if (expression.name.Equals(expressionName, caseInsensitiveMode))
            {
                return expression;
            }
        }
        return null;
    }

    //[YarnCommand("Flip")]
    private void Flip()
    {
        if (isForward)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            isForward = false;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            isForward = true;
        }
    }

    //[YarnCommand("Hop")]
    private IEnumerator HopUpAndDown(float repeat)
    {
        float val = 0;
        while (val < repeat)
        {
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y - 100f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            val++;
        }
    }

    //[YarnCommand("Spin")]
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


    private IEnumerator MoveTowards(Vector3 targetPosition, float duration)
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

    //[YarnCommand("WalkTowards")]
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
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            StartCoroutine(Hop(new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z), 0.15f));
            yield return new WaitForSeconds(0.15f);
            transform.position = Vector3.Lerp(startPosition, afterPosition[direction], time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void SetSprite(Image image)
    {
        foreach (var expression in expressions)
        {
            expression.sprite.gameObject.SetActive(false);
        }

        image.gameObject.SetActive(true);
    }
}
