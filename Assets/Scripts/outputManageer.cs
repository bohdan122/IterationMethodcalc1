using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class outputManageer : MonoBehaviour
{
    List<Text> outputTexts = new List<Text>(3);
    private void Start()
    {
        for(int i = 0; i< this.transform.childCount; i++)
        {
            outputTexts.Add(this.transform.GetChild(i).gameObject.GetComponent<Text>());
        }
    }
     public void outputNumbers(List<double> nums)
    {
        for(int i = 0; i< nums.Count; i++)
        {
            outputTexts[i].text = nums[i] + "";
        }
    }

    public void outputIteration(int num)
    {
        
            outputTexts[3].text =  "Iteration: " + num;
        
    }

}
