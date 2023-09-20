using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFLI_Position_Manager
{
    public partial class Main : Form
    {
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public static Process gameProcess = null;

        long oldProcessSession = 0;
        long processSession = 0;

        IntPtr mainModule = IntPtr.Zero;
        IntPtr sizeMainModule = IntPtr.Zero;
        IntPtr playerPointer = IntPtr.Zero;

        public static int hotkey_SavePlayerPosition = 0;
        public static int hotkey_LoadPlayerPosition = 0;

        public static bool formHotkeysOpen = false;
        public int[] keyboardTableReady = new int[999];

        private void Main_Load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            selector.Select();

            // fill out keyboard table
            for (int i = 0; i < keyboardTableReady.Length; i++)
                keyboardTableReady[i] = 0;

            // load hotkeys
            int.TryParse(Saves.Read("settings", "KeyValueSavePlayerPosition"), out hotkey_SavePlayerPosition);
            int.TryParse(Saves.Read("settings", "KeyValueLoadPlayerPosition"), out hotkey_LoadPlayerPosition);
            label_HotkeySavePlayerPosition.Text = Saves.Read("settings", "KeyCodeSavePlayerPosition");
            label_HotkeyLoadPlayerPosition.Text = Saves.Read("settings", "KeyCodeLoadPlayerPosition");

            backgroundWorker_CheckProcess.RunWorkerAsync();
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!formHotkeysOpen)
                {
                    if (Toolkit.IsKeyPressed(hotkey_SavePlayerPosition))
                    {
                        if (keyboardTableReady[hotkey_SavePlayerPosition] != 1)
                        {
                            button_SavePlayerPosition.PerformClick();
                            keyboardTableReady[hotkey_SavePlayerPosition] = 1;
                        }
                    }
                    else keyboardTableReady[hotkey_SavePlayerPosition] = 0;

                    if (Toolkit.IsKeyPressed(hotkey_LoadPlayerPosition))
                    {
                        if (keyboardTableReady[hotkey_LoadPlayerPosition] != 1)
                        {
                            button_LoadPlayerPosition.PerformClick();
                            keyboardTableReady[hotkey_LoadPlayerPosition] = 1;
                        }
                    }
                    else keyboardTableReady[hotkey_LoadPlayerPosition] = 0;
                }

                Thread.Sleep(5);
            }
        }

        private void backgroundWorker_CheckProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                long tempProcessSession = 0;
                bool foundProcess = false;

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == "LavenderIsland-Win64-Shipping")
                    {
                        gameProcess = process;
                        tempProcessSession = ((DateTimeOffset)gameProcess.StartTime).ToUnixTimeMilliseconds();
                        foundProcess = true;
                    }
                }

                if (foundProcess && processSession != tempProcessSession)
                {
                    foreach (ProcessModule module in gameProcess.Modules)
                    {
                        if (module.ModuleName.Equals("LavenderIsland-Win64-Shipping.exe", StringComparison.OrdinalIgnoreCase))
                        {
                            mainModule = module.BaseAddress;
                            sizeMainModule = (IntPtr)module.ModuleMemorySize;
                            break;
                        }
                    }

                    processSession = tempProcessSession;
                }

                // patch player object function
                if (processSession != oldProcessSession && foundProcess)
                {
                    byte[] defaultOp = { 0x0F, 0x10, 0x88, 0xD0, 0x01, 0x00, 0x00, 0x0F, 0x28, 0xC1, 0xF3, 0x0F, 0x11, 0x4D, 0xE0 };
                    Toolkit.WriteMemory(mainModule + 0x9AEC57, defaultOp);

                    playerPointer = Toolkit.SaveRegister(mainModule + 0x9AEC57, 15, "eax", true, IntPtr.Zero);
                    oldProcessSession = processSession;
                }

                Thread.Sleep(100);
            }
        }

        private void button_Hotkeys_Click(object sender, EventArgs e)
        {
            formHotkeysOpen = true;
            Hotkeys hotkeysForm = new Hotkeys();
            hotkeysForm.ShowDialog();
        }

        public INF.Vector3 GetPlayerPosition()
        {
            byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(playerPointer, 8);
            IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

            return new INF.Vector3(
                Toolkit.ReadMemoryFloat(aPointer + 0x1D0),
                Toolkit.ReadMemoryFloat(aPointer + 0x1D0 + 0x4),
                Toolkit.ReadMemoryFloat(aPointer + 0x1D0 + 0x8));
        }

        private void button_SavePlayerPosition_Click(object sender, EventArgs e)
        {
            INF.Vector3 temp = GetPlayerPosition();
            textBox_PlayerPositionX.Text = temp.X.ToString(CultureInfo.InvariantCulture);
            textBox_PlayerPositionY.Text = temp.Y.ToString(CultureInfo.InvariantCulture);
            textBox_PlayerPositionZ.Text = temp.Z.ToString(CultureInfo.InvariantCulture);
            selector.Select();
        }

        private void button_LoadPlayerPosition_Click(object sender, EventArgs e)
        {
            INF.Vector3 vector = new INF.Vector3();

            string posX = textBox_PlayerPositionX.Text.Replace(",", ".");
            string posY = textBox_PlayerPositionY.Text.Replace(",", ".");
            string posZ = textBox_PlayerPositionZ.Text.Replace(",", ".");

            if (float.TryParse(posX, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.X) &&
            float.TryParse(posY, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.Y) &&
            float.TryParse(posZ, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.Z))
            {
                byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(playerPointer, 8);
                IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

                if (vector.X != 0 && vector.Y != 0 && vector.Z != 0)
                {
                    Toolkit.WriteMemory(aPointer + 0x1D0, BitConverter.GetBytes(vector.X));
                    Toolkit.WriteMemory(aPointer + 0x1D0 + 0x4, BitConverter.GetBytes(vector.Y));
                    Toolkit.WriteMemory(aPointer + 0x1D0 + 0x8, BitConverter.GetBytes(vector.Z));
                }
                else Toolkit.ShowError("did not load position as one of the values was 0");
            }
            else Toolkit.ShowError("one of the position values is incorrect");
            selector.Select();
        }

        private void backgroundWorker_PatchUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
    }
}
