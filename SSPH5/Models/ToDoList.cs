using System;
using System.Collections.Generic;

namespace SSPH5.Models;

public partial class ToDoList
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string ToDoItem { get; set; } = null!;
}
