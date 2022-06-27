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

    public ParticleSystem speedLines;

    private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;

    private bool isForward;

    private bool shaking = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = gameObject.transform.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    ///Change character Expression
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
            if(direction == "Left")
            {
                gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if(direction == "Right")
            {
                gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
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

    public void Rotate(float rotation, float duration)
    {
        StartCoroutine(RotateRoutine(rotation, duration));
    }

    [YarnCommand("Spin")]
    public IEnumerator RotateRoutine(float rotation, float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + rotation;

        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation,
            transform.eulerAngles.z);
            yield return null;
        }
    }

    IEnumerator shakeGameObject(float totalShakeDuration, float decreasePoint, bool horizontal = false)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            yield break; //Exit!
        }

        //Get Original Pos and rot
        Transform objTransform = gameObject.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        float counter = 0f;

        //Shake Speed
        const float speed = 0.1f;

        //Angle Rotation(Optional)
        const float angleRot = 4;

        //Do the actual shaking
        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;
            float decreaseAngle = angleRot;

            //Shake GameObject
            if (horizontal)
            {
                //Don't Translate the Z Axis if 2D Object
                Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                tempPos.z = defaultPos.z;
                //objTransform.position = tempPos;
                objTransform.position = new Vector3(tempPos.x, gameObject.transform.position.y, gameObject.transform.position.z);

                //Only Rotate the Z axis if 2D
                //objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            }
            else
            {
                Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;

                objTransform.position = tempPos;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            }
            yield return null;


            //Check if we have reached the decreasePoint then start decreasing  decreaseSpeed value
            if (counter >= decreasePoint)
            {

                //Reset counter to 0 
                counter = 0f;
                while (counter <= decreasePoint)
                {
                    counter += Time.deltaTime;
                    decreaseSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    decreaseAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);

                    //Shake GameObject
                    if (horizontal)
                    {
                        //Don't Translate the Z Axis if 2D Object
                        Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        tempPos.z = defaultPos.z;
                        //objTransform.position = tempPos;
                        objTransform.position = new Vector3(tempPos.x, gameObject.transform.position.y, gameObject.transform.position.z);

                        //Only Rotate the Z axis if 2D
                        //objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));
                    }
                    else
                    {
                        Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        objTransform.position = tempPos;
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));

                    }
                    yield return null;
                }

                //Break from the outer loop
                break;
            }
        }
        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;//Reset to original rotation

        shaking = false; //So that we can call this function next time
    }

    [YarnCommand("ShakeSide")]
    public void shakeGameObjectHorizontal()
    {
        if (shaking)
        {
            return;
        }
        shaking = true;
        StartCoroutine(shakeGameObject(1f, 0.5f, true));
    }

    [YarnCommand("ShakeOver")]
    public void shakeGameObjectAllOver()
    {
        if (shaking)
        {
            return;
        }
        shaking = true;
        StartCoroutine(shakeGameObject(1f, 0.5f, false));
    }

    [YarnCommand("SpeedLines")]
    public void PlaySpeedLines(float duration)
    {
        var main = speedLines.main;
        main.duration = duration;
        speedLines.Play();
    }
}
