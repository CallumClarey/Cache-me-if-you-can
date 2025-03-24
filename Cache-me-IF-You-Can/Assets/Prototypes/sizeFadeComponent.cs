using UnityEngine;
using TMPro;

public class SizeFadeComponent : MonoBehaviour
{
    //--------------------------------------
    //All class Attributes
    //--------------------------------------
    [SerializeField] 
    private TMP_Text textBox;
    [SerializeField] // Determines the rate which the text grows
    private float growRate;
    [SerializeField] //determines how long it lasts
    private float growTime;
    //used to turn fade on and off
    public bool fadeOn = true;
    [SerializeField]
    private float fadeTime;

    // Update is called once per frame
    void Update()
    {
        //counts down the grow time
        growTime -= Time.deltaTime;

        if (growTime >= 0.0f)
        {
            Debug.Log(growTime);
            //variables on the x and y scale to increase the size of the text
            float xScale = textBox.transform.localScale.x + growRate * Time.deltaTime;
            float yScale = textBox.transform.localScale.y + growRate * Time.deltaTime;
            
            //grows the text over time 
            textBox.transform.localScale = new Vector3(xScale, yScale, 1f);
        }
        else if (fadeOn)
        {
            textBox.alpha = textBox.alpha - Time.deltaTime / fadeTime;
        }
    }
}
