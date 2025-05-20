using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;

    void Update()
    {
        transform.position = objectToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
