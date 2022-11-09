using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Globalization;
using Website.Services;
using Website.Shared;

namespace Website.Pages.Components
{
    public class CultureSelectorComponent : StudentComponentBase<CultureSelector>
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }

        protected CultureInfo NewCulture;

        protected async void SetNewCulture()
        {        
            if (await ApiClient.PostItem("api/Culture", NewCulture.Name))
            {
                Snackbar.Add("Test", Severity.Success);
            }
            Culture = NewCulture;
        }

        protected readonly CultureInfo[] SupportedCultures = {
            new("nl-NL"),
            new("en-GB"),
        };

        private CultureInfo Culture
        {
            set
            {
                if (!CultureInfo.CurrentCulture.Equals(value))
                {
                    var js = (IJSInProcessRuntime)JSRuntime;
                    js.InvokeVoid("set", value.Name);
                    Nav.NavigateTo(Nav.Uri, forceLoad: true);
                }
            }
        }
    }
}
