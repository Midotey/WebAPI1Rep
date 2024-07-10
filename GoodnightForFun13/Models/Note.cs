using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodnightForFun13.Models;

public partial class Note
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    [Required(ErrorMessage ="Write some text!")]
    public string Text { get; set; } = null!;

    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;
}
