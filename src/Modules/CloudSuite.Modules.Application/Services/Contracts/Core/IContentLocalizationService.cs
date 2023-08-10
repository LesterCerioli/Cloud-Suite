using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Infrastructure.Models;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IContentLocalizationService
    {
        string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue) where TEntity : EntityBase;

        string GetLocalizedProperty<TEntity>(TEntity entity, string propertyName, string propertyValue, string cultureId) where TEntity : EntityBase;
    }
}
