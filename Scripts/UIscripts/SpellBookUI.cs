using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookUI : MonoBehaviour {

    public AbilityList spellbook;
    public InventoryManagement inventory;
    public CreateAbilityManager createAbility;

    public GameObject LeftPage;
    public GameObject RightPage;

    public Image LeftPageSpellIcon;
    public Image RightPageSpellIcon;

    public Text LeftSpellName;
    public Text RightSpellName;

    public Text LeftSpellInfo;
    public Text RightSpellInfo;

    public Text LeftSpellType;
    public Text RightSpellType;

    public GameObject LeftSpellMaterialsUI;
    public GameObject RightSpellMaterialsUI;
    public GameObject materialUI;

    public BaseAbility leftSpell;
    public BaseAbility rightSpell;

    public Button createLeftButton;
    public Button createRightButton;

    private int lefti = 0;
    private int righti = 1;
    private GameObject materialPH;

    void Start()
    {
        if (spellbook)
        {
            if (spellbook.library.Count != 0)
            {
                leftSpell = spellbook.library[lefti];
                rightSpell = spellbook.library[righti];
                PageUI();
            }
        }
    }

    public void PageUI()
    {
        if (spellbook)
        {
            if (spellbook.library.Count != 0)
            {
                if(LeftPage.activeInHierarchy)
                {
                    LeftPageSpellIcon.sprite = leftSpell.UIicon;
                    LeftSpellName.text = leftSpell.abilityName;
                    LeftSpellInfo.text = SpellInfoModifier(leftSpell);
                    LeftSpellType.text = leftSpell.abilType.ToString();

                    foreach (InventoryItem item in leftSpell.craftingMaterialsNeeded)
                    {
                        GameObject materialPH = Instantiate(materialUI, LeftSpellMaterialsUI.transform);
                        materialPH.GetComponentInChildren<Image>().sprite = item.item.itemImage;
                        materialPH.GetComponentInChildren<Text>().text = item.item.itemName + " X " + item.amount;

                        if (!createAbility.CanCreateAbility(leftSpell.craftingMaterialsNeeded, leftSpell))
                        {
                            createLeftButton.interactable = false;
                            materialPH.GetComponentInChildren<Text>().color = Color.red;
                        } else
                        {
                            createLeftButton.interactable = true;
                            materialPH.GetComponentInChildren<Text>().color = Color.white;
                        }
                    }
                }

                if(RightPage.activeInHierarchy)
                {
                    RightPageSpellIcon.sprite = rightSpell.UIicon;
                    RightSpellName.text = rightSpell.abilityName;
                    RightSpellInfo.text = SpellInfoModifier(rightSpell);
                    RightSpellType.text = rightSpell.abilType.ToString();

                    foreach (InventoryItem item in rightSpell.craftingMaterialsNeeded)
                    {
                        GameObject materialPH = Instantiate(materialUI, RightSpellMaterialsUI.transform);
                        materialPH.GetComponentInChildren<Image>().sprite = item.item.itemImage;
                        materialPH.GetComponentInChildren<Text>().text = item.item.itemName + " X " + item.amount;

                        if (!createAbility.CanCreateAbility(rightSpell.craftingMaterialsNeeded, rightSpell))
                        {
                            createRightButton.interactable = false;
                            materialPH.GetComponentInChildren<Text>().color = Color.red;
                        } else
                        {
                            createRightButton.interactable = true;
                            materialPH.GetComponentInChildren<Text>().color = Color.white;
                        }
                    }
                }
            }
        }
    }

    public void TurnPageBackward()
    {
        if (spellbook)
        {
            if (spellbook.library.Count != 0)
            {
                if(lefti != 0 )
                {
                    lefti = lefti - 2;
                    righti = righti - 2;
                    leftSpell = spellbook.library[lefti];

                    if(!RightPage.activeInHierarchy)
                    {
                        RightPage.SetActive(true);
                    }

                    rightSpell = spellbook.library[righti];

                    foreach (Transform child in LeftSpellMaterialsUI.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    foreach (Transform child in RightSpellMaterialsUI.transform)
                    {
                        Destroy(child.gameObject);
                    }

                    PageUI();
                } 
            }
        }
    }

    public void TurnPageForward()
    {
        if(spellbook)
        {
            if (spellbook.library.Count != 0)
            {
                if(lefti != spellbook.library.Count)
                {
                    lefti = lefti + 2;
                    righti = righti + 2;
                    leftSpell = spellbook.library[lefti];

                    if(righti >= spellbook.library.Count)
                    {
                        RightPage.SetActive(false);
                    } else
                    {
                        rightSpell = spellbook.library[righti];
                    }

                    foreach (Transform child in LeftSpellMaterialsUI.transform)
                    {
                        Destroy(child.gameObject);
                    }
                    foreach (Transform child in RightSpellMaterialsUI.transform)
                    {
                        Destroy(child.gameObject);
                    }

                    PageUI();
                } 
            }
        }
    }

    private string SpellInfoModifier(BaseAbility ability) 
    {
        string returnedString = "";

        if (ability)
        {
            returnedString = "Mana: " + ability.manaUse
                + System.Environment.NewLine + "Damage: " + ability.damage 
                + System.Environment.NewLine + "Ability Effect 1: " + ability.AbilityEffects[0]
                + System.Environment.NewLine + "Ability Effect 2: " + ability.AbilityEffects[1]
                + System.Environment.NewLine + "Ability Effect 3: " + ability.AbilityEffects[2]
                + System.Environment.NewLine + "Ability Effect 4: " + ability.AbilityEffects[3]
                + System.Environment.NewLine + "Ability Effect 5: " + ability.AbilityEffects[4]
                + System.Environment.NewLine + "Ability Effect 6: " + ability.AbilityEffects[5]
                + System.Environment.NewLine + "Ability Effect 7: " + ability.AbilityEffects[6]
                + System.Environment.NewLine + "Ability Effect 8: " + ability.AbilityEffects[7]
                + System.Environment.NewLine + "Ability Effect 9: " + ability.AbilityEffects[8]
                + System.Environment.NewLine + "Ability Effect 10: " + ability.AbilityEffects[9];

            return returnedString;
        }

        return returnedString;
    }

}
