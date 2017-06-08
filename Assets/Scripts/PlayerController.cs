using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 15f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(Time.deltaTime * -velocity, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(Time.deltaTime * velocity, 0f, 0f);
        }

    }
}
