using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    void Start()
    {
       count = 0;
       SetCountText();
       winTextObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "PickupCylinder")
       {
          other.gameObject.SetActive(false);
          count += 1;
          SetCountText();
       }
        if(other.gameObject.tag == "PickupCapsule")
       {
          other.gameObject.SetActive(false);
          count += 3;
          SetCountText();
       }
     }

     void SetCountText() 
     {
         countText.text =  "Count: " + count.ToString();
         if (count >= 9)
         {
            winTextObject.SetActive(true);
         }
     }
}
