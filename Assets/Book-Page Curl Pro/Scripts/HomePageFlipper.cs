using UnityEngine;
using System.Collections;
using System;

public class HomePageFlipper : MonoBehaviour {
    public float duration;
    public BookPro book;
    bool isFlipping = false;
    Action finish;
    float elapsedTime = 0;
    //center x-coordinate 
    float xc,pageWidth,pageHeight;
    FlipMode flipMode;

    public static void FlipPage(int pageNumber, BookPro book,float duration, FlipMode mode, Action OnComplete)
    {
        book.targetPageNumber = pageNumber;

        HomePageFlipper flipper = book.GetComponent<HomePageFlipper>();
        if (!flipper)
            flipper = book.gameObject.AddComponent<HomePageFlipper>();
        flipper.enabled = true;
        flipper.book = book;
        flipper.isFlipping = true;
        flipper.duration = duration- Time.deltaTime;
        flipper.finish = OnComplete;
        flipper.xc=(book.EndBottomLeft.x+book.EndBottomRight.x)/ 2;
        flipper.pageWidth = (book.EndBottomRight.x - book.EndBottomLeft.x) / 2;
        flipper.pageHeight = Mathf.Abs(book.EndBottomRight.y);
        flipper.flipMode = mode;
        flipper.elapsedTime = 0;
        float x;
        if (mode == FlipMode.RightToLeft)
        {
            x = flipper.xc + (flipper.pageWidth * 0.99f);
            float y = (-flipper.pageHeight / (flipper.pageWidth * flipper.pageWidth)) * (x - flipper.xc) * (x - flipper.xc);
            book.DragRightPageToPoint(new Vector3(x, y, 0));
        }
        else
        {
            x = flipper.xc - (flipper.pageWidth * 0.99f);
            float y = (-flipper.pageHeight / (flipper.pageWidth * flipper.pageWidth)) * (x - flipper.xc) * (x - flipper.xc);
            book.DragLeftPageToPoint(new Vector3(x, y, 0));
        }
    }

    public static void AutoFlipPage(int pageNumber, BookPro book, float duration, FlipMode mode, Action OnComplete)
    {
        book.targetPageNumber = pageNumber;

        HomePageFlipper flipper = book.GetComponent<HomePageFlipper>();
        if (!flipper)
            flipper = book.gameObject.AddComponent<HomePageFlipper>();
        flipper.enabled = true;
        flipper.book = book;
        flipper.isFlipping = true;
        flipper.duration = duration - Time.deltaTime;
        flipper.finish = OnComplete;
        flipper.xc = (book.EndBottomLeft.x + book.EndBottomRight.x) / 2;
        flipper.pageWidth = (book.EndBottomRight.x - book.EndBottomLeft.x) / 2;
        flipper.pageHeight = Mathf.Abs(book.EndBottomRight.y);
        flipper.flipMode = mode;
        flipper.elapsedTime = 0;
        float x;
        if (mode == FlipMode.RightToLeft)
        {
            x = flipper.xc + (flipper.pageWidth * 0.99f);
            float y = (-flipper.pageHeight / (flipper.pageWidth * flipper.pageWidth)) * (x - flipper.xc) * (x - flipper.xc);
            book.AutoDragRightPageToPoint(new Vector3(x, y, 0));
        }
        else
        {
            x = flipper.xc - (flipper.pageWidth * 0.99f);
            float y = (-flipper.pageHeight / (flipper.pageWidth * flipper.pageWidth)) * (x - flipper.xc) * (x - flipper.xc);
            book.AutoDragLeftPageToPoint(new Vector3(x, y, 0));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            ParticleDisabler.instance.ToggleParticles(false);
            elapsedTime += Time.deltaTime;
            if (elapsedTime <  duration )
            {
                if (flipMode == FlipMode.RightToLeft)
                {
                    float x = xc + (0.5f - elapsedTime / duration) * 2 * (pageWidth);
                    float y = (-pageHeight / (pageWidth * pageWidth)) * (x - xc) * (x - xc);
                    book.UpdateBookRTLToPoint(new Vector3(x, y, 0));
                }
                else
                {
                    float x = xc - (0.5f - elapsedTime / duration) * 2 * (pageWidth);
                    float y = (-pageHeight / (pageWidth * pageWidth)) * (x - xc) * (x - xc);
                    book.UpdateBookLTRToPoint(new Vector3(x, y, 0));
                }

            }
            else
            {
                ParticleDisabler.instance.ToggleParticles(true);
                book.GoToPage(book.targetPageNumber);
                //book.Flip();
                isFlipping = false;
                this.enabled = false;
                if (finish != null)
                    finish();
            }
        }

    }
}
