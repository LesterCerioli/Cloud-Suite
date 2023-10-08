using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int NationalId { get; set; }
        public ParentType Type { get; set; }
    }

    public enum ParentType
    {
        Father = 1,
        Mother = 2,
        Spouse = 3
    }
}