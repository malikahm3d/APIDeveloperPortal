﻿using APIDeveloperPortal.API.Models;

namespace APIDeveloperPortal.API.VMs
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public int[] SelectedUserIds { get; set; } = new int[10];
    }
}
