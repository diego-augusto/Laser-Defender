using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 15f;
    public float padding = 1f;
    public float xmin;
    public float xmax;

    void Start()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        var rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * velocity * Time.deltaTime;
        }

        var newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.x);
    }
}
