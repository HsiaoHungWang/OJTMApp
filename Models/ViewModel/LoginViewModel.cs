﻿namespace OJTMApp.Models.ViewModel
{
    public class LoginViewModel
    {
        //屬性名稱要跟表單的input name一樣
        public string? userEmail { get; set; }
        public string? userPassword { get; set; }
        public string? rememberMe { get; set; }
    }
}
