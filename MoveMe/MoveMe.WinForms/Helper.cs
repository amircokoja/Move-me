using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MoveMe.WinForms
{
    class Helper
    {
        public static void ClearFormControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.ResetText();
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.ResetText();
                }
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public static byte[] ImageToByte(Image blob)
        {
            byte[] imgBytes = null;
            ImageConverter imgConverter = new ImageConverter();
            imgBytes = (byte[])imgConverter.ConvertTo(blob, Type.GetType("System.Byte[]"));

            return imgBytes;
        }
    }
}
