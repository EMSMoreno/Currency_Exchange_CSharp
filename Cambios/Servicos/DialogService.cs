﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambios.Servicos
{
    public class DialogService
    {
        public void ShowMessage (string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
