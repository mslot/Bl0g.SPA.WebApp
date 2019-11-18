using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bl0g.SPA.WebApp.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        public ViewModel Model { get; set; }

        public string Text { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Text = await Model.Text();
            await base.OnInitializedAsync();
        }

        protected async Task UpdateText(MouseEventArgs e)
        {
            Text = "Hello World";
        }
    }
}
