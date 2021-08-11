using System.Collections.Generic;

namespace TransNeftEnergo.Mock
{
    //public interface IDbTable
    //{   
    //    List<IDbItem> GetData();
    //    void Add(IDbItem item);
    //}

    public interface IDbItem {
        IDbItem Initialize();
    }
}
