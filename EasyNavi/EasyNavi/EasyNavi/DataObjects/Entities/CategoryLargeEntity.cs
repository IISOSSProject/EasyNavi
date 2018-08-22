using EasyNavi.Models.APIJsonModels.JsonModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.Entities
{
    public class CategoryLargeEntity : IJsonCategoryLarge
    {
        [SQLite.PrimaryKey]
        public int Id { get => ContentCategoryLargeId; set => ContentCategoryLargeId = value; }
        public string IconFileName { get; set; }
        public int ContentCategoryLargeId { get; set; }
        public string ContentCategoryLargeName { get; set; }
    }
}
