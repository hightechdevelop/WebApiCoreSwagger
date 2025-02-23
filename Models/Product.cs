﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]                                                     //атрибут [Required] делает поле обязательным для заполнения
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
