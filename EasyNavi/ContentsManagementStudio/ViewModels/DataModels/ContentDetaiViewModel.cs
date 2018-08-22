using ContentsManagementStudio.Commons;
using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ContentsManagementStudio.ViewModels.DataModels
{
    class ContentDetaiViewModel : BindableBase, IJsonContentDetail
    {
        private int? _contentId;
        public int? ContentId { get => _contentId; set => SetProperty(ref _contentId, value); }
        private string _contentName;
        public string ContentName { get => _contentName; set => SetProperty(ref _contentName, value); }
        private string _contentRead;
        public string ContentRead { get => _contentRead; set => SetProperty(ref _contentRead, value); }
        private string _zip;
        public string Zip { get => _zip; set => SetProperty(ref _zip, value); }
        private string _address;
        public string Address { get => _address; set => SetProperty(ref _address, value); }
        private string _contactName;
        public string ContactName { get => _contactName; set => SetProperty(ref _contactName, value); }
        private string _telNo;
        public string TelNo { get => _telNo; set => SetProperty(ref _telNo, value); }
        private string _openHour;
        public string OpenHour { get => _openHour; set => SetProperty(ref _openHour, value); }
        private string _closed;
        public string Closed { get => _closed; set => SetProperty(ref _closed, value); }
        private string _traffic;
        public string Traffic { get => _traffic; set => SetProperty(ref _traffic, value); }
        private string _parking;
        public string Parking { get => _parking; set => SetProperty(ref _parking, value); }
        private string _rate;
        public string Rate { get => _rate; set => SetProperty(ref _rate, value); }
        private string _webSiteUrl;
        public string WebSiteUrl { get => _webSiteUrl; set => SetProperty(ref _webSiteUrl, value); }
        private string _youTubeUrl;
        public string YouTubeUrl { get => _youTubeUrl; set => SetProperty(ref _youTubeUrl, value); }
        private double? _contentLatitude;
        public double? ContentLatitude { get => _contentLatitude; set => SetProperty(ref _contentLatitude, value); }
        private double? _contentLongitude;
        public double? ContentLongitude { get => _contentLongitude; set => SetProperty(ref _contentLongitude, value); }
        private double? _parkingLatitude;
        public double? ParkingLatitude { get => _parkingLatitude; set => SetProperty(ref _parkingLatitude, value); }
        private double? _parkingLongitude;
        public double? ParkingLongitude { get => _parkingLongitude; set => SetProperty(ref _parkingLongitude, value); }
        private string _openFlag;
        public string OpenFlag { get => _openFlag; set => SetProperty(ref _openFlag, value); }
        private string _deleteFlag;
        public string DeleteFlag { get => _deleteFlag; set => SetProperty(ref _deleteFlag, value); }
        private string _imageFlag;
        public string ImageFlag { get => _imageFlag; set => SetProperty(ref _imageFlag, value); }
        private string _topFilename;
        public string TopFilename { get => _topFilename; set => SetProperty(ref _topFilename, value); }
        private string _detailFilename1;
        public string DetailFilename1 { get => _detailFilename1; set => SetProperty(ref _detailFilename1, value); }
        private string _detailFilename2;
        public string DetailFilename2 { get => _detailFilename2; set => SetProperty(ref _detailFilename2, value); }
        private string _detailFilename3;
        public string DetailFilename3 { get => _detailFilename3; set => SetProperty(ref _detailFilename3, value); }
        private string _detailFilename4;
        public string DetailFilename4 { get => _detailFilename4; set => SetProperty(ref _detailFilename4, value); }
        private string _detailFilename5;
        public string DetailFilename5 { get => _detailFilename5; set => SetProperty(ref _detailFilename5, value); }

        private BitmapImage _topImage;
        public BitmapImage TopImage { get => _topImage; set => SetProperty(ref _topImage, value); }
        private BitmapImage _detailImage1;
        public BitmapImage DetailImage1 { get => _detailImage1; set => SetProperty(ref _detailImage1, value); }
        private BitmapImage _detailImage2;
        public BitmapImage DetailImage2 { get => _detailImage2; set => SetProperty(ref _detailImage2, value); }
        private BitmapImage _detailImage3;
        public BitmapImage DetailImage3 { get => _detailImage3; set => SetProperty(ref _detailImage3, value); }
        private BitmapImage _detailImage4;
        public BitmapImage DetailImage4 { get => _detailImage4; set => SetProperty(ref _detailImage4, value); }
        private BitmapImage _detailImage5;
        public BitmapImage DetailImage5 { get => _detailImage5; set => SetProperty(ref _detailImage5, value); }

        private string _contentDetail;
        public string ContentDetail { get => _contentDetail; set => SetProperty(ref _contentDetail, value); }
    }
}
