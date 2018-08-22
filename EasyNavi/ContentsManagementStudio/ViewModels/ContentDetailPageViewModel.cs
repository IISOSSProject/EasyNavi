using ContentsManagementStudio.Commons;
using ContentsManagementStudio.Models;
using ContentsManagementStudio.Navigations;
using ContentsManagementStudio.Navigations.Parameters;
using ContentsManagementStudio.ViewModels.DataModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ContentsManagementStudio.ViewModels
{
    class ContentDetailPageViewModel : BindableBase
    {
        public ICommand DoneCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand TopImageCommand { get; }
        public ICommand DetailImage1Command { get; }
        public ICommand DetailImage2Command { get; }
        public ICommand DetailImage3Command { get; }
        public ICommand DetailImage4Command { get; }
        public ICommand DetailImage5Command { get; }

        private ContentSummaryViewModel _summary = new ContentSummaryViewModel();
        public ContentSummaryViewModel Summary { get => _summary; set => SetProperty(ref _summary, value); }

        public ContentDetailPageViewModel()
        {
            DoneCommand = new Command(OnDone);
            DeleteCommand = new Command(OnDelete);
            CancelCommand = new Command(OnCancel);
            TopImageCommand = new Command(OnTopImage);
            DetailImage1Command = new Command(OnDetailImage1);
            DetailImage2Command = new Command(OnDetailImage2);
            DetailImage3Command = new Command(OnDetailImage3);
            DetailImage4Command = new Command(OnDetailImage4);
            DetailImage5Command = new Command(OnDetailImage5);

            var selectedContent = SelectedContent.Instance.Content;
            if (selectedContent != null)
            {
                Summary = PropertyCopier.CopyTo(selectedContent, new ContentSummaryViewModel());
                Summary.Detail = PropertyCopier.CopyTo(selectedContent.Detail, new ContentDetaiViewModel());
            }
        }

        private void OnDone(object parameter)
        {
            var content = SelectedContent.Instance.Content;
            if (content != null)
            {
                PropertyCopier.CopyTo(Summary, content);
                content.Detail = PropertyCopier.CopyTo(Summary.Detail, new ContentDetaiViewModel());
            }
            else
            {
                content = PropertyCopier.CopyTo(Summary, new ContentSummaryViewModel());
                content.Detail = PropertyCopier.CopyTo(Summary.Detail, new ContentDetaiViewModel());
                Contents.Instance.Items.Add(content);
            }
            PropertyCopier.CopyTo(content, content.Detail);
            content.Detail.ImageFlag = new[] {
                content.Detail.DetailImage1,
                content.Detail.DetailImage2,
                content.Detail.DetailImage3,
                content.Detail.DetailImage4,
                content.Detail.DetailImage5 }.Any(image => image != null) ? "1" : "0";


            OnCancel(null);
        }

        private void OnDelete(object parameter)
        {
            var content = SelectedContent.Instance.Content;
            if (content != null)
                Contents.Instance.Items.Remove(content);

            OnCancel(null);
        }

        private void OnCancel(object parameter)
        {
            SelectedContent.Instance.Content = null;
            NavigationController.Instance.GoBack();
        }

        private void OnTopImage(object parameter) => ReadBitmapImage(image => Summary.TopImage = image);
        private void OnDetailImage1(object parameter) => ReadBitmapImage(image => Summary.Detail.DetailImage1 = image);
        private void OnDetailImage2(object parameter) => ReadBitmapImage(image => Summary.Detail.DetailImage2 = image);
        private void OnDetailImage3(object parameter) => ReadBitmapImage(image => Summary.Detail.DetailImage3 = image);
        private void OnDetailImage4(object parameter) => ReadBitmapImage(image => Summary.Detail.DetailImage4 = image);
        private void OnDetailImage5(object parameter) => ReadBitmapImage(image => Summary.Detail.DetailImage5 = image);

        private void ReadBitmapImage(Action<BitmapImage> setter)
        {
            var (image, isSelected) = CreateBitmapImage();
            if (!isSelected) return;
            setter.Invoke(image);
        }

        private (BitmapImage, bool) CreateBitmapImage()
        {
            var dialog = new OpenFileDialog { Multiselect = false };
            if (!(true == dialog.ShowDialog())) return (null, false);

            using (var stream = dialog.OpenFile())
            {
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = stream;
                try
                {
                    bi.EndInit();
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine($"{ex.Message} FileName:{dialog.FileName}");
                    return (null, true);
                }
                return (bi, true);
            }
        }
    }
}
