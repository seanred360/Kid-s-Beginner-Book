using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileBook : MonoBehaviour
{
    public GameObject[] pages;
    public int currentPage;
    public Transform rightDestination, leftDestination;


    public void FlipPageRight()
    {
        if(currentPage < pages.Length)
        {
            pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
            pages[currentPage].GetComponent<Animator>().Play("FlipRight");
            //pages[currentPage].SetActive(false);
            pages[currentPage + 1].SetActive(true);

            currentPage++;
        }
    }

    public void FlipPageLeft()
    {
        if(currentPage > 0)
        {
            pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
            pages[currentPage].GetComponent<Animator>().Play("FlipLeft");
            //pages[currentPage].SetActive(false);
            pages[currentPage - 1].SetActive(true);

            currentPage--;
        }
    }

    public void GoToPage(int pageNum)
    {
        //pageNum += 7;
        
        pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
        pages[currentPage].GetComponent<Animator>().Play("FlipLeft");
        //pages[currentPage].SetActive(false);
        //pages[pageNum].SetActive(true);
        FindPageNumber(pageNum).SetActive(true);
    }

    public void GoToContentsPage()
    {
        pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
        pages[currentPage].GetComponent<Animator>().Play("FlipLeft");
        //pages[currentPage].SetActive(false);
        pages[8].SetActive(true);

        currentPage = 8;
    }

    private GameObject FindPageNumber(int pgNum)
    {
        foreach (GameObject pg in pages)
        {
            if (pg.name.EndsWith(pgNum.ToString()))
            {
                Debug.Log(pg.name);
                return pg;
            }
        }
        return null;
    }
}
