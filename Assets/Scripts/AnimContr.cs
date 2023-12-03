using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimContr : MonoBehaviour
{
    public Animator animatorC;

    [SerializeField] public GameObject[] effectss; 
    IEnumerator coro;

    // Start is called before the first frame update
    void Start()
    {
     foreach (GameObject g in effectss)
     {
        g.SetActive(false);
     }    
    }

    // Update is called once per frame
    void Update()
    {
        animatorC.SetFloat("vertical",Input.GetAxis("Vertical"));    
        animatorC.SetFloat("horizontal",Input.GetAxis("Horizontal"));

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animatorC.SetTrigger("Jump");
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            animatorC.SetBool("Running",true);
        }
        else
        {
            animatorC.SetBool("Running",false);
        }

        if(Input.GetKeyUp(KeyCode.Alpha1)) PlaySkill(1);
         if(Input.GetKeyUp(KeyCode.Alpha2)) PlaySkill(2);
          if(Input.GetKeyUp(KeyCode.Alpha3)) PlaySkill(3);
           if(Input.GetKeyUp(KeyCode.Alpha4)) PlaySkill(4);

        
    }

    void PlaySkill(int i)
    {
         animatorC.SetTrigger("s"+i);
         effectss[i-1].SetActive(true);
float timess = 0;
        switch (i)
        {
            case 1:
            timess = 2;
            break;

            case 2:
            timess = 1f;
            break;

            case 3:
            timess = 5;
            break;

            case 4:
            timess = 2;
            break;
        }
        


         coro = Waitt(effectss[i-1],timess);
         StartCoroutine(coro);



    }
    IEnumerator Waitt (GameObject ob, float ti)
    {
        yield return new WaitForSeconds(ti);
        ob.SetActive(false);

    }



}
