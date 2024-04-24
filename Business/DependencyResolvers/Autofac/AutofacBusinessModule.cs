using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //IoC(Inversion of Control):Yazdığımız kod bloğu çalışacağı zaman, framework bizim kodumuzu çağırır ve çalıştırır.
            //Daha sonra kontrol yeniden framework’e geçmesi olayının tümüne Inversion Of Control adı verilmektedir.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//Services.AddSingleton ile aynı işlevi görür.
            //Yani IProductService istendiği zaman ProductManager ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
