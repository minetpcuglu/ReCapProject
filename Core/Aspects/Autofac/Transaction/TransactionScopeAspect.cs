using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    //transaction yonetimi nedir ? uygulamalarda tutarlılıgı korumak ıcın uyguladıgımız yöntem
    //işlemin belli bir kısmında hata olustugunda işlemi geri alması gerekli
    public class TransactionScopeAspect : MethodInterception 
    {
        public override void Intercept(IInvocation invocation)   //ıınvocation method demek 
        {
            using (TransactionScope transactionScope = new TransactionScope()) //
            {
                try
                {
                    invocation.Proceed(); // managerda yazdıgın metodu calıstır
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
