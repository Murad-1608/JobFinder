﻿using Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.ViewModels
{
    public class VacancyViewModel
    {
        public AddVacancyModel AddVacancyModel { get; set; }
        public List<SelectListItem>? Cities { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<SelectListItem>? Educations { get; set; }
        public List<SelectListItem>? Experiences { get; set; }
    }
}
