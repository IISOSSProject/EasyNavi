using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.PluginInterfaces.Interfaces
{
    public interface IEasyNaviPlugin
    {
        void RegistAppAssembly(Assembly assembly);
        void RegistDataBaseConnectionFactory(Func<SQLite.SQLiteConnection> factory);
        void RegistFileStragePath(IFileStragePath path);
        Task Init();
        Task<bool> DataUpdate();
        void CreateDataBase(SQLite.SQLiteConnection db);
    }
}
