using EasyNavi.Core.Common;
using EasyNavi.Core.DataProviders.StrageDataProviders;
using EasyNavi.Core.Models;
using EasyNavi.Core.Resources.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Unity;
using EasyNavi.Core.DataProviders;
using EasyNavi.Core.DataObjects.DataModels;

namespace EasyNavi.Core.ViewModels.Contents
{
    class ContentViewModel : BindableBase
    {
        private bool _isFirst = true;

        public static InitialDataModel InitialData { get; set; }

        #region Property Name Description
        private string _contentName;
        public string ContentName { get => _contentName; private set => SetProperty(ref _contentName, value); }

        private string _contentDetail;
        public string ContentDetail { get => _contentDetail; private set => SetProperty(ref _contentDetail, value); }
        #endregion Property Name Description

        #region Property Attribute
        private ContentAttribute _zipCode;
        public ContentAttribute ZipCode { get => _zipCode; private set => SetProperty(ref _zipCode, value); }
        private ContentAttribute _address;
        public ContentAttribute Address { get => _address; private set => SetProperty(ref _address, value); }
        private ContentAttribute _contactName;
        public ContentAttribute ContactName { get => _contactName; private set => SetProperty(ref _contactName, value); }
        private ContentAttribute _telNo;
        public ContentAttribute TelNo { get => _telNo; private set => SetProperty(ref _telNo, value); }
        private ContentAttribute _traffic;
        public ContentAttribute Traffic { get => _traffic; private set => SetProperty(ref _traffic, value); }
        private ContentAttribute _parking;
        public ContentAttribute Parking { get => _parking; private set => SetProperty(ref _parking, value); }
        private ContentAttribute _money;
        public ContentAttribute Money { get => _money; private set => SetProperty(ref _money, value); }
        private ContentAttribute _openHour;
        public ContentAttribute OpenHour { get => _openHour; private set => SetProperty(ref _openHour, value); }
        private ContentAttribute _holiDay;
        public ContentAttribute HoliDay { get => _holiDay; private set => SetProperty(ref _holiDay, value); }
        private ContentAttribute _url;
        public ContentAttribute URL { get => _url; private set => SetProperty(ref _url, value); }
        private ContentAttribute _youTube;
        public ContentAttribute YouTube { get => _youTube; private set => SetProperty(ref _youTube, value); }
        #endregion Property Attribute

        #region Property Image
        private ImageFile _topImage;
        public ImageFile TopImage { get => _topImage; private set => SetProperty(ref _topImage, value); }

        private ImageFile _detailImage01;
        public ImageFile DetailImage01 { get => _detailImage01; private set => SetProperty(ref _detailImage01, value); }

        private ImageFile _detailImage02;
        public ImageFile DetailImage02 { get => _detailImage02; private set => SetProperty(ref _detailImage02, value); }

        private ImageFile _detailImage03;
        public ImageFile DetailImage03 { get => _detailImage03; private set => SetProperty(ref _detailImage03, value); }

        private ImageFile _detailImage04;
        public ImageFile DetailImage04 { get => _detailImage04; private set => SetProperty(ref _detailImage04, value); }

        private ImageFile _detailImage05;
        public ImageFile DetailImage05 { get => _detailImage05; private set => SetProperty(ref _detailImage05, value); }

        public bool HasDetailImages => new[] { _detailImage01, _detailImage02, _detailImage03, _detailImage04, _detailImage05 }.Any(i => i?.HasImage == true);
        #endregion Property Image

        public Command AppearingCommand { get; }
        public Command GoWebSiteViewCommand { get; }
        public Command GoYouTubeViewCommand { get; }

        public ContentViewModel()
        {
            AppearingCommand = new Command(Appearing);
            GoWebSiteViewCommand = new Command(() => { WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle(this.URL?.Value, "詳細情報"); MessagingCenter.Send(this, Messages.GoWebSiteView); });
            GoYouTubeViewCommand = new Command(() => { WebSites.WebSiteViewModel.InitialData = WebSites.WebSiteViewModel.InitialDataModel.FromUrlAndTitle(this.YouTube?.Value, "YouTube"); MessagingCenter.Send(this, Messages.GoWebSiteView); });
        }

        private void Appearing()
        {
            if (!_isFirst) return;
            _isFirst = false;

            var dataProvider = App.DIContainer.Resolve<ILocalDataProvider>();
            var fileStrage = App.DIContainer.Resolve<IFileStrage>();
            var imageDataProvider = new ContentImageDataProvider(fileStrage);

            var data = dataProvider.Content(InitialData.ContentId);

            ContentName = data.ContentName;
            ContentDetail = data.ContentDetail;

            ZipCode = new ContentAttribute(ResourceTexts.ZipCode, data.Zip);
            Address = new ContentAttribute(ResourceTexts.Address, data.Address);
            ContactName = new ContentAttribute(ResourceTexts.ContactName, data.ContactName);
            TelNo = new ContentAttribute(ResourceTexts.TelNo, data.TelNo);
            Traffic = new ContentAttribute(ResourceTexts.Traffic, data.Traffic);
            Parking = new ContentAttribute(ResourceTexts.Parking, data.Parking);
            Money = new ContentAttribute(ResourceTexts.Money, data.Rate);
            OpenHour = new ContentAttribute(ResourceTexts.OpenHour, data.OpenHour);
            HoliDay = new ContentAttribute(ResourceTexts.HoliDay, data.Closed);
            URL = new ContentAttribute(ResourceTexts.URL, data.WebSiteUrl);
            YouTube = new ContentAttribute(ResourceTexts.YouTube, data.YouTubeUrl);

            TopImage = imageDataProvider.ImageFile(data.TopFilename);
            DetailImage01 = imageDataProvider.ImageFile(data.DetailFilename1);
            DetailImage02 = imageDataProvider.ImageFile(data.DetailFilename2);
            DetailImage03 = imageDataProvider.ImageFile(data.DetailFilename3);
            DetailImage04 = imageDataProvider.ImageFile(data.DetailFilename4);
            DetailImage05 = imageDataProvider.ImageFile(data.DetailFilename5);
            OnPropertyChanged(nameof(HasDetailImages));
        }


        public class InitialDataModel
        {
            public int? ContentId { get; set; }

            public static InitialDataModel FromContentId(int? id) => new InitialDataModel { ContentId = id };
        }

        public static class Messages
        {
            public static string GoWebSiteView { get; } = nameof(GoWebSiteView);
        }
    }
}
