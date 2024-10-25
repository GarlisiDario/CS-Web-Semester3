namespace MVCSportStore.ViewModels
{
    public static class PagingSettings
    {
        public static int ProductPagination = 4;
        public static bool PagingSettingsPage = false;
    }
    public class PagingSettingViewModel
    {
        public int ProductPagination { get; set; }
    }
}
