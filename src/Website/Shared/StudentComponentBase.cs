using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using Website.Services;

namespace Website.Shared
{
    public class StudentComponentBase<T> : ComponentBase
    {
        [Inject]
        public IStringLocalizer<T> Localizer { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public ApiClient ApiClient { get; set; }

    }
}
