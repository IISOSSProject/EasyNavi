using EasyNavi.Core.Common;
using EasyNavi.Core.DataObjects.DataModels;
using EasyNavi.Core.DataObjects.Entities;
using EasyNavi.Core.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace EasyNavi.Core.Models.Updaters
{
    class ContentsUpdater: IContentsUpdater
    {
        private ISourceDataProvider _sourceDataProvider;
        private ILocalDataProvider _localDataProvider;

        public ContentsUpdater(ISourceDataProvider sourceDataProvider, ILocalDataProvider localDataProvider)
        {
            _sourceDataProvider = sourceDataProvider;
            _localDataProvider = localDataProvider;
        }

        public async Task<bool> Update(JsonVersions jsonVersions, DataVersions dataVersions)
        {
            if (!(jsonVersions.Contents > dataVersions.Contents)) return false;

            await UpdateContents( jsonVersions, dataVersions);
            return true;
        }

        private async Task UpdateContents(JsonVersions jsonVersions, DataVersions dataVersions)
        {
            var jsonContents = await _sourceDataProvider.JsonContentSummariesAndDetails();
            _localDataProvider.UnzipImages(await _sourceDataProvider.Images());
            foreach (var (summary, detail) in jsonContents) _localDataProvider.UnzipImages(await _sourceDataProvider.Images(summary?.ContentId));

            using (var db = DataBaseHelper.CreateConnection())
            {
                var dbSummaries = _localDataProvider.ContentSummaries(db).ToList();
                var dbDetails = _localDataProvider.ContentDetails(db).ToList();

                foreach (var (summary, detail) in jsonContents)
                {
                    var dbSummary = dbSummaries.Where(d => d.ContentId == summary.ContentId).FirstOrDefault() ?? new ContentSummaryEntity();
                    var dbDetail = dbDetails.Where(d => d.ContentId == detail.ContentId).FirstOrDefault() ?? new ContentDetailEntity();

                    dbSummaries.Remove(dbSummary);
                    dbDetails.Remove(dbDetail);

                    _localDataProvider.InsertOrReplace(db, PropertyCopier.CopyTo(summary, dbSummary));
                    _localDataProvider.InsertOrReplace(db, PropertyCopier.CopyTo(detail, dbDetail));
                }

                foreach (var dbSummary in dbSummaries) db.Delete(dbSummary);
                foreach (var dbDetail in dbDetails) db.Delete(dbDetail);

                // バージョン
                dataVersions.Entity.Contents = jsonVersions.Json.Contents;
                _localDataProvider.InsertOrReplace(db, dataVersions.Entity);
            }
        }
    }
}
