using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UI.UserControls;

namespace UI
{
    public class UIHelper
    {
        public static void UCValidate(UserControl uc)
        {
            Boolean esvalido = true;
            foreach (UCTextboxRFC userControl in FindVisualChildren<UCTextboxRFC>(uc))
            {
                userControl.UCValidate();
                if (!userControl.UCIsValid) esvalido = false;
            }
            foreach (UCTextbox userControl in FindVisualChildren<UCTextbox>(uc))
            {
                userControl.UCValidate();
                if (!userControl.UCIsValid) esvalido = false;
            }
            if (!esvalido)
            {
                throw new Exception("Algunos de los datos son inválidos y se marcaron en rojo.");
            }
        }

        public static void UCSetReadOnly(UserControl uc)
        {
            foreach (UCTextboxRFC userControl in FindVisualChildren<UCTextboxRFC>(uc))
            {
                userControl.UCIsReadOnly = true;
            }
            foreach (UCTextbox userControl in FindVisualChildren<UCTextbox>(uc))
            {
                userControl.UCIsReadOnly = true;
            }
        }

        public static void UCClear(UserControl uc)
        {
            foreach (UCTextboxRFC userControl in FindVisualChildren<UCTextboxRFC>(uc))
            {
                userControl.UCText = "";
            }
            foreach (UCTextbox userControl in FindVisualChildren<UCTextbox>(uc))
            {
                userControl.UCText = "";
            }
        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
