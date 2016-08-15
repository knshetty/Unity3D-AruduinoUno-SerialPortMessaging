using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO.Ports;

public class testscript : MonoBehaviour
{

    public Button toogleBtn;
    public Text toggleBtnTxt;
    public Image led;
    public Text diagnoticTxt;

    SerialPort portToMsg;
    bool toggleState;

    void OnEnable()
    {
        toggleState = false;
        toggleBtnTxt.text = "LED Switch";
        diagnoticTxt.text = "Debug Info...";
    }

    // Use this for initialization
    void Start()
    {
        // --- Initialise serail port for a specific OS ---
        string portNameExtracted = GetPortName("Windows");
        diagnoticTxt.text = portNameExtracted;
        portToMsg = new SerialPort(portNameExtracted, 9600, Parity.None, 8, StopBits.One);

        // --- Open serial port & send a initialisation msg ---
        portToMsg.Open();
        portToMsg.Write("0");

        // Initialise UI-LED indicator color
        led.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleState)
        {
            portToMsg.WriteLine("1");
        }
        else
        {
            portToMsg.WriteLine("0");
        }
    }

    void OnDisable()
    {
        // --- Clean-up & degrade ---
        portToMsg.Write("0");
        portToMsg.Close();
    }

    // --------------
    // Public Methods
    // --------------

    public void OnClick()
    {
        if (toggleState)
        {
            toggleState = false;
            toggleBtnTxt.text = "Off";
            led.color = Color.clear;
        }
        else
        {
            toggleState = true;
            toggleBtnTxt.text = "On";
            led.color = Color.red;
        }
    }

    // ---------------
    // Private Methods
    // ---------------

    private string GetPortName(string os)
    {
        switch (os)
        {
            case "Linux":
                return "/dev/ttyUSB0";

            case "Windows":
                return "COM8";

            case "Android":
                string[] portNames;
                portNames = System.IO.Ports.SerialPort.GetPortNames();
                return portNames[0].ToString();

            default:
                return "";
        }
    }
}
