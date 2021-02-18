using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class AddRoomViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Desc { get; set; }

        [Required]
        [Display(Name = "Количество комнат")]
        public int Local { get; set; }

        [Required]
        [Display(Name = "Изображение комнаты")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Этаж")]
        public int Floor { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }
    }
}
