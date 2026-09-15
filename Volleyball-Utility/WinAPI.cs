using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


internal static class WinAPI
{
    // windows api calls
    //this bit of code is for having placeholder text within controls - https://medium.com/@alexandermlharris/setting-place-holder-text-in-a-winforms-textbox-41a9e739a44c
    // https://learn.microsoft.com/en-us/windows/win32/inputdev/wm-keydown
    //taken from C:\Program Files (x86)\Windows Kits\10\Include\10.0.26100.0\um\WinUser.h
    //my brain hurts

    private const int EM_SETCUEBANNER = 0x1501;
    private const int WM_KEYDOWN = 0x0100;


    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern Int32 SendMessage(
        IntPtr hWnd,
        int msg,
        int wParam,
        [MarshalAs(UnmanagedType.LPWStr)] string lParam); //placeholder text

    public static void SetPlaceholderText(Control textBox, string placeholder)
    {
        //for any textbox that should have placeholder text
        SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
    }
}


