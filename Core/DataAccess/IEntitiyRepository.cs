using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntitiyRepository<T> where T : class,IEntity,new()
   //T ya IEntity ya da ondan kalıtım alan bir sınıf olmalı (generic constraint), new() demek ise newlenebilir bir sınıf olmalı demek. Yanı soyut bir sınıf olmamalı.
    {
        //Bu sınıfın amacı her bir entity sınıfı için ayrı bir data access interfacesi açmaktansa tek bir interfacede T değişkeni ile halletmek.
        List<T> GetAll(Expression<Func<T,bool>> filter =null); //filter =null filtre vermeyebilirsin demek
        //Bu kullanım sayesinde fonksiyonlarda LINQ sayesinde filtreleme işlemi yapılabilmekte
        T Get(Expression<Func<T, bool>> filter);//bu şekilde yazınca filtre zorunlu demek
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
