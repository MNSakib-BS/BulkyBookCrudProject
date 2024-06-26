﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1 , 100, ErrorMessage ="must be between 1 to 100 only!!!!!!")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public static implicit operator Category(List<Category> v)
    {
        throw new NotImplementedException();
    }
}
//DESKTOP-IHSC7M0\SQLEXPRESS