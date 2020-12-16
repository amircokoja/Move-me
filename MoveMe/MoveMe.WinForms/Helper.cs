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
    }
}
