// Updated MainWindow.xaml.cs with corrected DLL P/Invoke signatures
// Adjusted methods to handle .NET 8.0 on x64 architecture

using System;
using System.Runtime.InteropServices;

public class ToneCore
{
    // Adjusting the P/Invoke signature for ToneCore.dll
    [DllImport("ToneCore.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetParameter(int index, float value);
    
    [DllImport("ToneCore.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetDetectedPitch(); // corrected call if needed
    
    // Other methods and properties...

    public void UpdateParameter(int index, float value)
    {
        try
        {
            SetParameter(index, value);
        }
        catch (DllNotFoundException e)
        {
            Console.WriteLine("DLL not found: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error updating parameter: " + e.Message);
        }
    }
}