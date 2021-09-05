using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPanel : MonoBehaviour
{
    public static DialogPanel DialogPanel_Instance;
    [SerializeField] public GameObject RawImage;
    [SerializeField] public TextMeshProUGUI DisplayText;
    void Awake()
    {
        if (DialogPanel_Instance == null)
        {
            DialogPanel_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DialogPanel.DialogPanel_Instance.RawImage.SetActive(false);
        DialogPanel.DialogPanel_Instance.DisplayText.text = "";
    }
}
