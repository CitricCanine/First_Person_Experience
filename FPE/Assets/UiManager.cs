using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public Vector3 enlarged, normalSized;
    public Image spell1Box, spell2Box, spell3Box;
    public PlayerMagicSystem magic;

    void Awake()
    {
        enlarged = new Vector3(1.2f, 1.2f, 1.2f);
        normalSized = new Vector3(1, 1, 1);
    }
    private void Update() 
    {
        ScaleBoxes();
    }

    public void ScaleBoxes()
    {
        if (magic.spellObjectInUse == 1)
        {
            spell1Box.transform.localScale = enlarged;
            spell2Box.transform.localScale = normalSized;
            spell3Box.transform.localScale = normalSized;
        }
        if (magic.spellObjectInUse == 2)
        {
            spell1Box.transform.localScale = normalSized;
            spell2Box.transform.localScale = enlarged;
            spell3Box.transform.localScale = normalSized;
        }
        if (magic.spellObjectInUse == 3)
        {
            spell1Box.transform.localScale = normalSized;
            spell2Box.transform.localScale = normalSized;
            spell3Box.transform.localScale = enlarged;
        }
    }

}
