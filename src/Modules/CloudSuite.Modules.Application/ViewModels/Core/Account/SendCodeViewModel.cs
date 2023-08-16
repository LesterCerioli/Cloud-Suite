using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace CloudSuite.Modules.Application.ViewModels.Core.Account
{
    internal class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        //public ICollection<SelectionItem> Providers { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}
