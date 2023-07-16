using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions;

namespace Failover.Client.Pages
{
    public partial class Test
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        
        private Canvas2DContext _context;
        protected BECanvasComponent _canvasReference;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this._context = await this._canvasReference.CreateCanvas2DAsync();
            await this._context.SetFillStyleAsync("red");
            await this._context.FillRectAsync(10, 100, 100, 100);
            await this._context.SetFontAsync("38px Calibri");
            await this._context.StrokeTextAsync("Hello Blazor!!!", 5, 100);
        }
    }
}