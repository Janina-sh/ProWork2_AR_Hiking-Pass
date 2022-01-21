using System;
using System.Collections;
using System.IO;
using UnityEngine;


public class Screenshot : MonoBehaviour
{
    // screenshot resolution
    private int captureWidth = Screen.width;
    private int captureHeight = Screen.height;

    // file format settings for unity editor
    public enum Format { RAW, JPG, PNG, PPM };
    public Format format = Format.JPG;

    // output folder - data path is default (defining album/folder is not working on new iOS versions)
    private string outputFolder;

    // screenshot variables
    private Rect rect;
    private RenderTexture renderTexture;
    private Texture2D screenShot; // screenshot
    private bool isProcessing = false;
    //public Texture2D mask; // mask for overlay
    
    // screenshot UI variables
    /*[HideInInspector] public bool screenshotSaved;
    [Header("Screenshot")]
    public GameObject screenshotModal;
    public float screenshotModalTime = 1f;*/
    
    // reference to GameManager
    //private GameManager _gameManager;
    
    
    private void Start()
    {
        // initializing directory for files
        outputFolder = Application.persistentDataPath + "/Screenshots/";
        if(!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
            Debug.Log("Save Path will be : " + outputFolder);
        }
        
        //screenshotSaved = false;
    }

    // creating an unique filename for the screenshots
    private string CreateFileName(int width, int height)
    {
        // timestamp
        string timestamp = DateTime.Now.ToString("yyyyMMddTHHmmss");

        // adding different parameters to the filename // original: {0}/scree... - deleted because there were //
        var filename = string.Format("{0}screen_{1}x{2}_{3}.{4}", outputFolder, width, height, timestamp, format.ToString().ToLower());

        // return filename
        return filename;
    }
    
    // capturing the screenshot
    private void CaptureScreenshot()
    {

        Debug.Log("Starting CaptureScreenshot()");
        // START screenshot process
        isProcessing = true;

        // create  objects
        if (renderTexture == null)
        {
            // creates off-screen render texture
            rect = new Rect(0, 0, captureWidth, captureHeight);
            renderTexture = new RenderTexture(captureWidth, captureHeight, 24);
            Debug.Log("renderTexture == null");
            screenShot = new Texture2D(captureWidth, captureHeight, TextureFormat.RGB24, false);
        }

        // render camera view into the render texture
        Camera camera = Camera.main;
        camera.targetTexture = renderTexture;
        camera.Render();
        
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(rect, 0, 0);
        Debug.Log("Camera");
        // mask overlay for photo printing
        /*for (int y = 0; y < captureHeight; y++)
        {
            for (int x = 0; x < captureWidth; x++)
            {
                Color color = mask.GetPixel(x, y);

                if (color.a == 0)
                    continue;

                screenShot.SetPixel(x,y, color);
            }
        }
        
        // apply overlay
        screenShot.Apply();*/
        
        // reset the textures and remove the render texture from the camera
        camera.targetTexture = null;
        RenderTexture.active = null;

        // get  filename
        string filename = CreateFileName((int)rect.width, (int)rect.height);

        // get file header for the specified image format
        byte[] fileHeader = null;
        byte[] fileData = null;

        // encoding based on the chosen image format
        if (format == Format.RAW)
        {
            fileData = screenShot.GetRawTextureData();
        }
        else if (format == Format.PNG)
        {
            fileData = screenShot.EncodeToPNG();
        }
        else if (format == Format.JPG)
        {
            fileData = screenShot.EncodeToJPG();
            Debug.Log("JPG");
        }
        else
        {
            // additional steps for ppm files
            string headerStr = string.Format("P6\n{0} {1}\n255\n", rect.width, rect.height);
            fileHeader = System.Text.Encoding.ASCII.GetBytes(headerStr);
            fileData = screenShot.GetRawTextureData();
             Debug.Log("JPG Else");
        }
Debug.Log("I am here");
        // offload the saving from the main thread
        new System.Threading.Thread(() =>
        {
            // save screenshot in native gallery on iOS and Android
            NativeGallery.Permission permission = NativeGallery.SaveImageToGallery( fileData, "album", filename, ( success, path ) => Debug.Log( "Media save result: " + success + " " + path ) );
            

            // console success message
            Debug.Log(string.Format("Screenshot Saved {0}, size {1}", filename, fileData.Length));

            // END screenshot process
            isProcessing = false;

        }).Start();
        
        // cleanup and prepare for next screenshot
        Destroy(renderTexture);
        renderTexture = null;
        screenShot = null;
        
        // response on screenshot
       // StartCoroutine(ScreenshotModal());
        
    }
    
    // take screenshot
    public void TakeScreenShot()
    {
        Debug.Log("isProcessing: " + isProcessing);
        if (!isProcessing)
        {
               Debug.Log("TakeScreenShot();");
            CaptureScreenshot();
        }
    }
    
    // dismiss screenshot success modal
    //public void DismissScreenshotModal()
    //{
    //    screenshotModal.SetActive(false);
    //}
    
    //// auto-dismiss screenshot success modal
    //private IEnumerator ScreenshotModal()
    //{
    //    screenshotModal.SetActive(true);
    //    yield return new WaitForSecondsRealtime(screenshotModalTime);
    //    screenshotModal.SetActive(false);
    //}
}
