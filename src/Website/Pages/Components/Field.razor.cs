using Microsoft.AspNetCore.Components;
using Website.Enums;
using Microsoft.Extensions.Localization;
using Website.Shared;

namespace Website.Pages.Components
{
    public class FieldComponent : StudentComponentBase<Field>
    {
        Random rnd = new();

        private string _valueOne;
        private string _valueTwo;

        protected string LocalizedDescriptionId;
        protected string LocalizedLabelId;
        protected string IconLabelId;

        [Parameter, EditorRequired]
        public string Name { get; set; }

        [Parameter]
        public string LocalizedLabel { get; set; }

        [Parameter]
        public string LocalizedDescription { get; set; }

        [Parameter]
        public string LocalizedRequiredError { get; set; }

        [Parameter, EditorRequired]
        public string InputOnePlaceholder { get; set; }

        [Parameter]
        public string InputOne
        {
            get => _valueOne;
            set
            {
                if (_valueOne == value) return;
                _valueOne = value;
                InputOneChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<string> InputOneChanged { get; set; }

        [Parameter, EditorRequired]
        public InputType InputType { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter, EditorRequired]
        public bool HasIconLabel { get; set; }

        [Parameter]
        public LabelType LabelType { get; set; }

        [Parameter]
        public string IconLabel { get; set; }

        protected string InputTypeString;

        protected override void OnInitialized()
        {
            InputTypeString = InputType.ToString();
            LocalizedDescriptionId = rnd.Next().ToString();
            LocalizedLabelId = rnd.Next().ToString();
            IconLabelId = rnd.Next().ToString();
        }
    }
}
