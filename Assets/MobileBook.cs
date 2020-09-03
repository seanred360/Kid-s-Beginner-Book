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
        if(currentPage < pages.Length - 1)
        {
            pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
            pages[currentPage].GetComponent<Animator>().Play("FlipRight");
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
            pages[currentPage - 1].SetActive(true);

            currentPage--;
        }
    }

    public void GoToPage(int pageNum)
    {
        pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
        pages[currentPage].GetComponent<Animator>().Play("FlipLeft");
        FindPageNumber(pageNum).SetActive(true);
    }

    public void GoToContentsPage()
    {
        pages[currentPage].GetComponent<RectTransform>().SetAsLastSibling();
        pages[currentPage].GetComponent<Animator>().Play("FlipLeft");
        pages[8].SetActive(true);

        currentPage = 8;
    }

    private GameObject FindPageNumber(int pgNum)
    {
        //foreach (GameObject pg in pages)
        //{
        //    if (pg.name.EndsWith(pgNum.ToString()))
        //    {
        //        Debug.Log(pg.name);
        //        return pg;
        //    }
        //}
        //return null;

        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].name.EndsWith(pgNum.ToString()) && pages[i].name.StartsWith("Page"))
            {
               Debug.Log(pages[i].name);
                currentPage = i;
               return pages[i];
            }
        }
        return null;
    }
}
