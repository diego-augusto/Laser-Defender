using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width;
    public float height;
    public float speed;
    public float padding = 1f;

    private bool moveRight;
    private float xmin;
    private float xmax;

    void Start()
    {
        var distance = transform.position.z - Camera.main.transform.position.z;
        var leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftEdge.x;
        xmax = rightEdge.x;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
            moveRight = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax)
        {
            moveRight = !moveRight;
        }
    }
}
