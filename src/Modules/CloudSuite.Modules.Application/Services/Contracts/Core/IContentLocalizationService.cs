using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IContentLocalizationService
    {
        string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue) where TEntity : Entidade;

        string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue, string cultureId) where TEntity : Entidade;

        string GetLocalizedProperty(string entityType, long entityId, string propertyName, string propertyValue);

        string GetLocalizedProperty(string entityType, long entityId, string propertyName, string propertyValue, string cultureId);

        Func<long, string, string, string> GetLocalizationFunction<TEntity>();

        Func<long, string, string, string> GetLocalizationFunction(string entityType);
    }
}