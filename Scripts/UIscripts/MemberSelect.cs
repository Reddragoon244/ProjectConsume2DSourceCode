using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberSelect : MonoBehaviour
{
    public GameObject allplayerUI;
    public GameObject playermenu;
    public FillbarUI fillBar;
    public int MemberNumber;
    void OnEnable()
    {
        MemberNumber = fillBar.MemeberNumber;
    }

    public void Select()
	{
		//pass everything...
		playermenu.SetActive(true);
		FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = null;
		FindObjectOfType<UnityEngine.EventSystems.EventSystem>().firstSelectedGameObject = playermenu.GetComponentsInChildren<Button>()[0].gameObject;
        allplayerUI.SetActive(false);
	}
}
