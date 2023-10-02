using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube; 

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button button = root.Q<Button>("MyButton");

        button.clicked += () => {
            if (cube.activeSelf) {cube.SetActive(false);} else cube.SetActive(true);
        };
    } 
}
