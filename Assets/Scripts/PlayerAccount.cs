using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAccount : MonoBehaviour
{
    public Text playerAccount;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        string account = "0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2";
#else
        string account = PlayerPrefs.GetString("Account");
#endif
        playerAccount.text = account;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
