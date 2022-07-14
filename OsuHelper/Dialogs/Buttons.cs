using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;

namespace OsuHelper.Dialogs.Buttons
{
        public class OkButton : TaskDialogButton
        {
            public OkButton() : base()
            {
                Text = "Ok";
                Default = true;
            }
        }

        public class SelectButton : TaskDialogButton
        {
            public SelectButton() : base()
            {
                Text = "Select";
                ButtonType = ButtonType.Custom;
                Default = true;
            }
        }

        public class CancelButton : TaskDialogButton
        {
            public CancelButton() : base()
            {
                ButtonType = ButtonType.Cancel;
                Default = false;
            }
        }
}
