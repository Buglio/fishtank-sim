using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float maxSpeed;
    public float xLimit;
    public float yLimit;
    public float xPos = 0f;
    public float yPos = 0f;
    public float angleRad = 2f;
    public float jitterLevel = 0.1f;
    public bool flip = false;
    public float Speed = 0.1f;

    void SpeedChange()
    {
        if (UnityEngine.Random.Range(0f, 100f) > 95f)
        {
            Speed = UnityEngine.Random.Range(0, maxSpeed);
        }
    }
    void MoveRandom()
    {
        SpeedChange();
        //update angle random
        angleRad += UnityEngine.Random.Range(jitterLevel, -1f * jitterLevel);
        float velX = Mathf.Cos(angleRad);
        float velY = Mathf.Sin(angleRad);

        // update rotation
        if (velX > 0f) { transform.eulerAngles = new Vector3(0, 180, 0); }
        if (velX < 0f) { transform.eulerAngles = new Vector3(0, 0, 0); }

        if (velX > 0)
        {
            if (xPos <= xLimit)
            {
                xPos += velX * Speed;
            }
            else
            {
                angleRad += UnityEngine.Random.Range(Mathf.PI * 0.5f, Mathf.PI * 1.5f);
            }

        }
        else if (velX < 0)
        {
            if (xPos >= -1 * xLimit)
            {
                xPos += velX * Speed;
            }
            else
            {
                angleRad += UnityEngine.Random.Range(Mathf.PI * 0.5f, Mathf.PI * 1.5f);
            }
        }

        if (velY > 0)
        {
            if (yPos <= yLimit)
            {
                yPos += velY * Speed / 3;
            }
            else
            {
                angleRad += UnityEngine.Random.Range(Mathf.PI * 0.5f, Mathf.PI * 1.5f);
            }
        }
        else if (velY < 0)
        {
            if (yPos >= -1 * yLimit)
            {
                yPos += velY * Speed / 3;
            }
            else
            {
                angleRad += UnityEngine.Random.Range(Mathf.PI * 0.5f, Mathf.PI * 1.5f);
            }
        }

        transform.position = new Vector3(xPos, yPos, 0);
    }

    void Update()
    {
        MoveRandom();

    }
}