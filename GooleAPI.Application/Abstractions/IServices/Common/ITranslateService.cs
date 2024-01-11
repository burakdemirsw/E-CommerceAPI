using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.Common
{
    public interface ITranslateService
    {
        public Task<T> Translate<T>(T model, string targetLanguage, string sourceLanguage);
    }
}
