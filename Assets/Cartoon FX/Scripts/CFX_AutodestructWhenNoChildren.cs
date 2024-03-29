using UnityEngine;

/// <summary>
/// Automatically destroys the GameObject when there are no children left.
/// </summary>

public class CFX_AutodestructWhenNoChildren : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (transform.childCount == 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}