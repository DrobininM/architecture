﻿namespace Application.Base.Queries
{
    public abstract class BaseQuery<TDataProvider> where TDataProvider : class
    {
        protected readonly TDataProvider _dataProvider;

        protected BaseQuery(TDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
