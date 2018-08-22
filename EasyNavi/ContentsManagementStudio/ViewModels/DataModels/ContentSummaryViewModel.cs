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
    class ContentSummaryViewModel : BindableBase, IJsonContentSummary
    {
        private string _contentCategoryLargeId;
        public string ContentCategoryLargeId { get => _contentCategoryLargeId; set => SetProperty(ref _contentCategoryLargeId, value); }
        private int? _contentId;
        public int? ContentId { get => _contentId; set => SetProperty(ref _contentId, value); }
        private string _contentName;
        public string ContentName { get => _contentName; set => SetProperty(ref _contentName, value); }
        private string _contentDetail;
        public string ContentDetail { get => _contentDetail; set => SetProperty(ref _contentDetail, value); }
        private double? _contentLatitude;
        public double? ContentLatitude { get => _contentLatitude; set => SetProperty(ref _contentLatitude, value); }
        private double? _contentLongitude;
        public double? ContentLongitude { get => _contentLongitude; set => SetProperty(ref _contentLongitude, value); }
        private double? _parkingLatitude;
        public double? ParkingLatitude { get => _parkingLatitude; set => SetProperty(ref _parkingLatitude, value); }
        private double? _parkingLongitude;
        public double? ParkingLongitude { get => _parkingLongitude; set => SetProperty(ref _parkingLongitude, value); }
        private string _sctId;
        public string SctId { get => _sctId; set => SetProperty(ref _sctId, value); }
        private double? _viewFactor;
        public double? ViewFactor { get => _viewFactor; set => SetProperty(ref _viewFactor, value); }
        private string _openFlag;
        public string OpenFlag { get => _openFlag; set => SetProperty(ref _openFlag, value); }
        private string _deleteFlag;
        public string DeleteFlag { get => _deleteFlag; set => SetProperty(ref _deleteFlag, value); }
        private string _procDiv;
        public string ProcDiv { get => _procDiv; set => SetProperty(ref _procDiv, value); }
        private string _topFilename;
        public string TopFilename { get => _topFilename; set => SetProperty(ref _topFilename, value); }
        private BitmapImage _topImage;
        public BitmapImage TopImage { get => _topImage; set => SetProperty(ref _topImage, value); }

        private ContentDetaiViewModel _detail = new ContentDetaiViewModel();
        public ContentDetaiViewModel Detail { get => _detail; set => SetProperty(ref _detail, value); }
    }
}
