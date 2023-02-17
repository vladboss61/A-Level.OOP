﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.OOP;

internal sealed class Person
{
    public string Name { get; set; }
    public int Age { get; set; }


    public void Deconstruct(out string name, out int age)
    {
        name = Name;
        age = Age;
    }
}
