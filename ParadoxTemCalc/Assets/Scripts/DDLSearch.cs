using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DDLSearch : MonoBehaviour
{
    enum ListType
    {
        Monsters,
        Moves,
        Traits
    }

    [SerializeField] ListType listType = ListType.Monsters;
    [DisplayWithoutEdit()]
    public bool listLoaded = false;
    [Header("Filtering Using Monster:")]
    [SerializeField] bool filterUsingMonster;
    [SerializeField] MonsterName monsterReference;
    List<string> DDL_Options;

    TMP_InputField inputField;
    bool fieldSelected = false;
    TMP_Dropdown DDL;

    void Awake()
    {
        //search children for input field and drop down
        inputField = this.gameObject.GetComponentInChildren<TMP_InputField>();
        DDL = this.gameObject.GetComponentInChildren<TMP_Dropdown>();

        //Make a list in memory as dropdown options to be populated and referenced later as a master list
        DDL_Options = new List<string>();
    }

    private void FixedUpdate()
    {
        //run only if we have input field and DDL components
        //...and the lists are populated
        if (!listLoaded && inputField != null && DDL != null && MonsterDictionary.instance.listLoaded && MoveDictionary.instance.listLoaded)
        {
            InitializeDropdownList();
        }

        if (fieldSelected)
        {
            FilterSearch(inputField.text);
        }
    }

    #region Search Filter
    public void FilterSearch(string typedText)
    {

        List<string> newOptions = new List<string>();

        //sort new temp options strings based on typed text
        foreach (string s in DDL_Options)
        {
            bool match = false;
            int matchingChars = 0;
            //check each character of typed text for match, each one that doesn't match, remove
            for(int i = 0; i < typedText.Length; i++)
            {
                match = typedText[i].ToString().Equals(s[i].ToString(), StringComparison.InvariantCultureIgnoreCase);

                if (match)
                {
                    //log how many characters are matching
                    matchingChars++;
                }
            }
            //evaluate match status after all chars in typedText have been evaluated
            if (matchingChars == typedText.Length)
            {
                newOptions.Add(s);
            }
        }

        //update the list
        DDL.ClearOptions();
        DDL.AddOptions(newOptions);
        DDL.Show();

        fieldSelected = false;
    }
    #endregion

    #region Input Field Functions
    //called OnValueChanged from input field
    public void UpdateFilter()
    {
        if(inputField.text != "" && inputField.text != DDL_Options[0] && inputField.text != DDL.options[DDL.value].text)
        {
            fieldSelected = true;
        }
        if(inputField.text == "")
        {
            RestoreDefaultListValues();
        }
    }

    //called once the user presses enter
    public void Submit()
    {
        //NOTE: MAY NOT BE NEEDED

    }

    //called when selected
    public void FieldSelected()
    {

        //clear field text automatically
        inputField.text = "";

        //restore defaults
        RestoreDefaultListValues();
        
        //open the list
        DDL.Show();
        
    }

    //called when deselected
    public void FieldDeselected()
    {

        //update input field to reflect current dropdown value
        if (DDL.value > 0 && DDL.options.Count > 0 && DDL.value < DDL.options.Count)
        {
            inputField.text = DDL.options[DDL.value].text;
        }
        else
        {
            inputField.text = DDL_Options[0]; //default zero value for this list
        }
    }
    #endregion

    #region Dropdown List Functions
    void InitializeDropdownList()
    {
        //Clear the existing options in the list
        DDL.ClearOptions();

        //Populate list with appropriate data
        switch (listType)
        {
            case ListType.Monsters:
                //show defined list of all monsters
                foreach (MonsterName n in Enum.GetValues(typeof(MonsterName)))
                {
                    DDL_Options.Add(n.ToString());
                }

                break;
            case ListType.Moves:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    foreach (MoveName n in monster.canLearn)
                    {
                        DDL_Options.Add(n.ToString());
                    }
                }
                else
                {
                    //show defined list of all moves
                    foreach (MoveName n in Enum.GetValues(typeof(MoveName)))
                    {
                        DDL_Options.Add(n.ToString());
                    }
                }

                break;
            case ListType.Traits:

                if (filterUsingMonster)
                {
                    Monster monster = MonsterDictionary.instance.GetMonsterByName(monsterReference);
                    DDL_Options.Add(monster.trait1.ToString());
                    DDL_Options.Add(monster.trait2.ToString());
                }
                else
                {
                    //show defined list of all traits
                    foreach(MonsterTrait mt in Enum.GetValues(typeof(MonsterTrait)))
                    {
                        DDL_Options.Add(mt.ToString());
                    }
                }

                break;
            default:
                break;
        }

        //add these options to the list
        DDL.AddOptions(DDL_Options);

        //update input field to reflect current dropdown
        if (inputField.text != DDL.options[DDL.value].text)
        {
            inputField.text = DDL.options[DDL.value].text;
        }

        //finished loading our list
        listLoaded = true;
    }
    void RestoreDefaultListValues()
    {
        int prevVal = DDL.value;
        DDL.ClearOptions();
        DDL.AddOptions(DDL_Options);
        DDL.value = prevVal;
    }
    void UpdateListOptions(List<string> NewOptions)
    {
        DDL.ClearOptions();
        DDL.AddOptions(NewOptions);
    }
    //called when dropdown value changes
    public void UpdateText()
    {
        //update input field to reflect current dropdown value
        if (inputField.text != DDL.options[DDL.value].text)
        {
            inputField.text = DDL.options[DDL.value].text;
        }
    }
    #endregion

}
