using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public Button yourButton;
    public Rigidbody rb;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        rb = GetComponent<Rigidbody>();
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        var locVel = transform.InverseTransformDirection(rb.velocity);
        locVel.z = 5;
        rb.velocity = transform.TransformDirection(locVel);
    }
}