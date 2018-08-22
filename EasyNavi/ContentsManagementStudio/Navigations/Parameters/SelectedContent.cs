using ContentsManagementStudio.ViewModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentsManagementStudio.Navigations.Parameters
{
    class SelectedContent
    {
        public static SelectedContent Instance { get; } = new SelectedContent();
        private SelectedContent() {; }

        private WeakReference<ContentSummaryViewModel> _content { get; } = new WeakReference<ContentSummaryViewModel>(null);
        public ContentSummaryViewModel Content { get => _content.TryGetTarget(out var content) ? content : null; set => _content.SetTarget(value); }
    }
}
