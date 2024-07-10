using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodnightForFun13.Models;

public partial class Folder
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Write folder's title")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    public Folder()
    {
    }
    public Folder(string name)
    {
        Name = name;
    }
}
