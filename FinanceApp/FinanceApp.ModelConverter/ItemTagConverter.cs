using System;
using System.Collections.Generic;
using System.Text;
using FinanceApp.Core;
using FinanceApp.Domain.Entity;
using FinanceApp.Model;

namespace FinanceApp.ModelConverter
{
    public class ItemTagConverter : IModelConverter<ItemTag, ItemTagModel>
    {
        public ItemTagModel Convert(ItemTag model)
        {
            if (model.Equals(null)) return null;

            return new ItemTagModel
            {
                Value = model.Value,
                Key = model.TagType.Value
            };
        }

        public ItemTag Revert(ItemTagModel model)
        {
            if (model.Equals(null)) return null;

            return new ItemTag
            {
                Value = model.Value,

            };
        }
    }
}
