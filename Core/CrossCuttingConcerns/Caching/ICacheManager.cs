using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);//Cache den hangi tipte data getireceğiz yada çağıracağız Generic

        object Get(string key);//Cacheden object getirme Generic olmayan bunun için tip dönüşümü yapmak gerekir

        void Add(string key, object value, int duration);//cache (belleğe) ekleme

        bool IsAdd(string key); // cache de var mı  kontrolünü yapıyoruz.

        void IsRemove(string key); //cache den kaldırma 

        void RemoveByPattern(string pattern);//parametre olarak çalış örnek isminde get olan,isminde product,regex pattern 

    }
}
