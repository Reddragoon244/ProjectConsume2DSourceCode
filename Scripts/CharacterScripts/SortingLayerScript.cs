using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerScript : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    private SpriteRenderer otherRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Animation")
        {
            otherRenderer = collision.GetComponent<SpriteRenderer>();

            if (collision.transform.position.y <= GetComponentInParent<Transform>().position.y)
            {
                otherRenderer.sortingLayerName = "CharacterFront";
                spriteRenderer.sortingLayerName = "CharacterBack";
            } else if (collision.transform.position.y >= GetComponentInParent<Transform>().position.y)
            {
                otherRenderer.sortingLayerName = "CharacterBack";
                spriteRenderer.sortingLayerName = "CharacterFront";
            } else
            {
                Debug.Log("No Fucking Idea");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Animation")
        {
            otherRenderer = collision.GetComponent<SpriteRenderer>();
            otherRenderer.sortingLayerName = "CharacterDefault";
            spriteRenderer.sortingLayerName = "CharacterDefault";
        }
    }
}
