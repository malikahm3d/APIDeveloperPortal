namespace APIDeveloperPortal.Client.Models.VMs
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public List<User> AvailableUsers { get; set; }
        public int[] SelectedUserIds { get; set; } = new int[10];
    }
}
