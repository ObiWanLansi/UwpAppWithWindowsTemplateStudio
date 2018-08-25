using System.Threading.Tasks;

namespace UwpAppWithWindowsTemplateStudio.Helpers
{
    public interface IPivotPage
    {
        Task OnPivotSelectedAsync();

        Task OnPivotUnselectedAsync();
    }
}
